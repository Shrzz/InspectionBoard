using InspectionBoard.Domain;
using System.Windows.Input;

namespace InspectionBoard.Dialogs.AddSpecialityDialog
{
    public class AddSpecialityDialogViewModel : ViewModel
    {
        private ICommand AddSpecialityCommand { get; }
        private ICommand CancelCommand { get; }

        private string specName;
        public string SpecName
        {
            get => specName;
            set => Set(ref specName, value);
        }

        public AddSpecialityDialogViewModel()
        {
            AddSpecialityCommand = new RelayCommand(AddSpeciality);
        }

        private void Cancel()
        {
            return;
        }


        private void AddSpeciality()
        {
            /*$"CREATE TABLE {specName}(
             * ID int NOT NULL
             * name nvarchar(MAX) null
             * birthYear nvarchar(MAX) null
             * location nvarchar(MAX) null
             * mark nvarchar(MAX) not null
             * speciality nvarchar(MAX) not null)
             */
        }


    }
}
