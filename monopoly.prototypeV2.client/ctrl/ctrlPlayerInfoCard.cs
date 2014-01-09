using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monopoly.prototypeV2.client.ctrl
{
    public partial class ctrlPlayerInfoCard : UserControl
    {

        private String myTopInfo;
        private String myBottomInfo;
        public ctrlPlayerInfoCard()
        {
            InitializeComponent();

            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.ctrl_paintTop);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.ctrl_paintBottom);
        }


        private void ctrl_paintTop(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            int iStart = 2;
            foreach (String s in this.myTopInfo.Split(new Char[] {';' }))
            {
                e.Graphics.DrawString(this.myTopInfo, new Font("Arial", 8), Brushes.Black, new PointF(iStart , 2));
                iStart += 10;
            }
            
        }

        private void ctrl_paintBottom(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            int iStart = 2;
            foreach (String s in this.myBottomInfo.Split(new Char[] { ';' }))
            {
                e.Graphics.DrawString(this.myBottomInfo, new Font("Arial", 8), Brushes.Black, new PointF(iStart, 2));
                iStart += 10;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //not used anymore            
        }

        public String TopBackColor
        {
            get { return this.splitContainer1.Panel1.BackColor.Name; }
            set { this.splitContainer1.Panel1.BackColor = Color.FromName(value); }
        }

        public void setTopInfo(String val)
        {
            this.myTopInfo = val;
        }
        public void setBottomInfo(String val)
        {
            this.myBottomInfo = val;
        }


    }
}
