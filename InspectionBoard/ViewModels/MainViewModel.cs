using InspectionBoard.Domain;
using InspectionBoard.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using InspectionBoard.Dialogs.AddSpecialityDialog;

namespace InspectionBoard.ViewModels
{
    public class MainViewModel : ViewModel
    {
        public event EventHandler<ExitEventArgs> OnClosing;

        public ICommand CloseAppCommand { get; }
        public ICommand AddSpecialityCommand { get; }

        public MainViewModel()
        {
            AddSpecialityCommand = new RelayCommand(AddSpeciality);
            CloseAppCommand = new RelayCommand(CloseApp);
        }

        private ObservableCollection<Applicant> applicants = new ObservableCollection<Applicant>()
        {
            new Applicant(0,"name1","location1","birthDate1","mark1","specoality1")
        };

        public ObservableCollection<Applicant> Applicants
        {
            get => applicants;
            set => Set(ref applicants, value);
        }

        private string message;
        public string Message
        {
            get => message;
            set => Set(ref message, value);
        }







        private void AddSpeciality()
        {
            AddSpecialityDialogViewModel tempVM = new AddSpecialityDialogViewModel();
            AddSpecialityView tempView = new AddSpecialityView() { DataContext = tempVM };
            tempView.ShowDialog();
        }
 
    




        private void CloseApp()
        {
            Application.Current.Shutdown();
        }
    }
}
