using System.Windows.Controls;

namespace Workspace.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class Main : UserControl
    {
        public Main()
        {
            InitializeComponent();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            dataGrid.ScrollIntoView(dataGrid.SelectedItem);
        }

    }
}
