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
    public class JournalsViewModel : TablePage<Journal, ExamContext>
    {
        protected override string AddDialogName { get; set; }
        protected override string EditDialogName { get; set; }
        protected override string RemoveDialogName { get; set; }

        private ObservableCollection<Group> groups;
        public ObservableCollection<Group> Groups
        {
            get { return groups; }
            set { SetProperty(ref groups, value); }
        }

        private ObservableCollection<Subject> subjects;
        public ObservableCollection<Subject> Subjects
        {
            get { return subjects; }
            set { SetProperty(ref subjects, value); }
        }

        private Group selectedGroup;
        public Group SelectedGroup
        {
            get { return selectedGroup; }
            set { SetProperty(ref selectedGroup, value); }
        }

        private Subject selectedSubject;
        public Subject SelectedSubject
        {
            get { return selectedSubject; }
            set { SetProperty(ref selectedSubject, value); }
        }

        public JournalsViewModel(IDialogService service, IRepository<Journal> repository) : base(service, repository)
        {
            //this.repository.Searcher = new JournalSearcher();
            AddDialogName = "AddJournalDialog";
            EditDialogName = "EditJournalDialog";
            RemoveDialogName = "RemoveJournalDialog";
        }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var entities = await repository.SelectAsync();
            Groups = await (repository as JournalRepository).SelectGroups();
            Subjects = await (repository as JournalRepository).SelectSubjects();
            SelectedGroup = Groups[0];
            SelectedSubject = Subjects[0];
            if (SelectedGroup != null && SelectedSubject != null)
            {
                Entities = await (repository as JournalRepository).SelectCertainJournals(SelectedGroup.Id, SelectedSubject.Id);
            }
            else
            {
                Entities = new ObservableCollection<Journal>();
            }
            
        }

    }
}
