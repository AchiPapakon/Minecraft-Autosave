namespace Minecraft_Autosave
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnStart = new System.Windows.Forms.Button();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lblTimeUntil = new System.Windows.Forms.Label();
            this.timerInterval = new System.Windows.Forms.Timer(this.components);
            this.timerUpdateLabel = new System.Windows.Forms.Timer(this.components);
            this.btnSaveNow = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nmrMax = new System.Windows.Forms.NumericUpDown();
            this.opnWorld = new System.Windows.Forms.FolderBrowserDialog();
            this.cmbWorld = new System.Windows.Forms.ComboBox();
            this.opnBackupLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.lblWorldName = new System.Windows.Forms.Label();
            this.lblBackupLocation = new System.Windows.Forms.Label();
            this.txtZipDir = new System.Windows.Forms.TextBox();
            this.picZipDir = new System.Windows.Forms.PictureBox();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.flowPanelHide = new System.Windows.Forms.FlowLayoutPanel();
            this.picRefreshWorlds = new System.Windows.Forms.PictureBox();
            this.picWorldsDirectory = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nmrMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZipDir)).BeginInit();
            this.grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRefreshWorlds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWorldsDirectory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(82, 28);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(159, 98);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(62, 20);
            this.txtTime.TabIndex = 1;
            this.txtTime.Visible = false;
            // 
            // lblTimeUntil
            // 
            this.lblTimeUntil.AutoSize = true;
            this.lblTimeUntil.Location = new System.Drawing.Point(7, 101);
            this.lblTimeUntil.Name = "lblTimeUntil";
            this.lblTimeUntil.Size = new System.Drawing.Size(104, 13);
            this.lblTimeUntil.TabIndex = 2;
            this.lblTimeUntil.Text = "Time until next save:";
            // 
            // timerInterval
            // 
            this.timerInterval.Interval = 900000;
            this.timerInterval.Tick += new System.EventHandler(this.timerInterval_Tick);
            // 
            // timerUpdateLabel
            // 
            this.timerUpdateLabel.Interval = 1000;
            this.timerUpdateLabel.Tick += new System.EventHandler(this.timerUpdateLabel_Tick);
            // 
            // btnSaveNow
            // 
            this.btnSaveNow.Location = new System.Drawing.Point(12, 58);
            this.btnSaveNow.Name = "btnSaveNow";
            this.btnSaveNow.Size = new System.Drawing.Size(82, 23);
            this.btnSaveNow.TabIndex = 3;
            this.btnSaveNow.Text = "Save now!";
            this.btnSaveNow.UseVisualStyleBackColor = true;
            this.btnSaveNow.Click += new System.EventHandler(this.btnSaveNow_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(117, 101);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(16, 13);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "   ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Max saves";
            // 
            // nmrMax
            // 
            this.nmrMax.Location = new System.Drawing.Point(179, 13);
            this.nmrMax.Name = "nmrMax";
            this.nmrMax.ReadOnly = true;
            this.nmrMax.Size = new System.Drawing.Size(42, 20);
            this.nmrMax.TabIndex = 6;
            this.nmrMax.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nmrMax.ValueChanged += new System.EventHandler(this.nmrMax_ValueChanged);
            this.nmrMax.Leave += new System.EventHandler(this.nmrMax_Leave);
            // 
            // cmbWorld
            // 
            this.cmbWorld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorld.FormattingEnabled = true;
            this.cmbWorld.Location = new System.Drawing.Point(87, 25);
            this.cmbWorld.Name = "cmbWorld";
            this.cmbWorld.Size = new System.Drawing.Size(142, 21);
            this.cmbWorld.TabIndex = 8;
            this.cmbWorld.SelectedIndexChanged += new System.EventHandler(this.cmbWorld_SelectedIndexChanged);
            // 
            // lblWorldName
            // 
            this.lblWorldName.AutoSize = true;
            this.lblWorldName.Location = new System.Drawing.Point(12, 28);
            this.lblWorldName.Name = "lblWorldName";
            this.lblWorldName.Size = new System.Drawing.Size(69, 13);
            this.lblWorldName.TabIndex = 9;
            this.lblWorldName.Text = "World Name:";
            // 
            // lblBackupLocation
            // 
            this.lblBackupLocation.AutoSize = true;
            this.lblBackupLocation.Location = new System.Drawing.Point(12, 71);
            this.lblBackupLocation.Name = "lblBackupLocation";
            this.lblBackupLocation.Size = new System.Drawing.Size(91, 13);
            this.lblBackupLocation.TabIndex = 10;
            this.lblBackupLocation.Text = "Backup Location:";
            // 
            // txtZipDir
            // 
            this.txtZipDir.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtZipDir.Enabled = false;
            this.txtZipDir.Location = new System.Drawing.Point(109, 68);
            this.txtZipDir.Name = "txtZipDir";
            this.txtZipDir.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtZipDir.Size = new System.Drawing.Size(252, 20);
            this.txtZipDir.TabIndex = 11;
            this.txtZipDir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // picZipDir
            // 
            this.picZipDir.Image = ((System.Drawing.Image)(resources.GetObject("picZipDir.Image")));
            this.picZipDir.Location = new System.Drawing.Point(367, 68);
            this.picZipDir.Name = "picZipDir";
            this.picZipDir.Size = new System.Drawing.Size(26, 20);
            this.picZipDir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picZipDir.TabIndex = 13;
            this.picZipDir.TabStop = false;
            this.picZipDir.Click += new System.EventHandler(this.picZipDir_Click);
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.picWorldsDirectory);
            this.grpSettings.Controls.Add(this.picRefreshWorlds);
            this.grpSettings.Controls.Add(this.picZipDir);
            this.grpSettings.Controls.Add(this.txtZipDir);
            this.grpSettings.Controls.Add(this.lblBackupLocation);
            this.grpSettings.Controls.Add(this.lblWorldName);
            this.grpSettings.Controls.Add(this.cmbWorld);
            this.grpSettings.Location = new System.Drawing.Point(264, 7);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(399, 110);
            this.grpSettings.TabIndex = 0;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // flowPanelHide
            // 
            this.flowPanelHide.Location = new System.Drawing.Point(-5, 6);
            this.flowPanelHide.Name = "flowPanelHide";
            this.flowPanelHide.Size = new System.Drawing.Size(11, 112);
            this.flowPanelHide.TabIndex = 7;
            // 
            // picRefreshWorlds
            // 
            this.picRefreshWorlds.Image = ((System.Drawing.Image)(resources.GetObject("picRefreshWorlds.Image")));
            this.picRefreshWorlds.Location = new System.Drawing.Point(236, 25);
            this.picRefreshWorlds.Name = "picRefreshWorlds";
            this.picRefreshWorlds.Size = new System.Drawing.Size(25, 21);
            this.picRefreshWorlds.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRefreshWorlds.TabIndex = 14;
            this.picRefreshWorlds.TabStop = false;
            this.picRefreshWorlds.Click += new System.EventHandler(this.picRefreshWorlds_Click);
            // 
            // picWorldsDirectory
            // 
            this.picWorldsDirectory.Image = ((System.Drawing.Image)(resources.GetObject("picWorldsDirectory.Image")));
            this.picWorldsDirectory.Location = new System.Drawing.Point(267, 25);
            this.picWorldsDirectory.Name = "picWorldsDirectory";
            this.picWorldsDirectory.Size = new System.Drawing.Size(26, 20);
            this.picWorldsDirectory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWorldsDirectory.TabIndex = 15;
            this.picWorldsDirectory.TabStop = false;
            this.picWorldsDirectory.Click += new System.EventHandler(this.picWorldsDirectory_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 127);
            this.Controls.Add(this.flowPanelHide);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.nmrMax);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnSaveNow);
            this.Controls.Add(this.lblTimeUntil);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Minecraft Autosave";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmrMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZipDir)).EndInit();
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRefreshWorlds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWorldsDirectory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lblTimeUntil;
        private System.Windows.Forms.Timer timerInterval;
        private System.Windows.Forms.Timer timerUpdateLabel;
        private System.Windows.Forms.Button btnSaveNow;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nmrMax;
        private System.Windows.Forms.FolderBrowserDialog opnWorld;
        private System.Windows.Forms.ComboBox cmbWorld;
        private System.Windows.Forms.FolderBrowserDialog opnBackupLocation;
        private System.Windows.Forms.Label lblWorldName;
        private System.Windows.Forms.Label lblBackupLocation;
        private System.Windows.Forms.TextBox txtZipDir;
        private System.Windows.Forms.PictureBox picZipDir;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.FlowLayoutPanel flowPanelHide;
        private System.Windows.Forms.PictureBox picRefreshWorlds;
        private System.Windows.Forms.PictureBox picWorldsDirectory;
    }
}

