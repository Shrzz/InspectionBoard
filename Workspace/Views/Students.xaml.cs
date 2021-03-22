using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Workspace.Views
{
    /// <summary>
    /// Логика взаимодействия для Students.xaml
    /// </summary>
    public partial class Students : UserControl
    {
        public Students()
        {
            InitializeComponent();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid.SelectedItem != null)
            {
                dataGrid.ScrollIntoView(dataGrid.SelectedItem);
            }
        }

        private void dg_Sorting(object sender, DataGridSortingEventArgs e)
        {
            switch (e.Column.Header.ToString())
            {
                case "Идентификатор":
                    {
                        if (e.Column.SortDirection == ListSortDirection.Ascending || e.Column.SortDirection == null)
                        {
                            dg.ItemsSource = new ObservableCollection<Student>(from item in (ObservableCollection<Student>)dg.ItemsSource
                                                                               orderby item.Id descending
                                                                               select item);
                            e.Column.SortDirection = ListSortDirection.Descending;
                        }
                        else
                        {
                            dg.ItemsSource = new ObservableCollection<Student>(from item in (ObservableCollection<Student>)dg.ItemsSource
                                                                               orderby item.Id ascending
                                                                               select item);
                            e.Column.SortDirection = ListSortDirection.Ascending;
                        }
                        
                        e.Handled = true;
                        break;
                    }
                case "Фамилия":
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
