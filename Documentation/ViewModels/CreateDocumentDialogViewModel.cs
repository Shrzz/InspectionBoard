using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Models.Database;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.IO;

namespace Documentation.ViewModels
{
    public class CreateDocumentDialogViewModel : BindableBase, INavigationAware, IDialogAware
    {
        private readonly IDialogService dialogService;
        private IRepository<IEntity> repository;

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

        public CreateDocumentDialogViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }
        public string Title => "Создание документа";

        public event Action<IDialogResult> RequestClose;

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
                        repository = (IRepository<IEntity>)new StudentRepository(context);
                        FileName = "Сведения о студентах.docx";
                        break;
                    }
                case "Teachers":
                    {
                        repository = (IRepository<IEntity>)new TeacherRepository(context);
                        FileName = "Сведения о преподавателях.docx";
                        break;
                    }
                case "Subjects":
                    {
                        repository = (IRepository<IEntity>)new SubjectRepository(context);
                        FileName = "Сведения о предметах.docx";
                        break;
                    }
                case "Exams":
                    {
                        repository = (IRepository<IEntity>)new ExamRepository(context);
                        FileName = "Сведения об экзаменах.docx";

                        break;
                    }
                case "Groups":
                    {
                        repository = (IRepository<IEntity>)new GroupRepository(context);
                        FileName = "Сведения о группах.docx";
                        break;
                    }
                case "Tickets":
                    {
                        repository = (IRepository<IEntity>)new TicketRepository(context);
                        FileName = "Сведения о билетах.docx";
                        break;
                    }
                default:
                    {
                        return;
                    }
            }

            var list = await repository.SelectAsync();
            foreach (var item in list)
            {
                p.Range.Text = item.GetFullDescription();
                p.Range.InsertParagraphAfter();
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
    }
}
