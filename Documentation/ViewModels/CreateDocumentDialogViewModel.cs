using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.IO;

namespace Documentation.ViewModels
{
    public class CreateDocumentDialogViewModel : BindableBase, INavigationAware, IDialogAware
    {
        private readonly IDialogService dialogService;

        private string fileName;
        public string FileName
        {
            get => fileName;
            set { SetProperty(ref fileName, value); }
        }

        private string message;
        public string Message
        {
            get => message;
            set { SetProperty(ref message, value); }
        }

        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public CreateDocumentDialogViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
        }

        public string Title => "Создание документа";

        public event Action<IDialogResult> RequestClose;

        public virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                result = ButtonResult.OK;
            }
            else if (parameter?.ToLower() == "false")
            {
                result = ButtonResult.Cancel;
            }

            RaiseRequestClose(new DialogResult(result));
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }


        public bool CanCloseDialog() => true;

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnDialogClosed()
        {

        }

        public async void OnDialogOpened(IDialogParameters parameters)
        {
            var type = parameters.GetValue<string>("templateType");
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            app.Visible = false;
            object missing = Type.Missing;
            Microsoft.Office.Interop.Word.Document document = app.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            Microsoft.Office.Interop.Word.Paragraph p = document.Paragraphs.Add(ref missing);

            var context = new ExamContext();

            switch (type)
            {
                case "Students":
                    {
                        StudentRepository repository = new StudentRepository(context);
                        FileName = "Сведения о студентах.docx";
                        var list = await repository.SelectAsync();

                        if (list is null || list.Count < 1)
                        {
                            return;
                        }
                        foreach (var item in list)
                        {
                            p.Range.Text = item.GetFullDescription();
                            p.Range.InsertParagraphAfter();
                        }

                        break;
                    }
                case "Teachers":
                    {
                        TeacherRepository repository = new TeacherRepository(context);
                        FileName = "Сведения о преподавателях.docx";
                        var list = await repository.SelectAsync();

                        if (list is null || list.Count < 1)
                        {
                            return;
                        }
                        foreach (var item in list)
                        {
                            p.Range.Text = item.GetFullDescription();
                            p.Range.InsertParagraphAfter();
                        }
                        break;
                    }
                case "Subjects":
                    {
                        SubjectRepository repository = new SubjectRepository(context);
                        FileName = "Сведения о предметах.docx";
                        var list  = await repository.SelectAsync();

                        if (list is null || list.Count < 1)
                        {
                            return;
                        }
                        foreach (var item in list)
                        {
                            p.Range.Text = item.GetFullDescription();
                            p.Range.InsertParagraphAfter();
                        }

                        break;
                    }
                case "Exams":
                    {
                        ExamRepository repository = new ExamRepository(context);
                        FileName = "Сведения об экзаменах.docx";
                        var list  = await repository.SelectAsync();

                        if (list is null || list.Count < 1)
                        {
                            return;
                        }
                        foreach (var item in list)
                        {
                            p.Range.Text = item.GetFullDescription();
                            p.Range.InsertParagraphAfter();
                        }

                        break;
                    }
                case "Groups":
                    {
                        GroupRepository repository = new GroupRepository(context);
                        FileName = "Сведения о группах.docx";
                        var list = await repository.SelectAsync();

                        if (list is null || list.Count < 1)
                        {
                            return;
                        }
                        foreach (var item in list)
                        {
                            p.Range.Text = item.GetFullDescription();
                            p.Range.InsertParagraphAfter();
                        }

                        break;
                    }
                case "Tickets":
                    {
                        TicketRepository repository = new TicketRepository(context);
                        FileName = "Сведения о билетах.docx";
                        var list = await repository.SelectAsync();

                        if (list is null || list.Count < 1)
                        {
                            return;
                        }
                        foreach (var item in list)
                        {
                            p.Range.Text = item.GetFullDescription();
                            p.Range.InsertParagraphAfter();
                        }

                        break;
                    }
                default:
                    {
                        StudentRepository repository = new StudentRepository(context);
                        var list = await repository.SelectAsync();

                        if (list is null || list.Count < 1)
                        {
                            return;
                        }
                        foreach (var item in list)
                        {
                            p.Range.Text = item.GetFullDescription();
                            p.Range.InsertParagraphAfter();
                        }

                        return;
                    }
            }

            

            object filename = Directory.GetCurrentDirectory() + $"\\{FileName}";
            document.SaveAs2(ref filename, ref missing, ref missing, ref missing, ref missing);
            document.Close();
            app.Quit();
            Message = "Файл сохранён в : " + filename;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {



        }

        public void SwitchType(string type)
        {

        }
    }
}
