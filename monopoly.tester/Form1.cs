using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monopoly.tester
{
    public partial class frmMain : Form
    {
        

        public frmMain()
        {
            InitializeComponent();
            
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                monopoly.server.Program srv = new server.Program();
                this.txtInfo.Text += "Server gestartet..." + System.Environment.NewLine;
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
                            
        }

        private void btnStartClient_Click(object sender, EventArgs e)
        {
            try
            {

                this.txtInfo.Text += "Client gestartet..." + System.Environment.NewLine;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.txtInfo.Text = "";

        }

    }
}
