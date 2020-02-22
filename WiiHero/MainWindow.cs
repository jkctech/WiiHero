using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using SimWinInput;
using System.Media;

namespace GuitarConnector {
    public partial class MainWindow : Form {

        SoundPlayer sound;

        public MainWindow()
        {
            Worker.window = this;
            Dictionary<int, string> controllers = new Dictionary<int, string>
            {
                { 0, "Controller 1" },
                { 1, "Controller 2" },
                { 2, "Controller 3" },
                { 3, "Controller 4" }
            };

            InitializeComponent();
            ports_refresh();

            // Bind list of controllers to list
            cb_controller.DataSource = new BindingSource(controllers, null);
            cb_controller.DisplayMember = "Value";
            cb_controller.ValueMember = "Key";

            // Lock window size
            MinimumSize = Size;
            MaximumSize = Size;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            ports_refresh();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            // Disconnect if connected already
            if (Worker.serial != null && Worker.serial.IsOpen())
            {
                try
                {
                    Worker.serial.Close();
                }
                catch (Exception)
                {
                    Utils.Error(Properties.Strings.error_closing);
                    Worker.serial = null;
                }
                cb_ports.Enabled = true;
                btn_refresh.Enabled = true;
                btn_connect.Text = "Connect";
                try
                {
                    sound = new SoundPlayer(@"c:\Windows\Media\Speech Off.wav");
                    sound.Play();
                }
                catch (Exception) { }
                return;
            }
            // Start otherwise
            if (cb_ports.SelectedItem == null)
            {
                Utils.Warning(Properties.Strings.warning_selectport);
                return;
            }
            try
            {
                btn_connect.Text = "Connecting...";
                Worker.serial = new Serial(cb_ports.SelectedItem.ToString(), 115200, "\n");
                Worker.serial.Open();
            }
            catch (Exception)
            {
                Utils.Error(Properties.Strings.error_opening);
                btn_connect.Text = "Connect";
                return;
            }
            try
            {
                sound = new SoundPlayer(@"c:\Windows\Media\Speech On.wav");
                sound.Play();
            }
            catch (Exception) { }
            cb_ports.Enabled = false;
            btn_refresh.Enabled = false;
            btn_connect.Text = "Disconnect";
            Worker.exit = false;
        }

        // Refresh list of serial COM ports
        private void ports_refresh()
        {
            cb_ports.Items.Clear();
            foreach (string port in Serial.GetPorts())
            {
                cb_ports.Items.Add(port);
            }
            if (cb_ports.SelectedItem == null && cb_ports.Items.Count > 0)
                cb_ports.SelectedIndex = cb_ports.Items.Count - 1;
        }

        // Initialize the worker after the window is read.
        private void MainWindow_Shown(object sender, EventArgs e)
        {
            Worker.Init();
        }

        // Cleanup functions
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Worker.exit = true;
            if (Worker.plugged)
                SimGamePad.Instance.Unplug();
            SimGamePad.Instance.ShutDown();
        }

        private void btn_plugcontroller_Click(object sender, EventArgs e)
        {
            // Disconnect if already plugged in
            if (Worker.plugged)
            {
                SimGamePad.Instance.Unplug();
                btn_plugcontroller.Text = "Plug";
                Worker.plugged = false;
                return;
            }
            // Attempt to plug in controller
            try
            {
                SimGamePad.Instance.Initialize();
                SimGamePad.Instance.PlugIn();
                btn_plugcontroller.Text = "Plug";
                Worker.plugged = false;
            }
            catch (Exception)
            {
                Utils.Error(Properties.Strings.error_driver);
                return;
            }
            btn_plugcontroller.Text = "Unplug";
            Worker.plugged = true;
        }

        private void cb_controller_SelectedIndexChanged(object sender, EventArgs e) {
            Worker.controllerid = ((KeyValuePair<int, string>)cb_controller.SelectedItem).Key;
        }

        private void ll_github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/jkctech/WiiHero");
        }

        private void btn_guitarscreen_Click(object sender, EventArgs e) {
            Worker.gscreen = new GuitarScreen();
            Worker.gscreen.Show();
            btn_guitarscreen.Enabled = false;
        }
    }
}
