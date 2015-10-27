namespace PharmInventory
{
    partial class IssuesByDep
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
            this.Item = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstItem = new PrintableListView.PrintableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckExcNeverIssued = new DevExpress.XtraEditors.CheckEdit();
            this.txtItemName = new DevExpress.XtraEditors.TextEdit();
            this.ckExclude = new DevExpress.XtraEditors.CheckEdit();
            this.xpButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.xpButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dtDate = new CalendarLib.DateTimePickerEx();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtTo = new CalendarLib.DateTimePickerEx();
            this.dtFrom = new CalendarLib.DateTimePickerEx();
            this.label4 = new System.Windows.Forms.Label();
            this.cboStores = new System.Windows.Forms.ComboBox();
            this.lblState = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lkCommodityTypes = new DevExpress.XtraEditors.LookUpEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckExcNeverIssued.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckExclude.Properties)).BeginInit();
            this.groupBox3.SuspendLayout();
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
            this.ProductTree.Size = new System.Drawing.Size(269, 393);
            this.ProductTree.TabIndex = 7;
            this.ProductTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ProductTree_NodeMouseDoubleClick);
            // 
            // Item
            // 
            this.Item.Text = "Item";
            this.Item.Width = 77;
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
            this.Item});
            this.lstItem.FitToPage = false;
            this.lstItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstItem.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lstItem.FullRowSelect = true;
            this.lstItem.GridLines = true;
            this.lstItem.Location = new System.Drawing.Point(279, 116);
            this.lstItem.Name = "lstItem";
            this.lstItem.ShowItemToolTips = true;
            this.lstItem.Size = new System.Drawing.Size(840, 305);
            this.lstItem.TabIndex = 9;
            this.lstItem.Title = "";
            this.lstItem.UseCompatibleStateImageBehavior = false;
            this.lstItem.View = System.Windows.Forms.View.Details;
            this.lstItem.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstItem_ColumnClick);
            this.lstItem.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstItem_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No.";
            this.columnHeader1.Width = 37;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lkCommodityTypes);
            this.groupBox1.Controls.Add(this.ckExcNeverIssued);
            this.groupBox1.Controls.Add(this.txtItemName);
            this.groupBox1.Controls.Add(this.ckExclude);
            this.groupBox1.Controls.Add(this.xpButton2);
            this.groupBox1.Controls.Add(this.xpButton1);
            this.groupBox1.Controls.Add(this.dtDate);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.cboStores);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(279, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(840, 91);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtering";
            // 
            // ckExcNeverIssued
            // 
            this.ckExcNeverIssued.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckExcNeverIssued.EditValue = true;
            this.ckExcNeverIssued.Location = new System.Drawing.Point(261, 61);
            this.ckExcNeverIssued.Name = "ckExcNeverIssued";
            this.ckExcNeverIssued.Properties.Caption = "Exclude Never Issued Items";
            this.ckExcNeverIssued.Size = new System.Drawing.Size(187, 19);
            this.ckExcNeverIssued.TabIndex = 44;
            this.ckExcNeverIssued.CheckedChanged += new System.EventHandler(this.ckExcNeverIssued_CheckedChanged);
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(291, 19);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(157, 20);
            this.txtItemName.TabIndex = 43;
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // ckExclude
            // 
            this.ckExclude.EditValue = true;
            this.ckExclude.Location = new System.Drawing.Point(23, 61);
            this.ckExclude.Name = "ckExclude";
            this.ckExclude.Properties.Caption = "Exclude Never Received Items";
            this.ckExclude.Size = new System.Drawing.Size(201, 19);
            this.ckExclude.TabIndex = 33;
            this.ckExclude.CheckedChanged += new System.EventHandler(this.ckExclude_CheckedChanged);
            // 
            // xpButton2
            // 
            this.xpButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xpButton2.Image = global::PharmInventory.Properties.Resources.MS_Excel;
            this.xpButton2.Location = new System.Drawing.Point(756, 32);
            this.xpButton2.Name = "xpButton2";
            this.xpButton2.Size = new System.Drawing.Size(75, 23);
            this.xpButton2.TabIndex = 26;
            this.xpButton2.Text = "Export";
            this.xpButton2.Click += new System.EventHandler(this.xpButton2_Click);
            // 
            // xpButton1
            // 
            this.xpButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xpButton1.Image = global::PharmInventory.Properties.Resources.printer;
            this.xpButton1.Location = new System.Drawing.Point(759, 62);
            this.xpButton1.Name = "xpButton1";
            this.xpButton1.Size = new System.Drawing.Size(75, 23);
            this.xpButton1.TabIndex = 25;
            this.xpButton1.Text = "Print";
            this.xpButton1.Click += new System.EventHandler(this.xpButton1_Click);
            // 
            // dtDate
            // 
            this.dtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDate.CalendarFont = new System.Drawing.Font("Nyala", 10.75F);
            this.dtDate.CustomFormat = "MM/dd/yyyy";
            this.dtDate.DayOfWeekCharacters = 2;
            this.dtDate.Location = new System.Drawing.Point(606, 0);
            this.dtDate.Name = "dtDate";
            this.dtDate.PopUpFontSize = 9.75F;
            this.dtDate.Size = new System.Drawing.Size(114, 20);
            this.dtDate.TabIndex = 15;
            this.dtDate.Value = new System.DateTime(2008, 10, 3, 0, 0, 0, 0);
            this.dtDate.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dtTo);
            this.groupBox3.Controls.Add(this.dtFrom);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(524, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 68);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Date Range";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "From";
            // 
            // dtTo
            // 
            this.dtTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtTo.CalendarFont = new System.Drawing.Font("Nyala", 10.75F);
            this.dtTo.CustomFormat = "MM/dd/ yyyy";
            this.dtTo.DayOfWeekCharacters = 2;
            this.dtTo.Location = new System.Drawing.Point(58, 42);
            this.dtTo.Name = "dtTo";
            this.dtTo.PopUpFontSize = 9.75F;
            this.dtTo.Size = new System.Drawing.Size(138, 20);
            this.dtTo.TabIndex = 12;
            this.dtTo.ValueChanged += new System.EventHandler(this.btnSearchByDate_Click);
            // 
            // dtFrom
            // 
            this.dtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFrom.CalendarFont = new System.Drawing.Font("Nyala", 10.75F);
            this.dtFrom.CustomFormat = "MM/dd/ yyyy";
            this.dtFrom.DayOfWeekCharacters = 2;
            this.dtFrom.Location = new System.Drawing.Point(58, 18);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.PopUpFontSize = 9.75F;
            this.dtFrom.Size = new System.Drawing.Size(138, 20);
            this.dtFrom.TabIndex = 12;
            this.dtFrom.ValueChanged += new System.EventHandler(this.btnSearchByDate_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "To";
            // 
            // cboStores
            // 
            this.cboStores.DisplayMember = "StoreName";
            this.cboStores.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStores.FormattingEnabled = true;
            this.cboStores.Location = new System.Drawing.Point(23, 20);
            this.cboStores.Name = "cboStores";
            this.cboStores.Size = new System.Drawing.Size(136, 21);
            this.cboStores.TabIndex = 0;
            this.cboStores.ValueMember = "ID";
            this.cboStores.SelectedIndexChanged += new System.EventHandler(this.cboStores_SelectedIndexChanged);
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
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(400, 200);
            this.progressBar1.Minimum = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(300, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 24;
            this.progressBar1.UseWaitCursor = true;
            this.progressBar1.Value = 1;
            this.progressBar1.Visible = false;
            // 
            // lkCommodityTypes
            // 
            this.lkCommodityTypes.Location = new System.Drawing.Point(165, 20);
            this.lkCommodityTypes.Name = "lkCommodityTypes";
            this.lkCommodityTypes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkCommodityTypes.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.lkCommodityTypes.Properties.DisplayMember = "Name";
            this.lkCommodityTypes.Properties.NullText = "";
            this.lkCommodityTypes.Properties.ValueMember = "ID";
            this.lkCommodityTypes.Size = new System.Drawing.Size(114, 20);
            this.lkCommodityTypes.TabIndex = 51;
            this.lkCommodityTypes.EditValueChanged += new System.EventHandler(this.cboStores_SelectedIndexChanged);
            // 
            // IssuesByDep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1122, 432);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ProductTree);
            this.Controls.Add(this.lstItem);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "IssuesByDep";
            this.Text = "Stock Report";
            this.Load += new System.EventHandler(this.ManageItems_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ckExcNeverIssued.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckExclude.Properties)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkCommodityTypes.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView ProductTree;
        private System.Windows.Forms.ColumnHeader Item;
        private PrintableListView.PrintableListView lstItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboStores;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private CalendarLib.DateTimePickerEx dtTo;
        private CalendarLib.DateTimePickerEx dtFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private CalendarLib.DateTimePickerEx dtDate;
        private DevExpress.XtraEditors.SimpleButton xpButton2;
        private DevExpress.XtraEditors.SimpleButton xpButton1;
        private DevExpress.XtraEditors.CheckEdit ckExclude;
        private DevExpress.XtraEditors.CheckEdit ckExcNeverIssued;
        private DevExpress.XtraEditors.TextEdit txtItemName;
        private DevExpress.XtraEditors.LookUpEdit lkCommodityTypes;
    }
}