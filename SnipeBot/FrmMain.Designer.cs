namespace SnipeBot
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.cTabControl1 = new cTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnLogin = new cButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRegex = new cTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProbability = new cTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAltitude = new cTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLng = new cTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLat = new cTextBox();
            this.chkUseBerries = new cCheckBox();
            this.cbAuthType = new BoosterComboBox();
            this.txtPass = new cTextBox();
            this.txtUser = new cTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnStart = new cButton();
            this.txtCoords = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lvWalkLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cTabControl1
            // 
            this.cTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.cTabControl1.Controls.Add(this.tabPage1);
            this.cTabControl1.Controls.Add(this.tabPage2);
            this.cTabControl1.Controls.Add(this.tabPage3);
            this.cTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cTabControl1.ItemSize = new System.Drawing.Size(40, 170);
            this.cTabControl1.Location = new System.Drawing.Point(0, 0);
            this.cTabControl1.Multiline = true;
            this.cTabControl1.Name = "cTabControl1";
            this.cTabControl1.SelectedIndex = 0;
            this.cTabControl1.Size = new System.Drawing.Size(791, 419);
            this.cTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.cTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(43)))));
            this.tabPage1.Controls.Add(this.btnLogin);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtRegex);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtProbability);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.txtAltitude);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtLng);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtLat);
            this.tabPage1.Controls.Add(this.chkUseBerries);
            this.tabPage1.Controls.Add(this.cbAuthType);
            this.tabPage1.Controls.Add(this.txtPass);
            this.tabPage1.Controls.Add(this.txtUser);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tabPage1.Location = new System.Drawing.Point(174, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(613, 411);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(28, 124);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Scheme = cButton.Schemes.Green;
            this.btnLogin.Size = new System.Drawing.Size(207, 23);
            this.btnLogin.TabIndex = 39;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 38;
            this.label2.Text = "Coord Regex";
            // 
            // txtRegex
            // 
            this.txtRegex.Location = new System.Drawing.Point(352, 125);
            this.txtRegex.MaxLength = 32767;
            this.txtRegex.Name = "txtRegex";
            this.txtRegex.ReadOnly = false;
            this.txtRegex.Scheme = cTextBox.Schemes.Black;
            this.txtRegex.Size = new System.Drawing.Size(169, 30);
            this.txtRegex.TabIndex = 37;
            this.txtRegex.Text = "([a-zA-Z]{3,40})(?: at)?[^a-zA-HJ-UW-Z]+?(-?\\d+.\\d+)[,\\s;]+(-?\\d+.\\d+)";
            this.txtRegex.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "Probability (%)";
            // 
            // txtProbability
            // 
            this.txtProbability.Location = new System.Drawing.Point(352, 199);
            this.txtProbability.MaxLength = 32767;
            this.txtProbability.Name = "txtProbability";
            this.txtProbability.ReadOnly = false;
            this.txtProbability.Scheme = cTextBox.Schemes.Black;
            this.txtProbability.Size = new System.Drawing.Size(55, 30);
            this.txtProbability.TabIndex = 35;
            this.txtProbability.Text = "40";
            this.txtProbability.UseSystemPasswordChar = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(266, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 15);
            this.label11.TabIndex = 34;
            this.label11.Text = "Altitude";
            // 
            // txtAltitude
            // 
            this.txtAltitude.Location = new System.Drawing.Point(352, 89);
            this.txtAltitude.MaxLength = 32767;
            this.txtAltitude.Name = "txtAltitude";
            this.txtAltitude.ReadOnly = false;
            this.txtAltitude.Scheme = cTextBox.Schemes.Black;
            this.txtAltitude.Size = new System.Drawing.Size(169, 30);
            this.txtAltitude.TabIndex = 33;
            this.txtAltitude.Text = "50";
            this.txtAltitude.UseSystemPasswordChar = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 32;
            this.label6.Text = "Longitude";
            // 
            // txtLng
            // 
            this.txtLng.Location = new System.Drawing.Point(352, 53);
            this.txtLng.MaxLength = 32767;
            this.txtLng.Name = "txtLng";
            this.txtLng.ReadOnly = false;
            this.txtLng.Scheme = cTextBox.Schemes.Black;
            this.txtLng.Size = new System.Drawing.Size(169, 30);
            this.txtLng.TabIndex = 31;
            this.txtLng.Text = "138.599732";
            this.txtLng.UseSystemPasswordChar = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(266, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "Latitude";
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(352, 17);
            this.txtLat.MaxLength = 32767;
            this.txtLat.Name = "txtLat";
            this.txtLat.ReadOnly = false;
            this.txtLat.Scheme = cTextBox.Schemes.Black;
            this.txtLat.Size = new System.Drawing.Size(169, 30);
            this.txtLat.TabIndex = 29;
            this.txtLat.Text = "-34.92577";
            this.txtLat.UseSystemPasswordChar = false;
            // 
            // chkUseBerries
            // 
            this.chkUseBerries.AutoSize = true;
            this.chkUseBerries.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkUseBerries.Location = new System.Drawing.Point(352, 174);
            this.chkUseBerries.Name = "chkUseBerries";
            this.chkUseBerries.Size = new System.Drawing.Size(83, 19);
            this.chkUseBerries.TabIndex = 28;
            this.chkUseBerries.Text = "Use Berries";
            this.chkUseBerries.UseVisualStyleBackColor = true;
            // 
            // cbAuthType
            // 
            this.cbAuthType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbAuthType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAuthType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuthType.FormattingEnabled = true;
            this.cbAuthType.ItemHeight = 20;
            this.cbAuthType.Items.AddRange(new object[] {
            "Ptc",
            "Google"});
            this.cbAuthType.Location = new System.Drawing.Point(28, 21);
            this.cbAuthType.Name = "cbAuthType";
            this.cbAuthType.Size = new System.Drawing.Size(207, 26);
            this.cbAuthType.TabIndex = 26;
            this.cbAuthType.SelectedIndexChanged += new System.EventHandler(this.cbAuthType_SelectedIndexChanged);
            // 
            // txtPass
            // 
            this.txtPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPass.Location = new System.Drawing.Point(28, 89);
            this.txtPass.MaxLength = 32767;
            this.txtPass.Name = "txtPass";
            this.txtPass.ReadOnly = false;
            this.txtPass.Scheme = cTextBox.Schemes.Black;
            this.txtPass.Size = new System.Drawing.Size(207, 30);
            this.txtPass.TabIndex = 24;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // txtUser
            // 
            this.txtUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUser.Location = new System.Drawing.Point(28, 53);
            this.txtUser.MaxLength = 32767;
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = false;
            this.txtUser.Scheme = cTextBox.Schemes.Black;
            this.txtUser.Size = new System.Drawing.Size(207, 30);
            this.txtUser.TabIndex = 23;
            this.txtUser.UseSystemPasswordChar = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(43)))));
            this.tabPage2.Controls.Add(this.btnStart);
            this.tabPage2.Controls.Add(this.txtCoords);
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tabPage2.Location = new System.Drawing.Point(174, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(613, 411);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Coordinates";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(203, 380);
            this.btnStart.Name = "btnStart";
            this.btnStart.Scheme = cButton.Schemes.Green;
            this.btnStart.Size = new System.Drawing.Size(207, 23);
            this.btnStart.TabIndex = 23;
            this.btnStart.Text = "Snipe!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtCoords
            // 
            this.txtCoords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(43)))));
            this.txtCoords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCoords.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtCoords.Location = new System.Drawing.Point(21, 18);
            this.txtCoords.Multiline = true;
            this.txtCoords.Name = "txtCoords";
            this.txtCoords.Size = new System.Drawing.Size(574, 356);
            this.txtCoords.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(43)))));
            this.tabPage3.Controls.Add(this.lvWalkLog);
            this.tabPage3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabPage3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tabPage3.Location = new System.Drawing.Point(174, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(613, 411);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log";
            // 
            // lvWalkLog
            // 
            this.lvWalkLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvWalkLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(43)))));
            this.lvWalkLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvWalkLog.ForeColor = System.Drawing.Color.Gainsboro;
            this.lvWalkLog.FullRowSelect = true;
            this.lvWalkLog.Location = new System.Drawing.Point(41, 8);
            this.lvWalkLog.Name = "lvWalkLog";
            this.lvWalkLog.Size = new System.Drawing.Size(530, 384);
            this.lvWalkLog.TabIndex = 1;
            this.lvWalkLog.UseCompatibleStateImageBehavior = false;
            this.lvWalkLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Time";
            this.columnHeader1.Width = 123;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Message";
            this.columnHeader2.Width = 387;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 419);
            this.Controls.Add(this.cTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SnipeBot - GoBot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.cTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private cTabControl cTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private BoosterComboBox cbAuthType;
        private cTextBox txtPass;
        private cTextBox txtUser;
        private cButton btnStart;
        private System.Windows.Forms.TextBox txtCoords;
        private System.Windows.Forms.ListView lvWalkLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private cCheckBox chkUseBerries;
        private System.Windows.Forms.Label label11;
        private cTextBox txtAltitude;
        private System.Windows.Forms.Label label6;
        private cTextBox txtLng;
        private System.Windows.Forms.Label label5;
        private cTextBox txtLat;
        private System.Windows.Forms.Label label1;
        private cTextBox txtProbability;
        private System.Windows.Forms.Label label2;
        private cTextBox txtRegex;
        private cButton btnLogin;
    }
}

