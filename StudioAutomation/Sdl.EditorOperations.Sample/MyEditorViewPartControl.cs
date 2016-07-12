using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.TranslationStudioAutomation.IntegrationApi.Actions;
using Sdl.Desktop.IntegrationApi;

namespace Sdl.EditorOperations.Sample
{
    public partial class MyEditorViewPartControl : UserControl
    {
        public MyEditorViewPartControl()
        {
            InitializeComponent();
            InitializeDocumentListTab();
            InitializeTrackingEventsTab();
            InitializeSelectionsTab();
        }

        #region GetEditorController

        private EditorController GetEditorController()
        {
            return SdlTradosStudio.Application.GetController<EditorController>();
        }

        #endregion

        #region DocumentsListView

        private void InitializeDocumentListTab()
        {
            EditorController editorController = GetEditorController();

            editorController.Opened += (s, e) => RepopulateDocumentList();
            editorController.Closed += (s, e) => RepopulateDocumentList();
            editorController.ActiveDocumentChanged += (s, e) => ActiveDocument = e.Document;            
        }

        private void RepopulateDocumentList()
        {
            EditorController editorController = GetEditorController();            
            DocumentsList.Items.Clear();
            foreach (Document document in editorController.GetDocuments())
            {
                string documentName = document.Files.Count() > 1 ? "Multiple merged files" : document.Files.First().Name;
                ListViewItem item = DocumentsList.Items.Add(documentName);
                item.SubItems.Add(document.SegmentPairs.Count().ToString());
                item.Tag = document;
                item.SubItems.Add(document.Project.GetProjectInfo().SourceLanguage.DisplayName);
                item.SubItems.Add(document.Project.GetProjectInfo().TargetLanguages[0].DisplayName);
            }

            ActiveDocument = editorController.ActiveDocument;
        }

        private void OpenUsingStudioActionButton_Click(object sender, EventArgs e)
        {
            SdlTradosStudio.Application.ExecuteAction<OpenDocumentAction>();
        }

        private void DocumentsList_ItemActivate(object sender, EventArgs e)
        {
            GetEditorController().Activate(DocumentsList.SelectedItems[0].Tag as Document);

            //keep the focus on the list items.
            SdlTradosStudio.Application.GetController<MyEditorViewPart>().Activate();
            DocumentsList.Focus();
        }

        private Document ActiveDocument
        {
            set
            {
                for (var i = 0; i < DocumentsList.Items.Count; i++)
                {
                    var item = DocumentsList.Items[i];
                    item.Selected = item.Tag as Document == value;
                }
            }
        }


        #endregion

        #region SaveCloseReplaceAll

        private void SaveAllButton_Click(object sender, EventArgs e)
        {
            SdlTradosStudio.Application.ExecuteAction<SaveAllDocumentsAction>();
        }

        private void CloseAllDocumentsButton_Click(object sender, EventArgs e)
        {
            EditorController editorController = GetEditorController();
            editorController.GetDocuments()
                            .ToList()
                            .ForEach(editorController.Close);
        }

        private void ReplaceAllButton_Click(object sender, EventArgs e)
        {
            var editorController = SdlTradosStudio.Application.GetController<EditorController>();
            editorController.Activate();

            if (editorController.ActiveDocument == null)
            {
                MessageBox.Show("There is no document loaded in the editor");
                return;
            }

            IEnumerable<Document> searchDocumentList =
                FindReplaceAllButton.Checked
                    ? editorController.GetDocuments()
                    : new List<Document> {editorController.ActiveDocument};

            string findText = FindText.Text;
            string replaceWith = ReplaceText.Text;
            if (string.IsNullOrEmpty(findText))
            {
                MessageBox.Show("Please provide a text to search.");
                return;
            }

            foreach (var doc in searchDocumentList)
            {
                //traverse in an updatable mode the segment pairs and perform replace
                doc.ProcessSegmentPairs("Find and replace", 
                    (segPair, eventArg) =>
                    {
                        foreach (IAbstractMarkupData markupData in segPair.Target)
                        {
                            var text = markupData as IText;
                            if (text != null)
                            {
                                text.Properties.Text =
                                    text.Properties.Text.Replace(findText,
                                                                    replaceWith);
                            }
                        }
                    });
            }
        }

        #endregion

        #region TrackingDocumentsEvents

        private void InitializeTrackingEventsTab()
        {
            EditorController editorController = GetEditorController();
            editorController.ActiveDocumentChanged +=
                (sender, args) =>
                AddListViewEvent("Active document changed", args.Document != null ? args.Document.Files.First().Name : string.Empty);

            editorController.Saving += (sender, args) => AddListViewEvent("Document saving", args.Document.Files.First().Name);
            editorController.Saved += (sender, args) => AddListViewEvent("Document saved", args.Document.Files.First().Name);
            editorController.SaveFailed += (sender, args) => AddListViewEvent("Document save failed", args.Document.Files.First().Name);

            editorController.Closing += (sender, args) =>
                AddListViewEvent("Document closing", args.Document != null ? args.Document.Files.First().Name : string.Empty);
            editorController.Closed += (sender, args) =>
                AddListViewEvent("Document closed", args.Document != null ? args.Document.Files.First().Name : string.Empty);
            editorController.Opening += (sender, args) =>
                AddListViewEvent("Document opening", args.Document != null ? args.Document.Files.First().Name : string.Empty);
            editorController.Opened += (sender, args) =>
                                           {
                                               //bind document events.
                                               InitializeDocumentTrackingEvents(args.Document);

                                               AddListViewEvent("Document opened",
                                                                args.Document != null
                                                                    ? args.Document.Files.First().Name
                                                                    : string.Empty);
                                           };            
        }

        private void InitializeDocumentTrackingEvents(Document doc)
        {
            doc.ActiveSegmentChanged += (o, eventArgs) => AddListViewEvent("ActiveSegmentChanged");
            doc.ContentChanged +=
                (sender, args) => AddListViewEvent("Document changed", args.Segments.First().ToString());

            
            doc.Selection.Changed +=
                (o, eventArgs) => AddListViewEvent("Document selection changed", doc.Selection.Current.ToString());
            doc.Selection.Source.Changed +=
                (o, eventArgs) =>
                AddListViewEvent("Source selection changed.", doc.Selection.Source.ToString());
            doc.Selection.Target.Changed +=
                (o, eventArgs) =>
                AddListViewEvent("Target selection changed.", doc.Selection.Target.ToString());

        }

        private void AddListViewEvent(string eventName, string eventMetadata = "")
        {
            var item = new ListViewItem(EventsListView.Items.Count.ToString());
            item.SubItems.Add(eventName);
            item.SubItems.Add(eventMetadata);
            EventsListView.Items.Insert(0, item);
        }

        #endregion

        #region HandlingSelections

        private void InitializeSelectionsTab()
        {
            EditorController editorController = GetEditorController();
            editorController.Opened += (sender, args) =>
                                           {
                                               args.Document.Selection.Changed +=
                                                   (o, eventArgs) =>
                                                   CurrentSelectionTextBox.Text = args.Document.Selection.Current.ToString();
                                           };
        }

        private void ReplaceSelectionButton_Click(object sender, EventArgs e)
        {
            var editorController = GetEditorController();
            Document doc = editorController.ActiveDocument;
            if (doc.Selection.Current as SourceSelection != null)
            {
                MessageBox.Show("The replace of a source selection is not available.");
                return;
            }

            doc.Selection.Target.Replace(ReplaceSelectionTextBox.Text, "Manual selection replacement");
            doc.Selection.Target.Collapse();
        }

        #endregion       
    }
}
