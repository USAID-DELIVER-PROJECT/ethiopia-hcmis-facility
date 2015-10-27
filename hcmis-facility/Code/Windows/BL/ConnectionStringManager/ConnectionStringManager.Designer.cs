namespace ConnectionStringManager
{
    partial class ConnectionStringManager
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
            this.txtDBPath = new DevExpress.XtraEditors.TextEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lkPrevConnectionStrings = new DevExpress.XtraEditors.LookUpEdit();
            this.txtUid = new DevExpress.XtraEditors.TextEdit();
            this.txtpwd = new DevExpress.XtraEditors.TextEdit();
            this.txtCatalogName = new DevExpress.XtraEditors.TextEdit();
            this.gridServers = new DevExpress.XtraGrid.GridControl();
            this.gridViewServers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.chkUseInitialCatalog = new DevExpress.XtraEditors.CheckEdit();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcUID = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcCatalogName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkPrevConnectionStrings.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCatalogName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridServers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewServers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseInitialCatalog.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcUID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcCatalogName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDBPath
            // 
            this.txtDBPath.Enabled = false;
            this.txtDBPath.Location = new System.Drawing.Point(101, 179);
            this.txtDBPath.Name = "txtDBPath";
            this.txtDBPath.Size = new System.Drawing.Size(218, 20);
            this.txtDBPath.StyleController = this.layoutControl1;
            this.txtDBPath.TabIndex = 1;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.lkPrevConnectionStrings);
            this.layoutControl1.Controls.Add(this.txtUid);
            this.layoutControl1.Controls.Add(this.txtpwd);
            this.layoutControl1.Controls.Add(this.txtCatalogName);
            this.layoutControl1.Controls.Add(this.gridServers);
            this.layoutControl1.Controls.Add(this.txtConnectionString);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.chkUseInitialCatalog);
            this.layoutControl1.Controls.Add(this.txtDBPath);
            this.layoutControl1.Controls.Add(this.btnBrowse);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(751, 123, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(430, 448);
            this.layoutControl1.TabIndex = 12;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(288, 153);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(130, 22);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 16;
            this.simpleButton1.Text = "Search Available Servers";
            this.simpleButton1.Click += new System.EventHandler(this.btnSearchAvailableServers_Click);
            // 
            // lkPrevConnectionStrings
            // 
            this.lkPrevConnectionStrings.Location = new System.Drawing.Point(101, 205);
            this.lkPrevConnectionStrings.Name = "lkPrevConnectionStrings";
            this.lkPrevConnectionStrings.Properties.NullText = "";
            this.lkPrevConnectionStrings.Size = new System.Drawing.Size(317, 20);
            this.lkPrevConnectionStrings.StyleController = this.layoutControl1;
            this.lkPrevConnectionStrings.TabIndex = 15;
            this.lkPrevConnectionStrings.EditValueChanged += new System.EventHandler(this.lkPrevConnectionStrings_EditValueChanged);
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(101, 276);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(317, 20);
            this.txtUid.StyleController = this.layoutControl1;
            this.txtUid.TabIndex = 14;
            this.txtUid.EditValueChanged += new System.EventHandler(this.txtUid_EditValueChanged);
            // 
            // txtpwd
            // 
            this.txtpwd.Location = new System.Drawing.Point(101, 300);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.Size = new System.Drawing.Size(317, 20);
            this.txtpwd.StyleController = this.layoutControl1;
            this.txtpwd.TabIndex = 13;
            this.txtpwd.EditValueChanged += new System.EventHandler(this.txtpwd_EditValueChanged);
            // 
            // txtCatalogName
            // 
            this.txtCatalogName.Location = new System.Drawing.Point(101, 252);
            this.txtCatalogName.Name = "txtCatalogName";
            this.txtCatalogName.Size = new System.Drawing.Size(317, 20);
            this.txtCatalogName.StyleController = this.layoutControl1;
            this.txtCatalogName.TabIndex = 12;
            this.txtCatalogName.EditValueChanged += new System.EventHandler(this.txtCatalogName_EditValueChanged);
            // 
            // gridServers
            // 
            this.gridServers.Location = new System.Drawing.Point(101, 12);
            this.gridServers.MainView = this.gridViewServers;
            this.gridServers.Name = "gridServers";
            this.gridServers.Size = new System.Drawing.Size(317, 137);
            this.gridServers.TabIndex = 6;
            this.gridServers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewServers});
            // 
            // gridViewServers
            // 
            this.gridViewServers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridViewServers.GridControl = this.gridServers;
            this.gridViewServers.Name = "gridViewServers";
            this.gridViewServers.OptionsBehavior.Editable = false;
            this.gridViewServers.OptionsCustomization.AllowGroup = false;
            this.gridViewServers.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewServers.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Server Name";
            this.gridColumn1.FieldName = "ServerName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Instance Name";
            this.gridColumn2.FieldName = "InstanceName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(101, 324);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(317, 86);
            this.txtConnectionString.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(322, 414);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 22);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkUseInitialCatalog
            // 
            this.chkUseInitialCatalog.Location = new System.Drawing.Point(12, 229);
            this.chkUseInitialCatalog.Name = "chkUseInitialCatalog";
            this.chkUseInitialCatalog.Properties.Caption = "Use Inital Catalog";
            this.chkUseInitialCatalog.Size = new System.Drawing.Size(406, 19);
            this.chkUseInitialCatalog.StyleController = this.layoutControl1;
            this.chkUseInitialCatalog.TabIndex = 11;
            this.chkUseInitialCatalog.CheckedChanged += new System.EventHandler(this.chkUseInitialCatalog_CheckedChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(323, 179);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(95, 22);
            this.btnBrowse.StyleController = this.layoutControl1;
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.lcUID,
            this.lcCatalogName,
            this.lcPassword,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.emptySpaceItem2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(430, 448);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridServers;
            this.layoutControlItem1.CustomizationFormText = "Server Instances";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(104, 40);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(410, 141);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Server Instances";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(85, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtDBPath;
            this.layoutControlItem2.CustomizationFormText = "Database";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 167);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(143, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(311, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Database";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(85, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnBrowse;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(311, 167);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(99, 26);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(99, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(99, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.chkUseInitialCatalog;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 217);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 23);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(112, 23);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(410, 23);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtConnectionString;
            this.layoutControlItem5.CustomizationFormText = "Connection String";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 312);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(0, 90);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(89, 90);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(410, 90);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "Connection String";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(85, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnSave;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(310, 402);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(100, 26);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(100, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(100, 26);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // lcUID
            // 
            this.lcUID.Control = this.txtUid;
            this.lcUID.CustomizationFormText = "User ID";
            this.lcUID.Location = new System.Drawing.Point(0, 264);
            this.lcUID.MaxSize = new System.Drawing.Size(0, 24);
            this.lcUID.MinSize = new System.Drawing.Size(143, 24);
            this.lcUID.Name = "lcUID";
            this.lcUID.Size = new System.Drawing.Size(410, 24);
            this.lcUID.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcUID.Text = "User ID";
            this.lcUID.TextSize = new System.Drawing.Size(85, 13);
            // 
            // lcCatalogName
            // 
            this.lcCatalogName.Control = this.txtCatalogName;
            this.lcCatalogName.CustomizationFormText = "Name";
            this.lcCatalogName.Location = new System.Drawing.Point(0, 240);
            this.lcCatalogName.MaxSize = new System.Drawing.Size(0, 24);
            this.lcCatalogName.MinSize = new System.Drawing.Size(143, 24);
            this.lcCatalogName.Name = "lcCatalogName";
            this.lcCatalogName.Size = new System.Drawing.Size(410, 24);
            this.lcCatalogName.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcCatalogName.Text = "Name";
            this.lcCatalogName.TextSize = new System.Drawing.Size(85, 13);
            // 
            // lcPassword
            // 
            this.lcPassword.Control = this.txtpwd;
            this.lcPassword.CustomizationFormText = "Password";
            this.lcPassword.Location = new System.Drawing.Point(0, 288);
            this.lcPassword.MaxSize = new System.Drawing.Size(0, 24);
            this.lcPassword.MinSize = new System.Drawing.Size(143, 24);
            this.lcPassword.Name = "lcPassword";
            this.lcPassword.Size = new System.Drawing.Size(410, 24);
            this.lcPassword.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcPassword.Text = "Password";
            this.lcPassword.TextSize = new System.Drawing.Size(85, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.lkPrevConnectionStrings;
            this.layoutControlItem7.CustomizationFormText = "Used Previously";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 193);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(143, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(410, 24);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "Used Previously";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(85, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.simpleButton1;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(276, 141);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(134, 26);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 141);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(276, 26);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 402);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(310, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ConnectionStringManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 448);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ConnectionStringManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection String Manager";
            this.Load += new System.EventHandler(this.ConnectionStringManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDBPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkPrevConnectionStrings.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCatalogName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridServers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewServers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseInitialCatalog.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcUID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcCatalogName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDBPath;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private DevExpress.XtraGrid.GridControl gridServers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewServers;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.TextBox txtConnectionString;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtCatalogName;
        private DevExpress.XtraEditors.CheckEdit chkUseInitialCatalog;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem lcCatalogName;
        private DevExpress.XtraEditors.TextEdit txtUid;
        private DevExpress.XtraEditors.TextEdit txtpwd;
        private DevExpress.XtraLayout.LayoutControlItem lcPassword;
        private DevExpress.XtraLayout.LayoutControlItem lcUID;
        private DevExpress.XtraEditors.LookUpEdit lkPrevConnectionStrings;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}