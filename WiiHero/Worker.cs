using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using SimWinInput;
using System.Drawing;

namespace GuitarConnector
{
    class Worker
    {
        public static MainWindow window;
        public static GuitarScreen gscreen;

        public static Serial serial;

        public static ThreadStart ts;
        public static Thread worker;

        public static bool exit = false;
        public static bool plugged = false;
        public static int controllerid = 0;

        public static Image[,] images = new Image[9,2] {
            { Properties.Resources.green_off, Properties.Resources.green_on },
            { Properties.Resources.red_off, Properties.Resources.red_on },
            { Properties.Resources.yellow_off, Properties.Resources.yellow_on },
            { Properties.Resources.blue_off, Properties.Resources.blue_on },
            { Properties.Resources.orange_off, Properties.Resources.orange_on },
            { Properties.Resources.plus_off, Properties.Resources.plus_on },
            { Properties.Resources.starpower_off, Properties.Resources.starpower_on },
            { Properties.Resources.strum_off, Properties.Resources.strum_up },
            { Properties.Resources.strum_off, Properties.Resources.strum_down }
        };

        public enum Button
        {
            Green = 0,
            Red = 1,
            Yellow = 2,
            Blue = 3,
            Orange = 4,
            Plus = 5,
            Starpower = 6,
            StrumUp = 7,
            StrumDown = 8
        }

        private static GamePadControl[] buttonmap = new GamePadControl[9] {
            GamePadControl.A,
            GamePadControl.B,
            GamePadControl.Y,
            GamePadControl.X,
            GamePadControl.LeftShoulder,
            GamePadControl.Start,
            GamePadControl.Back,
            GamePadControl.DPadUp,
            GamePadControl.DPadDown,
            
        };

        public static void Init()
        {
            ts = new ThreadStart(Work);
            worker = new Thread(ts);
            worker.Start();
        }

        private static void Process(int[] bytes)
        {
            bool[] buttons;

            // Save button states to bool array
            buttons = new bool[9];
            buttons[(int)Button.Plus]      = bytes[1] == 255;
            buttons[(int)Button.Starpower] = bytes[1] == 0;
            buttons[(int)Button.StrumUp]   = bytes[2] == 255;
            buttons[(int)Button.StrumDown] = bytes[2] == 0;
            buttons[(int)Button.Green]     = bytes[3] == 255;
            buttons[(int)Button.Red]       = bytes[4] == 255;
            buttons[(int)Button.Yellow]    = bytes[5] == 255;
            buttons[(int)Button.Blue]      = bytes[6] == 255;
            buttons[(int)Button.Orange]    = bytes[7] == 255;

            // Process button presses in GUI
            ProcessButtons(buttons, bytes);

            if (plugged)
            {
                SimGamePad simPad;
                SimulatedGamePadState state;

                simPad = SimGamePad.Instance;
                state = simPad.State[controllerid];
                state.Reset();

                // Loop over pressable buttons
                foreach (Button button in Enum.GetValues(typeof(Button)))
                {
                    if (buttons[(int)button])
                        state.Buttons |= buttonmap[(int)button];
                }

                // Whammy bar
                state.RightStickX = (short)(short.MaxValue * Map(Limit(bytes[0], 16, 26), 16, 26, 0, 1));

                // Perfom update on controllers
                simPad.Update(controllerid);
                simPad.Update();
            }
        }

        private static void ProcessButtons(bool[] buttons, int[] bytes)
        {
            // Main window press display

            // Menu Buttons
            window.cb_plus.Checked = buttons[(int)Button.Plus];
            window.cb_starpower.Checked = buttons[(int)Button.Starpower];

            // Strum
            window.cb_up.Checked = buttons[(int)Button.StrumUp];
            window.cb_down.Checked = buttons[(int)Button.StrumDown];

            // Notes
            window.cb_green.Checked = buttons[(int)Button.Green];
            window.cb_red.Checked = buttons[(int)Button.Red];
            window.cb_yellow.Checked = buttons[(int)Button.Yellow];
            window.cb_blue.Checked = buttons[(int)Button.Blue];
            window.cb_orange.Checked = buttons[(int)Button.Orange];

            // Whammy bar
            window.tb_wham.Value = Limit(bytes[0], 16, 26) - 16;

            // Guitar window press display
            if (gscreen != null)
            {
                // Menu Buttons
                gscreen.pb_plus.Image = images[(int)Button.Plus, buttons[(int)Button.Plus] ? 1 : 0];
                gscreen.pb_starpower.Image = images[(int)Button.Starpower, buttons[(int)Button.Starpower] ? 1 : 0];

                // Strum
                if (buttons[(int)Button.StrumUp])
                    gscreen.pb_strum.Image = images[(int)Button.StrumUp, 1];
                else if (buttons[(int)Button.StrumDown])
                    gscreen.pb_strum.Image = images[(int)Button.StrumDown, 1];
                else
                    gscreen.pb_strum.Image = images[(int)Button.StrumUp, 0];

                // Notes
                gscreen.pb_green.Image = images[(int)Button.Green, buttons[(int)Button.Green] ? 1 : 0];
                gscreen.pb_red.Image = images[(int)Button.Red, buttons[(int)Button.Red] ? 1 : 0];
                gscreen.pb_yellow.Image = images[(int)Button.Yellow, buttons[(int)Button.Yellow] ? 1 : 0];
                gscreen.pb_blue.Image = images[(int)Button.Blue, buttons[(int)Button.Blue] ? 1 : 0];
                gscreen.pb_orange.Image = images[(int)Button.Orange, buttons[(int)Button.Orange] ? 1 : 0];

                // Whammy bar
                // IDK how I should visualize this tbh
            }
        }

        // Worker thread
        private static void Work()
        {
            // Make an invoke because we're accessing from another thread
            window.Invoke(new Action(() => {
                string data;
                int[] bytes;

                while (!exit)
                {
                    if (serial != null && serial.IsOpen())
                    {
                        for (int i = 1; i < 3; i++)
                        {
                            try
                            {
                                data = serial.ReadLine(true);
                                bytes = data.Split(',').Select(n => int.Parse(n)).ToArray();
                                Process(bytes);
                            }
                            catch (Exception)
                            {
                                if (i >= 3)
                                {
                                    Utils.Warning(Properties.Strings.error_pairing);
                                    exit = true;
                                    if (serial.IsOpen())
                                        serial.Close();
                                    window.cb_ports.Enabled = true;
                                    window.btn_refresh.Enabled = true;
                                    window.btn_connect.Text = "Connect";
                                    break;
                                }
                                continue;
                            }
                            break;
                        }
                    }
                    Application.DoEvents();
                }
            }));
        }

        public static double Map(int value, int fromSource, int toSource, int fromTarget, int toTarget)
        {
            return ((double)value - fromSource) / ((double)toSource - fromSource) * ((double)toTarget - fromTarget) + fromTarget;
        }

        private static int Limit(int num, int min, int max)
        {
            if (num < min)
                num = min;
            if (num > max)
                num = max;
            return num;
        }
    }
}
