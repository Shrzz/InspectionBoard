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
using Prism.Services.Dialogs;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.Searchers;
using InspectionBoardLibrary.Database.Contexts;
using System.Collections.ObjectModel;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Ioc;
using InspectionBoardLibrary.Domain.ViewModels.Pages;
using InspectionBoardLibrary.Database.Domain;

namespace Workspace.Views
{
    /// <summary>
    /// Логика взаимодействия для Exams.xaml
    /// </summary>
    public partial class Exams : UserControl
    {
        public Exams(IDialogService dialogService, IRepository<Exam> repository)
        {
            InitializeComponent();
            DataContext = new ExamsViewModel(dialogService, repository);
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
