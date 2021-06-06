using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using System.Linq;

namespace InspectionBoardLibrary.Dialogs.TicketsDialogs
{
    public class EditTicketDialogViewModel : EditDialogViewModel<Ticket, ExamContext>
    {
        private ObservableCollection<Subject> subjects;
        public ObservableCollection<Subject> Subjects
        {
            get => subjects;
            set { SetProperty(ref subjects, value); }
        }

        public EditTicketDialogViewModel(IRepository<Ticket> repository) : base(repository)
        {

        }

        public async override void OnDialogOpened(IDialogParameters parameters)
        {
            base.OnDialogOpened(parameters);
            Subjects = await(repository as TicketRepository).SelectSubjects();
        }

    }
}
