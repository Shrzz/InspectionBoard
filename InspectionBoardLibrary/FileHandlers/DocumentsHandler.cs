using System;
using System.Collections.Generic;
using System.Linq;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using InspectionBoardLibrary.Models;

namespace InspectionBoardLibrary.FileHandlers
{
    public class DocumentsHandler
    {
        private Word.Application wordApp;
        private Word.Document doc;

        public void CreateEnrollmentReport(object reportPath, string spec, string group, List<Applicant> applicants)
        {
            wordApp = new Word.Application();
            wordApp.ShowAnimation = false;
            wordApp.Visible = false;

            try
            {
                string templatePath = DocumentsSettings.Settings["EnrollmentReportTemplate"];
                doc = wordApp.Documents.Open(templatePath);
                
                var bookmarks = doc.Bookmarks;
                int bookmarksCount = bookmarks.Count;
                var content = bookmarks[1].Range;
                for (int i = 0; i < applicants.Count; i++)
                {
                    content.Text += i+ " " + applicants[i].Name + "\n";
                }
                content = bookmarks[2].Range;
                content.Text = DateTime.Now.ToLongDateString();
                content = bookmarks[3].Range;
                content.Text = group;
                content = bookmarks[4].Range;
                content.Text = spec;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при создании документа");
            }
            finally
            {
                try
                {
                    doc.SaveAs2(ref reportPath);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка при сохранении документа");
                }
                doc.Close();
                wordApp.Quit();
            }
            
        }

        public void CreateSingleEnrollmentReport(object reportPath, string group, Applicant applicant)
        {
            wordApp = new Word.Application();
            wordApp.ShowAnimation = false;
            wordApp.Visible = false;
            try
            {
                string templatePath = DocumentsSettings.Settings["SingleEnrollmentReportTemplate"];
                doc = wordApp.Documents.Open(templatePath);

                var bookmarks = doc.Bookmarks;
                int bookmarksCount = bookmarks.Count;
                var content = bookmarks[1].Range;
                content.Text = applicant.BirthDate;
                content = bookmarks[2].Range;
                content.Text = DateTime.Now.ToLongDateString();
                content = bookmarks[3].Range;
                content.Text = group;
                content = bookmarks[4].Range;
                content.Text = applicant.Location;
                content = bookmarks[5].Range;
                content.Text = applicant.Mark;
                content = bookmarks[6].Range;
                content.Text += applicant.Name;
                content = bookmarks[7].Range;
                content.Text = applicant.Speciality;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при создании документа");
            }
            finally
            {
                try
                {
                    doc.SaveAs2(ref reportPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка при сохранении документа");
                }
                finally
                {
                    if (wordApp != null)
                    {
                        if (doc != null)
                        {
                            doc.Close();
                        }
                        wordApp.Quit();
                    }
                }
            }
        }
    }
}
