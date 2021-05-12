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
            base.OnDialogOpened(parameters);
            Subjects = await (repository as TicketRepository).SelectSubjects();
            Entity = new Ticket();
            Entity.Subject = Subjects.FirstOrDefault();
            Entity.Number = 1;
        }
    }
}
