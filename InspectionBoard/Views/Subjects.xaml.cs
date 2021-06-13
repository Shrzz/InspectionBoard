using System.Windows.Controls;

namespace Workspace.Views
{
    /// <summary>
    /// Логика взаимодействия для Subjects.xaml
    /// </summary>
    public partial class Subjects : UserControl
    {
        public Subjects()
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
