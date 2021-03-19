using InspectionBoardLibrary.FileHandlers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Windows.Forms;

namespace InspectionBoard.Dialogs
{
    public class DocsSettingsDialogViewModel : BindableBase, IDialogAware
    {
        private string title = "Настройки документов";
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string enrollmentReportTemplate;
        public string EnrollmentReportTemplate
        {
            get { return enrollmentReportTemplate; }
            set { SetProperty(ref enrollmentReportTemplate, value); }
        }

        private string enrollmentReports;
        public string EnrollmentReports
        {
            get { return enrollmentReports; }
            set { SetProperty(ref enrollmentReports, value); }
        }   

        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand<string> BrowseFilesCommand {get; private set; }
        public DelegateCommand<string> BrowseFoldersCommand { get; private set; }

        public DocsSettingsDialogViewModel()
        {
            DocumentsSettings.LoadSettings();
            BrowseFilesCommand = new DelegateCommand<string>(BrowseFiles);
            BrowseFoldersCommand = new DelegateCommand<string>(BrowseFolders);

        }

        protected virtual void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower() == "true")
            {
                result = ButtonResult.OK;
                DocumentsSettings.SaveSettings();
            }
            else
            {
                if (parameter?.ToLower() == "false")
                    result = ButtonResult.Cancel;
            }

            RaiseRequestClose(new Prism.Services.Dialogs.DialogResult(result));
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
           
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }

        private void BrowseFolders(string settingName)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DocumentsSettings.Settings[settingName] = dlg.SelectedPath;

            }
            UpdateViewProperties();
        }

        private void BrowseFiles(string settingName)
        {
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.Filter = "(*.docx)|*.docx";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DocumentsSettings.Settings[settingName] = dlg.FileName;
            }
        }

        private void UpdateViewProperties()
        {
            EnrollmentReportTemplate = DocumentsSettings.Settings["EnrollmentReportTemplate"];
            EnrollmentReportTemplate = DocumentsSettings.Settings["EnrollmentReportTemplate"];
            EnrollmentReports = DocumentsSettings.Settings["EnrollmentReports"];
        }
    }
}
