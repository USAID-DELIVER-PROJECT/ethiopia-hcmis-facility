namespace PharmInventory
{
    partial class ReceiveTrend
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
            this.Sep = new System.Windows.Forms.ColumnHeader();
            this.Nov = new System.Windows.Forms.ColumnHeader();
            this.Item = new System.Windows.Forms.ColumnHeader();
            this.lstItem = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.SOH = new System.Windows.Forms.ColumnHeader();
            this.Jly = new System.Windows.Forms.ColumnHeader();
            this.Aug = new System.Windows.Forms.ColumnHeader();
            this.Oct = new System.Windows.Forms.ColumnHeader();
            this.Dec = new System.Windows.Forms.ColumnHeader();
            this.Jan = new System.Windows.Forms.ColumnHeader();
            this.Feb = new System.Windows.Forms.ColumnHeader();
            this.Mar = new System.Windows.Forms.ColumnHeader();
            this.Apr = new System.Windows.Forms.ColumnHeader();
            this.may = new System.Windows.Forms.ColumnHeader();
            this.Jun = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboStores = new System.Windows.Forms.ComboBox();
            this.lblState = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dtDate = new CalendarLib.DateTimePickerEx();
            this.groupBox1.SuspendLayout();
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
            this.Item.Width = 99;
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
            this.lstItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstItem.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lstItem.FullRowSelect = true;
            this.lstItem.GridLines = true;
            this.lstItem.Location = new System.Drawing.Point(279, 81);
            this.lstItem.Name = "lstItem";
            this.lstItem.ShowItemToolTips = true;
            this.lstItem.Size = new System.Drawing.Size(933, 340);
            this.lstItem.TabIndex = 9;
            this.lstItem.UseCompatibleStateImageBehavior = false;
            this.lstItem.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No.";
            this.columnHeader1.Width = 37;
            // 
            // SOH
            // 
            this.SOH.Text = "SOH";
            this.SOH.Width = 57;
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
            this.Oct.Text = "Tik";
            this.Oct.Width = 50;
            // 
            // Dec
            // 
            this.Dec.Text = "Tahs";
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
            this.may.Text = "Genb";
            this.may.Width = 50;
            // 
            // Jun
            // 
            this.Jun.Text = "Sene";
            this.Jun.Width = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtDate);
            this.groupBox1.Controls.Add(this.cboStores);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(279, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(926, 51);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtring Options";
            // 
            // cboStores
            // 
            this.cboStores.DisplayMember = "StoreName";
            this.cboStores.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStores.FormattingEnabled = true;
            this.cboStores.Location = new System.Drawing.Point(23, 20);
            this.cboStores.Name = "cboStores";
            this.cboStores.Size = new System.Drawing.Size(221, 21);
            this.cboStores.TabIndex = 0;
            this.cboStores.ValueMember = "ID";
            this.cboStores.SelectedValueChanged += new System.EventHandler(this.cboStores_SelectedValueChanged);
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
            this.progressBar1.TabIndex = 16;
            this.progressBar1.UseWaitCursor = true;
            this.progressBar1.Value = 1;
            this.progressBar1.Visible = false;
            // 
            // dtDate
            // 
            this.dtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDate.CalendarFont = new System.Drawing.Font("Nyala", 10.75F);
            this.dtDate.CustomFormat = "dd/MM/ yy";
            this.dtDate.DayOfWeekCharacters = 2;
            this.dtDate.Location = new System.Drawing.Point(293, 20);
            this.dtDate.Name = "dtDate";
            this.dtDate.PopUpFontSize = 9.75F;
            this.dtDate.Size = new System.Drawing.Size(114, 20);
            this.dtDate.TabIndex = 14;
            this.dtDate.Value = new System.DateTime(2008, 10, 3, 0, 0, 0, 0);
            this.dtDate.Visible = false;
            // 
            // ReceiveTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1226, 432);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ProductTree);
            this.Controls.Add(this.lstItem);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ReceiveTrend";
            this.Text = "Stock Report";
            this.Load += new System.EventHandler(this.ManageItems_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView ProductTree;
        private System.Windows.Forms.ColumnHeader Sep;
        private System.Windows.Forms.ColumnHeader Nov;
        private System.Windows.Forms.ColumnHeader Item;
        private System.Windows.Forms.ListView lstItem;
        private System.Windows.Forms.ColumnHeader SOH;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboStores;
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
        private System.Windows.Forms.ProgressBar progressBar1;
        private CalendarLib.DateTimePickerEx dtDate;
    }
}