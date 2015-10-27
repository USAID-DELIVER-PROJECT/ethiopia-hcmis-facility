namespace PharmInventory.Forms.Tools
{
    partial class ConnectionStringGenerator
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
            this.btnGetServerInstances = new DevExpress.XtraEditors.SimpleButton();
            this.lstDatabases = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboServers = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lstDatabases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboServers.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetServerInstances
            // 
            this.btnGetServerInstances.Location = new System.Drawing.Point(11, 197);
            this.btnGetServerInstances.Name = "btnGetServerInstances";
            this.btnGetServerInstances.Size = new System.Drawing.Size(139, 23);
            this.btnGetServerInstances.TabIndex = 0;
            this.btnGetServerInstances.Text = "Get Connection String";
            this.btnGetServerInstances.Click += new System.EventHandler(this.btnGetServerInstances_Click);
            // 
            // lstDatabases
            // 
            this.lstDatabases.Location = new System.Drawing.Point(11, 65);
            this.lstDatabases.Name = "lstDatabases";
            this.lstDatabases.Size = new System.Drawing.Size(243, 120);
            this.lstDatabases.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Server";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Databases";
            // 
            // cboServers
            // 
            this.cboServers.Location = new System.Drawing.Point(63, 5);
            this.cboServers.Name = "cboServers";
            this.cboServers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboServers.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cboServers.Properties.NullText = "Select Server";
            this.cboServers.Size = new System.Drawing.Size(191, 20);
            this.cboServers.TabIndex = 8;
            this.cboServers.EditValueChanged += new System.EventHandler(this.cboServers_EditValueChanged);
            // 
            // ConnectionStringGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 230);
            this.Controls.Add(this.cboServers);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lstDatabases);
            this.Controls.Add(this.btnGetServerInstances);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ConnectionStringGenerator";
            this.Text = "Connection String Generator";
            this.Load += new System.EventHandler(this.ConnectionStringGenerator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lstDatabases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboServers.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnGetServerInstances;
        private DevExpress.XtraEditors.ListBoxControl lstDatabases;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit cboServers;
    }
}