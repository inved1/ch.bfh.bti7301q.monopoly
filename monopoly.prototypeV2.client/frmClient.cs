using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monopoly.prototypeV2.client
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmClient());
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            frmClientGame f = new frmClientGame(this.textBox1.Text,this.textBox2.Text );
            f.Show();
        }


    }
}
