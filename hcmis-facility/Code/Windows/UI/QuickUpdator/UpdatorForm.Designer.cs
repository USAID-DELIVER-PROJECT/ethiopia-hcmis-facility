using System.Windows.Forms;

namespace QuickUpdator
{
    partial class UpdatorForm
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
            System.Windows.Forms.DataGridView grdViewItemBatches;
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.removeNegatives = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lkItems = new DevExpress.XtraEditors.LookUpEdit();
            this.lkStores = new DevExpress.XtraEditors.LookUpEdit();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.btnEmptyBatch = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.ddnItem = new DevExpress.XtraEditors.LookUpEdit();
            this.ddnStore = new DevExpress.XtraEditors.LookUpEdit();
            this.lkCommodityTypes = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            grdViewItemBatches = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(grdViewItemBatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkItems.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkStores.Properties)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddnItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddnStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkCommodityTypes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdViewItemBatches
            // 
            grdViewItemBatches.AllowUserToAddRows = false;
            grdViewItemBatches.AllowUserToDeleteRows = false;
            grdViewItemBatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdViewItemBatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.ItemID});
            grdViewItemBatches.Location = new System.Drawing.Point(7, 66);
            grdViewItemBatches.Name = "grdViewItemBatches";
            grdViewItemBatches.ReadOnly = true;
            grdViewItemBatches.Size = new System.Drawing.Size(529, 212);
            grdViewItemBatches.TabIndex = 8;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "BatchNo";
            this.Column2.HeaderText = "Batch No.";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "QuantityLeft";
            this.Column3.HeaderText = "Quantity Left";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // ItemID
            // 
            this.ItemID.DataPropertyName = "ItemID";
            this.ItemID.HeaderText = "Item ID";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            this.ItemID.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(3, 69);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(175, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Update Only Once";
            this.simpleButton1.Visible = false;
            this.simpleButton1.Click += new System.EventHandler(this.btnUpdateOnlyOnce_Click);
            // 
            // removeNegatives
            // 
            this.removeNegatives.Location = new System.Drawing.Point(3, 39);
            this.removeNegatives.Name = "removeNegatives";
            this.removeNegatives.Size = new System.Drawing.Size(174, 24);
            this.removeNegatives.TabIndex = 1;
            this.removeNegatives.Text = "Remove -Ve SOHs";
            this.removeNegatives.Click += new System.EventHandler(this.removeNegatives_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(551, 312);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.simpleButton1);
            this.xtraTabPage1.Controls.Add(this.removeNegatives);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(545, 284);
            this.xtraTabPage1.Text = "Negative Removal";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.lkCommodityTypes);
            this.xtraTabPage2.Controls.Add(this.btnReset);
            this.xtraTabPage2.Controls.Add(this.labelControl5);
            this.xtraTabPage2.Controls.Add(this.labelControl2);
            this.xtraTabPage2.Controls.Add(this.labelControl1);
            this.xtraTabPage2.Controls.Add(this.lkItems);
            this.xtraTabPage2.Controls.Add(this.lkStores);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(545, 284);
            this.xtraTabPage2.Text = "Item Removal";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(284, 137);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(112, 19);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(82, 103);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Item";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(82, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Store";
            // 
            // lkItems
            // 
            this.lkItems.Location = new System.Drawing.Point(193, 100);
            this.lkItems.Name = "lkItems";
            this.lkItems.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkItems.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullItemName", "Item Name")});
            this.lkItems.Properties.DisplayMember = "FullItemName";
            this.lkItems.Properties.ValueMember = "ID";
            this.lkItems.Size = new System.Drawing.Size(200, 20);
            this.lkItems.TabIndex = 0;
            // 
            // lkStores
            // 
            this.lkStores.Location = new System.Drawing.Point(191, 35);
            this.lkStores.Name = "lkStores";
            this.lkStores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkStores.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreName", "Store Name")});
            this.lkStores.Properties.DisplayMember = "StoreName";
            this.lkStores.Properties.ValueMember = "ID";
            this.lkStores.Size = new System.Drawing.Size(202, 20);
            this.lkStores.TabIndex = 0;
            this.lkStores.EditValueChanged += new System.EventHandler(this.lkStores_EditValueChanged);
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(grdViewItemBatches);
            this.xtraTabPage3.Controls.Add(this.btnEmptyBatch);
            this.xtraTabPage3.Controls.Add(this.labelControl3);
            this.xtraTabPage3.Controls.Add(this.labelControl4);
            this.xtraTabPage3.Controls.Add(this.ddnItem);
            this.xtraTabPage3.Controls.Add(this.ddnStore);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(545, 284);
            this.xtraTabPage3.Text = "Batch Removal";
            // 
            // btnEmptyBatch
            // 
            this.btnEmptyBatch.Location = new System.Drawing.Point(444, 36);
            this.btnEmptyBatch.Name = "btnEmptyBatch";
            this.btnEmptyBatch.Size = new System.Drawing.Size(92, 24);
            this.btnEmptyBatch.TabIndex = 7;
            this.btnEmptyBatch.Text = "Empty Batch";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(7, 43);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(22, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Item";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(7, 10);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(26, 13);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Store";
            // 
            // ddnItem
            // 
            this.ddnItem.Location = new System.Drawing.Point(116, 40);
            this.ddnItem.Name = "ddnItem";
            this.ddnItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddnItem.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullItemName", "Item Name")});
            this.ddnItem.Properties.DisplayMember = "FullItemName";
            this.ddnItem.Properties.ValueMember = "ID";
            this.ddnItem.Size = new System.Drawing.Size(202, 20);
            this.ddnItem.TabIndex = 2;
            this.ddnItem.EditValueChanged += new System.EventHandler(this.ddnItem_EditValueChanged);
            // 
            // ddnStore
            // 
            this.ddnStore.Location = new System.Drawing.Point(116, 7);
            this.ddnStore.Name = "ddnStore";
            this.ddnStore.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddnStore.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreName", "Store Name")});
            this.ddnStore.Properties.DisplayMember = "StoreName";
            this.ddnStore.Properties.ValueMember = "ID";
            this.ddnStore.Size = new System.Drawing.Size(202, 20);
            this.ddnStore.TabIndex = 3;
            this.ddnStore.EditValueChanged += new System.EventHandler(this.ddnStore_EditValueChanged);
            // 
            // lkCommodityTypes
            // 
            this.lkCommodityTypes.Location = new System.Drawing.Point(191, 69);
            this.lkCommodityTypes.Name = "lkCommodityTypes";
            this.lkCommodityTypes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkCommodityTypes.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.lkCommodityTypes.Properties.DisplayMember = "Name";
            this.lkCommodityTypes.Properties.NullText = "";
            this.lkCommodityTypes.Properties.ValueMember = "ID";
            this.lkCommodityTypes.Size = new System.Drawing.Size(202, 20);
            this.lkCommodityTypes.TabIndex = 52;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(82, 72);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 13);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "Type";
            // 
            // UpdatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 312);
            this.Controls.Add(this.xtraTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UpdatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Reset Utility";
            this.Load += new System.EventHandler(this.UpdatorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(grdViewItemBatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkItems.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkStores.Properties)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddnItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddnStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkCommodityTypes.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton removeNegatives;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lkItems;
        private DevExpress.XtraEditors.LookUpEdit lkStores;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraEditors.SimpleButton btnEmptyBatch;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit ddnItem;
        private DevExpress.XtraEditors.LookUpEdit ddnStore;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn ItemID;
        private DevExpress.XtraEditors.LookUpEdit lkCommodityTypes;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}

