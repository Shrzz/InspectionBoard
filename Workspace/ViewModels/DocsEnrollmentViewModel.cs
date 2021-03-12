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

        private List<Student> students;
        public List<Student> Students
        {
            get { return students; }
            set { SetProperty(ref students, value); }
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
                    dh.CreateSingleEnrollmentReport(DocumentsSettings.Settings["EnrollmentReports"] + $"\\Приказ о зачислении ({SelectedApplicant}, {GroupName}).docx", GroupName, students.FirstOrDefault(c => c.Name == SelectedApplicant));
                }
            }
            else
            {
                if (students != null && students.Count > 0)
                {
                    DocumentsHandler dh = new DocumentsHandler();
                    dh.CreateEnrollmentReport(DocumentsSettings.Settings["EnrollmentReports"] + $"\\Приказ о зачислении ({students[0].Faculty.Name}, {GroupName}).docx", students[0].Faculty.Name, GroupName, students);
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
            Students = navigationContext.Parameters["Applicants"] as List<Student>;
            if (Students != null && Students.Count > 0)
            {
                Names = new List<string>();
                foreach (var item in Students)
                {
                    Names.Add(item.Name);
                }

                SelectedApplicant = Names[0];
            }

        }
    }
}
