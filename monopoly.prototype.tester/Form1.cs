using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monopoly.prototype.tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            monopoly.prototype.client.FrmClient f = new client.FrmClient();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            monopoly.prototype.server.FrmServer f = new server.FrmServer();
            f.Show();

        }
    }
}
