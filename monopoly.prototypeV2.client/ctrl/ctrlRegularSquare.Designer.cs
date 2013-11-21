namespace monopoly.prototypeV2.client.ctrl
{
    partial class ctrlRegularSquare
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.con = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.con)).BeginInit();
            this.con.SuspendLayout();
            this.SuspendLayout();
            // 
            // con
            // 
            this.con.Dock = System.Windows.Forms.DockStyle.Fill;
            this.con.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.con.IsSplitterFixed = true;
            this.con.Location = new System.Drawing.Point(0, 0);
            this.con.Name = "con";
            this.con.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.con.Size = new System.Drawing.Size(117, 167);
            this.con.TabIndex = 0;
            // 
            // ctrlRegularSquare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.con);
            this.Name = "ctrlRegularSquare";
            this.Size = new System.Drawing.Size(117, 167);
            ((System.ComponentModel.ISupportInitialize)(this.con)).EndInit();
            this.con.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer con;


    }
}
