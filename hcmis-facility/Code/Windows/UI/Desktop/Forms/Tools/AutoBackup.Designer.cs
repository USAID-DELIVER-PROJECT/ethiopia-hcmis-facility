namespace PharmInventory.Forms.Tools
{
    partial class AutoBackup
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
            this.chkAutobackupEnabled = new DevExpress.XtraEditors.CheckEdit();
            this.gpAutoBackupSettings = new DevExpress.XtraEditors.GroupControl();
            this.btnEditFolder = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboFrequency = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutobackupEnabled.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpAutoBackupSettings)).BeginInit();
            this.gpAutoBackupSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditFolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFrequency.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chkAutobackupEnabled
            // 
            this.chkAutobackupEnabled.Location = new System.Drawing.Point(11, 8);
            this.chkAutobackupEnabled.Name = "chkAutobackupEnabled";
            this.chkAutobackupEnabled.Properties.Caption = "Enable Autobackup";
            this.chkAutobackupEnabled.Size = new System.Drawing.Size(127, 19);
            this.chkAutobackupEnabled.TabIndex = 0;
            this.chkAutobackupEnabled.CheckedChanged += new System.EventHandler(this.chkAutobackupEnabled_CheckedChanged);
            // 
            // gpAutoBackupSettings
            // 
            this.gpAutoBackupSettings.Controls.Add(this.btnEditFolder);
            this.gpAutoBackupSettings.Controls.Add(this.labelControl2);
            this.gpAutoBackupSettings.Controls.Add(this.cboFrequency);
            this.gpAutoBackupSettings.Controls.Add(this.labelControl1);
            this.gpAutoBackupSettings.Location = new System.Drawing.Point(-1, 33);
            this.gpAutoBackupSettings.Name = "gpAutoBackupSettings";
            this.gpAutoBackupSettings.Size = new System.Drawing.Size(314, 110);
            this.gpAutoBackupSettings.TabIndex = 1;
            this.gpAutoBackupSettings.Text = "Auto Backup Settings";
            // 
            // btnEditFolder
            // 
            this.btnEditFolder.Location = new System.Drawing.Point(138, 67);
            this.btnEditFolder.Name = "btnEditFolder";
            this.btnEditFolder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnEditFolder.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnEditFolder.Size = new System.Drawing.Size(159, 20);
            this.btnEditFolder.TabIndex = 3;
            this.btnEditFolder.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEditFolder_ButtonClick);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 70);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(93, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Auto Backup Folder";
            // 
            // cboFrequency
            // 
            this.cboFrequency.Location = new System.Drawing.Point(138, 41);
            this.cboFrequency.Name = "cboFrequency";
            this.cboFrequency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFrequency.Properties.Items.AddRange(new object[] {
            "Daily",
            "Twice a Week",
            "Weekly",
            "Twice a Month",
            "Monthly"});
            this.cboFrequency.Size = new System.Drawing.Size(159, 20);
            this.cboFrequency.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Frequency";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(193, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AutoBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 169);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gpAutoBackupSettings);
            this.Controls.Add(this.chkAutobackupEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AutoBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Backup Settings";
            this.Load += new System.EventHandler(this.AutoBackup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkAutobackupEnabled.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpAutoBackupSettings)).EndInit();
            this.gpAutoBackupSettings.ResumeLayout(false);
            this.gpAutoBackupSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditFolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFrequency.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkAutobackupEnabled;
        private DevExpress.XtraEditors.GroupControl gpAutoBackupSettings;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboFrequency;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.ButtonEdit btnEditFolder;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}