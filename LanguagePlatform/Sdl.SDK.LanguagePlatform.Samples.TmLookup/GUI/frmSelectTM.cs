using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sdl.LanguagePlatform.TranslationMemoryApi;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.Core.Tokenization;
using Sdl.LanguagePlatform.Core;

namespace Sdl.SDK.LanguagePlatform.Samples.TmLookup
{
    public partial class frmSelectTM : Form
    {
        public frmSelectTM()
        {
            InitializeComponent();
        }

        #region "cancel"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


         


        #region "connect"
        // By clicking the Connect button you establish a connectionw with the TM
        // Server. This will fill populate the dropdown list with the names of the
        // server TMs and enable the list, which is by default disabled.
        // Moreover, the OK button gets enabled.
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connector connection = new Connector();
            connection.Connect(this.txtServerUri.Text, this.txtUserName.Text, 
                this.txtPassword.Text, this.comboServerTMs);
            
            this.btnOK.Enabled = true;
        }
        #endregion



        #region "ok"
        // By clicking OK the user connects the server-based TM
        // through the Connector class.
        // The TM language directions are propagated into the corresponding list of the frmLookup form.
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Establish a connection to the TM Server.
            Connector connect = new Connector();

            connect.SelectServerTm(this.comboServerTMs.Text, this.txtServerUri.Text,
                    this.txtUserName.Text, this.txtPassword.Text);

            // Enter the TM URI and TM name into the main application form.
            frmLookup lookupFrm = new frmLookup();
            lookupFrm.txtTmPath.Text = Connector.serverTM.Uri.ToString();            

            // Loop throught the available language directions of the selected TM and fill them
            // into the corresponding list in the main application form.
            lookupFrm.comboLanguagePairs.Items.Clear();
            for (int i = 0; i < Connector.serverTM.LanguageDirections.Count; i++)
            {
                string srcLang = Connector.serverTM.LanguageDirections[i].SourceLanguage.DisplayName;
                string trgLang = Connector.serverTM.LanguageDirections[i].TargetLanguage.DisplayName;
                lookupFrm.comboLanguagePairs.Items.Add(srcLang + " -> " + trgLang);
            }

            // Select the first available language direction.
            string currentSrcLang = Connector.serverTM.LanguageDirections[0].SourceLanguage.DisplayName;
            string currentTrgLang = Connector.serverTM.LanguageDirections[0].TargetLanguage.DisplayName;
            lookupFrm.comboLanguagePairs.Text = currentSrcLang + " -> " + currentTrgLang;

            lookupFrm.Show();
            this.Close();
        }
        #endregion 

        private void frmSelectTM_Load(object sender, EventArgs e)
        {

        }


  




  
    }
}
