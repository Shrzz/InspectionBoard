using Prism.Services.Dialogs;
using System.Windows;

namespace InspectionBoard.Dialogs.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для EditDialogWindow.xaml
    /// </summary>
    public partial class EditDialogWindow : Window, IDialogWindow
    {
        public EditDialogWindow()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }

    }
}
