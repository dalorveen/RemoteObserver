namespace MissionControlCenter
{
    partial class Dashboard
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_connect = new System.Windows.Forms.Button();
            this.groupBox_sending = new System.Windows.Forms.GroupBox();
            this.label_help = new System.Windows.Forms.Label();
            this.textBox_simulated = new System.Windows.Forms.TextBox();
            this.label_simulated = new System.Windows.Forms.Label();
            this.label_windowTitle = new System.Windows.Forms.Label();
            this.comboBox_windowTitle = new System.Windows.Forms.ComboBox();
            this.groupBox_snapshot = new System.Windows.Forms.GroupBox();
            this.numericUpDown_interval = new System.Windows.Forms.NumericUpDown();
            this.button_loop = new System.Windows.Forms.Button();
            this.pictureBox_snapshot = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_serverIPPort = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.button_updateImage = new System.Windows.Forms.Button();
            this.button_saveImage = new System.Windows.Forms.Button();
            this.groupBox_sending.SuspendLayout();
            this.groupBox_snapshot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_snapshot)).BeginInit();
            this.SuspendLayout();
            // 
            // button_connect
            // 
            this.button_connect.BackColor = System.Drawing.Color.YellowGreen;
            this.button_connect.Location = new System.Drawing.Point(284, 12);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(178, 26);
            this.button_connect.TabIndex = 0;
            this.button_connect.Text = "Connect to server";
            this.button_connect.UseVisualStyleBackColor = false;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // groupBox_sending
            // 
            this.groupBox_sending.Controls.Add(this.label_help);
            this.groupBox_sending.Controls.Add(this.textBox_simulated);
            this.groupBox_sending.Controls.Add(this.label_simulated);
            this.groupBox_sending.Controls.Add(this.label_windowTitle);
            this.groupBox_sending.Controls.Add(this.comboBox_windowTitle);
            this.groupBox_sending.Location = new System.Drawing.Point(12, 44);
            this.groupBox_sending.Name = "groupBox_sending";
            this.groupBox_sending.Size = new System.Drawing.Size(456, 72);
            this.groupBox_sending.TabIndex = 3;
            this.groupBox_sending.TabStop = false;
            this.groupBox_sending.Text = "Sending";
            // 
            // label_help
            // 
            this.label_help.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_help.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_help.Location = new System.Drawing.Point(430, 46);
            this.label_help.Margin = new System.Windows.Forms.Padding(0);
            this.label_help.Name = "label_help";
            this.label_help.Size = new System.Drawing.Size(20, 20);
            this.label_help.TabIndex = 7;
            this.label_help.Text = "?";
            this.label_help.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_help.Click += new System.EventHandler(this.label_help_Click);
            // 
            // textBox_simulated
            // 
            this.textBox_simulated.Location = new System.Drawing.Point(132, 46);
            this.textBox_simulated.Name = "textBox_simulated";
            this.textBox_simulated.Size = new System.Drawing.Size(292, 20);
            this.textBox_simulated.TabIndex = 6;
            this.textBox_simulated.Text = "<0x5B+R><N><O><T><E><P><A><D><0x0D><H><I>";
            this.textBox_simulated.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_simulated_KeyDown);
            // 
            // label_simulated
            // 
            this.label_simulated.AutoSize = true;
            this.label_simulated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_simulated.Location = new System.Drawing.Point(6, 50);
            this.label_simulated.Name = "label_simulated";
            this.label_simulated.Size = new System.Drawing.Size(120, 13);
            this.label_simulated.TabIndex = 5;
            this.label_simulated.Text = "Simulated key press";
            // 
            // label_windowTitle
            // 
            this.label_windowTitle.AutoSize = true;
            this.label_windowTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_windowTitle.Location = new System.Drawing.Point(6, 22);
            this.label_windowTitle.Name = "label_windowTitle";
            this.label_windowTitle.Size = new System.Drawing.Size(77, 13);
            this.label_windowTitle.TabIndex = 4;
            this.label_windowTitle.Text = "Window title";
            // 
            // comboBox_windowTitle
            // 
            this.comboBox_windowTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_windowTitle.FormattingEnabled = true;
            this.comboBox_windowTitle.Location = new System.Drawing.Point(89, 19);
            this.comboBox_windowTitle.Name = "comboBox_windowTitle";
            this.comboBox_windowTitle.Size = new System.Drawing.Size(361, 21);
            this.comboBox_windowTitle.TabIndex = 3;
            this.comboBox_windowTitle.DropDown += new System.EventHandler(this.comboBox_windowTitle_DropDown);
            this.comboBox_windowTitle.SelectionChangeCommitted += new System.EventHandler(this.comboBox_windowTitle_SelectionChangeCommitted);
            // 
            // groupBox_snapshot
            // 
            this.groupBox_snapshot.Controls.Add(this.button_saveImage);
            this.groupBox_snapshot.Controls.Add(this.button_updateImage);
            this.groupBox_snapshot.Controls.Add(this.numericUpDown_interval);
            this.groupBox_snapshot.Controls.Add(this.button_loop);
            this.groupBox_snapshot.Controls.Add(this.pictureBox_snapshot);
            this.groupBox_snapshot.Location = new System.Drawing.Point(12, 122);
            this.groupBox_snapshot.Name = "groupBox_snapshot";
            this.groupBox_snapshot.Size = new System.Drawing.Size(456, 307);
            this.groupBox_snapshot.TabIndex = 4;
            this.groupBox_snapshot.TabStop = false;
            this.groupBox_snapshot.Text = "Snapshot";
            // 
            // numericUpDown_interval
            // 
            this.numericUpDown_interval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_interval.Location = new System.Drawing.Point(309, 21);
            this.numericUpDown_interval.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDown_interval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_interval.Name = "numericUpDown_interval";
            this.numericUpDown_interval.ReadOnly = true;
            this.numericUpDown_interval.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown_interval.TabIndex = 5;
            this.numericUpDown_interval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_interval.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_interval.ValueChanged += new System.EventHandler(this.numericUpDown_interval_ValueChanged);
            // 
            // button_loop
            // 
            this.button_loop.Location = new System.Drawing.Point(375, 19);
            this.button_loop.Name = "button_loop";
            this.button_loop.Size = new System.Drawing.Size(75, 23);
            this.button_loop.TabIndex = 6;
            this.button_loop.Text = "LOOP";
            this.button_loop.UseVisualStyleBackColor = true;
            this.button_loop.Click += new System.EventHandler(this.loop_Click);
            // 
            // pictureBox_snapshot
            // 
            this.pictureBox_snapshot.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox_snapshot.Location = new System.Drawing.Point(6, 48);
            this.pictureBox_snapshot.Name = "pictureBox_snapshot";
            this.pictureBox_snapshot.Size = new System.Drawing.Size(444, 253);
            this.pictureBox_snapshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_snapshot.TabIndex = 1;
            this.pictureBox_snapshot.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label_serverIPPort
            // 
            this.label_serverIPPort.AutoSize = true;
            this.label_serverIPPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_serverIPPort.Location = new System.Drawing.Point(15, 19);
            this.label_serverIPPort.Name = "label_serverIPPort";
            this.label_serverIPPort.Size = new System.Drawing.Size(123, 13);
            this.label_serverIPPort.TabIndex = 5;
            this.label_serverIPPort.Text = "Server IP and PORT";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(144, 16);
            this.textBox_ip.MaxLength = 15;
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(88, 20);
            this.textBox_ip.TabIndex = 6;
            this.textBox_ip.Text = "192.168.0.2";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(238, 16);
            this.textBox_port.MaxLength = 5;
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(40, 20);
            this.textBox_port.TabIndex = 4;
            this.textBox_port.Text = "49073";
            // 
            // button_updateImage
            // 
            this.button_updateImage.Location = new System.Drawing.Point(6, 19);
            this.button_updateImage.Name = "button_updateImage";
            this.button_updateImage.Size = new System.Drawing.Size(104, 23);
            this.button_updateImage.TabIndex = 7;
            this.button_updateImage.Text = "UPDATE IMAGE";
            this.button_updateImage.UseVisualStyleBackColor = true;
            this.button_updateImage.Click += new System.EventHandler(this.button_updateImage_Click);
            // 
            // button_saveImage
            // 
            this.button_saveImage.Location = new System.Drawing.Point(116, 19);
            this.button_saveImage.Name = "button_saveImage";
            this.button_saveImage.Size = new System.Drawing.Size(104, 23);
            this.button_saveImage.TabIndex = 8;
            this.button_saveImage.Text = "SAVE IMAGE";
            this.button_saveImage.UseVisualStyleBackColor = true;
            this.button_saveImage.Click += new System.EventHandler(this.button_saveImage_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(480, 441);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.label_serverIPPort);
            this.Controls.Add(this.groupBox_snapshot);
            this.Controls.Add(this.groupBox_sending);
            this.Controls.Add(this.button_connect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dashboard";
            this.Text = "Mission control center";
            this.groupBox_sending.ResumeLayout(false);
            this.groupBox_sending.PerformLayout();
            this.groupBox_snapshot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_snapshot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.GroupBox groupBox_sending;
        private System.Windows.Forms.GroupBox groupBox_snapshot;
        private System.Windows.Forms.PictureBox pictureBox_snapshot;
        private System.Windows.Forms.ComboBox comboBox_windowTitle;
        private System.Windows.Forms.NumericUpDown numericUpDown_interval;
        private System.Windows.Forms.Button button_loop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_serverIPPort;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label_simulated;
        private System.Windows.Forms.Label label_windowTitle;
        private System.Windows.Forms.TextBox textBox_simulated;
        private System.Windows.Forms.Label label_help;
        private System.Windows.Forms.Button button_saveImage;
        private System.Windows.Forms.Button button_updateImage;
    }
}

