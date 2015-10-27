namespace PharmInventory.Forms.UtilitiesAndForms
{
    partial class DatabaseActions
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
            this.btnAutoBackup = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.btnRunSSIS = new DevExpress.XtraEditors.SimpleButton();
            this.lblLastSyncDate = new System.Windows.Forms.Label();
            this.lblLastBackupDate = new System.Windows.Forms.Label();
            this.picSync = new System.Windows.Forms.PictureBox();
            this.lblSync = new System.Windows.Forms.Label();
            this.btnRefreshDirectoryService = new DevExpress.XtraEditors.SimpleButton();
            this.btnRestore = new DevExpress.XtraEditors.SimpleButton();
            this.btnBackup = new DevExpress.XtraEditors.SimpleButton();
            this.btnImportUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcSyncLabel = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcSyncPic = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem11 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem12 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem13 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.layoutConverter1 = new DevExpress.XtraLayout.Converter.LayoutConverter(this.components);
            this.bw = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1ConvertedLayout)).BeginInit();
            this.groupBox1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSync)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcSyncLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcSyncPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAutoBackup
            // 
            this.btnAutoBackup.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnAutoBackup.Appearance.Options.UseFont = true;
            this.btnAutoBackup.Location = new System.Drawing.Point(171, 32);
            this.btnAutoBackup.Name = "btnAutoBackup";
            this.btnAutoBackup.Size = new System.Drawing.Size(353, 54);
            this.btnAutoBackup.StyleController = this.groupBox1ConvertedLayout;
            this.btnAutoBackup.TabIndex = 4;
            this.btnAutoBackup.Text = "Auto Backup Settings";
            this.btnAutoBackup.Click += new System.EventHandler(this.btnAutoBackup_Click);
            // 
            // groupBox1ConvertedLayout
            // 
            this.groupBox1ConvertedLayout.Controls.Add(this.btnRunSSIS);
            this.groupBox1ConvertedLayout.Controls.Add(this.lblLastSyncDate);
            this.groupBox1ConvertedLayout.Controls.Add(this.lblLastBackupDate);
            this.groupBox1ConvertedLayout.Controls.Add(this.picSync);
            this.groupBox1ConvertedLayout.Controls.Add(this.lblSync);
            this.groupBox1ConvertedLayout.Controls.Add(this.btnRefreshDirectoryService);
            this.groupBox1ConvertedLayout.Controls.Add(this.btnAutoBackup);
            this.groupBox1ConvertedLayout.Controls.Add(this.btnRestore);
            this.groupBox1ConvertedLayout.Controls.Add(this.btnBackup);
            this.groupBox1ConvertedLayout.Controls.Add(this.btnImportUpdate);
            this.groupBox1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1ConvertedLayout.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.groupBox1ConvertedLayout.Location = new System.Drawing.Point(0, 0);
            this.groupBox1ConvertedLayout.Name = "groupBox1ConvertedLayout";
            this.groupBox1ConvertedLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(678, 364, 250, 350);
            this.groupBox1ConvertedLayout.Root = this.layoutControlGroup1;
            this.groupBox1ConvertedLayout.Size = new System.Drawing.Size(909, 512);
            this.groupBox1ConvertedLayout.TabIndex = 1;
            // 
            // btnRunSSIS
            // 
            this.btnRunSSIS.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F);
            this.btnRunSSIS.Appearance.Options.UseFont = true;
            this.btnRunSSIS.Location = new System.Drawing.Point(193, 316);
            this.btnRunSSIS.Name = "btnRunSSIS";
            this.btnRunSSIS.Size = new System.Drawing.Size(322, 52);
            this.btnRunSSIS.StyleController = this.groupBox1ConvertedLayout;
            this.btnRunSSIS.TabIndex = 12;
            this.btnRunSSIS.Text = "Send Reports";
            this.btnRunSSIS.Click += new System.EventHandler(this.btnRunSSIS_Click);
            // 
            // lblLastSyncDate
            // 
            this.lblLastSyncDate.Location = new System.Drawing.Point(518, 254);
            this.lblLastSyncDate.Name = "lblLastSyncDate";
            this.lblLastSyncDate.Size = new System.Drawing.Size(359, 48);
            this.lblLastSyncDate.TabIndex = 11;
            this.lblLastSyncDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastBackupDate
            // 
            this.lblLastBackupDate.Location = new System.Drawing.Point(518, 74);
            this.lblLastBackupDate.Name = "lblLastBackupDate";
            this.lblLastBackupDate.Size = new System.Drawing.Size(359, 46);
            this.lblLastBackupDate.TabIndex = 10;
            this.lblLastBackupDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picSync
            // 
            this.picSync.Image = global::PharmInventory.Properties.Resources.Loading;
            this.picSync.Location = new System.Drawing.Point(216, 387);
            this.picSync.Name = "picSync";
            this.picSync.Size = new System.Drawing.Size(46, 43);
            this.picSync.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picSync.TabIndex = 8;
            this.picSync.TabStop = false;
            // 
            // lblSync
            // 
            this.lblSync.Location = new System.Drawing.Point(266, 387);
            this.lblSync.Name = "lblSync";
            this.lblSync.Size = new System.Drawing.Size(399, 43);
            this.lblSync.TabIndex = 7;
            this.lblSync.Text = "Synchronizing with Directory Services";
            this.lblSync.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRefreshDirectoryService
            // 
            this.btnRefreshDirectoryService.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F);
            this.btnRefreshDirectoryService.Appearance.Options.UseFont = true;
            this.btnRefreshDirectoryService.Location = new System.Drawing.Point(193, 254);
            this.btnRefreshDirectoryService.Name = "btnRefreshDirectoryService";
            this.btnRefreshDirectoryService.Size = new System.Drawing.Size(321, 48);
            this.btnRefreshDirectoryService.StyleController = this.groupBox1ConvertedLayout;
            this.btnRefreshDirectoryService.TabIndex = 5;
            this.btnRefreshDirectoryService.Text = "Refresh Directory Service";
            this.btnRefreshDirectoryService.Click += new System.EventHandler(this.btnRefreshDirectoryService_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.Appearance.Options.UseFont = true;
            this.btnRestore.Location = new System.Drawing.Point(193, 134);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(321, 46);
            this.btnRestore.StyleController = this.groupBox1ConvertedLayout;
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "Restore/Import Database";
            this.btnRestore.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.Appearance.Options.UseFont = true;
            this.btnBackup.Location = new System.Drawing.Point(193, 74);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(321, 46);
            this.btnBackup.StyleController = this.groupBox1ConvertedLayout;
            this.btnBackup.TabIndex = 2;
            this.btnBackup.Text = "Backup/Export Database";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnImportUpdate
            // 
            this.btnImportUpdate.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportUpdate.Appearance.Options.UseFont = true;
            this.btnImportUpdate.Location = new System.Drawing.Point(193, 194);
            this.btnImportUpdate.Name = "btnImportUpdate";
            this.btnImportUpdate.Size = new System.Drawing.Size(321, 46);
            this.btnImportUpdate.StyleController = this.groupBox1ConvertedLayout;
            this.btnImportUpdate.TabIndex = 2;
            this.btnImportUpdate.Text = "Import Update";
            this.btnImportUpdate.Click += new System.EventHandler(this.btnImportUpdate_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnAutoBackup;
            this.layoutControlItem1.CustomizationFormText = "Last backup date :";
            this.layoutControlItem1.Location = new System.Drawing.Point(135, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 58);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(158, 58);
            this.layoutControlItem1.Name = "btnAutoBackupitem";
            this.layoutControlItem1.Size = new System.Drawing.Size(307, 58);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Last backup date :";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem2,
            this.emptySpaceItem1,
            this.emptySpaceItem3,
            this.layoutControlItem6,
            this.lcSyncLabel,
            this.lcSyncPic,
            this.emptySpaceItem5,
            this.emptySpaceItem7,
            this.emptySpaceItem9,
            this.layoutControlItem2,
            this.layoutControlItem7,
            this.emptySpaceItem10,
            this.emptySpaceItem11,
            this.emptySpaceItem4,
            this.emptySpaceItem6,
            this.layoutControlItem8,
            this.emptySpaceItem8,
            this.emptySpaceItem12,
            this.emptySpaceItem13});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(909, 512);
            this.layoutControlGroup1.Text = " ";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnImportUpdate;
            this.layoutControlItem3.CustomizationFormText = "btnImportUpdateitem";
            this.layoutControlItem3.Location = new System.Drawing.Point(181, 157);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 50);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(110, 50);
            this.layoutControlItem3.Name = "btnImportUpdateitem";
            this.layoutControlItem3.Size = new System.Drawing.Size(325, 50);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "btnImportUpdateitem";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnRestore;
            this.layoutControlItem4.CustomizationFormText = "btnRestoreitem";
            this.layoutControlItem4.Location = new System.Drawing.Point(181, 97);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 50);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(181, 50);
            this.layoutControlItem4.Name = "btnRestoreitem";
            this.layoutControlItem4.Size = new System.Drawing.Size(325, 50);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "btnRestoreitem";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnBackup;
            this.layoutControlItem5.CustomizationFormText = "btnBackupitem";
            this.layoutControlItem5.Location = new System.Drawing.Point(181, 37);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(0, 50);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(177, 50);
            this.layoutControlItem5.Name = "btnBackupitem";
            this.layoutControlItem5.Size = new System.Drawing.Size(325, 50);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "btnBackupitem";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(869, 37);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(20, 430);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 37);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(181, 0);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(181, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(181, 430);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(889, 37);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnRefreshDirectoryService;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(181, 217);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(325, 52);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(325, 52);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(325, 52);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // lcSyncLabel
            // 
            this.lcSyncLabel.Control = this.lblSync;
            this.lcSyncLabel.CustomizationFormText = "layoutControlItem7";
            this.lcSyncLabel.Location = new System.Drawing.Point(254, 350);
            this.lcSyncLabel.MaxSize = new System.Drawing.Size(0, 47);
            this.lcSyncLabel.MinSize = new System.Drawing.Size(24, 47);
            this.lcSyncLabel.Name = "lcSyncLabel";
            this.lcSyncLabel.Size = new System.Drawing.Size(403, 47);
            this.lcSyncLabel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcSyncLabel.Text = "lcSyncLabel";
            this.lcSyncLabel.TextSize = new System.Drawing.Size(0, 0);
            this.lcSyncLabel.TextToControlDistance = 0;
            this.lcSyncLabel.TextVisible = false;
            // 
            // lcSyncPic
            // 
            this.lcSyncPic.Control = this.picSync;
            this.lcSyncPic.CustomizationFormText = "layoutControlItem2";
            this.lcSyncPic.Location = new System.Drawing.Point(204, 350);
            this.lcSyncPic.MaxSize = new System.Drawing.Size(50, 0);
            this.lcSyncPic.MinSize = new System.Drawing.Size(50, 24);
            this.lcSyncPic.Name = "lcSyncPic";
            this.lcSyncPic.Size = new System.Drawing.Size(50, 47);
            this.lcSyncPic.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcSyncPic.Text = "lcSyncPic";
            this.lcSyncPic.TextSize = new System.Drawing.Size(0, 0);
            this.lcSyncPic.TextToControlDistance = 0;
            this.lcSyncPic.TextVisible = false;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem5.Location = new System.Drawing.Point(181, 397);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(476, 70);
            this.emptySpaceItem5.Text = "emptySpaceItem5";
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.CustomizationFormText = "emptySpaceItem7";
            this.emptySpaceItem7.Location = new System.Drawing.Point(506, 97);
            this.emptySpaceItem7.MaxSize = new System.Drawing.Size(363, 0);
            this.emptySpaceItem7.MinSize = new System.Drawing.Size(363, 10);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(363, 110);
            this.emptySpaceItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem7.Text = "emptySpaceItem7";
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            this.emptySpaceItem9.CustomizationFormText = "emptySpaceItem9";
            this.emptySpaceItem9.Location = new System.Drawing.Point(657, 350);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(212, 117);
            this.emptySpaceItem9.Text = "emptySpaceItem9";
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lblLastBackupDate;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(506, 37);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(363, 0);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(363, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(363, 50);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.lblLastSyncDate;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(506, 217);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(363, 0);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(363, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(363, 52);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem10
            // 
            this.emptySpaceItem10.AllowHotTrack = false;
            this.emptySpaceItem10.CustomizationFormText = "emptySpaceItem10";
            this.emptySpaceItem10.Location = new System.Drawing.Point(181, 207);
            this.emptySpaceItem10.MaxSize = new System.Drawing.Size(0, 10);
            this.emptySpaceItem10.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem10.Name = "emptySpaceItem10";
            this.emptySpaceItem10.Size = new System.Drawing.Size(688, 10);
            this.emptySpaceItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem10.Text = "emptySpaceItem10";
            this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem11
            // 
            this.emptySpaceItem11.AllowHotTrack = false;
            this.emptySpaceItem11.CustomizationFormText = "emptySpaceItem11";
            this.emptySpaceItem11.Location = new System.Drawing.Point(181, 87);
            this.emptySpaceItem11.MaxSize = new System.Drawing.Size(0, 10);
            this.emptySpaceItem11.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem11.Name = "emptySpaceItem11";
            this.emptySpaceItem11.Size = new System.Drawing.Size(688, 10);
            this.emptySpaceItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem11.Text = "emptySpaceItem11";
            this.emptySpaceItem11.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(181, 147);
            this.emptySpaceItem4.MaxSize = new System.Drawing.Size(0, 10);
            this.emptySpaceItem4.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(325, 10);
            this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.CustomizationFormText = "emptySpaceItem6";
            this.emptySpaceItem6.Location = new System.Drawing.Point(181, 350);
            this.emptySpaceItem6.MaxSize = new System.Drawing.Size(23, 0);
            this.emptySpaceItem6.MinSize = new System.Drawing.Size(23, 10);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(23, 47);
            this.emptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem6.Text = "emptySpaceItem6";
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnRunSSIS;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(181, 279);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(326, 56);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(326, 56);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(326, 56);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.CustomizationFormText = "emptySpaceItem8";
            this.emptySpaceItem8.Location = new System.Drawing.Point(507, 279);
            this.emptySpaceItem8.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(362, 56);
            this.emptySpaceItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem8.Text = "emptySpaceItem8";
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem12
            // 
            this.emptySpaceItem12.AllowHotTrack = false;
            this.emptySpaceItem12.CustomizationFormText = "emptySpaceItem12";
            this.emptySpaceItem12.Location = new System.Drawing.Point(181, 269);
            this.emptySpaceItem12.Name = "emptySpaceItem12";
            this.emptySpaceItem12.Size = new System.Drawing.Size(688, 10);
            this.emptySpaceItem12.Text = "emptySpaceItem12";
            this.emptySpaceItem12.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem13
            // 
            this.emptySpaceItem13.AllowHotTrack = false;
            this.emptySpaceItem13.CustomizationFormText = "emptySpaceItem13";
            this.emptySpaceItem13.Location = new System.Drawing.Point(181, 335);
            this.emptySpaceItem13.Name = "emptySpaceItem13";
            this.emptySpaceItem13.Size = new System.Drawing.Size(688, 15);
            this.emptySpaceItem13.Text = "emptySpaceItem13";
            this.emptySpaceItem13.TextSize = new System.Drawing.Size(0, 0);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bw
            // 
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // DatabaseActions
            // 
            this.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 512);
            this.Controls.Add(this.groupBox1ConvertedLayout);
            this.Name = "DatabaseActions";
            this.Load += new System.EventHandler(this.DatabaseActions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1ConvertedLayout)).EndInit();
            this.groupBox1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSync)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcSyncLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcSyncPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnBackup;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private DevExpress.XtraEditors.SimpleButton btnRestore;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.SimpleButton btnImportUpdate;
        private DevExpress.XtraEditors.SimpleButton btnAutoBackup;
        private DevExpress.XtraLayout.LayoutControl groupBox1ConvertedLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.Converter.LayoutConverter layoutConverter1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.SimpleButton btnRefreshDirectoryService;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.Label lblSync;
        private DevExpress.XtraLayout.LayoutControlItem lcSyncLabel;
        private System.Windows.Forms.PictureBox picSync;
        private DevExpress.XtraLayout.LayoutControlItem lcSyncPic;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private System.Windows.Forms.Label lblLastSyncDate;
        private System.Windows.Forms.Label lblLastBackupDate;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem11;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem12;
        private DevExpress.XtraEditors.SimpleButton btnRunSSIS;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem13;
    }
}