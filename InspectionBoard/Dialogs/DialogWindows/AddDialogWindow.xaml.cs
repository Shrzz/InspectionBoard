using Prism.Services.Dialogs;
using System.Windows;

namespace InspectionBoard.Dialogs.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для AddDialogWindow.xaml
    /// </summary>
    public partial class AddDialogWindow : Window, IDialogWindow
    {
        public AddDialogWindow()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }
    }
}
