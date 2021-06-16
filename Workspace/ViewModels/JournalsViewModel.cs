using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Linq;

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

        private ObservableCollection<DateTime> dates;
        public ObservableCollection<DateTime> Dates
        {
            get => dates;
            set
            {
                SetProperty(ref dates, value);
            }
        }

        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get => students;
            set
            {
                SetProperty(ref students, value);
            }
        }

        private ObservableCollection<byte> marks;
        public ObservableCollection<byte> Marks
        {
            get => marks;
            set
            {
                SetProperty(ref marks, value);
            }
        }

        private ObservableCollection<Journal> journals;
        public ObservableCollection<Journal> Journals
        {
            get => journals;
            set
            {
                SetProperty(ref journals, value);
            }
        }

        private ObservableCollection<GridItem> gridItems;
        public ObservableCollection<GridItem> GridItems
        {
            get => gridItems;
            set
            {
                SetProperty(ref gridItems, value);
            }
        }




        public JournalsViewModel(IDialogService service, IRegionManager regionManager, IRepository<Journal> repository) : base(service, regionManager, repository)
        {
            AddDialogName = "AddJournalDialog";
            EditDialogName = "EditJournalDialog";
            RemoveDialogName = "RemoveJournalDialog";
            RegionName = "Journals";
            GetRowsCommand = new DelegateCommand(GetRows);

            GridItems = new ObservableCollection<GridItem>();

        }

        public DelegateCommand GetRowsCommand { get; private set; }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var entities = await repository.SelectAsync();
            Groups = await (repository as JournalRepository).SelectGroupsAsync();
            Subjects = await (repository as JournalRepository).SelectSubjectsAsync();
            SelectedGroup = Groups.FirstOrDefault();
            SelectedSubject = Subjects.FirstOrDefault();
            if (SelectedGroup != null && SelectedSubject != null)
            {
                Entities = await (repository as JournalRepository).SelectCertainJournalsAsync(SelectedGroup.Id, SelectedSubject.Id);
            }
            else
            {
                Entities = new ObservableCollection<Journal>();
            }
        }

        private async void GetRows()
        {
            Journals = null;
            Journals = await (repository as JournalRepository).SelectCertainJournalsAsync(SelectedGroup.Id, SelectedSubject.Id);
            Dates = new ObservableCollection<DateTime>(Journals.Select(j => j.Date).Distinct().ToList());
            Students = new ObservableCollection<Student>(Journals.Select(j => j.Student).Distinct().ToList());
            Marks = new ObservableCollection<byte>(Journals.Select(j => j.Mark).Distinct().ToList());

            foreach (var student in Students)
            {
                GridItem item = new GridItem();
                item.StudentSurname = student.Surname;
                foreach (var journal in Journals)
                {
                    if (student.Surname == journal.Student.Surname)
                    {
                        item.AddToDictionary(journal.Date.Date, journal.Mark);
                    }
                }

                GridItems.Add(item);
            }
        }
    }

    public class GridItem
    {
        public string StudentSurname { get; set; }
        public Dictionary<DateTime, byte> Marks { get; set; }

        public GridItem()
        {
            Marks = new Dictionary<DateTime, byte>();
        }

        public GridItem(string surname)
        {
            this.StudentSurname = surname;
            Marks = new Dictionary<DateTime, byte>();
        }

        public GridItem(string surname, List<DateTime> dates, List<byte> marks)
        {
            this.StudentSurname = surname;
            Marks = new Dictionary<DateTime, byte>();
            for (int i = 0; i < dates.Count; i++)
            {
                Marks.Add(dates[i], marks[i]);
            }
        }

        public void AddToDictionary(DateTime date, byte mark)
        {
            Marks.Add(date, mark);
        }


    }
}
