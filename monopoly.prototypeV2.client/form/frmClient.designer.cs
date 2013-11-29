namespace monopoly.prototypeV2.client
{
    partial class frmClient
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxServer = new System.Windows.Forms.ComboBox();
            this.cbxPlayer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imgsAvatar = new System.Windows.Forms.ImageList(this.components);
            this.cbxAvatars = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(162, 66);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Verbinden";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server:Port";
            // 
            // cbxServer
            // 
            this.cbxServer.FormattingEnabled = true;
            this.cbxServer.Location = new System.Drawing.Point(12, 237);
            this.cbxServer.Name = "cbxServer";
            this.cbxServer.Size = new System.Drawing.Size(162, 21);
            this.cbxServer.TabIndex = 3;
            // 
            // cbxPlayer
            // 
            this.cbxPlayer.FormattingEnabled = true;
            this.cbxPlayer.Location = new System.Drawing.Point(12, 282);
            this.cbxPlayer.Name = "cbxPlayer";
            this.cbxPlayer.Size = new System.Drawing.Size(92, 21);
            this.cbxPlayer.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Spielername:";
            // 
            // imgsAvatar
            // 
            this.imgsAvatar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgsAvatar.ImageSize = new System.Drawing.Size(16, 16);
            this.imgsAvatar.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cbxAvatars
            // 
            this.cbxAvatars.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxAvatars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAvatars.FormattingEnabled = true;
            this.cbxAvatars.ItemHeight = 16;
            this.cbxAvatars.Location = new System.Drawing.Point(111, 282);
            this.cbxAvatars.Name = "cbxAvatars";
            this.cbxAvatars.Size = new System.Drawing.Size(63, 22);
            this.cbxAvatars.TabIndex = 4;
            this.cbxAvatars.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbxAvatars_DrawItem);
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::monopoly.prototypeV2.client.Properties.Resources.logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(186, 315);
            this.Controls.Add(this.cbxAvatars);
            this.Controls.Add(this.cbxPlayer);
            this.Controls.Add(this.cbxServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmClient";
            this.Text = "MonopolyClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxServer;
        private System.Windows.Forms.ComboBox cbxPlayer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imgsAvatar;
        private System.Windows.Forms.ComboBox cbxAvatars;
    }
}

