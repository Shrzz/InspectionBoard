﻿using Prism.Ioc;
using Prism.Modularity;
using Tickets.ViewModels;
using Tickets.Views;

namespace Tickets
{
    public class TicketsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Main, MainViewModel>("Tickets");
        }
    }
}
