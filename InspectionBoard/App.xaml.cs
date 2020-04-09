using InspectionBoard.Views;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;

namespace InspectionBoard
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Main>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
