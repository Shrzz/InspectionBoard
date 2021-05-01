using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.Searchers;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Workspace.ViewModels;

namespace Workspace.Views
{
    /// <summary>
    /// Логика взаимодействия для Subjects.xaml
    /// </summary>
    public partial class Subjects : UserControl
    {
        public Subjects(IDialogService dialogService)
        {
            InitializeComponent();
            DataContext = new SubjectsViewModel(dialogService, new SubjectRepository(new ExamContext()), new SubjectSearcher());
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid.SelectedItem != null)
            {
                dataGrid.ScrollIntoView(dataGrid.SelectedItem);      
            }
        }
    }
}
