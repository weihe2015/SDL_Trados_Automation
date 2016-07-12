using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sdl.LanguagePlatform.TranslationMemoryApi;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.Core.Tokenization;
using Sdl.LanguagePlatform.Core;

namespace Sdl.SDK.LanguagePlatform.Samples.TmLookup
{
    class Connector
    {
        #region "TmServer"
        private TranslationProviderServer tmServer;
        #endregion        

        #region "FileOrServer"
        /// <summary>
        /// Property to flag whether a file or server TM should be used for the search
        /// </summary> 
        public static bool server
        {
            get;
            set;
        }
        #endregion

        #region "fileTM"
        /// <summary>
        /// The file TM object
        /// </summary> 
        public static FileBasedTranslationMemory fileTm
        {
            get;
            set;           
        }
        #endregion



        #region "SelectFileTm"
        /// <summary>
        /// Select the file TM using the file name and path chosen by the user through the GUI.
        /// </summary>
        public void SelectFileTm(string tmPath)
        {
            fileTm = new FileBasedTranslationMemory(tmPath);
            server = false;
        }
        #endregion

        #region "serverTM"
        /// <summary>
        /// The server TM object
        /// </summary>
        public static ServerBasedTranslationMemory serverTM
        {
            get;
            set;
        }
        #endregion

        #region "connect"
        /// <summary>
        /// Establishing a connection to the TM Server.
        /// This connection is primarily needed for populating the 
        /// TM dropdown list with the TM names.
        /// </summary>
        public void Connect(string serverUri, string userName, string password, ComboBox tmList)
        {
            try
            {
                tmServer = new TranslationProviderServer(GetUri(serverUri),  false, userName, password);
                foreach (ServerBasedTranslationMemory item in tmServer.GetTranslationMemories(TranslationMemoryProperties.All))
                {
                    //Resolve path to the TM inclusive name of the organization(s)
                    string tmPath = item.ParentResourceGroupPath == "/" ? "" : item.ParentResourceGroupPath;
                    tmList.Items.Add(tmPath + "/" + item.Name);
                }

                if (tmList.Items.Count > 0)
                {
                    tmList.Enabled = true;
                    tmList.SelectedIndex = 0;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion


        #region "uri"
        /// <summary>
        /// Returns the address of the TM Server.
        /// </summary>
        private Uri GetUri(string uri)
        {
            string address = uri;
            return new Uri(address);
        }
        #endregion


        #region "SelectServerTm"
        /// <summary>
        /// Selects the particular server TM as chosen by the user through the dropdown list.
        /// </summary>
        public void SelectServerTm(string tmName, string uri, string userName, string password)
        {
            tmServer = new TranslationProviderServer(GetUri(uri), false, userName, password);
            serverTM = tmServer.GetTranslationMemory(tmName, 
                TranslationMemoryProperties.None);
            server = true;
        }
        #endregion
    }
}
