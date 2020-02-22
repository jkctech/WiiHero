using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarConnector {
    public partial class GuitarScreen : Form {

        public GuitarScreen() {
            InitializeComponent();

            // Lock size
            MaximumSize = Size;
            MinimumSize = Size;
        }

        private void GuitarScreen_Click(object sender, EventArgs e) {
            colordialog.AllowFullOpen = true;
            colordialog.ShowHelp = true;
            colordialog.Color = BackColor;
            if (colordialog.ShowDialog() == DialogResult.OK)
                BackColor = colordialog.Color;
        }
    }
}
