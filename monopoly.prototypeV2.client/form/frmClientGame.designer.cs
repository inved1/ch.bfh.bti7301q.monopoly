namespace monopoly.prototypeV2.client
{
    partial class frmClientGame
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
            this.spltContainerLeft = new System.Windows.Forms.SplitContainer();
            this.tblLayPnl = new System.Windows.Forms.TableLayoutPanel();
            this.field1 = new System.Windows.Forms.FlowLayoutPanel();
            this.field2 = new System.Windows.Forms.FlowLayoutPanel();
            this.field3 = new System.Windows.Forms.FlowLayoutPanel();
            this.field4 = new System.Windows.Forms.FlowLayoutPanel();
            this.field5 = new System.Windows.Forms.FlowLayoutPanel();
            this.field7 = new System.Windows.Forms.FlowLayoutPanel();
            this.field8 = new System.Windows.Forms.FlowLayoutPanel();
            this.field9 = new System.Windows.Forms.FlowLayoutPanel();
            this.field10 = new System.Windows.Forms.FlowLayoutPanel();
            this.field6 = new System.Windows.Forms.FlowLayoutPanel();
            this.field0 = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstPlayers = new System.Windows.Forms.ListBox();
            this.pnlAction = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.spltContainerLeft)).BeginInit();
            this.spltContainerLeft.Panel1.SuspendLayout();
            this.spltContainerLeft.Panel2.SuspendLayout();
            this.spltContainerLeft.SuspendLayout();
            this.tblLayPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spltContainerLeft
            // 
            this.spltContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltContainerLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltContainerLeft.IsSplitterFixed = true;
            this.spltContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.spltContainerLeft.Name = "spltContainerLeft";
            // 
            // spltContainerLeft.Panel1
            // 
            this.spltContainerLeft.Panel1.BackgroundImage = global::monopoly.prototypeV2.client.Properties.Resources.monopoly_Spielbrett;
            this.spltContainerLeft.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.spltContainerLeft.Panel1.Controls.Add(this.tblLayPnl);
            // 
            // spltContainerLeft.Panel2
            // 
            this.spltContainerLeft.Panel2.Controls.Add(this.splitContainer1);
            this.spltContainerLeft.Size = new System.Drawing.Size(931, 774);
            this.spltContainerLeft.SplitterDistance = 773;
            this.spltContainerLeft.TabIndex = 0;
            // 
            // tblLayPnl
            // 
            this.tblLayPnl.BackColor = System.Drawing.Color.Transparent;
            this.tblLayPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tblLayPnl.ColumnCount = 11;
            this.tblLayPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.90476F));
            this.tblLayPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.09524F));
            this.tblLayPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblLayPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tblLayPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tblLayPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tblLayPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tblLayPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblLayPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tblLayPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tblLayPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tblLayPnl.Controls.Add(this.field1, 9, 10);
            this.tblLayPnl.Controls.Add(this.field2, 8, 10);
            this.tblLayPnl.Controls.Add(this.field3, 7, 10);
            this.tblLayPnl.Controls.Add(this.field4, 6, 10);
            this.tblLayPnl.Controls.Add(this.field5, 5, 10);
            this.tblLayPnl.Controls.Add(this.field7, 3, 10);
            this.tblLayPnl.Controls.Add(this.field8, 2, 10);
            this.tblLayPnl.Controls.Add(this.field9, 1, 10);
            this.tblLayPnl.Controls.Add(this.field10, 0, 10);
            this.tblLayPnl.Controls.Add(this.field6, 4, 10);
            this.tblLayPnl.Controls.Add(this.field0, 10, 10);
            this.tblLayPnl.Location = new System.Drawing.Point(12, 12);
            this.tblLayPnl.Name = "tblLayPnl";
            this.tblLayPnl.RowCount = 11;
            this.tblLayPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.25301F));
            this.tblLayPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.74699F));
            this.tblLayPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblLayPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tblLayPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tblLayPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tblLayPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblLayPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tblLayPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblLayPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblLayPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tblLayPnl.Size = new System.Drawing.Size(748, 750);
            this.tblLayPnl.TabIndex = 0;
            // 
            // field1
            // 
            this.field1.Location = new System.Drawing.Point(586, 647);
            this.field1.Name = "field1";
            this.field1.Size = new System.Drawing.Size(51, 100);
            this.field1.TabIndex = 3;
            // 
            // field2
            // 
            this.field2.Location = new System.Drawing.Point(524, 647);
            this.field2.Name = "field2";
            this.field2.Size = new System.Drawing.Size(56, 100);
            this.field2.TabIndex = 4;
            // 
            // field3
            // 
            this.field3.Location = new System.Drawing.Point(464, 647);
            this.field3.Name = "field3";
            this.field3.Size = new System.Drawing.Size(54, 100);
            this.field3.TabIndex = 5;
            // 
            // field4
            // 
            this.field4.Location = new System.Drawing.Point(405, 647);
            this.field4.Name = "field4";
            this.field4.Size = new System.Drawing.Size(53, 100);
            this.field4.TabIndex = 6;
            // 
            // field5
            // 
            this.field5.Location = new System.Drawing.Point(346, 647);
            this.field5.Name = "field5";
            this.field5.Size = new System.Drawing.Size(53, 100);
            this.field5.TabIndex = 7;
            // 
            // field7
            // 
            this.field7.Location = new System.Drawing.Point(227, 647);
            this.field7.Name = "field7";
            this.field7.Size = new System.Drawing.Size(55, 100);
            this.field7.TabIndex = 9;
            // 
            // field8
            // 
            this.field8.Location = new System.Drawing.Point(167, 647);
            this.field8.Name = "field8";
            this.field8.Size = new System.Drawing.Size(54, 100);
            this.field8.TabIndex = 10;
            // 
            // field9
            // 
            this.field9.Location = new System.Drawing.Point(105, 647);
            this.field9.Name = "field9";
            this.field9.Size = new System.Drawing.Size(56, 100);
            this.field9.TabIndex = 11;
            // 
            // field10
            // 
            this.field10.Location = new System.Drawing.Point(3, 647);
            this.field10.Name = "field10";
            this.field10.Size = new System.Drawing.Size(96, 100);
            this.field10.TabIndex = 12;
            // 
            // field6
            // 
            this.field6.Location = new System.Drawing.Point(288, 647);
            this.field6.Name = "field6";
            this.field6.Size = new System.Drawing.Size(52, 100);
            this.field6.TabIndex = 14;
            // 
            // field0
            // 
            this.field0.Location = new System.Drawing.Point(643, 647);
            this.field0.Name = "field0";
            this.field0.Size = new System.Drawing.Size(100, 100);
            this.field0.TabIndex = 15;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstPlayers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlAction);
            this.splitContainer1.Size = new System.Drawing.Size(154, 774);
            this.splitContainer1.SplitterDistance = 384;
            this.splitContainer1.TabIndex = 0;
            // 
            // lstPlayers
            // 
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.Location = new System.Drawing.Point(3, 3);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(148, 121);
            this.lstPlayers.TabIndex = 0;
            // 
            // pnlAction
            // 
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAction.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlAction.Location = new System.Drawing.Point(0, 0);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(154, 386);
            this.pnlAction.TabIndex = 0;
            // 
            // frmClientGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(931, 774);
            this.Controls.Add(this.spltContainerLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmClientGame";
            this.Text = "frmClientGame";
            this.spltContainerLeft.Panel1.ResumeLayout(false);
            this.spltContainerLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltContainerLeft)).EndInit();
            this.spltContainerLeft.ResumeLayout(false);
            this.tblLayPnl.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spltContainerLeft;
        private System.Windows.Forms.TableLayoutPanel tblLayPnl;
        private System.Windows.Forms.FlowLayoutPanel field1;
        private System.Windows.Forms.FlowLayoutPanel field2;
        private System.Windows.Forms.FlowLayoutPanel field3;
        private System.Windows.Forms.FlowLayoutPanel field4;
        private System.Windows.Forms.FlowLayoutPanel field5;
        private System.Windows.Forms.FlowLayoutPanel field7;
        private System.Windows.Forms.FlowLayoutPanel field8;
        private System.Windows.Forms.FlowLayoutPanel field9;
        private System.Windows.Forms.FlowLayoutPanel field10;
        private System.Windows.Forms.FlowLayoutPanel field6;
        private System.Windows.Forms.FlowLayoutPanel field0;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel pnlAction;
        private System.Windows.Forms.ListBox lstPlayers;
    }
}