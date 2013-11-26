namespace monopoly.prototypeV2.tester
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
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.btnRoll = new System.Windows.Forms.Button();
            this.btnBuySquare = new System.Windows.Forms.Button();
            this.btnGetCard = new System.Windows.Forms.Button();
            this.btnEndTurn = new System.Windows.Forms.Button();
            this.btnPayRent = new System.Windows.Forms.Button();
            this.btnPayTax = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(12, 12);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(75, 23);
            this.btnAddPlayer.TabIndex = 0;
            this.btnAddPlayer.Text = "addPlayer";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
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
            // btnGetCard
            // 
            this.btnGetCard.Location = new System.Drawing.Point(13, 102);
            this.btnGetCard.Name = "btnGetCard";
            this.btnGetCard.Size = new System.Drawing.Size(75, 23);
            this.btnGetCard.TabIndex = 3;
            this.btnGetCard.Text = "getCard";
            this.btnGetCard.UseVisualStyleBackColor = true;
            // 
            // btnEndTurn
            // 
            this.btnEndTurn.Location = new System.Drawing.Point(13, 209);
            this.btnEndTurn.Name = "btnEndTurn";
            this.btnEndTurn.Size = new System.Drawing.Size(75, 23);
            this.btnEndTurn.TabIndex = 4;
            this.btnEndTurn.Text = "endTurn";
            this.btnEndTurn.UseVisualStyleBackColor = true;
            // 
            // btnPayRent
            // 
            this.btnPayRent.Location = new System.Drawing.Point(95, 42);
            this.btnPayRent.Name = "btnPayRent";
            this.btnPayRent.Size = new System.Drawing.Size(75, 23);
            this.btnPayRent.TabIndex = 5;
            this.btnPayRent.Text = "payRent";
            this.btnPayRent.UseVisualStyleBackColor = true;
            // 
            // btnPayTax
            // 
            this.btnPayTax.Location = new System.Drawing.Point(95, 72);
            this.btnPayTax.Name = "btnPayTax";
            this.btnPayTax.Size = new System.Drawing.Size(75, 23);
            this.btnPayTax.TabIndex = 6;
            this.btnPayTax.Text = "payTax";
            this.btnPayTax.UseVisualStyleBackColor = true;
            // 
            // GameTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 244);
            this.Controls.Add(this.btnPayTax);
            this.Controls.Add(this.btnPayRent);
            this.Controls.Add(this.btnEndTurn);
            this.Controls.Add(this.btnGetCard);
            this.Controls.Add(this.btnBuySquare);
            this.Controls.Add(this.btnRoll);
            this.Controls.Add(this.btnAddPlayer);
            this.Name = "GameTest";
            this.Text = "GameTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.Button btnBuySquare;
        private System.Windows.Forms.Button btnGetCard;
        private System.Windows.Forms.Button btnEndTurn;
        private System.Windows.Forms.Button btnPayRent;
        private System.Windows.Forms.Button btnPayTax;
    }
}