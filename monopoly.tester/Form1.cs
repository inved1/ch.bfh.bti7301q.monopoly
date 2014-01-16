using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using monopoly.server;
using monopoly.client;

namespace monopoly.tester
{
    public partial class Form1 : Form
    {
        private monopoly.server.frmServer srv;

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (srv == null)
            {

                monopoly.server.frmServer F = new monopoly.server.frmServer();
                srv = F;
                F.Show();

            }
            else
            {
                srv.BringToFront();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            monopoly.client.frmClient c = new monopoly.client.frmClient();
            c.Show();
        }
    }
}
