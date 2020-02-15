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

namespace GuitarConnector {
    public partial class MainWindow : Form {

        public MainWindow() {
            Worker.window = this;
            InitializeComponent();
            ports_refresh();
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
                Worker.run = false;
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
            cb_ports.Enabled = false;
            btn_refresh.Enabled = false;
            btn_connect.Text = "Disconnect";
            Worker.run = true;
        }

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

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            Worker.Init();
            MinimumSize = Size;
            MaximumSize = Size;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Worker.exit = true;
            SimGamePad.Instance.ShutDown();
        }

        private void btn_plugcontroller_Click(object sender, EventArgs e)
        {
            if (Worker.plugged)
            {
                SimGamePad.Instance.Unplug();
                btn_plugcontroller.Text = "Plug";
                Worker.plugged = false;
                return;
            }
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
    }
}
