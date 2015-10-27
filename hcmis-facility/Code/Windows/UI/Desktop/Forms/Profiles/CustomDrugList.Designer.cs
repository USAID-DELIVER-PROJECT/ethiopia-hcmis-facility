namespace PharmInventory.Forms.Profiles
{
    partial class CustomDrugList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomDrugList));
            this.txtItemName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridItemsChoice = new DevExpress.XtraGrid.GridControl();
            this.gridItemChoiceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsInHospitalList = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn66 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn67 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkCategories = new DevExpress.XtraEditors.LookUpEdit();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.cboPrograms = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemsChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemChoiceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkCategories.Properties)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPrograms.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(122, 48);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(386, 20);
            this.txtItemName.StyleController = this.layoutControl1;
            this.txtItemName.TabIndex = 3;
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridItemsChoice);
            this.layoutControl1.Controls.Add(this.lkCategories);
            this.layoutControl1.Controls.Add(this.toolStrip2);
            this.layoutControl1.Controls.Add(this.cboPrograms);
            this.layoutControl1.Controls.Add(this.txtItemName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(161, 226, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1119, 613);
            this.layoutControl1.TabIndex = 33;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridItemsChoice
            // 
            this.gridItemsChoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridItemsChoice.Location = new System.Drawing.Point(24, 72);
            this.gridItemsChoice.MainView = this.gridItemChoiceView;
            this.gridItemsChoice.Name = "gridItemsChoice";
            this.gridItemsChoice.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridItemsChoice.Size = new System.Drawing.Size(1071, 517);
            this.gridItemsChoice.TabIndex = 31;
            this.gridItemsChoice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemChoiceView});
            this.gridItemsChoice.DoubleClick += new System.EventHandler(this.gridItemsChoice_DoubleClick);
            // 
            // gridItemChoiceView
            // 
            this.gridItemChoiceView.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.gridItemChoiceView.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridItemChoiceView.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridItemChoiceView.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridItemChoiceView.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(190)))), ((int)(((byte)(243)))));
            this.gridItemChoiceView.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridItemChoiceView.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridItemChoiceView.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridItemChoiceView.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.gridItemChoiceView.Appearance.Empty.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.gridItemChoiceView.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridItemChoiceView.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridItemChoiceView.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(109)))), ((int)(((byte)(185)))));
            this.gridItemChoiceView.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White;
            this.gridItemChoiceView.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.gridItemChoiceView.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridItemChoiceView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            this.gridItemChoiceView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridItemChoiceView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.gridItemChoiceView.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridItemChoiceView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridItemChoiceView.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.gridItemChoiceView.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.gridItemChoiceView.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridItemChoiceView.Appearance.GroupButton.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.gridItemChoiceView.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.gridItemChoiceView.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridItemChoiceView.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(109)))), ((int)(((byte)(185)))));
            this.gridItemChoiceView.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.gridItemChoiceView.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.gridItemChoiceView.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridItemChoiceView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridItemChoiceView.Appearance.GroupRow.Options.UseFont = true;
            this.gridItemChoiceView.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.gridItemChoiceView.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridItemChoiceView.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridItemChoiceView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(228)))));
            this.gridItemChoiceView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(224)))), ((int)(((byte)(251)))));
            this.gridItemChoiceView.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.HorzLine.BackColor = System.Drawing.Color.AliceBlue;
            this.gridItemChoiceView.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.gridItemChoiceView.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.OddRow.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.OddRow.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.gridItemChoiceView.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(129)))), ((int)(((byte)(185)))));
            this.gridItemChoiceView.Appearance.Preview.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.Preview.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gridItemChoiceView.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.Row.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.Row.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
            this.gridItemChoiceView.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(126)))), ((int)(((byte)(217)))));
            this.gridItemChoiceView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridItemChoiceView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.VertLine.BackColor = System.Drawing.Color.AliceBlue;
            this.gridItemChoiceView.Appearance.VertLine.Options.UseBackColor = true;
            this.gridItemChoiceView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn28,
            this.colItemName,
            this.gridColumn29,
            this.VEN,
            this.IsInHospitalList,
            this.gridColumn66,
            this.gridColumn67,
            this.gridColumn2});
            this.gridItemChoiceView.FixedLineWidth = 1;
            this.gridItemChoiceView.GridControl = this.gridItemsChoice;
            this.gridItemChoiceView.IndicatorWidth = 40;
            this.gridItemChoiceView.Name = "gridItemChoiceView";
            this.gridItemChoiceView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridItemChoiceView.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridItemChoiceView.OptionsDetail.EnableDetailToolTip = true;
            this.gridItemChoiceView.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled;
            this.gridItemChoiceView.OptionsDetail.SmartDetailHeight = true;
            this.gridItemChoiceView.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridItemChoiceView.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gridItemChoiceView.OptionsPrint.EnableAppearanceOddRow = true;
            this.gridItemChoiceView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridItemChoiceView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridItemChoiceView.OptionsSelection.MultiSelect = true;
            this.gridItemChoiceView.OptionsView.EnableAppearanceEvenRow = true;
            this.gridItemChoiceView.OptionsView.EnableAppearanceOddRow = true;
            this.gridItemChoiceView.OptionsView.ShowGroupPanel = false;
            this.gridItemChoiceView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridItemChoiceView_CustomDrawRowIndicator);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No.";
            this.gridColumn1.FieldName = "No";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.Width = 42;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Stock Code";
            this.gridColumn28.FieldName = "StockCode";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.AllowEdit = false;
            this.gridColumn28.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn28.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn28.OptionsColumn.AllowMove = false;
            this.gridColumn28.OptionsFilter.AllowFilter = false;
            this.gridColumn28.Width = 112;
            // 
            // colItemName
            // 
            this.colItemName.Caption = "Item Name";
            this.colItemName.FieldName = "FullItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.OptionsColumn.AllowEdit = false;
            this.colItemName.OptionsFilter.AllowFilter = false;
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 0;
            this.colItemName.Width = 464;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "ABC";
            this.gridColumn29.FieldName = "ABC";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.AllowEdit = false;
            this.gridColumn29.OptionsFilter.AllowFilter = false;
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 1;
            this.gridColumn29.Width = 31;
            // 
            // VEN
            // 
            this.VEN.Caption = "VEN";
            this.VEN.FieldName = "VEN";
            this.VEN.Name = "VEN";
            this.VEN.OptionsColumn.AllowEdit = false;
            this.VEN.OptionsColumn.AllowIncrementalSearch = false;
            this.VEN.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.VEN.OptionsColumn.AllowMove = false;
            this.VEN.OptionsFilter.AllowFilter = false;
            this.VEN.Visible = true;
            this.VEN.VisibleIndex = 2;
            this.VEN.Width = 45;
            // 
            // IsInHospitalList
            // 
            this.IsInHospitalList.Caption = " Used @ Facility";
            this.IsInHospitalList.ColumnEdit = this.repositoryItemCheckEdit1;
            this.IsInHospitalList.FieldName = "IsInHospitalList";
            this.IsInHospitalList.Name = "IsInHospitalList";
            this.IsInHospitalList.Visible = true;
            this.IsInHospitalList.VisibleIndex = 3;
            this.IsInHospitalList.Width = 89;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn66
            // 
            this.gridColumn66.Caption = "gridColumn66";
            this.gridColumn66.FieldName = "SubCategoryID";
            this.gridColumn66.Name = "gridColumn66";
            this.gridColumn66.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn66.OptionsFilter.AllowFilter = false;
            // 
            // gridColumn67
            // 
            this.gridColumn67.Caption = "gridColumn67";
            this.gridColumn67.FieldName = "CategoryId";
            this.gridColumn67.Name = "gridColumn67";
            this.gridColumn67.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn67.OptionsFilter.AllowFilter = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "TypeID";
            this.gridColumn2.FieldName = "TypeID";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // lkCategories
            // 
            this.lkCategories.Location = new System.Drawing.Point(122, 24);
            this.lkCategories.Name = "lkCategories";
            this.lkCategories.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkCategories.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.lkCategories.Properties.DisplayMember = "Name";
            this.lkCategories.Properties.NullText = "";
            this.lkCategories.Properties.ValueMember = "ID";
            this.lkCategories.Size = new System.Drawing.Size(142, 20);
            this.lkCategories.StyleController = this.layoutControl1;
            this.lkCategories.TabIndex = 39;
            this.lkCategories.EditValueChanged += new System.EventHandler(this.lkCategories_EditValueChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolBtnEdit,
            this.toolStripSeparator3,
            this.toolStripButton2,
            this.toolStripSeparator5,
            this.toolStripButton4,
            this.toolStripSeparator2,
            this.toolStripButton5,
            this.toolStripSeparator6,
            this.toolStripButton6});
            this.toolStrip2.Location = new System.Drawing.Point(833, 24);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(262, 44);
            this.toolStrip2.TabIndex = 30;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::PharmInventory.Properties.Resources.floppy_disk_48;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(36, 41);
            this.toolStripButton3.Text = "Save";
            this.toolStripButton3.Click += new System.EventHandler(this.toolBtnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 44);
            // 
            // toolBtnEdit
            // 
            this.toolBtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnEdit.Image")));
            this.toolBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnEdit.Name = "toolBtnEdit";
            this.toolBtnEdit.Size = new System.Drawing.Size(36, 41);
            this.toolBtnEdit.Text = "Edit ";
            this.toolBtnEdit.Click += new System.EventHandler(this.toolBtnEdit_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 44);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 41);
            this.toolStripButton2.Text = "Refresh";
            this.toolStripButton2.Click += new System.EventHandler(this.toolBtnRefresh_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 44);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::PharmInventory.Properties.Resources.printer_48;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(36, 41);
            this.toolStripButton4.Text = "Print";
            this.toolStripButton4.ToolTipText = "Print";
            this.toolStripButton4.Click += new System.EventHandler(this.toolBtnShowPrintPreview_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 44);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::PharmInventory.Properties.Resources.Excel;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(36, 41);
            this.toolStripButton5.Text = "Export to Excel";
            this.toolStripButton5.ToolTipText = "Export to Excel";
            this.toolStripButton5.Click += new System.EventHandler(this.toolBtnExportToXls_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 44);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(36, 41);
            this.toolStripButton6.Text = "Export to PDF";
            this.toolStripButton6.ToolTipText = "Export to PDF";
            this.toolStripButton6.Click += new System.EventHandler(this.toolBtnExportToPdf_Click);
            // 
            // cboPrograms
            // 
            this.cboPrograms.Location = new System.Drawing.Point(714, 24);
            this.cboPrograms.Name = "cboPrograms";
            this.cboPrograms.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboPrograms.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.cboPrograms.Properties.DisplayMember = "Name";
            this.cboPrograms.Properties.NullText = "";
            this.cboPrograms.Properties.ValueMember = "ID";
            this.cboPrograms.Size = new System.Drawing.Size(115, 20);
            this.cboPrograms.StyleController = this.layoutControl1;
            this.cboPrograms.TabIndex = 0;
            this.cboPrograms.EditValueChanged += new System.EventHandler(this.cboPrograms_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1119, 613);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup3";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.emptySpaceItem2,
            this.layoutControlItem6,
            this.layoutControlItem4,
            this.emptySpaceItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(1099, 593);
            this.layoutControlGroup3.Text = "layoutControlGroup3";
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lkCategories;
            this.layoutControlItem5.CustomizationFormText = "Categories";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(244, 24);
            this.layoutControlItem5.Text = "Categories";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.toolStrip2;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(809, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(266, 0);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(266, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(266, 48);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridItemsChoice;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1075, 521);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(488, 0);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(104, 48);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.cboPrograms;
            this.layoutControlItem6.CustomizationFormText = "Programs";
            this.layoutControlItem6.Location = new System.Drawing.Point(592, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(217, 48);
            this.layoutControlItem6.Text = "Programs";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(94, 13);
            this.layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtItemName;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(488, 24);
            this.layoutControlItem4.Text = "Filter By Item Name";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(94, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(244, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(244, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // CustomDrugList
            // 
            this.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 613);
            this.Controls.Add(this.layoutControl1);
            this.Name = "CustomDrugList";
            this.Text = "Customize Drug List";
            this.Load += new System.EventHandler(this.ManageItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItemsChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemChoiceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkCategories.Properties)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPrograms.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cboPrograms;
        private DevExpress.XtraEditors.TextEdit txtItemName;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolBtnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private DevExpress.XtraGrid.GridControl gridItemsChoice;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemChoiceView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn VEN;
        private DevExpress.XtraGrid.Columns.GridColumn IsInHospitalList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn66;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn67;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LookUpEdit lkCategories;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}