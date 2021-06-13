using Prism.Services.Dialogs;
using System.Windows;

namespace Workspace.Windows
{
    /// <summary>
    /// Логика взаимодействия для RemoveDialogWindow.xaml
    /// </summary>
    public partial class RemoveDialogWindow : Window, IDialogWindow
    {
        public RemoveDialogWindow()
        {
            InitializeComponent();
        }
        public IDialogResult Result { get; set; }
    }
}
