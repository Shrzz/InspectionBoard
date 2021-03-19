using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Workspace.ViewModels
{
    public class AnalysisViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        private string amount;
        public string Amount
        {
            get { return amount; }
            set { SetProperty(ref amount, value); }
        }

        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get { return students; }
            set { SetProperty(ref students, value); }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        public DelegateCommand ReturnCommand { get; private set; }
        public DelegateCommand AnalyzeCommand { get; private set; }
        public AnalysisViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            AnalyzeCommand = new DelegateCommand(Analyze);
            ReturnCommand = new DelegateCommand(Return);
        }

        private void Analyze()
        {
            if (Students == null)
            {
                Message = "Список абитуриентов пуст";
                MessageBox.Show("Список абитуриентов пуст", "Ошибка");
            }
            else if (Amount == null)
            {
                Message = "Число свободных мест не введено";
                MessageBox.Show("Введите число свободных мест", "Ошибка");
            }
            else
            {
                try
                {
                    int parsedValue;
                    bool success = int.TryParse(Amount, out parsedValue);
                    if (parsedValue <= 0 || !success)
                    {
                        Message = "Необходимо ввести корректные данные";
                    }
                    else
                    {
                        var list = new ObservableCollection<Student>(Students.OrderByDescending(s => s).ToList());
                        while (list.Count > int.Parse(Amount))
                        {
                            list.RemoveAt(list.Count - 1);
                        }

                        var parameters1 = new NavigationParameters
                        {
                            { "ApplicantsAnalyzed", list }
                        };
                        regionManager.RequestNavigate("ContentRegion", "Workspace", parameters1);
                    }
                }
                catch
                {
                    Message = "Произошла ошибка при анализе";
                    MessageBox.Show("Произошла ошибка при анализе", "Ошибка");
                }
            }
        }

        private void Return()
        {
            regionManager.RequestNavigate("ContentRegion", "Workspace");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Students = navigationContext.Parameters["Applicants"] as ObservableCollection<Student>;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
