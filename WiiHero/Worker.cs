using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using SimWinInput;

namespace GuitarConnector
{
    class Worker
    {
        public static MainWindow window;
        public static Serial serial;
        public static bool run;
        public static ThreadStart ts;
        public static Thread worker;
        public static bool exit = false;
        public static bool plugged = false;

        private enum Buttons
        {
            Plus = 0,
            Starpower = 1,
            StrumUp = 2,
            StrumDown = 3,
            Green = 4,
            Red = 5,
            Yellow = 6,
            Blue = 7,
            Orange = 8
        }

        private static GamePadControl[] buttonmap = new GamePadControl[9] {
            GamePadControl.Start,
            GamePadControl.Back,
            GamePadControl.DPadUp,
            GamePadControl.DPadDown,
            GamePadControl.A,
            GamePadControl.B,
            GamePadControl.Y,
            GamePadControl.X,
            GamePadControl.LeftShoulder
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

            // Save button states to int array
            buttons = new bool[9];
            buttons[(int)Buttons.Plus]      = bytes[1] == 255;
            buttons[(int)Buttons.Starpower] = bytes[1] == 0;
            buttons[(int)Buttons.StrumUp]   = bytes[2] == 255;
            buttons[(int)Buttons.StrumDown] = bytes[2] == 0;
            buttons[(int)Buttons.Green]     = bytes[3] == 255;
            buttons[(int)Buttons.Red]       = bytes[4] == 255;
            buttons[(int)Buttons.Yellow]    = bytes[5] == 255;
            buttons[(int)Buttons.Blue]      = bytes[6] == 255;
            buttons[(int)Buttons.Orange]    = bytes[7] == 255;

            // Menu Buttons
            window.cb_plus.Checked      = buttons[(int)Buttons.Plus];
            window.cb_starpower.Checked = buttons[(int)Buttons.Starpower];

            // Strum
            window.cb_up.Checked   = buttons[(int)Buttons.StrumUp];
            window.cb_down.Checked = buttons[(int)Buttons.StrumDown];

            // Notes
            window.cb_green.Checked  = buttons[(int)Buttons.Green];
            window.cb_red.Checked    = buttons[(int)Buttons.Red];
            window.cb_yellow.Checked = buttons[(int)Buttons.Yellow];
            window.cb_blue.Checked   = buttons[(int)Buttons.Blue];
            window.cb_orange.Checked = buttons[(int)Buttons.Orange];

            // Whammy bar
            try
            {
                window.tb_wham.Value = Limit(bytes[0], 16, 26) - 16;
            }
            catch (Exception)
            {
                window.tb_wham.Value = 0;
            }

            //controls[(int)Controls.WhammyBar] =  - 16;
            if (plugged)
            {
                SimGamePad simPad;
                SimulatedGamePadState state;

                simPad = SimGamePad.Instance;
                state = simPad.State[0];
                state.Reset();

                // Loop over pressable buttons
                foreach (Buttons button in Enum.GetValues(typeof(Buttons)))
                {
                    if (buttons[(int)button])
                        state.Buttons |= buttonmap[(int)button];
                }

                // Whammy bar
                state.RightStickX = (short)(short.MaxValue * Map(Limit(bytes[0], 16, 26), 16, 26, 0, 1));

                simPad.Update(0);
                simPad.Update();
            }
        }

        private static void Work()
        {
            window.Invoke(new Action(() => {
                string data;
                int[] bytes;
                while (true)
                {
                    if (exit)
                        break;
                    if (run && serial != null && serial.IsOpen())
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
                                    run = false;
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
