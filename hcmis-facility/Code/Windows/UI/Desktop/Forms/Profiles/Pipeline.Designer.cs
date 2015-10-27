namespace PharmInventory.Forms.Profiles
{
    partial class Pipeline
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboNearExpiryFlag = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboAmcRange = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtmax = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMin = new DevExpress.XtraEditors.TextEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboEOP = new System.Windows.Forms.ComboBox();
            this.cboLeadTime = new System.Windows.Forms.ComboBox();
            this.cboReview = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSafety = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboDUMax = new System.Windows.Forms.ComboBox();
            this.cboDUMin = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdEven = new System.Windows.Forms.RadioButton();
            this.rdOdd = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.bwAMCCalculate = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtmax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMin.Properties)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(681, 514);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PipeLine";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.cboNearExpiryFlag);
            this.groupBox6.Location = new System.Drawing.Point(440, 117);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(235, 100);
            this.groupBox6.TabIndex = 18;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Near Expiry Flag for Dispensaries";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Less than";
            // 
            // cboNearExpiryFlag
            // 
            this.cboNearExpiryFlag.FormattingEnabled = true;
            this.cboNearExpiryFlag.Items.AddRange(new object[] {
            "2 Weeks",
            "3 Weeks",
            "1 Month"});
            this.cboNearExpiryFlag.Location = new System.Drawing.Point(106, 35);
            this.cboNearExpiryFlag.Name = "cboNearExpiryFlag";
            this.cboNearExpiryFlag.Size = new System.Drawing.Size(100, 21);
            this.cboNearExpiryFlag.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.cboAmcRange);
            this.groupBox5.Location = new System.Drawing.Point(440, 39);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(237, 71);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "AMC Calculator modifier";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Up to Previous";
            // 
            // cboAmcRange
            // 
            this.cboAmcRange.DisplayMember = "Month";
            this.cboAmcRange.FormattingEnabled = true;
            this.cboAmcRange.Location = new System.Drawing.Point(106, 21);
            this.cboAmcRange.Name = "cboAmcRange";
            this.cboAmcRange.Size = new System.Drawing.Size(100, 21);
            this.cboAmcRange.TabIndex = 11;
            this.cboAmcRange.ValueMember = "Value";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtmax);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtMin);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.cboEOP);
            this.groupBox4.Controls.Add(this.cboLeadTime);
            this.groupBox4.Controls.Add(this.cboReview);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.cboSafety);
            this.groupBox4.Location = new System.Drawing.Point(42, 29);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(381, 252);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Store";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Lead Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Safety Stock";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Review Period";
            // 
            // txtmax
            // 
            this.txtmax.Location = new System.Drawing.Point(117, 196);
            this.txtmax.Name = "txtmax";
            this.txtmax.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.txtmax.Properties.Appearance.Options.UseBackColor = true;
            this.txtmax.Properties.ReadOnly = true;
            this.txtmax.Size = new System.Drawing.Size(99, 20);
            this.txtmax.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "EOP";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(117, 162);
            this.txtMin.Name = "txtMin";
            this.txtMin.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.txtMin.Properties.Appearance.Options.UseBackColor = true;
            this.txtMin.Properties.ReadOnly = true;
            this.txtMin.Size = new System.Drawing.Size(99, 20);
            this.txtMin.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(221, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Min + Review Period";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(221, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Lead Time + Safety Stock";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Min";
            // 
            // cboEOP
            // 
            this.cboEOP.DisplayMember = "Month";
            this.cboEOP.FormattingEnabled = true;
            this.cboEOP.Location = new System.Drawing.Point(117, 128);
            this.cboEOP.Name = "cboEOP";
            this.cboEOP.Size = new System.Drawing.Size(100, 21);
            this.cboEOP.TabIndex = 11;
            this.cboEOP.ValueMember = "Value";
            // 
            // cboLeadTime
            // 
            this.cboLeadTime.DisplayMember = "Month";
            this.cboLeadTime.FormattingEnabled = true;
            this.cboLeadTime.Location = new System.Drawing.Point(117, 26);
            this.cboLeadTime.Name = "cboLeadTime";
            this.cboLeadTime.Size = new System.Drawing.Size(100, 21);
            this.cboLeadTime.TabIndex = 11;
            this.cboLeadTime.ValueMember = "Value";
            this.cboLeadTime.SelectionChangeCommitted += new System.EventHandler(this.cboReview_SelectionChangeCommitted);
            // 
            // cboReview
            // 
            this.cboReview.DisplayMember = "Month";
            this.cboReview.FormattingEnabled = true;
            this.cboReview.Location = new System.Drawing.Point(117, 94);
            this.cboReview.Name = "cboReview";
            this.cboReview.Size = new System.Drawing.Size(100, 21);
            this.cboReview.TabIndex = 11;
            this.cboReview.ValueMember = "Value";
            this.cboReview.SelectionChangeCommitted += new System.EventHandler(this.cboReview_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(70, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Max";
            // 
            // cboSafety
            // 
            this.cboSafety.DisplayMember = "Month";
            this.cboSafety.FormattingEnabled = true;
            this.cboSafety.Location = new System.Drawing.Point(117, 60);
            this.cboSafety.Name = "cboSafety";
            this.cboSafety.Size = new System.Drawing.Size(100, 21);
            this.cboSafety.TabIndex = 11;
            this.cboSafety.ValueMember = "Value";
            this.cboSafety.SelectionChangeCommitted += new System.EventHandler(this.cboReview_SelectionChangeCommitted);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboDUMax);
            this.groupBox3.Controls.Add(this.cboDUMin);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(42, 315);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(224, 96);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dispensing Units ";
            this.groupBox3.Visible = false;
            // 
            // cboDUMax
            // 
            this.cboDUMax.DisplayMember = "Month";
            this.cboDUMax.FormattingEnabled = true;
            this.cboDUMax.Location = new System.Drawing.Point(111, 49);
            this.cboDUMax.Name = "cboDUMax";
            this.cboDUMax.Size = new System.Drawing.Size(100, 21);
            this.cboDUMax.TabIndex = 12;
            this.cboDUMax.ValueMember = "Value";
            // 
            // cboDUMin
            // 
            this.cboDUMin.DisplayMember = "Month";
            this.cboDUMin.FormattingEnabled = true;
            this.cboDUMin.Location = new System.Drawing.Point(111, 23);
            this.cboDUMin.Name = "cboDUMin";
            this.cboDUMin.Size = new System.Drawing.Size(100, 21);
            this.cboDUMin.TabIndex = 12;
            this.cboDUMin.ValueMember = "Value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(67, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Max";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(70, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Min";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdEven);
            this.groupBox2.Controls.Add(this.rdOdd);
            this.groupBox2.Location = new System.Drawing.Point(497, 385);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 42);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // rdEven
            // 
            this.rdEven.AutoSize = true;
            this.rdEven.Location = new System.Drawing.Point(19, 19);
            this.rdEven.Name = "rdEven";
            this.rdEven.Size = new System.Drawing.Size(53, 17);
            this.rdEven.TabIndex = 13;
            this.rdEven.TabStop = true;
            this.rdEven.Text = "Even";
            // 
            // rdOdd
            // 
            this.rdOdd.AutoSize = true;
            this.rdOdd.Location = new System.Drawing.Point(73, 19);
            this.rdOdd.Name = "rdOdd";
            this.rdOdd.Size = new System.Drawing.Size(48, 17);
            this.rdOdd.TabIndex = 13;
            this.rdOdd.TabStop = true;
            this.rdOdd.Text = "Odd";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(391, 404);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Reporting Month";
            this.label6.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Image = global::PharmInventory.Properties.Resources.cross;
            this.btnCancel.Location = new System.Drawing.Point(177, 445);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = global::PharmInventory.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(84, 445);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // bwAMCCalculate
            // 
            this.bwAMCCalculate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwAMCCalculate_DoWork);
            // 
            // Pipeline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 514);
            this.Controls.Add(this.groupBox1);
            this.Name = "Pipeline";
            this.Text = "Pipeline";
            this.Load += new System.EventHandler(this.Pipeline_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtmax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMin.Properties)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboLeadTime;
        private System.Windows.Forms.ComboBox cboReview;
        private System.Windows.Forms.ComboBox cboSafety;
        private System.Windows.Forms.ComboBox cboEOP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtMin;
        private DevExpress.XtraEditors.TextEdit txtmax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdOdd;
        private System.Windows.Forms.RadioButton rdEven;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDUMax;
        private System.Windows.Forms.ComboBox cboDUMin;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboAmcRange;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboNearExpiryFlag;
        private System.ComponentModel.BackgroundWorker bwAMCCalculate;
    }
}