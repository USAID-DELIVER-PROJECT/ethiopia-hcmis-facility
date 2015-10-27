namespace PharmInventory.Forms.Modals
{
    partial class EditIssue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditIssue));
            this.cboReceivingUnit = new System.Windows.Forms.ComboBox();
            this.cboStores = new System.Windows.Forms.ComboBox();
            this.dtIssDate = new CalendarLib.DateTimePickerEx();
            this.txtItemName = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQuantity = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemark = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.txtReceivedBy = new DevExpress.XtraEditors.TextEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.txtQtyPack = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPack = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBatchNo = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRefNo = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.xpButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtDate = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceivedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyPack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBatchNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefNo.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboReceivingUnit
            // 
            this.cboReceivingUnit.DisplayMember = "Name";
            this.cboReceivingUnit.FormattingEnabled = true;
            this.cboReceivingUnit.Location = new System.Drawing.Point(286, 145);
            this.cboReceivingUnit.Name = "cboReceivingUnit";
            this.cboReceivingUnit.Size = new System.Drawing.Size(184, 21);
            this.cboReceivingUnit.TabIndex = 41;
            this.cboReceivingUnit.ValueMember = "ID";
            // 
            // cboStores
            // 
            this.cboStores.DisplayMember = "StoreName";
            this.cboStores.FormattingEnabled = true;
            this.cboStores.Location = new System.Drawing.Point(286, 179);
            this.cboStores.Name = "cboStores";
            this.cboStores.Size = new System.Drawing.Size(184, 21);
            this.cboStores.TabIndex = 40;
            this.cboStores.ValueMember = "ID";
            // 
            // dtIssDate
            // 
            this.dtIssDate.CalendarFont = new System.Drawing.Font("Nyala", 10.75F);
            this.dtIssDate.DayOfWeekCharacters = 2;
            this.dtIssDate.Location = new System.Drawing.Point(10, 24);
            this.dtIssDate.Name = "dtIssDate";
            this.dtIssDate.PopUpFontSize = 9.75F;
            this.dtIssDate.Size = new System.Drawing.Size(184, 20);
            this.dtIssDate.TabIndex = 39;
            this.dtIssDate.TextSelect = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtIssDate.Value = new System.DateTime(2012, 10, 25, 0, 0, 0, 0);
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(190, 19);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.txtItemName.Properties.Appearance.Options.UseBackColor = true;
            this.txtItemName.Properties.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(414, 20);
            this.txtItemName.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(96, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Item Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(167, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Store";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(167, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Issued To";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(286, 318);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.txtQuantity.Properties.Appearance.Options.UseBackColor = true;
            this.txtQuantity.Properties.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(184, 20);
            this.txtQuantity.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Quantity";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(286, 426);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(305, 20);
            this.txtRemark.TabIndex = 32;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(167, 430);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Remark";
            // 
            // txtReceivedBy
            // 
            this.txtReceivedBy.Location = new System.Drawing.Point(286, 390);
            this.txtReceivedBy.Name = "txtReceivedBy";
            this.txtReceivedBy.Size = new System.Drawing.Size(184, 20);
            this.txtReceivedBy.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(167, 394);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Issued By";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(286, 354);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.Properties.Appearance.Options.UseBackColor = true;
            this.txtPrice.Properties.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(184, 20);
            this.txtPrice.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(167, 358);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Price/Pack";
            // 
            // txtQtyPack
            // 
            this.txtQtyPack.Location = new System.Drawing.Point(286, 284);
            this.txtQtyPack.Name = "txtQtyPack";
            this.txtQtyPack.Size = new System.Drawing.Size(184, 20);
            this.txtQtyPack.TabIndex = 29;
            this.txtQtyPack.TextChanged += new System.EventHandler(this.txtQtyPack_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(167, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Qty/Pack";
            // 
            // txtPack
            // 
            this.txtPack.Location = new System.Drawing.Point(286, 250);
            this.txtPack.Name = "txtPack";
            this.txtPack.Size = new System.Drawing.Size(184, 20);
            this.txtPack.TabIndex = 28;
            this.txtPack.TextChanged += new System.EventHandler(this.txtQtyPack_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(167, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Pack ";
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Location = new System.Drawing.Point(286, 213);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.txtBatchNo.Properties.Appearance.Options.UseBackColor = true;
            this.txtBatchNo.Properties.ReadOnly = true;
            this.txtBatchNo.Size = new System.Drawing.Size(184, 20);
            this.txtBatchNo.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Batch No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Issued Date";
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(286, 78);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(184, 20);
            this.txtRefNo.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Reference No.";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = global::PharmInventory.Properties.Resources.cross;
            this.btnCancel.Location = new System.Drawing.Point(394, 529);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 22);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::PharmInventory.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(286, 529);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 22);
            this.btnSave.TabIndex = 37;
            this.btnSave.Text = "Update";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.xpButton1);
            this.groupBox1.Controls.Add(this.dtIssDate);
            this.groupBox1.Location = new System.Drawing.Point(484, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change Date";
            this.groupBox1.Visible = false;
            // 
            // xpButton1
            // 
            this.xpButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xpButton1.Image = global::PharmInventory.Properties.Resources.icon_accept;
            this.xpButton1.Location = new System.Drawing.Point(75, 59);
            this.xpButton1.Name = "xpButton1";
            this.xpButton1.Size = new System.Drawing.Size(70, 22);
            this.xpButton1.TabIndex = 7;
            this.xpButton1.Text = "Change";
            this.xpButton1.Click += new System.EventHandler(this.xpButton1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(481, 104);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(82, 13);
            this.linkLabel1.TabIndex = 43;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Change Date";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(286, 107);
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(184, 20);
            this.txtDate.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(470, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(470, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 13);
            this.label14.TabIndex = 45;
            this.label14.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(470, 146);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 13);
            this.label15.TabIndex = 45;
            this.label15.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(470, 180);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(14, 13);
            this.label16.TabIndex = 45;
            this.label16.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(470, 251);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 13);
            this.label18.TabIndex = 45;
            this.label18.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(470, 285);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(14, 13);
            this.label17.TabIndex = 45;
            this.label17.Text = "*";
            // 
            // EditIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(700, 584);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.cboReceivingUnit);
            this.Controls.Add(this.cboStores);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtReceivedBy);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtQtyPack);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPack);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBatchNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRefNo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditIssue";
            this.Text = "Edit Issue";
            this.Load += new System.EventHandler(this.EditIssue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceivedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyPack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBatchNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefNo.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboReceivingUnit;
        private System.Windows.Forms.ComboBox cboStores;
        private CalendarLib.DateTimePickerEx dtIssDate;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtItemName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txtQuantity;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtRemark;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.TextEdit txtReceivedBy;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.TextEdit txtQtyPack;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtPack;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtBatchNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtRefNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton xpButton1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private DevExpress.XtraEditors.TextEdit txtDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
    }
}