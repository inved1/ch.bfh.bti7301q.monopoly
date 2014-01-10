using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monopoly.prototypeV2.client.form
{
    public partial class frmTradeConfirm : Form
    {
        public frmTradeConfirm()
        {
            InitializeComponent();
        }

        public void setText(String text){
            this.textBox1.Text = text;
        }
    }
}
