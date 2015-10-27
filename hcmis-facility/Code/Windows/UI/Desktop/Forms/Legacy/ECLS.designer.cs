namespace PharmInventory
{
    partial class ECLS
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
            this.AMC = new System.Windows.Forms.ColumnHeader();
            this.min = new System.Windows.Forms.ColumnHeader();
            this.Item = new System.Windows.Forms.ColumnHeader();
            this.lstItem = new PrintableListView.PrintableListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.SOH = new System.Windows.Forms.ColumnHeader();
            this.MOS = new System.Windows.Forms.ColumnHeader();
            this.max = new System.Windows.Forms.ColumnHeader();
            this.issued = new System.Windows.Forms.ColumnHeader();
            this.Status = new System.Windows.Forms.ColumnHeader();
            this.reorderAmount = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboStores = new System.Windows.Forms.ComboBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.lblState = new System.Windows.Forms.Label();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.xpButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dtDate = new CalendarLib.DateTimePickerEx();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.xpButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // AMC
            // 
            this.AMC.Text = "AMC";
            this.AMC.Width = 50;
            // 
            // min
            // 
            this.min.Text = "Min";
            this.min.Width = 66;
            // 
            // Item
            // 
            this.Item.Text = "Item";
            this.Item.Width = 393;
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
            this.AMC,
            this.MOS,
            this.min,
            this.max,
            this.issued,
            this.Status,
            this.reorderAmount});
            this.lstItem.FitToPage = false;
            this.lstItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstItem.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lstItem.FullRowSelect = true;
            this.lstItem.GridLines = true;
            this.lstItem.Location = new System.Drawing.Point(6, 77);
            this.lstItem.MultiSelect = false;
            this.lstItem.Name = "lstItem";
            this.lstItem.ShowItemToolTips = true;
            this.lstItem.Size = new System.Drawing.Size(1050, 321);
            this.lstItem.TabIndex = 9;
            this.lstItem.Title = "";
            this.lstItem.UseCompatibleStateImageBehavior = false;
            this.lstItem.View = System.Windows.Forms.View.Details;
            this.lstItem.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstItem_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No.";
            this.columnHeader1.Width = 31;
            // 
            // SOH
            // 
            this.SOH.Text = "SOH";
            // 
            // MOS
            // 
            this.MOS.Text = "MOS";
            this.MOS.Width = 52;
            // 
            // max
            // 
            this.max.Text = "Max";
            this.max.Width = 63;
            // 
            // issued
            // 
            this.issued.Text = "Issued";
            this.issued.Width = 105;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 97;
            // 
            // reorderAmount
            // 
            this.reorderAmount.Text = "Reorder Amount";
            this.reorderAmount.Width = 123;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboStores);
            this.groupBox1.Controls.Add(this.cboStatus);
            this.groupBox1.Controls.Add(this.cboMonth);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 51);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtering Options ";
            // 
            // cboStores
            // 
            this.cboStores.DisplayMember = "StoreName";
            this.cboStores.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStores.FormattingEnabled = true;
            this.cboStores.Location = new System.Drawing.Point(295, 20);
            this.cboStores.Name = "cboStores";
            this.cboStores.Size = new System.Drawing.Size(129, 21);
            this.cboStores.TabIndex = 0;
            this.cboStores.ValueMember = "ID";
            this.cboStores.SelectedValueChanged += new System.EventHandler(this.cboStores_SelectedValueChanged);
            // 
            // cboStatus
            // 
            this.cboStatus.DisplayMember = "Month";
            this.cboStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "All",
            "Stock Out",
            "Near EOP",
            "Normal",
            "Excess Stock"});
            this.cboStatus.Location = new System.Drawing.Point(171, 20);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(118, 21);
            this.cboStatus.TabIndex = 0;
            this.cboStatus.Text = "Select Status";
            this.cboStatus.ValueMember = "Value";
            this.cboStatus.SelectedValueChanged += new System.EventHandler(this.cboStatus_SelectedValueChanged);
            // 
            // cboMonth
            // 
            this.cboMonth.DisplayMember = "Month";
            this.cboMonth.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(5, 20);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(141, 21);
            this.cboMonth.TabIndex = 0;
            this.cboMonth.ValueMember = "Value";
            this.cboMonth.SelectedValueChanged += new System.EventHandler(this.cboMonth_SelectedValueChanged);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(559, 48);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(160, 18);
            this.lblState.TabIndex = 11;
            this.lblState.Text = "Contraceptive Items";
            // 
            // xpButton2
            // 
            this.xpButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            
            this.xpButton2.Image = global::PharmInventory.Properties.Resources.MS_Excel;
            this.xpButton2.Location = new System.Drawing.Point(888, 30);
            this.xpButton2.Name = "xpButton2";
            this.xpButton2.Size = new System.Drawing.Size(75, 23);
            this.xpButton2.TabIndex = 13;
            this.xpButton2.Text = "Export";
            
            this.xpButton2.Click += new System.EventHandler(this.xpButton1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(200, 200);
            this.progressBar1.Minimum = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(300, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 23;
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
            this.dtDate.Location = new System.Drawing.Point(526, 6);
            this.dtDate.Name = "dtDate";
            this.dtDate.PopUpFontSize = 9.75F;
            this.dtDate.Size = new System.Drawing.Size(114, 20);
            this.dtDate.TabIndex = 24;
            this.dtDate.Value = new System.DateTime(2008, 10, 3, 0, 0, 0, 0);
            this.dtDate.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1088, 432);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(253)))));
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.xpButton1);
            this.tabPage1.Controls.Add(this.xpButton2);
            this.tabPage1.Controls.Add(this.lblState);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.dtDate);
            this.tabPage1.Controls.Add(this.lstItem);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1080, 406);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CS Stock Status";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Location = new System.Drawing.Point(725, -3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 79);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Legend  ";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(51, 62);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(63, 13);
            this.label28.TabIndex = 0;
            this.label28.Text = "Stock Out";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label27.Location = new System.Drawing.Point(6, 62);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(35, 13);
            this.label27.TabIndex = 0;
            this.label27.Text = "       ";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(51, 45);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(61, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "Near EOP";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(51, 28);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(82, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Excess Stock";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(153)))));
            this.label24.Location = new System.Drawing.Point(6, 45);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(35, 13);
            this.label24.TabIndex = 0;
            this.label24.Text = "       ";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(209)))), ((int)(((byte)(255)))));
            this.label22.Location = new System.Drawing.Point(6, 28);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 13);
            this.label22.TabIndex = 0;
            this.label22.Text = "       ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(51, 11);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Normal";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(6, 11);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "       ";
            // 
            // xpButton1
            // 
            this.xpButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            
            this.xpButton1.Image = global::PharmInventory.Properties.Resources.printer;
            this.xpButton1.Location = new System.Drawing.Point(981, 30);
            this.xpButton1.Name = "xpButton1";
            this.xpButton1.Size = new System.Drawing.Size(75, 23);
            this.xpButton1.TabIndex = 27;
            this.xpButton1.Text = "Print";
            
            this.xpButton1.Click += new System.EventHandler(this.xpButton1_Click_1);
            // 
            // ECLS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1088, 432);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ECLS";
            this.Text = "Stock Report";
            this.Load += new System.EventHandler(this.ManageItems_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader AMC;
        private System.Windows.Forms.ColumnHeader min;
        private System.Windows.Forms.ColumnHeader Item;
        private PrintableListView.PrintableListView lstItem;
        private System.Windows.Forms.ColumnHeader SOH;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ColumnHeader max;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader MOS;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.ColumnHeader issued;
        private System.Windows.Forms.ColumnHeader reorderAmount;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.ComboBox cboStores;
        private System.Drawing.Printing.PrintDocument printDoc;
        private DevExpress.XtraEditors.SimpleButton xpButton2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private CalendarLib.DateTimePickerEx dtDate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DevExpress.XtraEditors.SimpleButton xpButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
    }
}