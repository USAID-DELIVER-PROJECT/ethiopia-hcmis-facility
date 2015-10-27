namespace PharmInventory.Forms.Transactions
{
    partial class AMCView
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cboStores = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFullItemName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmcRange1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIssueInAmcRange1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaysOutOfStock1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmcWithDOS1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmcWithOutDOS1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastIndexedTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnExportToEx = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.colFullItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmcRange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIssueInAmcRange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaysOutOfStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmcWithDOS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmcWithOutDOS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboStores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cboStores);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.btnExportToEx);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(374, 260, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1122, 419);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cboStores
            // 
            this.cboStores.Location = new System.Drawing.Point(41, 12);
            this.cboStores.Name = "cboStores";
            this.cboStores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboStores.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreName", "Store Name", 66, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.cboStores.Properties.DisplayMember = "StoreName";
            this.cboStores.Properties.NullText = "Select Store";
            this.cboStores.Properties.ValueMember = "ID";
            this.cboStores.Size = new System.Drawing.Size(168, 20);
            this.cboStores.StyleController = this.layoutControl1;
            this.cboStores.TabIndex = 4;
            this.cboStores.EditValueChanged += new System.EventHandler(this.cboStores_EditValueChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 38);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit2});
            this.gridControl1.Size = new System.Drawing.Size(1098, 369);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFullItemName1,
            this.colAmcRange1,
            this.colIssueInAmcRange1,
            this.colDaysOutOfStock1,
            this.colAmcWithDOS1,
            this.colAmcWithOutDOS1,
            this.colLastIndexedTime,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // colFullItemName1
            // 
            this.colFullItemName1.FieldName = "FullItemName";
            this.colFullItemName1.Name = "colFullItemName1";
            this.colFullItemName1.OptionsColumn.AllowEdit = false;
            this.colFullItemName1.Visible = true;
            this.colFullItemName1.VisibleIndex = 1;
            this.colFullItemName1.Width = 222;
            // 
            // colAmcRange1
            // 
            this.colAmcRange1.Caption = "AMC Range";
            this.colAmcRange1.FieldName = "AmcRange";
            this.colAmcRange1.Name = "colAmcRange1";
            this.colAmcRange1.OptionsColumn.AllowEdit = false;
            this.colAmcRange1.Visible = true;
            this.colAmcRange1.VisibleIndex = 3;
            this.colAmcRange1.Width = 72;
            // 
            // colIssueInAmcRange1
            // 
            this.colIssueInAmcRange1.Caption = "Issue Not Considering DOS";
            this.colIssueInAmcRange1.FieldName = "IssueInAmcRange";
            this.colIssueInAmcRange1.Name = "colIssueInAmcRange1";
            this.colIssueInAmcRange1.OptionsColumn.AllowEdit = false;
            this.colIssueInAmcRange1.Visible = true;
            this.colIssueInAmcRange1.VisibleIndex = 5;
            this.colIssueInAmcRange1.Width = 146;
            // 
            // colDaysOutOfStock1
            // 
            this.colDaysOutOfStock1.FieldName = "DaysOutOfStock";
            this.colDaysOutOfStock1.Name = "colDaysOutOfStock1";
            this.colDaysOutOfStock1.OptionsColumn.AllowEdit = false;
            this.colDaysOutOfStock1.Visible = true;
            this.colDaysOutOfStock1.VisibleIndex = 6;
            this.colDaysOutOfStock1.Width = 95;
            // 
            // colAmcWithDOS1
            // 
            this.colAmcWithDOS1.Caption = "AMC Considering DOS";
            this.colAmcWithDOS1.DisplayFormat.FormatString = "##0.#0";
            this.colAmcWithDOS1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmcWithDOS1.FieldName = "AmcWithDOS";
            this.colAmcWithDOS1.Name = "colAmcWithDOS1";
            this.colAmcWithDOS1.OptionsColumn.AllowEdit = false;
            this.colAmcWithDOS1.Visible = true;
            this.colAmcWithDOS1.VisibleIndex = 7;
            this.colAmcWithDOS1.Width = 120;
            // 
            // colAmcWithOutDOS1
            // 
            this.colAmcWithOutDOS1.Caption = "AMC Not Considering DOS";
            this.colAmcWithOutDOS1.DisplayFormat.FormatString = "##0.#0";
            this.colAmcWithOutDOS1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmcWithOutDOS1.FieldName = "AmcWithOutDOS";
            this.colAmcWithOutDOS1.Name = "colAmcWithOutDOS1";
            this.colAmcWithOutDOS1.OptionsColumn.AllowEdit = false;
            this.colAmcWithOutDOS1.Visible = true;
            this.colAmcWithOutDOS1.VisibleIndex = 8;
            this.colAmcWithOutDOS1.Width = 132;
            // 
            // colLastIndexedTime
            // 
            this.colLastIndexedTime.Caption = "Last Indexed Time";
            this.colLastIndexedTime.FieldName = "LastIndexedTime";
            this.colLastIndexedTime.Name = "colLastIndexedTime";
            this.colLastIndexedTime.OptionsColumn.AllowEdit = false;
            this.colLastIndexedTime.Visible = true;
            this.colLastIndexedTime.VisibleIndex = 9;
            this.colLastIndexedTime.Width = 132;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "No.";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 36;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Issue Considering  DOS";
            this.gridColumn4.DisplayFormat.FormatString = "#,##0.#0";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "IssueWithDOS";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 134;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Unit";
            this.gridColumn5.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.gridColumn5.FieldName = "UnitID";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.OptionsFilter.AllowFilter = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Text", 32, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit2.DisplayMember = "Text";
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.NullText = "Unit";
            this.repositoryItemLookUpEdit2.ValueMember = "ID";
            // 
            // btnExportToEx
            // 
            this.btnExportToEx.Location = new System.Drawing.Point(1024, 12);
            this.btnExportToEx.Name = "btnExportToEx";
            this.btnExportToEx.Size = new System.Drawing.Size(86, 22);
            this.btnExportToEx.StyleController = this.layoutControl1;
            this.btnExportToEx.TabIndex = 7;
            this.btnExportToEx.Text = "Export";
            this.btnExportToEx.Click += new System.EventHandler(this.btnExportToEx_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1122, 419);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cboStores;
            this.layoutControlItem1.CustomizationFormText = "Store";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(201, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(201, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(201, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Store";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(26, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1102, 373);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(201, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(811, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnExportToEx;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(1012, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(90, 26);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(90, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(90, 26);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // colFullItemName
            // 
            this.colFullItemName.FieldName = "FullItemName";
            this.colFullItemName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colFullItemName.Name = "colFullItemName";
            this.colFullItemName.OptionsColumn.AllowEdit = false;
            this.colFullItemName.Visible = true;
            this.colFullItemName.VisibleIndex = 1;
            this.colFullItemName.Width = 304;
            // 
            // colAmcRange
            // 
            this.colAmcRange.Caption = "AMC Range";
            this.colAmcRange.FieldName = "AmcRange";
            this.colAmcRange.Name = "colAmcRange";
            this.colAmcRange.OptionsColumn.AllowEdit = false;
            this.colAmcRange.Visible = true;
            this.colAmcRange.VisibleIndex = 2;
            this.colAmcRange.Width = 20;
            // 
            // colIssueInAmcRange
            // 
            this.colIssueInAmcRange.Caption = "Issue In AMC Range";
            this.colIssueInAmcRange.FieldName = "IssueInAmcRange";
            this.colIssueInAmcRange.Name = "colIssueInAmcRange";
            this.colIssueInAmcRange.OptionsColumn.AllowEdit = false;
            this.colIssueInAmcRange.Visible = true;
            this.colIssueInAmcRange.VisibleIndex = 3;
            this.colIssueInAmcRange.Width = 20;
            // 
            // colDaysOutOfStock
            // 
            this.colDaysOutOfStock.FieldName = "DaysOutOfStock";
            this.colDaysOutOfStock.Name = "colDaysOutOfStock";
            this.colDaysOutOfStock.OptionsColumn.AllowEdit = false;
            this.colDaysOutOfStock.Visible = true;
            this.colDaysOutOfStock.VisibleIndex = 4;
            this.colDaysOutOfStock.Width = 20;
            // 
            // colAmcWithDOS
            // 
            this.colAmcWithDOS.Caption = "AMC With DOS";
            this.colAmcWithDOS.DisplayFormat.FormatString = "#,##0.#0";
            this.colAmcWithDOS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmcWithDOS.FieldName = "AmcWithDOS";
            this.colAmcWithDOS.Name = "colAmcWithDOS";
            this.colAmcWithDOS.OptionsColumn.AllowEdit = false;
            this.colAmcWithDOS.Visible = true;
            this.colAmcWithDOS.VisibleIndex = 5;
            this.colAmcWithDOS.Width = 37;
            // 
            // colAmcWithOutDOS
            // 
            this.colAmcWithOutDOS.Caption = "AMC Without DOS";
            this.colAmcWithOutDOS.DisplayFormat.FormatString = "#,##0.#0";
            this.colAmcWithOutDOS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmcWithOutDOS.FieldName = "AmcWithOutDOS";
            this.colAmcWithOutDOS.Name = "colAmcWithOutDOS";
            this.colAmcWithOutDOS.OptionsColumn.AllowEdit = false;
            this.colAmcWithOutDOS.Visible = true;
            this.colAmcWithOutDOS.VisibleIndex = 6;
            this.colAmcWithOutDOS.Width = 124;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No.";
            this.gridColumn1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 51;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Last Indexed Time";
            this.gridColumn2.FieldName = "LastIndexedTime";
            this.gridColumn2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            this.gridColumn2.Width = 138;
            // 
            // AMCView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 419);
            this.Controls.Add(this.layoutControl1);
            this.Name = "AMCView";
            this.Text = "AMC Report";
            this.Load += new System.EventHandler(this.AMCView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboStores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LookUpEdit cboStores;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colFullItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colAmcRange;
        private DevExpress.XtraGrid.Columns.GridColumn colIssueInAmcRange;
        private DevExpress.XtraGrid.Columns.GridColumn colDaysOutOfStock;
        private DevExpress.XtraGrid.Columns.GridColumn colAmcWithDOS;
        private DevExpress.XtraGrid.Columns.GridColumn colAmcWithOutDOS;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colFullItemName1;
        private DevExpress.XtraGrid.Columns.GridColumn colAmcRange1;
        private DevExpress.XtraGrid.Columns.GridColumn colIssueInAmcRange1;
        private DevExpress.XtraGrid.Columns.GridColumn colDaysOutOfStock1;
        private DevExpress.XtraGrid.Columns.GridColumn colAmcWithDOS1;
        private DevExpress.XtraGrid.Columns.GridColumn colAmcWithOutDOS1;
        private DevExpress.XtraGrid.Columns.GridColumn colLastIndexedTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton btnExportToEx;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
      

    }
}