using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Dialogs.JournalDialogs
{
    public class EditJournalDialogViewModel : EditDialogViewModel<Journal, ExamContext>
    {
        // Entity properties
        private byte mark;
        public byte Mark { get => mark; set { SetProperty(ref mark, value); } }

        private Student student;
        public Student Student { get => student; set { SetProperty(ref student, value); } }

        private Subject subject;
        public Subject Subject { get => subject; set { SetProperty(ref subject, value); } }

        private DateTime date;
        public DateTime Date { get => date; set { SetProperty(ref date, value); } }

        // Values collections
        private ObservableCollection<Group> groups;
        public ObservableCollection<Group> Groups
        {
            get => groups;
            set { SetProperty(ref groups, value); }
        }

        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get => students;
            set { SetProperty(ref students, value); }
        }

        private ObservableCollection<Subject> subjects;
        public ObservableCollection<Subject> Subjects
        {
            get => subjects;
            set { SetProperty(ref subjects, value); }
        }

        public EditJournalDialogViewModel(IRepository<Journal> repository) : base(repository)
        {

        }

        public override async Task EditEntity()
        {
            if (Entity != null)
            {
                await repository.Update(Entity);
            }
        }

        public async override void OnDialogOpened(IDialogParameters parameters)
        {
            base.OnDialogOpened(parameters);
            Students = await (repository as JournalRepository).SelectStudentsAsync();
            Groups = await (repository as JournalRepository).SelectGroupsAsync();
            Subjects = await (repository as JournalRepository).SelectSubjectsAsync();

        }

        public override void CloseDialog(string parameter)
        {
            if (Entity != null)
            {
                Entity.Date = Date;
            }
            base.CloseDialog(parameter);
        }
    }
}
