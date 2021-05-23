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

namespace InspectionBoardLibrary.Dialogs.TicketsDialogs
{
    public class AddTicketDialogViewModel : AddDialogViewModel<Ticket, ExamContext>
    {
        private Subject subject;
        public Subject Subject { get => subject; set { SetProperty(ref subject, value); } }

        private User user;
        public User User { get => user; set { SetProperty(ref user, value); } }

        private int number;
        public int Number { get => number; set { SetProperty(ref number, value); } }

        private string text;
        public string Text { get => text; set { SetProperty(ref text, value); } }

        private ObservableCollection<Subject> subjects;
        public ObservableCollection<Subject> Subjects
        {
            get => subjects;
            set { SetProperty(ref subjects, value); }
        }

        public AddTicketDialogViewModel(IRepository<Ticket> repository) : base(repository)
        {

        }

        public override async void OnDialogOpened(IDialogParameters parameters)
        {
            dialogParameters = parameters;
            Subjects = await (repository as TicketRepository).SelectSubjects();
        }

        public override void CloseDialog(string parameter)
        {
            Entity = new Ticket();
            Entity.Subject = Subject;
            Entity.User = User;
            Entity.Number = Number;
            Entity.Text = Text;

            base.CloseDialog(parameter);
        }
    }
}
