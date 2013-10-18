namespace monopoly.prototype.client
{
    partial class FrmClient
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkRoll = new System.Windows.Forms.CheckBox();
            this.chkGiveUp = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "GO !";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 143);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 106);
            this.textBox1.TabIndex = 1;
            // 
            // chkRoll
            // 
            this.chkRoll.AutoSize = true;
            this.chkRoll.Location = new System.Drawing.Point(13, 13);
            this.chkRoll.Name = "chkRoll";
            this.chkRoll.Size = new System.Drawing.Size(44, 17);
            this.chkRoll.TabIndex = 2;
            this.chkRoll.Text = "Roll";
            this.chkRoll.UseVisualStyleBackColor = true;
            // 
            // chkGiveUp
            // 
            this.chkGiveUp.AutoSize = true;
            this.chkGiveUp.Location = new System.Drawing.Point(13, 37);
            this.chkGiveUp.Name = "chkGiveUp";
            this.chkGiveUp.Size = new System.Drawing.Size(65, 17);
            this.chkGiveUp.TabIndex = 3;
            this.chkGiveUp.Text = "Give Up";
            this.chkGiveUp.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.chkGiveUp);
            this.Controls.Add(this.chkRoll);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chkRoll;
        private System.Windows.Forms.CheckBox chkGiveUp;
    }
}

