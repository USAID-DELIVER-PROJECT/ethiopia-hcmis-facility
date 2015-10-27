namespace PharmInventory.Forms.Reports
{
    partial class ItemReport
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition5 = new DevExpress.XtraGrid.StyleFormatCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemReport));
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lkCommodityTypes = new DevExpress.XtraEditors.LookUpEdit();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.legend1 = new PharmInventory.UserControls.Legend();
            this.cboIssuedTo = new DevExpress.XtraEditors.LookUpEdit();
            this.cboSubProgram = new DevExpress.XtraEditors.LookUpEdit();
            this.cboStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.cboStores = new DevExpress.XtraEditors.LookUpEdit();
            this.gridItemsChoice = new DevExpress.XtraGrid.GridControl();
            this.gridItemChoiceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn67 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn66 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.unitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.cboYear = new DevExpress.XtraEditors.LookUpEdit();
            this.treeCategory = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cboMonth = new DevExpress.XtraEditors.LookUpEdit();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.ckExcNeverIssued = new System.Windows.Forms.CheckBox();
            this.ckExclude = new System.Windows.Forms.CheckBox();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.simpleSeparator2 = new DevExpress.XtraLayout.SimpleSeparator();
            this.simpleSeparator3 = new DevExpress.XtraLayout.SimpleSeparator();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dtDate = new CalendarLib.DateTimePickerEx();
            this.label20 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.pcl = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkCommodityTypes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboIssuedTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSubProgram.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemsChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemChoiceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcl.ImageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.OptionsFilter.AllowFilter = false;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 9;
            this.colStatus.Width = 115;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "SOH";
            this.gridColumn29.DisplayFormat.FormatString = "#,##0";
            this.gridColumn29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn29.FieldName = "SOH";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.AllowEdit = false;
            this.gridColumn29.OptionsFilter.AllowFilter = false;
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 2;
            this.gridColumn29.Width = 45;
            // 
            // radioGroup1
            // 
            this.radioGroup1.EditValue = "Drug";
            this.radioGroup1.Location = new System.Drawing.Point(12, 12);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Drug", "Drug"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Supplies", "Supplies")});
            this.radioGroup1.Size = new System.Drawing.Size(251, 41);
            this.radioGroup1.StyleController = this.layoutControl1;
            this.radioGroup1.TabIndex = 39;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lkCommodityTypes);
            this.layoutControl1.Controls.Add(this.btnPrint);
            this.layoutControl1.Controls.Add(this.btnExport);
            this.layoutControl1.Controls.Add(this.legend1);
            this.layoutControl1.Controls.Add(this.cboIssuedTo);
            this.layoutControl1.Controls.Add(this.radioGroup1);
            this.layoutControl1.Controls.Add(this.cboSubProgram);
            this.layoutControl1.Controls.Add(this.cboStatus);
            this.layoutControl1.Controls.Add(this.cboStores);
            this.layoutControl1.Controls.Add(this.gridItemsChoice);
            this.layoutControl1.Controls.Add(this.cboYear);
            this.layoutControl1.Controls.Add(this.treeCategory);
            this.layoutControl1.Controls.Add(this.cboMonth);
            this.layoutControl1.Controls.Add(this.txtItemName);
            this.layoutControl1.Controls.Add(this.ckExcNeverIssued);
            this.layoutControl1.Controls.Add(this.ckExclude);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem12});
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1088, 662);
            this.layoutControl1.TabIndex = 34;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lkCommodityTypes
            // 
            this.lkCommodityTypes.Location = new System.Drawing.Point(736, 12);
            this.lkCommodityTypes.Name = "lkCommodityTypes";
            this.lkCommodityTypes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkCommodityTypes.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.lkCommodityTypes.Properties.DisplayMember = "Name";
            this.lkCommodityTypes.Properties.NullText = "All";
            this.lkCommodityTypes.Properties.ValueMember = "ID";
            this.lkCommodityTypes.Size = new System.Drawing.Size(155, 20);
            this.lkCommodityTypes.StyleController = this.layoutControl1;
            this.lkCommodityTypes.TabIndex = 35;
            this.lkCommodityTypes.EditValueChanged += new System.EventHandler(this.lkCategories_EditValueChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(800, 84);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(91, 22);
            this.btnPrint.StyleController = this.layoutControl1;
            this.btnPrint.TabIndex = 42;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(688, 84);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(108, 22);
            this.btnExport.StyleController = this.layoutControl1;
            this.btnExport.TabIndex = 41;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // legend1
            // 
            this.legend1.Location = new System.Drawing.Point(897, 12);
            this.legend1.Name = "legend1";
            this.legend1.Padding = new System.Windows.Forms.Padding(2);
            this.legend1.Size = new System.Drawing.Size(179, 94);
            this.legend1.TabIndex = 40;
            // 
            // cboIssuedTo
            // 
            this.cboIssuedTo.Location = new System.Drawing.Point(649, 60);
            this.cboIssuedTo.Name = "cboIssuedTo";
            this.cboIssuedTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboIssuedTo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.cboIssuedTo.Properties.DisplayMember = "Name";
            this.cboIssuedTo.Properties.NullText = "";
            this.cboIssuedTo.Properties.ValueMember = "ID";
            this.cboIssuedTo.Size = new System.Drawing.Size(140, 20);
            this.cboIssuedTo.StyleController = this.layoutControl1;
            this.cboIssuedTo.TabIndex = 27;
            this.cboIssuedTo.EditValueChanged += new System.EventHandler(this.cboIssuedTo_SelectedValueChanged);
            // 
            // cboSubProgram
            // 
            this.cboSubProgram.Location = new System.Drawing.Point(736, 60);
            this.cboSubProgram.Name = "cboSubProgram";
            this.cboSubProgram.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSubProgram.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.cboSubProgram.Properties.DisplayMember = "Name";
            this.cboSubProgram.Properties.NullText = "";
            this.cboSubProgram.Properties.ValueMember = "ID";
            this.cboSubProgram.Size = new System.Drawing.Size(155, 20);
            this.cboSubProgram.StyleController = this.layoutControl1;
            this.cboSubProgram.TabIndex = 31;
            this.cboSubProgram.EditValueChanged += new System.EventHandler(this.cboSubProgram_SelectedValueChanged);
            // 
            // cboStatus
            // 
            this.cboStatus.Location = new System.Drawing.Point(736, 36);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.Properties.Appearance.Options.UseFont = true;
            this.cboStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Column", "Status")});
            this.cboStatus.Properties.DisplayMember = "Column";
            this.cboStatus.Properties.NullText = "";
            this.cboStatus.Properties.ValueMember = "Column";
            this.cboStatus.Size = new System.Drawing.Size(155, 20);
            this.cboStatus.StyleController = this.layoutControl1;
            this.cboStatus.TabIndex = 0;
            this.cboStatus.EditValueChanged += new System.EventHandler(this.cboStatus_SelectedValueChanged);
            // 
            // cboStores
            // 
            this.cboStores.Location = new System.Drawing.Point(369, 60);
            this.cboStores.Name = "cboStores";
            this.cboStores.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStores.Properties.Appearance.Options.UseFont = true;
            this.cboStores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboStores.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreName", "Name")});
            this.cboStores.Properties.DisplayMember = "StoreName";
            this.cboStores.Properties.NullText = "";
            this.cboStores.Properties.ValueMember = "ID";
            this.cboStores.Size = new System.Drawing.Size(170, 20);
            this.cboStores.StyleController = this.layoutControl1;
            this.cboStores.TabIndex = 0;
            this.cboStores.EditValueChanged += new System.EventHandler(this.cboStores_SelectedValueChanged);
            // 
            // gridItemsChoice
            // 
            this.gridItemsChoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridItemsChoice.Location = new System.Drawing.Point(40, 110);
            this.gridItemsChoice.MainView = this.gridItemChoiceView;
            this.gridItemsChoice.Name = "gridItemsChoice";
            this.gridItemsChoice.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemLookUpEdit1});
            this.gridItemsChoice.Size = new System.Drawing.Size(1036, 540);
            this.gridItemsChoice.TabIndex = 32;
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
            this.colItemName,
            this.gridColumn29,
            this.VEN,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.colStatus,
            this.gridColumn7,
            this.gridColumn67,
            this.gridColumn66,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.gridItemChoiceView.FixedLineWidth = 1;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colStatus;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "Stock Out";
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(209)))), ((int)(((byte)(255)))));
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.colStatus;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = "Over Stocked";
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(153)))));
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Column = this.colStatus;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition3.Value1 = "Near EOP";
            styleFormatCondition4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            styleFormatCondition4.Appearance.Options.UseBackColor = true;
            styleFormatCondition4.ApplyToRow = true;
            styleFormatCondition4.Column = this.colStatus;
            styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition4.Value1 = "Below EOP";
            styleFormatCondition5.Appearance.BackColor = System.Drawing.Color.White;
            styleFormatCondition5.Appearance.Options.UseBackColor = true;
            styleFormatCondition5.ApplyToRow = true;
            styleFormatCondition5.Column = this.colStatus;
            styleFormatCondition5.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition5.Value1 = "Normal";
            this.gridItemChoiceView.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3,
            styleFormatCondition4,
            styleFormatCondition5});
            this.gridItemChoiceView.GridControl = this.gridItemsChoice;
            this.gridItemChoiceView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Count", this.gridColumn1, "")});
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
            this.gridItemChoiceView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridItemChoiceView.OptionsView.ShowGroupPanel = false;
            this.gridItemChoiceView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
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
            this.colItemName.Width = 283;
            // 
            // VEN
            // 
            this.VEN.Caption = "AMC";
            this.VEN.DisplayFormat.FormatString = "##0.#0";
            this.VEN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.VEN.FieldName = "AMC";
            this.VEN.Name = "VEN";
            this.VEN.OptionsColumn.AllowEdit = false;
            this.VEN.OptionsColumn.AllowIncrementalSearch = false;
            this.VEN.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.VEN.OptionsColumn.AllowMove = false;
            this.VEN.OptionsFilter.AllowFilter = false;
            this.VEN.Visible = true;
            this.VEN.VisibleIndex = 3;
            this.VEN.Width = 47;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "MOS";
            this.gridColumn2.DisplayFormat.FormatString = "#,##0.#0";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "MOS";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsFilter.AllowFilter = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 47;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Min";
            this.gridColumn3.DisplayFormat.FormatString = "#,##0";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "Min";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsFilter.AllowFilter = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 39;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Max";
            this.gridColumn4.DisplayFormat.FormatString = "#,##0";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "Max";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsFilter.AllowFilter = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 44;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Issued";
            this.gridColumn5.DisplayFormat.FormatString = "#,##0";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "IssuedMonth";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsFilter.AllowFilter = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 62;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "U. Stock";
            this.gridColumn6.DisplayFormat.FormatString = "#,##0";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "Dispatchable";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsFilter.AllowFilter = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Reorder Amount";
            this.gridColumn7.FieldName = "ReorderAmount";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsFilter.AllowFilter = false;
            this.gridColumn7.Width = 81;
            // 
            // gridColumn67
            // 
            this.gridColumn67.Caption = "gridColumn67";
            this.gridColumn67.FieldName = "CategoryId";
            this.gridColumn67.Name = "gridColumn67";
            this.gridColumn67.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn67.OptionsFilter.AllowFilter = false;
            this.gridColumn67.Width = 77;
            // 
            // gridColumn66
            // 
            this.gridColumn66.Caption = "gridColumn66";
            this.gridColumn66.FieldName = "SubCategoryID";
            this.gridColumn66.Name = "gridColumn66";
            this.gridColumn66.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn66.OptionsFilter.AllowFilter = false;
            this.gridColumn66.Width = 77;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Received";
            this.gridColumn8.FieldName = "Received";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "gridColumn9";
            this.gridColumn9.FieldName = "ID";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Issued";
            this.gridColumn10.FieldName = "Issued";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "TypeID";
            this.gridColumn11.FieldName = "TypeID";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Unit";
            this.gridColumn12.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.gridColumn12.FieldName = "UnitID";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.FixedWidth = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Text", 32, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit1.DataSource = this.unitBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "Text";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ValueMember = "ID";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // cboYear
            // 
            this.cboYear.Location = new System.Drawing.Point(369, 12);
            this.cboYear.Name = "cboYear";
            this.cboYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboYear.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("year", "year")});
            this.cboYear.Properties.DisplayMember = "year";
            this.cboYear.Properties.NullText = "";
            this.cboYear.Properties.ValueMember = "year";
            this.cboYear.Size = new System.Drawing.Size(170, 20);
            this.cboYear.StyleController = this.layoutControl1;
            this.cboYear.TabIndex = 25;
            this.cboYear.EditValueChanged += new System.EventHandler(this.cboYear_SelectedValueChanged);
            // 
            // treeCategory
            // 
            this.treeCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeCategory.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.treeCategory.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.treeCategory.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeCategory.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeCategory.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.treeCategory.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeCategory.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeCategory.Location = new System.Drawing.Point(12, 57);
            this.treeCategory.Name = "treeCategory";
            this.treeCategory.OptionsView.ShowIndicator = false;
            this.treeCategory.ParentFieldName = "Parent";
            this.treeCategory.Size = new System.Drawing.Size(251, 569);
            this.treeCategory.TabIndex = 33;
            this.treeCategory.Click += new System.EventHandler(this.treeCategory_Click);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AllNodesSummary = true;
            this.treeListColumn1.Caption = "Category";
            this.treeListColumn1.FieldName = "Name";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowSort = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // cboMonth
            // 
            this.cboMonth.Location = new System.Drawing.Point(369, 36);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonth.Properties.Appearance.Options.UseFont = true;
            this.cboMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMonth.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Month", "Month")});
            this.cboMonth.Properties.DisplayMember = "Month";
            this.cboMonth.Properties.NullText = "";
            this.cboMonth.Properties.ValueMember = "Value";
            this.cboMonth.Size = new System.Drawing.Size(170, 20);
            this.cboMonth.StyleController = this.layoutControl1;
            this.cboMonth.TabIndex = 0;
            this.cboMonth.EditValueChanged += new System.EventHandler(this.cboMonth_SelectedValueChanged);
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(88, 60);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(227, 20);
            this.txtItemName.TabIndex = 32;
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // ckExcNeverIssued
            // 
            this.ckExcNeverIssued.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckExcNeverIssued.Location = new System.Drawing.Point(40, 36);
            this.ckExcNeverIssued.Name = "ckExcNeverIssued";
            this.ckExcNeverIssued.Size = new System.Drawing.Size(275, 20);
            this.ckExcNeverIssued.TabIndex = 27;
            this.ckExcNeverIssued.Text = "Exclude Never Issued Items";
            this.ckExcNeverIssued.CheckedChanged += new System.EventHandler(this.ckExcNeverIssued_CheckedChanged_1);
            // 
            // ckExclude
            // 
            this.ckExclude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckExclude.Checked = true;
            this.ckExclude.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckExclude.Location = new System.Drawing.Point(40, 12);
            this.ckExclude.Name = "ckExclude";
            this.ckExclude.Size = new System.Drawing.Size(275, 20);
            this.ckExclude.TabIndex = 27;
            this.ckExclude.Text = "Exclude Never Received Items";
            this.ckExclude.CheckedChanged += new System.EventHandler(this.ckExclude_CheckedChanged);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.cboIssuedTo;
            this.layoutControlItem12.CustomizationFormText = "Issued To";
            this.layoutControlItem12.Location = new System.Drawing.Point(586, 48);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(195, 24);
            this.layoutControlItem12.Text = "Issued To";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(47, 13);
            this.layoutControlItem12.TextToControlDistance = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlGroup2,
            this.layoutControlItem13,
            this.simpleSeparator1,
            this.simpleSeparator2,
            this.simpleSeparator3,
            this.layoutControlItem14,
            this.layoutControlItem15,
            this.layoutControlItem4,
            this.layoutControlItem16,
            this.emptySpaceItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1088, 662);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.gridItemsChoice;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(28, 98);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(1040, 544);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtItemName;
            this.layoutControlItem2.CustomizationFormText = "Item";
            this.layoutControlItem2.Location = new System.Drawing.Point(28, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(279, 50);
            this.layoutControlItem2.Text = "Item";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(45, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.ckExclude;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(28, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(279, 24);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.cboYear;
            this.layoutControlItem7.CustomizationFormText = "Year";
            this.layoutControlItem7.Location = new System.Drawing.Point(309, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(222, 24);
            this.layoutControlItem7.Text = "Year";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(45, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.cboMonth;
            this.layoutControlItem8.CustomizationFormText = "Month";
            this.layoutControlItem8.Location = new System.Drawing.Point(309, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(222, 24);
            this.layoutControlItem8.Text = "Month";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(45, 13);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.cboStores;
            this.layoutControlItem9.CustomizationFormText = "Store";
            this.layoutControlItem9.Location = new System.Drawing.Point(309, 48);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(222, 50);
            this.layoutControlItem9.Text = "Store";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(45, 13);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.cboStatus;
            this.layoutControlItem10.CustomizationFormText = "Status";
            this.layoutControlItem10.Location = new System.Drawing.Point(676, 24);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(207, 24);
            this.layoutControlItem10.Text = "Status";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(45, 13);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.cboSubProgram;
            this.layoutControlItem11.CustomizationFormText = "Program";
            this.layoutControlItem11.Location = new System.Drawing.Point(676, 48);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(207, 24);
            this.layoutControlItem11.Text = "Program";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(45, 13);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Categories";
            this.layoutControlGroup2.ExpandButtonVisible = true;
            this.layoutControlGroup2.Expanded = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(28, 642);
            this.layoutControlGroup2.Text = "Categories";
            this.layoutControlGroup2.TextLocation = DevExpress.Utils.Locations.Left;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.radioGroup1;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(255, 0);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(255, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(255, 45);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.treeCategory;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 45);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(255, 573);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.legend1;
            this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
            this.layoutControlItem13.Location = new System.Drawing.Point(885, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(183, 98);
            this.layoutControlItem13.Text = "layoutControlItem13";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextToControlDistance = 0;
            this.layoutControlItem13.TextVisible = false;
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
            this.simpleSeparator1.Location = new System.Drawing.Point(307, 0);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(2, 98);
            this.simpleSeparator1.Text = "simpleSeparator1";
            // 
            // simpleSeparator2
            // 
            this.simpleSeparator2.AllowHotTrack = false;
            this.simpleSeparator2.CustomizationFormText = "simpleSeparator2";
            this.simpleSeparator2.Location = new System.Drawing.Point(674, 0);
            this.simpleSeparator2.Name = "simpleSeparator2";
            this.simpleSeparator2.Size = new System.Drawing.Size(2, 98);
            this.simpleSeparator2.Text = "simpleSeparator2";
            // 
            // simpleSeparator3
            // 
            this.simpleSeparator3.AllowHotTrack = false;
            this.simpleSeparator3.CustomizationFormText = "simpleSeparator3";
            this.simpleSeparator3.Location = new System.Drawing.Point(883, 0);
            this.simpleSeparator3.Name = "simpleSeparator3";
            this.simpleSeparator3.Size = new System.Drawing.Size(2, 98);
            this.simpleSeparator3.Text = "simpleSeparator3";
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.btnExport;
            this.layoutControlItem14.CustomizationFormText = "layoutControlItem14";
            this.layoutControlItem14.Location = new System.Drawing.Point(676, 72);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(112, 26);
            this.layoutControlItem14.Text = "layoutControlItem14";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextToControlDistance = 0;
            this.layoutControlItem14.TextVisible = false;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.btnPrint;
            this.layoutControlItem15.CustomizationFormText = "layoutControlItem15";
            this.layoutControlItem15.Location = new System.Drawing.Point(788, 72);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(95, 26);
            this.layoutControlItem15.Text = "layoutControlItem15";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextToControlDistance = 0;
            this.layoutControlItem15.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.ckExcNeverIssued;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(28, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(279, 24);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.lkCommodityTypes;
            this.layoutControlItem16.CustomizationFormText = "Category";
            this.layoutControlItem16.Location = new System.Drawing.Point(676, 0);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(207, 24);
            this.layoutControlItem16.Text = "Category";
            this.layoutControlItem16.TextSize = new System.Drawing.Size(45, 13);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(531, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(143, 98);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dtDate
            // 
            this.dtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dtDate.CalendarForeColor = System.Drawing.Color.Black;
            this.dtDate.CustomFormat = "dd/MM/ yy";
            this.dtDate.DayOfWeekCharacters = 2;
            this.dtDate.ForeColor = System.Drawing.Color.Black;
            this.dtDate.Location = new System.Drawing.Point(12, 414);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(114, 20);
            this.dtDate.TabIndex = 24;
            this.dtDate.Value = new System.DateTime(2008, 10, 3, 0, 0, 0, 0);
            this.dtDate.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(192, 386);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Normal";
            this.label20.Visible = false;
            // 
            // bw
            // 
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = true;
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.pcl});
            // 
            // pcl
            // 
            this.pcl.Component = this.gridItemsChoice;
            // 
            // 
            // 
            this.pcl.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("pcl.ImageCollection.ImageStream")));
            this.pcl.Landscape = true;
            this.pcl.Margins = new System.Drawing.Printing.Margins(20, 20, 100, 40);
            this.pcl.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
                "",
                "Stock Status Report",
                ""}, new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.XtraPrinting.BrickAlignment.Near), new DevExpress.XtraPrinting.PageFooterArea(new string[] {
                "[Page # of Pages #]",
                "",
                "[Date Printed]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.XtraPrinting.BrickAlignment.Near));
            this.pcl.PrintingSystem = this.printingSystem1;
            this.pcl.PrintingSystemBase = this.printingSystem1;
            // 
            // ItemReport
            // 
            this.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 662);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label20);
            this.Name = "ItemReport";
            this.Text = "Stock Report";
            this.Load += new System.EventHandler(this.ManageItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkCommodityTypes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboIssuedTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSubProgram.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemsChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemChoiceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcl.ImageCollection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cboMonth;
        private DevExpress.XtraEditors.LookUpEdit cboStatus;
        private DevExpress.XtraEditors.LookUpEdit cboStores;
        private CalendarLib.DateTimePickerEx dtDate;
        private DevExpress.XtraEditors.LookUpEdit cboYear;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox ckExclude;
        private System.Windows.Forms.CheckBox ckExcNeverIssued;
        private DevExpress.XtraEditors.LookUpEdit cboSubProgram;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevExpress.XtraEditors.LookUpEdit cboIssuedTo;
        private DevExpress.XtraGrid.GridControl gridItemsChoice;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemChoiceView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn VEN;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn66;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn67;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraTreeList.TreeList treeCategory;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private System.ComponentModel.BackgroundWorker bw;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private UserControls.Legend legend1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator2;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator3;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink pcl;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.LookUpEdit lkCommodityTypes;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource unitBindingSource;
    }
}