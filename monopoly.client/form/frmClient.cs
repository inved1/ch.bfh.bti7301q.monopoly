﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using monopoly.client.form;
using monopoly.logic.util;
using monopoly.logic.classes;


namespace monopoly.client
{
    public partial class frmClient : Form
    {
        #region "vars"

        private cConfig myConfig;
        
        #endregion

        #region "constructor"
        public frmClient()
        {
            InitializeComponent();
            LogWriter w = LogWriter.Instance;
            myConfig = cConfig.getInstance;
            w.WriteLogQueue("Client started");


            initHistory();
        }
        #endregion

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

        #region "events"
        private void btnConnect_Click(object sender, EventArgs e)
        {

            LogWriter w = LogWriter.Instance;
            w.WriteLogQueue(string.Format("Client connect to {0}", this.cbxServer.Text.ToString() ));

            frmClientGame_V02 frmClient = new frmClientGame_V02(this.cbxServer.Text.ToString(), this.cbxPlayer.Text.ToString(), this.cbxAvatars.Text.ToString());
            frmClient.FormClosed += new FormClosedEventHandler(frmClient_FormClosed);
            frmClient.Show();
            this.Hide();
        }

        private void cbxAvatars_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            e.DrawFocusRectangle();

            if (e.Index > -1 && this.imgsAvatar.Images.Count >= e.Index)

                e.Graphics.DrawImage(this.imgsAvatar.Images[e.Index], new PointF(e.Bounds.X, e.Bounds.Y));
        }


        #endregion


        #region "functions"

        private void initHistory()
        {
           
            foreach (KeyValuePair<String, String> entry in myConfig.ClientHistoryNames)
            {
                this.cbxPlayer.Items.Add(entry.Value);
            }
            foreach (KeyValuePair<String, String> entry in myConfig.ClientHistoryServers)
            {
                this.cbxServer.Items.Add(entry.Value); 
            }

         


            this.imgsAvatar.Images.Add("barrow", monopoly.client.Properties.Resources.barrow);
            this.imgsAvatar.Images.Add("dog", monopoly.client.Properties.Resources.dog );
            this.imgsAvatar.Images.Add("hat", monopoly.client.Properties.Resources.hat );
            this.imgsAvatar.Images.Add("iron", monopoly.client.Properties.Resources.iron);
            this.imgsAvatar.Images.Add("ship", monopoly.client.Properties.Resources.ship );
            this.imgsAvatar.Images.Add("thimble", monopoly.client.Properties.Resources.thimble );

            this.cbxAvatars.Items.Add("barrow");
            this.cbxAvatars.Items.Add("dog");
            this.cbxAvatars.Items.Add("hat");
            this.cbxAvatars.Items.Add("iron");
            this.cbxAvatars.Items.Add("ship");
            this.cbxAvatars.Items.Add("thimble");
            
            this.cbxPlayer.SelectedIndex = 0;
            this.cbxServer.SelectedIndex = 0;
            this.cbxAvatars.SelectedIndex = 0;
            

        }

        public void frmClient_FormClosed(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion





    }
}
