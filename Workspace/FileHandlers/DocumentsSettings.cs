using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Prism.Mvvm;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.Entity.Infrastructure.DependencyResolution;

namespace Workspace.FileHandlers
{
    public static class DocumentsSettings 
    {
        public static Dictionary<string, string> Settings { get; set; }
        private static readonly string settingsPath = Directory.GetCurrentDirectory() + "\\settings.txt";
        private static bool loaded;

        static DocumentsSettings()
        {
            Settings = new Dictionary<string, string>();
        }

        public static void LoadSettings()
        {
            if (loaded)
            {
                using (StreamReader reader = new StreamReader(settingsPath))
                {
                    var setArray = reader.ReadToEnd().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    Settings["EnrollmentReportTemplate"] = setArray[0];
                    Settings["SingleEnrollmentReportTemplate"] = setArray[1];
                    Settings["EnrollmentReports"] = setArray[2];
                }
            }
            else
            {
                using (StreamReader reader = new StreamReader(settingsPath))
                {
                    var setArray = reader.ReadToEnd().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    Settings.Add("EnrollmentReportTemplate", setArray[0]);
                    Settings.Add("SingleEnrollmentReportTemplate", setArray[1]);
                    Settings.Add("EnrollmentReports", setArray[2]);
                    loaded = true;
                }
            }
        }

        public static void SaveSettings()
        {
            using (StreamWriter writer = new StreamWriter(settingsPath, false))
            {
                writer.WriteLine(Settings["EnrollmentReportTemplate"]);
                writer.WriteLine(Settings["SingleEnrollmentReportTemplate"]);
                writer.WriteLine(Settings["EnrollmentReports"]);
            }
        }
    }
}
