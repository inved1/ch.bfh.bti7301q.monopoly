using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using monopoly.prototypeV2.logic.util;

namespace monopoly.prototypeV2.client
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
            LogWriter w = LogWriter.Instance;
            w.WriteLogQueue("Client started");
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
            LogWriter w = LogWriter.Instance;
            w.WriteLogQueue(string.Format("Client connect to {0}, {1}",this.textBox1.Text,this.textBox2.Text)   );

            frmClientGame f = new frmClientGame(this.textBox1.Text,this.textBox2.Text );
            f.Show();
        }


    }
}
