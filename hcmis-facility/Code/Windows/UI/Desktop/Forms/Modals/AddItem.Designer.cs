using DevExpress.XtraEditors;

namespace PharmInventory.Forms.Modals
{
    partial class AddItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddItem));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ProductTree = new System.Windows.Forms.TreeView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStrength = new TextEdit();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.cboDosageForm = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboIIN = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStock2 = new TextEdit();
            this.txtStock3 = new TextEdit();
            this.txtStockCode = new TextEdit();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lstCat = new System.Windows.Forms.ListView();
            this.categ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subCateg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckIsFree = new DevExpress.XtraEditors.CheckEdit();
            this.ckIsEDL = new DevExpress.XtraEditors.CheckEdit();
            this.ckIsRefrigerated = new DevExpress.XtraEditors.CheckEdit();
            this.ckSeasonal = new DevExpress.XtraEditors.CheckEdit();
            this.ckIsDiscontinued = new DevExpress.XtraEditors.CheckEdit();
            this.ckIsPedatric = new DevExpress.XtraEditors.CheckEdit();
            this.btnAddCat = new DevExpress.XtraEditors.SimpleButton();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ProductTree);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 510);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Detail";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox7_Enter);
            // 
            // ProductTree
            // 
            this.ProductTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.ProductTree.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductTree.Location = new System.Drawing.Point(392, 135);
            this.ProductTree.Name = "ProductTree";
            this.ProductTree.ShowNodeToolTips = true;
            this.ProductTree.Size = new System.Drawing.Size(262, 336);
            this.ProductTree.TabIndex = 14;
            this.ProductTree.Visible = false;
            this.ProductTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ProductTree_NodeMouseDoubleClick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.txtStrength);
            this.groupBox7.Controls.Add(this.cboUnit);
            this.groupBox7.Controls.Add(this.cboDosageForm);
            this.groupBox7.Location = new System.Drawing.Point(41, 293);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(345, 171);
            this.groupBox7.TabIndex = 13;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Detail";
            this.groupBox7.Enter += new System.EventHandler(this.groupBox7_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Strength";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Dosage Form";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Unit";
            // 
            // txtStrength
            // 
            this.txtStrength.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStrength.Location = new System.Drawing.Point(112, 41);
            this.txtStrength.Name = "txtStrength";
            this.txtStrength.Size = new System.Drawing.Size(220, 21);
            this.txtStrength.TabIndex = 1;
            // 
            // cboUnit
            // 
            this.cboUnit.DisplayMember = "Unit";
            this.cboUnit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(112, 105);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(220, 21);
            this.cboUnit.TabIndex = 10;
            this.cboUnit.ValueMember = "ID";
            // 
            // cboDosageForm
            // 
            this.cboDosageForm.DisplayMember = "Form";
            this.cboDosageForm.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDosageForm.FormattingEnabled = true;
            this.cboDosageForm.Location = new System.Drawing.Point(112, 73);
            this.cboDosageForm.Name = "cboDosageForm";
            this.cboDosageForm.Size = new System.Drawing.Size(220, 21);
            this.cboDosageForm.TabIndex = 10;
            this.cboDosageForm.ValueMember = "ID";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cboIIN);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.txtStock2);
            this.groupBox5.Controls.Add(this.txtStock3);
            this.groupBox5.Controls.Add(this.txtStockCode);
            this.groupBox5.Location = new System.Drawing.Point(41, 145);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(345, 139);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Drug Name";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox7_Enter);
            // 
            // cboIIN
            // 
            this.cboIIN.DisplayMember = "IIN";
            this.cboIIN.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIIN.FormattingEnabled = true;
            this.cboIIN.Location = new System.Drawing.Point(112, 13);
            this.cboIIN.Name = "cboIIN";
            this.cboIIN.Size = new System.Drawing.Size(220, 21);
            this.cboIIN.TabIndex = 10;
            this.cboIIN.ValueMember = "ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "IIN";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Stock Code 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock Code 3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Stock Code";
            // 
            // txtStock2
            // 
            this.txtStock2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock2.Location = new System.Drawing.Point(112, 71);
            this.txtStock2.Name = "txtStock2";
            this.txtStock2.Size = new System.Drawing.Size(219, 21);
            this.txtStock2.TabIndex = 1;
            // 
            // txtStock3
            // 
            this.txtStock3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock3.Location = new System.Drawing.Point(113, 100);
            this.txtStock3.Name = "txtStock3";
            this.txtStock3.Size = new System.Drawing.Size(219, 21);
            this.txtStock3.TabIndex = 1;
            // 
            // txtStockCode
            // 
            this.txtStockCode.BackColor = System.Drawing.Color.Wheat;
            this.txtStockCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockCode.Location = new System.Drawing.Point(112, 42);
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.Properties.ReadOnly = true;
            this.txtStockCode.Size = new System.Drawing.Size(219, 21);
            this.txtStockCode.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnAddCat);
            this.groupBox6.Controls.Add(this.lstCat);
            this.groupBox6.Location = new System.Drawing.Point(41, 20);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(613, 119);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Category Info.";
            this.groupBox6.Enter += new System.EventHandler(this.groupBox7_Enter);
            // 
            // lstCat
            // 
            this.lstCat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCat.BackColor = System.Drawing.Color.White;
            this.lstCat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstCat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.categ,
            this.subCateg});
            this.lstCat.ContextMenuStrip = this.contextMenuStrip1;
            this.lstCat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCat.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lstCat.FullRowSelect = true;
            this.lstCat.GridLines = true;
            this.lstCat.Location = new System.Drawing.Point(6, 20);
            this.lstCat.Name = "lstCat";
            this.lstCat.Size = new System.Drawing.Size(567, 89);
            this.lstCat.TabIndex = 14;
            this.lstCat.UseCompatibleStateImageBehavior = false;
            this.lstCat.View = System.Windows.Forms.View.Details;
            // 
            // categ
            // 
            this.categ.Text = "Category";
            this.categ.Width = 246;
            // 
            // subCateg
            // 
            this.subCateg.Text = "Sub Category";
            this.subCateg.Width = 313;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(115, 26);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckIsFree);
            this.groupBox2.Controls.Add(this.ckIsEDL);
            this.groupBox2.Controls.Add(this.ckIsRefrigerated);
            this.groupBox2.Controls.Add(this.ckSeasonal);
            this.groupBox2.Controls.Add(this.ckIsDiscontinued);
            this.groupBox2.Controls.Add(this.ckIsPedatric);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(392, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 165);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Properties";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox7_Enter);
            // 
            // ckIsFree
            // 
            this.ckIsFree.AutoSize = true;
            this.ckIsFree.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckIsFree.Location = new System.Drawing.Point(31, 23);
            this.ckIsFree.Name = "ckIsFree";
            this.ckIsFree.Size = new System.Drawing.Size(66, 17);
            this.ckIsFree.TabIndex = 3;
            this.ckIsFree.Text = "Is Free";

            // 
            // ckIsEDL
            // 
            this.ckIsEDL.AutoSize = true;
            this.ckIsEDL.Checked = true;
            this.ckIsEDL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIsEDL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckIsEDL.Location = new System.Drawing.Point(31, 110);
            this.ckIsEDL.Name = "ckIsEDL";
            this.ckIsEDL.Size = new System.Drawing.Size(130, 17);
            this.ckIsEDL.TabIndex = 3;
            this.ckIsEDL.Text = "Drug found in EDL";
            
            // 
            // ckIsRefrigerated
            // 
            this.ckIsRefrigerated.AutoSize = true;
            this.ckIsRefrigerated.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckIsRefrigerated.Location = new System.Drawing.Point(31, 52);
            this.ckIsRefrigerated.Name = "ckIsRefrigerated";
            this.ckIsRefrigerated.Size = new System.Drawing.Size(112, 17);
            this.ckIsRefrigerated.TabIndex = 3;
            this.ckIsRefrigerated.Text = "Is Refrigerated";

            // 
            // ckSeasonal
            // 
            this.ckSeasonal.AutoSize = true;
            this.ckSeasonal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSeasonal.Location = new System.Drawing.Point(31, 139);
            this.ckSeasonal.Name = "ckSeasonal";
            this.ckSeasonal.Size = new System.Drawing.Size(93, 17);
            this.ckSeasonal.TabIndex = 3;
            this.ckSeasonal.Text = "Is Seasonal";

            // 
            // ckIsDiscontinued
            // 
            this.ckIsDiscontinued.AutoSize = true;
            this.ckIsDiscontinued.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckIsDiscontinued.Location = new System.Drawing.Point(31, 81);
            this.ckIsDiscontinued.Name = "ckIsDiscontinued";
            this.ckIsDiscontinued.Size = new System.Drawing.Size(114, 17);
            this.ckIsDiscontinued.TabIndex = 3;
            this.ckIsDiscontinued.Text = "Is Discontinued";
            // 
            // ckIsPedatric
            // 
            this.ckIsPedatric.AutoSize = true;
            this.ckIsPedatric.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckIsPedatric.Location = new System.Drawing.Point(162, 139);
            this.ckIsPedatric.Name = "ckIsPedatric";
            this.ckIsPedatric.Size = new System.Drawing.Size(90, 17);
            this.ckIsPedatric.TabIndex = 3;
            this.ckIsPedatric.Text = "Is Pediatric";
            this.ckIsPedatric.Visible = false;
            // 
            // btnAddCat
            // 
            this.btnAddCat.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCat.Appearance.Options.UseFont = true;
            this.btnAddCat.Image = global::PharmInventory.Properties.Resources.add_16;
            this.btnAddCat.Location = new System.Drawing.Point(579, 86);
            this.btnAddCat.Name = "btnAddCat";
            this.btnAddCat.Size = new System.Drawing.Size(24, 23);
            this.btnAddCat.TabIndex = 15;
            this.btnAddCat.Click += new System.EventHandler(this.btnAddCat_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::PharmInventory.Properties.Resources.cancel_16;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.removeToolStripMenuItem.Text = "remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Image = global::PharmInventory.Properties.Resources.cross;
            this.btnCancel.Location = new System.Drawing.Point(359, 475);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.Enter += new System.EventHandler(this.groupBox7_Enter);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = global::PharmInventory.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(235, 475);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.groupBox7_Enter);
            // 
            // AddItem
            // 
            this.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 510);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddItem";
            this.Text = "Item Details";
            this.Load += new System.EventHandler(this.AddItem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private TextEdit txtStrength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.CheckEdit ckIsDiscontinued;
        private DevExpress.XtraEditors.CheckEdit ckIsPedatric;
        private DevExpress.XtraEditors.CheckEdit ckIsRefrigerated;
        private DevExpress.XtraEditors.CheckEdit ckIsFree;
        private DevExpress.XtraEditors.CheckEdit ckIsEDL;
        private System.Windows.Forms.GroupBox groupBox2;
        private SimpleButton btnCancel;
        private SimpleButton btnSave;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.ComboBox cboDosageForm;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cboIIN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private TextEdit txtStockCode;
        private DevExpress.XtraEditors.CheckEdit ckSeasonal;
        private System.Windows.Forms.ListView lstCat;
        private System.Windows.Forms.ColumnHeader categ;
        private System.Windows.Forms.ColumnHeader subCateg;
        private SimpleButton btnAddCat;
        private System.Windows.Forms.TreeView ProductTree;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private TextEdit txtStock2;
        private TextEdit txtStock3;
    }
}