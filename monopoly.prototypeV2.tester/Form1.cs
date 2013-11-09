using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using monopoly.prototypeV2.server;
using monopoly.prototypeV2.client;

namespace monopoly.prototypeV2.tester
{
    public partial class Form1 : Form
    {
        private monopoly.prototypeV2.server.frmServer srv;

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (srv == null)
            {

                monopoly.prototypeV2.server.frmServer F = new monopoly.prototypeV2.server.frmServer();
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
            monopoly.prototypeV2.client.frmClient c = new monopoly.prototypeV2.client.frmClient();
            c.Show();
        }
    }
}
