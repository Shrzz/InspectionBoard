using System.Windows.Controls;

namespace Workspace.Views
{
    /// <summary>
    /// Логика взаимодействия для Faculties.xaml
    /// </summary>
    public partial class Groups : UserControl
    {
        public Groups()
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
    }
}
