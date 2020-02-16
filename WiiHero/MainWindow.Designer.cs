namespace GuitarConnector {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.cb_ports = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.cb_green = new System.Windows.Forms.CheckBox();
            this.cb_red = new System.Windows.Forms.CheckBox();
            this.cb_yellow = new System.Windows.Forms.CheckBox();
            this.cb_blue = new System.Windows.Forms.CheckBox();
            this.cb_orange = new System.Windows.Forms.CheckBox();
            this.cb_up = new System.Windows.Forms.CheckBox();
            this.cb_down = new System.Windows.Forms.CheckBox();
            this.cb_starpower = new System.Windows.Forms.CheckBox();
            this.cb_plus = new System.Windows.Forms.CheckBox();
            this.tb_wham = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_plugcontroller = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tb_wham)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_ports
            // 
            this.cb_ports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ports.FormattingEnabled = true;
            this.cb_ports.Location = new System.Drawing.Point(74, 12);
            this.cb_ports.Name = "cb_ports";
            this.cb_ports.Size = new System.Drawing.Size(140, 21);
            this.cb_ports.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "COM Port:";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(119, 39);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(95, 23);
            this.btn_connect.TabIndex = 2;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(12, 39);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(95, 23);
            this.btn_refresh.TabIndex = 3;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // cb_green
            // 
            this.cb_green.AutoSize = true;
            this.cb_green.Location = new System.Drawing.Point(12, 77);
            this.cb_green.Name = "cb_green";
            this.cb_green.Size = new System.Drawing.Size(55, 17);
            this.cb_green.TabIndex = 4;
            this.cb_green.Text = "Green";
            this.cb_green.UseVisualStyleBackColor = true;
            // 
            // cb_red
            // 
            this.cb_red.AutoSize = true;
            this.cb_red.Location = new System.Drawing.Point(12, 100);
            this.cb_red.Name = "cb_red";
            this.cb_red.Size = new System.Drawing.Size(46, 17);
            this.cb_red.TabIndex = 6;
            this.cb_red.Text = "Red";
            this.cb_red.UseVisualStyleBackColor = true;
            // 
            // cb_yellow
            // 
            this.cb_yellow.AutoSize = true;
            this.cb_yellow.Location = new System.Drawing.Point(12, 123);
            this.cb_yellow.Name = "cb_yellow";
            this.cb_yellow.Size = new System.Drawing.Size(57, 17);
            this.cb_yellow.TabIndex = 7;
            this.cb_yellow.Text = "Yellow";
            this.cb_yellow.UseVisualStyleBackColor = true;
            // 
            // cb_blue
            // 
            this.cb_blue.AutoSize = true;
            this.cb_blue.Location = new System.Drawing.Point(12, 146);
            this.cb_blue.Name = "cb_blue";
            this.cb_blue.Size = new System.Drawing.Size(47, 17);
            this.cb_blue.TabIndex = 8;
            this.cb_blue.Text = "Blue";
            this.cb_blue.UseVisualStyleBackColor = true;
            // 
            // cb_orange
            // 
            this.cb_orange.AutoSize = true;
            this.cb_orange.Location = new System.Drawing.Point(12, 169);
            this.cb_orange.Name = "cb_orange";
            this.cb_orange.Size = new System.Drawing.Size(61, 17);
            this.cb_orange.TabIndex = 9;
            this.cb_orange.Text = "Orange";
            this.cb_orange.UseVisualStyleBackColor = true;
            // 
            // cb_up
            // 
            this.cb_up.AutoSize = true;
            this.cb_up.Location = new System.Drawing.Point(119, 77);
            this.cb_up.Name = "cb_up";
            this.cb_up.Size = new System.Drawing.Size(40, 17);
            this.cb_up.TabIndex = 11;
            this.cb_up.Text = "Up";
            this.cb_up.UseVisualStyleBackColor = true;
            // 
            // cb_down
            // 
            this.cb_down.AutoSize = true;
            this.cb_down.Location = new System.Drawing.Point(119, 100);
            this.cb_down.Name = "cb_down";
            this.cb_down.Size = new System.Drawing.Size(54, 17);
            this.cb_down.TabIndex = 12;
            this.cb_down.Text = "Down";
            this.cb_down.UseVisualStyleBackColor = true;
            // 
            // cb_starpower
            // 
            this.cb_starpower.AutoSize = true;
            this.cb_starpower.Location = new System.Drawing.Point(119, 123);
            this.cb_starpower.Name = "cb_starpower";
            this.cb_starpower.Size = new System.Drawing.Size(74, 17);
            this.cb_starpower.TabIndex = 13;
            this.cb_starpower.Text = "Starpower";
            this.cb_starpower.UseVisualStyleBackColor = true;
            // 
            // cb_plus
            // 
            this.cb_plus.AutoSize = true;
            this.cb_plus.Location = new System.Drawing.Point(119, 146);
            this.cb_plus.Name = "cb_plus";
            this.cb_plus.Size = new System.Drawing.Size(46, 17);
            this.cb_plus.TabIndex = 14;
            this.cb_plus.Text = "Plus";
            this.cb_plus.UseVisualStyleBackColor = true;
            // 
            // tb_wham
            // 
            this.tb_wham.Location = new System.Drawing.Point(12, 214);
            this.tb_wham.Name = "tb_wham";
            this.tb_wham.Size = new System.Drawing.Size(205, 45);
            this.tb_wham.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Wham";
            // 
            // btn_plugcontroller
            // 
            this.btn_plugcontroller.Location = new System.Drawing.Point(118, 185);
            this.btn_plugcontroller.Name = "btn_plugcontroller";
            this.btn_plugcontroller.Size = new System.Drawing.Size(96, 23);
            this.btn_plugcontroller.TabIndex = 17;
            this.btn_plugcontroller.Text = "Plug";
            this.btn_plugcontroller.UseVisualStyleBackColor = true;
            this.btn_plugcontroller.Click += new System.EventHandler(this.btn_plugcontroller_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 271);
            this.Controls.Add(this.btn_plugcontroller);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_wham);
            this.Controls.Add(this.cb_plus);
            this.Controls.Add(this.cb_starpower);
            this.Controls.Add(this.cb_down);
            this.Controls.Add(this.cb_up);
            this.Controls.Add(this.cb_orange);
            this.Controls.Add(this.cb_blue);
            this.Controls.Add(this.cb_yellow);
            this.Controls.Add(this.cb_red);
            this.Controls.Add(this.cb_green);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_ports);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "WiiHero";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.tb_wham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox cb_green;
        public System.Windows.Forms.CheckBox cb_red;
        public System.Windows.Forms.CheckBox cb_yellow;
        public System.Windows.Forms.CheckBox cb_blue;
        public System.Windows.Forms.CheckBox cb_orange;
        public System.Windows.Forms.CheckBox cb_up;
        public System.Windows.Forms.CheckBox cb_down;
        public System.Windows.Forms.CheckBox cb_starpower;
        public System.Windows.Forms.CheckBox cb_plus;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TrackBar tb_wham;
        private System.Windows.Forms.Button btn_plugcontroller;
        public System.Windows.Forms.ComboBox cb_ports;
        public System.Windows.Forms.Button btn_connect;
        public System.Windows.Forms.Button btn_refresh;
    }
}

