namespace Sdl.SDK.ProjectAutomation.Samples.BatchAnaylze
{
    using System;
    using System.Globalization;
    using System.IO;
    using Sdl.Core.Globalization;
    using Sdl.Core.Settings;
    using Sdl.LanguagePlatform.TranslationMemoryApi;
    using Sdl.ProjectAutomation.Core;
    using Sdl.ProjectAutomation.FileBased;
    using Sdl.ProjectAutomation.Settings;

    public class ProjectCreator
    {
      
        #region "Create"
        #region "CreateMainFunction"
        /// <summary>
        /// Creates the actual project that is used as a container for
        /// the files to analyze. Triggers all subsequent helper function
        /// in sequence, i.e. adding the source files, the TM, configuring
        /// the task settings, and running the required tasks, 
        /// if required publishing the result to a project server
        /// </summary> 
        public void Create(
            string docFolder,
            string projectName,
            string sourceLang,
            string targetLang)
        #endregion

        {
            #region "RetrieveTmLanguages"

            string srcLocale = sourceLang;
            string trgLocale = targetLang;

            #endregion

            #region "newProject"

            FileBasedProject newProject = new FileBasedProject(this.GetProjectInfo(projectName,srcLocale, trgLocale));

            #endregion

            #region "CallAddFiles"

            this.AddFiles(newProject, docFolder, false);

            #endregion
        
            #region "CallConvert"
            this.ConvertFiles(newProject);
            #endregion

            #region "Save"
            newProject.Save();
            #endregion

        }
        #endregion

        #region "GetProjectInfo"
        #region "GetProjectInfoFunction"
        /// <summary>
        /// Configures the project information, i.e. the project location (folder), the project name,
        /// and the source/target language.
        /// </summary> 
        private ProjectInfo GetProjectInfo(string projectName, string srcLocale, string trgLocale)
        #endregion
        {
            #region "ProjectInfo"
            ProjectInfo info = new ProjectInfo();
            #endregion

            #region "ProjectName"
            info.Name = projectName + "_" + srcLocale + "_" + trgLocale;
            #endregion

            #region "ProjectFolder"
            string localProjectFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() +
                Path.DirectorySeparatorChar + @"Studio 2014\Projects\" + info.Name;
            info.LocalProjectFolder = localProjectFolder;
            #endregion

            #region "SetProjectSourceLanguage"
            Language srcLang = new Language(CultureInfo.GetCultureInfo(srcLocale));
            info.SourceLanguage = srcLang;
            #endregion

            #region "SetProjectTargetLanguage"
            Language[] trgLang = new Language[] { new Language(CultureInfo.GetCultureInfo(trgLocale)) };
            info.TargetLanguages = trgLang;
            #endregion

            #region "ReturnInfo"
            return info;
            #endregion
        }
        #endregion

        #region "Addfolder"
        /// <summary>
        /// Adds the files from the specified folder to the project and sets the file use, e.g. translatable or reference.            
        /// </summary> 
        #region "AddFilesFunction"
        private void AddFiles(FileBasedProject project, string folder, bool recursion)
        #endregion
        {
            #region "AddFolderWithFiles"
            project.AddFolderWithFiles(folder, recursion);
            #endregion

            #region "GetSourceLanguageFiles"
            ProjectFile[] projectFiles = project.GetSourceLanguageFiles();

            AutomaticTask scan = project.RunAutomaticTask(
                projectFiles.GetIds(),
                AutomaticTaskTemplateIds.Scan);
            #endregion
        }
        #endregion

        #region "ConvertAndCopy"
        /// <summary>
        /// Runs the two automatic tasks: Convert translatable files to a translatable format (i.e. SDL XLIFF)
        /// and creates target file copies.
        /// </summary> 
        private void ConvertFiles(FileBasedProject project)
        {
            #region "GetFilesForProcessing"
            ProjectFile[] files = project.GetSourceLanguageFiles();
            #endregion

            #region "RunConversion"
            for (int i = 0; i < project.GetSourceLanguageFiles().Length; i++)
            {
                if (files[i].Role == FileRole.Translatable)
                {
                    Guid[] currentFileId = { files[i].Id };
                    AutomaticTask convertTask = project.RunAutomaticTask(
                        currentFileId,
                        AutomaticTaskTemplateIds.ConvertToTranslatableFormat);

                    #region "CopyToTarget"
                    AutomaticTask copyTask = project.RunAutomaticTask(
                        currentFileId,
                        AutomaticTaskTemplateIds.CopyToTargetLanguages);
                    #endregion
                }
            }
            #endregion
        }
        #endregion

    }
}
