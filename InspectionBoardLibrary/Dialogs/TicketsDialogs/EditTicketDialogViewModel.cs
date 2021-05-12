using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;

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
            Entities = await repository.Select();
            Entity = await repository.SelectFirst();
            Ids = await repository.SelectIds();
            if (Ids.Count > 0)
            {
                SelectedEntityId = Ids[0];
            }
            else
            {
                SelectedEntityId = -1;
            }

            Subjects = await(repository as TicketRepository).SelectSubjects();
        }

    }
}
