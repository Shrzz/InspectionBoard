using InspectionBoardLibrary.FileHandlers;
using InspectionBoardLibrary.Models;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Workspace.ViewModels
{
    public class DocsEnrollmentViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        private List<Applicant> applicants;
        public List<Applicant> Applicants
        {
            get { return applicants; }
            set { SetProperty(ref applicants, value); }
        }

        private List<string> names;
        public List<string> Names
        {
            get { return names; }
            set { SetProperty(ref names, value); }
        }

        private string selectedApplicant;
        public string SelectedApplicant
        {
            get { return selectedApplicant; }
            set { SetProperty(ref selectedApplicant, value); }
        }

        private bool isSinglePersonReport;
        public bool IsSinglePersonReport
        {
            get { return isSinglePersonReport; }
            set { SetProperty(ref isSinglePersonReport, value); }
        }

        private string groupName;
        public string GroupName
        {
            get { return groupName; }
            set { SetProperty(ref groupName, value); }
        }

        private string reportPath;
        public string ReportPath
        {
            get { return reportPath; }
            set { SetProperty(ref reportPath, value); }
        }

        public DelegateCommand ReturnCommand { get; private set; }
        public DelegateCommand CreateReportCommand { get; private set; }

        public DocsEnrollmentViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            ReturnCommand = new DelegateCommand(Return);
            CreateReportCommand = new DelegateCommand(CreateReport);
        }

        private void Return()
        {
            regionManager.RequestNavigate("ContentRegion", "Workspace");
        }

        private void CreateReport()
        {
            if (isSinglePersonReport)
            {
                if (SelectedApplicant != null)
                {
                    DocumentsHandler dh = new DocumentsHandler();
                    dh.CreateSingleEnrollmentReport(DocumentsSettings.Settings["EnrollmentReports"] + $"\\Приказ о зачислении ({SelectedApplicant}, {GroupName}).docx", GroupName, applicants.FirstOrDefault(c => c.Name == SelectedApplicant));
                }
            }
            else
            {
                if (applicants != null && applicants.Count > 0)
                {
                    DocumentsHandler dh = new DocumentsHandler();
                    dh.CreateEnrollmentReport(DocumentsSettings.Settings["EnrollmentReports"] + $"\\Приказ о зачислении ({applicants[0].Speciality}, {GroupName}).docx", applicants[0].Speciality, GroupName, applicants);
                    Return();
                }
                else
                {
                    MessageBox.Show("Список абитуриентов пуст");
                }
            }
            Return();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Applicants = navigationContext.Parameters["Applicants"] as List<Applicant>;
            if (Applicants != null && Applicants.Count > 0)
            {
                Names = new List<string>();
                foreach (var item in Applicants)
                {
                    Names.Add(item.Name);
                }

                SelectedApplicant = Names[0];
            }

        }
    }
}
