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
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.Searchers;
using InspectionBoardLibrary.Database.Contexts;

namespace Workspace.Views
{
    /// <summary>
    /// Логика взаимодействия для Faculties.xaml
    /// </summary>
    public partial class Groups : UserControl
    {
        public Groups(IDialogService dialogService)
        {
            InitializeComponent();
            DataContext = new GroupsViewModel(dialogService, new GroupRepository(new ExamContext()), new GroupSearcher());
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
