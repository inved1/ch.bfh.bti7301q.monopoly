namespace monopoly.tester
{
    partial class GameTest
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
            this.btnRoll = new System.Windows.Forms.Button();
            this.btnBuySquare = new System.Windows.Forms.Button();
            this.btnEndTurn = new System.Windows.Forms.Button();
            this.btnGiveUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRoll
            // 
            this.btnRoll.Location = new System.Drawing.Point(13, 42);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(75, 23);
            this.btnRoll.TabIndex = 1;
            this.btnRoll.Text = "roll";
            this.btnRoll.UseVisualStyleBackColor = true;
            // 
            // btnBuySquare
            // 
            this.btnBuySquare.Location = new System.Drawing.Point(13, 72);
            this.btnBuySquare.Name = "btnBuySquare";
            this.btnBuySquare.Size = new System.Drawing.Size(75, 23);
            this.btnBuySquare.TabIndex = 2;
            this.btnBuySquare.Text = "buySquare";
            this.btnBuySquare.UseVisualStyleBackColor = true;
            // 
            // btnEndTurn
            // 
            this.btnEndTurn.Location = new System.Drawing.Point(124, 72);
            this.btnEndTurn.Name = "btnEndTurn";
            this.btnEndTurn.Size = new System.Drawing.Size(75, 23);
            this.btnEndTurn.TabIndex = 4;
            this.btnEndTurn.Text = "endTurn";
            this.btnEndTurn.UseVisualStyleBackColor = true;
            // 
            // btnGiveUp
            // 
            this.btnGiveUp.Location = new System.Drawing.Point(124, 124);
            this.btnGiveUp.Name = "btnGiveUp";
            this.btnGiveUp.Size = new System.Drawing.Size(75, 23);
            this.btnGiveUp.TabIndex = 5;
            this.btnGiveUp.Text = "giveUp";
            this.btnGiveUp.UseVisualStyleBackColor = true;
            // 
            // GameTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 244);
            this.Controls.Add(this.btnGiveUp);
            this.Controls.Add(this.btnEndTurn);
            this.Controls.Add(this.btnBuySquare);
            this.Controls.Add(this.btnRoll);
            this.Name = "GameTest";
            this.Text = "GameTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.Button btnBuySquare;
        private System.Windows.Forms.Button btnEndTurn;
        private System.Windows.Forms.Button btnGiveUp;
    }
}