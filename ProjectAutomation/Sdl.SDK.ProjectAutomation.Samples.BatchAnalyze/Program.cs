namespace Sdl.SDK.ProjectAutomation.Samples.BatchAnaylze
{
    using System;
    using System.IO;
    using System.Collections;
    using System.Collections.Generic;

    public class Program
    {
        public static Hashtable ht;
        public static Hashtable DoubleName = new Hashtable();
        public static string homeFolder = "C:\\work\\HPE";
        public static string targetFolder = "\\\\nyal-sol_eng\\Sol_Eng\\HPE\\TM_Migration";
        public static string tradosFolder = "C:\\Users\\whe\\Documents\\Studio 2014\\Projects";
        #region "main"
        public static void Main(string[] args)
        {
            try
            {
                CreateDoubleName();
                processAllTask();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("All tasks are done, Press Enter to Exit");
            Console.ReadLine();
        }
        #endregion

        public static void processAllTask()
        {
            List<string> folderLists = new List<string>();
            folderLists.Add("C:\\work\\HPE\\ESSN-HP\\TGT");
            //folderLists.Add("C:\\work\\HPE\\ESSN-Human_Science\\TGT");
            //folderLists.Add("C:\\work\\HPE\\ESSN-LionBridge\\TGT");
            //folderLists.Add("C:\\work\\HPE\\ESSN-wwACG\\TGT");
            folderLists.Add("C:\\work\\HPE\\Ad-hoc\\TGT");
            folderLists.Add("C:\\work\\HPE\\AES-ACG\\TGT");
            folderLists.Add("C:\\work\\HPE\\AES-Janus\\TGT");
            folderLists.Add("C:\\work\\HPE\\EULM\\TGT");
            folderLists.Add("C:\\work\\HPE\\HP_Legal_VIA\\TGT");
            folderLists.Add("C:\\work\\HPE\\HP_Proposal\\TGT");
            folderLists.Add("C:\\work\\HPE\\HPCP-Global_Cert-Marketing-MPower\\TGT");
            folderLists.Add("C:\\work\\HPE\\SDL\\TGT");
            folderLists.Add("C:\\work\\HPE\\TW-ACG\\TGT");
            foreach (string folderList in folderLists)
            {
                Console.WriteLine("Process folder {0}", folderList);
                ht = new Hashtable();
                #region "DeclareVariables"
                string mainPath = folderList;
                string parPath = mainPath.Substring(0, mainPath.LastIndexOf("\\"));
                string projectName = parPath.Substring(parPath.LastIndexOf("\\") + 1);
                projectName = projectName.Replace('.', '_');
                projectName = projectName.Replace(':', '_');
                projectName = projectName.Replace('/', '_');
                projectName = projectName.Replace(' ', '_');
                #endregion

                var folders = Directory.GetDirectories(folderList);
                foreach (var f in folders)
                {
                    string folder = f.ToString();
                    Console.WriteLine("Process subfolder {0}", folder);
                    #region "ProcessTask"
                    try
                    {
                        string k = folder.Substring(folder.LastIndexOf("\\") + 1, folder.Length - folder.LastIndexOf("\\") - 1);
                        string sourceLang = k.Substring(0, k.LastIndexOf("_"));
                        string targetLang = k.Substring(k.LastIndexOf("_") + 1, k.Length-k.LastIndexOf("_")-1);

                        if (Object.Equals(sourceLang, "TL") || Object.Equals(targetLang, "TL"))
                        {
                            Console.WriteLine("Miss TL language code for {0}\n", folder);
                            continue;
                        }

                        if (DoubleName.Contains(sourceLang))
                        {
                            sourceLang = DoubleName[sourceLang].ToString();
                        }
                        if (DoubleName.Contains(targetLang))
                        {
                            targetLang = DoubleName[targetLang].ToString();
                        }
                        
                        ProjectCreator process = new ProjectCreator();
                        process.Create(
                            folder,
                            projectName,
                            sourceLang,
                            targetLang);
                        
                        string sourcefolderPath =  tradosFolder + "\\" + projectName + "_" + sourceLang + "_" + targetLang + "\\" + sourceLang;
                        string tgtfolderPath = tradosFolder + "\\" + projectName + "_" + sourceLang + "_" + targetLang + "\\" + targetLang;
                        string destFolder = targetFolder + "\\" + projectName + "\\" + sourceLang + "_" + targetLang;
                        SearchFile(tgtfolderPath, destFolder);
                        DeleteSourceFile(sourcefolderPath);
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                    #endregion

                }
            }
        }

        #region "deleteFiles"
        private static void DeleteSourceFile(string sourcefolderPath)
        {
            try
            {
                foreach (string f in Directory.GetFiles(sourcefolderPath))
                {
                    File.Delete(f);
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region "MoveFiles"
        private static void SearchFile(string folderPath, string destFolder)
        {
            try
            {
                Directory.CreateDirectory(destFolder);
                foreach (string f in Directory.GetFiles(folderPath))
                {
                    string fileName = f.Substring(f.LastIndexOf("\\")+1);
                    string path1 = destFolder + "\\" + fileName;
                    if (fileName.EndsWith(".sdlxliff"))
                        File.Copy(f, path1);
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region "Function of getting all files"
        private static void GetFiles(string mainFolder)
        {
            try
            {
                foreach (String d in Directory.GetDirectories(mainFolder))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        addFiles(f);
                    }
                    GetFiles(d);
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region "CreateDoubleLanguageCode"
        private static void CreateDoubleName()
        {
            DoubleName.Add("AR-SA", "ar-SA");
            DoubleName.Add("BE", "be-BY");
            DoubleName.Add("BG", "bg-BG");
            DoubleName.Add("BN", "bn-IN");
            DoubleName.Add("CA", "ca-ES");
            DoubleName.Add("CS", "cs-CZ");
            DoubleName.Add("DA", "da-DK");
            DoubleName.Add("DE", "de-DE");
            DoubleName.Add("DE-AT", "de-AT");
            DoubleName.Add("EL", "el-GR");
            DoubleName.Add("EN-GB", "en-GB");
            DoubleName.Add("EN-US", "en-US");
            DoubleName.Add("ES", "es-ES");
            DoubleName.Add("ES-MX", "es-MX");
            DoubleName.Add("ES-XL", "es-MX");
            DoubleName.Add("ES-XM", "es-MX");
            DoubleName.Add("ET", "et-EE");
            DoubleName.Add("FI", "fi-FI");
            DoubleName.Add("FR", "fr-FR");
            DoubleName.Add("FR-CA", "fr-CA");
            DoubleName.Add("HE", "he-IL");
            DoubleName.Add("HI", "hi-IN");
            DoubleName.Add("HR", "hy-AM");
            DoubleName.Add("HY", "hr-HR");
            DoubleName.Add("HU", "hu-HU");
            DoubleName.Add("IN", "id-ID");
            DoubleName.Add("IS", "is-IS");
            DoubleName.Add("IT", "it-IT");
            DoubleName.Add("JA", "ja-JP");
            DoubleName.Add("KK", "kk-KZ");
            DoubleName.Add("KO", "ko-KR");
            DoubleName.Add("LT", "lt-LT");
            DoubleName.Add("LV", "lv-LV");
            DoubleName.Add("MS-MY", "ms-MY");
            DoubleName.Add("NL", "nl-NL");
            DoubleName.Add("NL-BE", "nl-BE");
            DoubleName.Add("NO-NO", "nb-NO");
            DoubleName.Add("PL", "pl-PL");
            DoubleName.Add("PT", "pt-PT");
            DoubleName.Add("PT-BR", "pt-BR");
            DoubleName.Add("RO", "ro-RO");
            DoubleName.Add("RU", "ru-RU");
            DoubleName.Add("SK", "sk-SK");
            DoubleName.Add("SL", "sl-SL");
            DoubleName.Add("SQ", "sq-AL");
            DoubleName.Add("SR", "sr-Cyrl-RS");
            DoubleName.Add("SV", "sv-SE");
            DoubleName.Add("TH", "th-TH");
            //DoubleName.Add("TL", "TL");
            DoubleName.Add("TR", "tr-TR");
            DoubleName.Add("TK", "tk-TM");
            DoubleName.Add("UK", "uk-UA");
            DoubleName.Add("VI", "vi-VN");
            DoubleName.Add("ZH-CN", "zh-CN");
            DoubleName.Add("ZH-HK", "zh-HK");
            DoubleName.Add("ZH-TW", "zh-TW");
        }
        #endregion



        private static void addFiles(string filePath)
        {
            string folder = filePath.Substring(0, filePath.LastIndexOf("\\"));
            string targetLang = folder.Substring(folder.LastIndexOf("_") + 1);
            string sourceLang = folder.Substring(folder.LastIndexOf("\\") + 1, folder.LastIndexOf("_") - folder.LastIndexOf("\\") - 1);

            if (Object.Equals(sourceLang, "TL") || Object.Equals(targetLang, "TL"))
            {
                Console.WriteLine("Miss TL language code for {0}\n", filePath);
                return;
            }

            if (DoubleName.Contains(sourceLang))
            {
                sourceLang = DoubleName[sourceLang].ToString();
            }
            if (DoubleName.Contains(targetLang))
            {
                targetLang = DoubleName[targetLang].ToString();
            }

            List<string> fileList;
            string key = sourceLang + "_" + targetLang;
            if (!ht.ContainsKey(key))
            {
                fileList = new List<string>();
                fileList.Add(filePath);
                ht.Add(key, fileList);

            }
            else
            {
                fileList = (List<string>)ht[key];
                fileList.Add(filePath);

            }

        }
    }

}
