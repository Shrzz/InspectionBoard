using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;

namespace Workspace.ViewModels
{
    public class TicketsViewModel : TablePage<Ticket, ExamContext>
    {
        protected override string AddDialogName { get; set; }
        protected override string EditDialogName { get; set; }
        protected override string RemoveDialogName { get; set; }

        private ObservableCollection<Subject> subjects;
        public ObservableCollection<Subject> Subjects
        {
            get => subjects;
            set { SetProperty(ref subjects, value); }
        }

        private Subject selectedSubject;
        public Subject SelectedSubject
        {
            get => selectedSubject;
            set { SetProperty(ref selectedSubject, value); }
        }


        public TicketsViewModel(IDialogService service, IRepository<Ticket> repository) : base(service, repository)
        {
            AddDialogName = "AddTicketDialog";
            EditDialogName = "EditTicketDialog";
            RemoveDialogName = "RemoveTicketDialog";
        }

        public async override void OnNavigatedTo(NavigationContext navigationContext)
        {
            var entities = await repository.SelectAsync();
            Entities = new ObservableCollection<Ticket>(entities);
            Subjects = await (repository as TicketRepository).SelectSubjects();
        }


    }
}
