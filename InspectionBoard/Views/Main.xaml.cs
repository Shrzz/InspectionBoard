using MaterialDesignThemes.Wpf;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace InspectionBoard.Views
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        //public static Snackbar Snackbar = new Snackbar();

        public Main()
        {
            InitializeComponent();
            InitializeSnackbar();
        }


        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            dataGrid.ScrollIntoView(dataGrid.SelectedItem);
            dataGrid.Focus();
        }

        private void InitializeSnackbar()
        {
            /*Task.Factory.StartNew(() => Thread.Sleep(1000)).ContinueWith(t =>
            {
                MainSnackbar.MessageQueue?.Enqueue("Добро пожаловать");
            }, TaskScheduler.FromCurrentSynchronizationContext());

            var paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();

            Snackbar = MainSnackbar;*/
        }

        //private void OnSelectedItemChanged(object sender, DependencyPropertyChangedEventArgs e) => MainScrollViewer.ScrollToHome();

    }
}
