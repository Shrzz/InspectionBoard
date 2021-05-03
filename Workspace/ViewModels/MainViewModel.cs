using InspectionBoardLibrary.Database;
using InspectionBoardLibrary.DataSeeder;
using InspectionBoardLibrary.Models;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using InspectionBoardLibrary.Domain;

namespace Workspace.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string message;
        public string Message
        {
            get => message;
            set { SetProperty(ref message, value); }
        }

        private IDialogService dialogService;

        public MainViewModel(IDialogService dialogService)
        {
            Message = "message";
            this.dialogService = dialogService;
            ShowDialogCommand = new DelegateCommand(ShowDialog);
        }

        public DelegateCommand ShowDialogCommand { get; set; }

        public void ShowDialog()
        {
            var param = new DialogParameters();
            dialogService.Show("AddExamDialog", param, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    Message = "OK";
                }
                else
                {
                    Message = "Not OK";
                }
            });
        }

    }
}
