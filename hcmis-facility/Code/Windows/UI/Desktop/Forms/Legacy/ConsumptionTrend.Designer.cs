namespace PharmInventory
{
    partial class ConsumptionTrend
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
            this.ProductTree = new System.Windows.Forms.TreeView();
            this.Sep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nov = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Item = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstItem = new PrintableListView.PrintableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SOH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Jly = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Aug = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Oct = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Jan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Feb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Apr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.may = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Jun = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblState = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboIssuedTo = new System.Windows.Forms.ComboBox();
            this.cboSubProgram = new System.Windows.Forms.ComboBox();
            this.ckExcNeverIssued = new DevExpress.XtraEditors.CheckEdit();
            this.txtItemName = new DevExpress.XtraEditors.TextEdit();
            this.ckExclude = new DevExpress.XtraEditors.CheckEdit();
            this.xpButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.xpButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dtDate = new CalendarLib.DateTimePickerEx();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboStores = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lkCommodityTypes = new DevExpress.XtraEditors.LookUpEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckExcNeverIssued.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckExclude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkCommodityTypes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductTree
            // 
            this.ProductTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ProductTree.BackColor = System.Drawing.Color.PowderBlue;
            this.ProductTree.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductTree.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.ProductTree.Location = new System.Drawing.Point(2, 29);
            this.ProductTree.Name = "ProductTree";
            this.ProductTree.ShowNodeToolTips = true;
            this.ProductTree.Size = new System.Drawing.Size(269, 377);
            this.ProductTree.TabIndex = 7;
            this.ProductTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ProductTree_NodeMouseDoubleClick);
            // 
            // Sep
            // 
            this.Sep.Text = "Mesk";
            this.Sep.Width = 50;
            // 
            // Nov
            // 
            this.Nov.Text = "Hed";
            this.Nov.Width = 50;
            // 
            // Item
            // 
            this.Item.Text = "Item";
            this.Item.Width = 93;
            // 
            // lstItem
            // 
            this.lstItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItem.BackColor = System.Drawing.Color.White;
            this.lstItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.Item,
            this.SOH,
            this.Jly,
            this.Aug,
            this.Sep,
            this.Oct,
            this.Nov,
            this.Dec,
            this.Jan,
            this.Feb,
            this.Mar,
            this.Apr,
            this.may,
            this.Jun});
            this.lstItem.FitToPage = false;
            this.lstItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstItem.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lstItem.FullRowSelect = true;
            this.lstItem.GridLines = true;
            this.lstItem.Location = new System.Drawing.Point(279, 113);
            this.lstItem.Name = "lstItem";
            this.lstItem.ShowItemToolTips = true;
            this.lstItem.Size = new System.Drawing.Size(792, 293);
            this.lstItem.TabIndex = 9;
            this.lstItem.Title = "";
            this.lstItem.UseCompatibleStateImageBehavior = false;
            this.lstItem.View = System.Windows.Forms.View.Details;
            this.lstItem.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstItem_ColumnClick);
            this.lstItem.SelectedIndexChanged += new System.EventHandler(this.lstItem_SelectedIndexChanged);
            this.lstItem.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstItem_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No.";
            this.columnHeader1.Width = 37;
            // 
            // SOH
            // 
            this.SOH.Text = "SOH";
            this.SOH.Width = 59;
            // 
            // Jly
            // 
            this.Jly.Text = "Ham";
            this.Jly.Width = 50;
            // 
            // Aug
            // 
            this.Aug.Text = "Neh";
            this.Aug.Width = 50;
            // 
            // Oct
            // 
            this.Oct.Text = "Tek";
            this.Oct.Width = 50;
            // 
            // Dec
            // 
            this.Dec.Text = "Tah";
            this.Dec.Width = 50;
            // 
            // Jan
            // 
            this.Jan.Text = "Tir";
            this.Jan.Width = 50;
            // 
            // Feb
            // 
            this.Feb.Text = "Yek";
            this.Feb.Width = 50;
            // 
            // Mar
            // 
            this.Mar.Text = "Meg";
            this.Mar.Width = 50;
            // 
            // Apr
            // 
            this.Apr.Text = "Miz";
            this.Apr.Width = 50;
            // 
            // may
            // 
            this.may.Text = "Gen";
            this.may.Width = 50;
            // 
            // Jun
            // 
            this.Jun.Text = "Sen";
            this.Jun.Width = 50;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(447, 9);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(58, 13);
            this.lblState.TabIndex = 11;
            this.lblState.Text = "All Items";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(44, 7);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(132, 13);
            this.lblCategory.TabIndex = 12;
            this.lblCategory.Text = "Products By Category";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lkCommodityTypes);
            this.groupBox1.Controls.Add(this.cboIssuedTo);
            this.groupBox1.Controls.Add(this.cboSubProgram);
            this.groupBox1.Controls.Add(this.ckExcNeverIssued);
            this.groupBox1.Controls.Add(this.txtItemName);
            this.groupBox1.Controls.Add(this.ckExclude);
            this.groupBox1.Controls.Add(this.xpButton2);
            this.groupBox1.Controls.Add(this.xpButton1);
            this.groupBox1.Controls.Add(this.dtDate);
            this.groupBox1.Controls.Add(this.cboYear);
            this.groupBox1.Controls.Add(this.cboStores);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(279, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 85);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtering";
            // 
            // cboIssuedTo
            // 
            this.cboIssuedTo.DisplayMember = "Name";
            this.cboIssuedTo.FormattingEnabled = true;
            this.cboIssuedTo.Location = new System.Drawing.Point(415, 60);
            this.cboIssuedTo.Name = "cboIssuedTo";
            this.cboIssuedTo.Size = new System.Drawing.Size(157, 21);
            this.cboIssuedTo.TabIndex = 42;
            this.cboIssuedTo.Text = "Select Issue Location";
            this.cboIssuedTo.ValueMember = "ID";
            this.cboIssuedTo.SelectedValueChanged += new System.EventHandler(this.cboIssuedTo_SelectedValueChanged);
            // 
            // cboSubProgram
            // 
            this.cboSubProgram.DisplayMember = "Name";
            this.cboSubProgram.FormattingEnabled = true;
            this.cboSubProgram.Location = new System.Drawing.Point(415, 37);
            this.cboSubProgram.Name = "cboSubProgram";
            this.cboSubProgram.Size = new System.Drawing.Size(157, 21);
            this.cboSubProgram.TabIndex = 41;
            this.cboSubProgram.Text = "Select Program";
            this.cboSubProgram.ValueMember = "ID";
            this.cboSubProgram.SelectedIndexChanged += new System.EventHandler(this.cboSubProgram_SelectedIndexChanged);
            this.cboSubProgram.SelectedValueChanged += new System.EventHandler(this.cboSubProgram_SelectedValueChanged);
            // 
            // ckExcNeverIssued
            // 
            this.ckExcNeverIssued.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckExcNeverIssued.EditValue = true;
            this.ckExcNeverIssued.Location = new System.Drawing.Point(234, 62);
            this.ckExcNeverIssued.Name = "ckExcNeverIssued";
            this.ckExcNeverIssued.Properties.Caption = "Exclude Never Issued Items";
            this.ckExcNeverIssued.Size = new System.Drawing.Size(187, 19);
            this.ckExcNeverIssued.TabIndex = 40;
            this.ckExcNeverIssued.CheckedChanged += new System.EventHandler(this.ckExcNeverIssued_CheckedChanged);
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(415, 14);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(157, 20);
            this.txtItemName.TabIndex = 39;
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // ckExclude
            // 
            this.ckExclude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckExclude.EditValue = true;
            this.ckExclude.Location = new System.Drawing.Point(23, 62);
            this.ckExclude.Name = "ckExclude";
            this.ckExclude.Properties.Caption = "Exclude Never Received Items";
            this.ckExclude.Size = new System.Drawing.Size(201, 19);
            this.ckExclude.TabIndex = 32;
            this.ckExclude.CheckedChanged += new System.EventHandler(this.ckExclude_CheckedChanged);
            // 
            // xpButton2
            // 
            this.xpButton2.Image = global::PharmInventory.Properties.Resources.MS_Excel;
            this.xpButton2.Location = new System.Drawing.Point(711, 14);
            this.xpButton2.Name = "xpButton2";
            this.xpButton2.Size = new System.Drawing.Size(75, 23);
            this.xpButton2.TabIndex = 15;
            this.xpButton2.Text = "Export";
            this.xpButton2.Click += new System.EventHandler(this.xpButton2_Click);
            // 
            // xpButton1
            // 
            this.xpButton1.Image = global::PharmInventory.Properties.Resources.printer;
            this.xpButton1.Location = new System.Drawing.Point(711, 43);
            this.xpButton1.Name = "xpButton1";
            this.xpButton1.Size = new System.Drawing.Size(75, 23);
            this.xpButton1.TabIndex = 14;
            this.xpButton1.Text = "Print";
            this.xpButton1.Click += new System.EventHandler(this.xpButton1_Click);
            // 
            // dtDate
            // 
            this.dtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDate.CalendarFont = new System.Drawing.Font("Nyala", 10.75F);
            this.dtDate.CustomFormat = "MM/dd/ yy";
            this.dtDate.DayOfWeekCharacters = 2;
            this.dtDate.Location = new System.Drawing.Point(591, 22);
            this.dtDate.Name = "dtDate";
            this.dtDate.PopUpFontSize = 9.75F;
            this.dtDate.Size = new System.Drawing.Size(114, 20);
            this.dtDate.TabIndex = 13;
            this.dtDate.Value = new System.DateTime(2008, 10, 29, 0, 0, 0, 0);
            this.dtDate.Visible = false;
            // 
            // cboYear
            // 
            this.cboYear.DisplayMember = "StoreName";
            this.cboYear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(185, 21);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(81, 21);
            this.cboYear.TabIndex = 0;
            this.cboYear.ValueMember = "ID";
            this.cboYear.SelectedValueChanged += new System.EventHandler(this.cboStores_SelectedValueChanged);
            // 
            // cboStores
            // 
            this.cboStores.DisplayMember = "StoreName";
            this.cboStores.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStores.FormattingEnabled = true;
            this.cboStores.Location = new System.Drawing.Point(23, 20);
            this.cboStores.Name = "cboStores";
            this.cboStores.Size = new System.Drawing.Size(156, 21);
            this.cboStores.TabIndex = 0;
            this.cboStores.ValueMember = "ID";
            this.cboStores.SelectedValueChanged += new System.EventHandler(this.cboStores_SelectedValueChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(400, 200);
            this.progressBar1.Minimum = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(300, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 26;
            this.progressBar1.UseWaitCursor = true;
            this.progressBar1.Value = 1;
            this.progressBar1.Visible = false;
            // 
            // lkCommodityTypes
            // 
            this.lkCommodityTypes.Location = new System.Drawing.Point(273, 20);
            this.lkCommodityTypes.Name = "lkCommodityTypes";
            this.lkCommodityTypes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkCommodityTypes.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.lkCommodityTypes.Properties.DisplayMember = "Name";
            this.lkCommodityTypes.Properties.NullText = "";
            this.lkCommodityTypes.Properties.ValueMember = "ID";
            this.lkCommodityTypes.Size = new System.Drawing.Size(103, 20);
            this.lkCommodityTypes.TabIndex = 51;
            // 
            // ConsumptionTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1085, 432);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.ProductTree);
            this.Controls.Add(this.lstItem);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ConsumptionTrend";
            this.Text = "Stock Report";
            this.Load += new System.EventHandler(this.ManageItems_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ckExcNeverIssued.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckExclude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkCommodityTypes.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView ProductTree;
        private System.Windows.Forms.ColumnHeader Sep;
        private System.Windows.Forms.ColumnHeader Nov;
        private System.Windows.Forms.ColumnHeader Item;
        private PrintableListView.PrintableListView lstItem;
        private System.Windows.Forms.ColumnHeader SOH;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ColumnHeader Dec;
        private System.Windows.Forms.ColumnHeader Jan;
        private System.Windows.Forms.ColumnHeader Oct;
        private System.Windows.Forms.ColumnHeader Feb;
        private System.Windows.Forms.ColumnHeader Mar;
        private System.Windows.Forms.ColumnHeader Apr;
        private System.Windows.Forms.ColumnHeader Jun;
        private System.Windows.Forms.ColumnHeader Jly;
        private System.Windows.Forms.ColumnHeader Aug;
        private System.Windows.Forms.ColumnHeader may;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboStores;
        private System.Windows.Forms.ProgressBar progressBar1;
        private CalendarLib.DateTimePickerEx dtDate;
        private System.Windows.Forms.ComboBox cboYear;
        private DevExpress.XtraEditors.SimpleButton xpButton2;
        private DevExpress.XtraEditors.SimpleButton xpButton1;
        private DevExpress.XtraEditors.CheckEdit ckExclude;
        private DevExpress.XtraEditors.TextEdit txtItemName;
        private DevExpress.XtraEditors.CheckEdit ckExcNeverIssued;
        private System.Windows.Forms.ComboBox cboSubProgram;
        private System.Windows.Forms.ComboBox cboIssuedTo;
        private DevExpress.XtraEditors.LookUpEdit lkCommodityTypes;
    }
}