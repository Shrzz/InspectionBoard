using InspectionBoard.Domain;
using InspectionBoard.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using InspectionBoard.Dialogs.AddSpecialityDialog;
using Prism.Mvvm;
using Prism.Commands;

namespace InspectionBoard.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string message;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        private ObservableCollection<Applicant> applicants;
        public ObservableCollection<Applicant> Applicants
        {
            get { return applicants; }
            set { SetProperty(ref applicants, value); }
        }

        public DelegateCommand QuitCommand { get; set; }

        public MainViewModel()
        {
            QuitCommand = new DelegateCommand(Quit);
        }

        private void Quit()
        {
            Application.Current.Shutdown();
        }
    }
}
