using System;
using System.Collections.Generic;
using System.Linq;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.DatabaseModels;

namespace InspectionBoardLibrary.FileHandlers
{
    public class DocumentsHandler
    {
        private Word.Application wordApp;
        private Word.Document doc;

        public void CreateEnrollmentReport(object reportPath, string spec, string group, List<Student> students)
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
                for (int i = 0; i < students.Count; i++)
                {
                    content.Text += i+ " " + students[i].Name + "\n";
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

        public void CreateSingleEnrollmentReport(object reportPath, string group, Student student)
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

                // добавить значения для вывода

                //var content = bookmarks[1].Range;
                //content.Text = student.BirthDate;
                //content = bookmarks[2].Range;
                //content.Text = DateTime.Now.ToLongDateString();
                //content = bookmarks[3].Range;
                //content.Text = group;
                //content = bookmarks[4].Range;
                //content.Text = student.Location;
                //content = bookmarks[5].Range;
                //content.Text = student.Mark;
                //content = bookmarks[6].Range;
                //content.Text += student.Name;
                //content = bookmarks[7].Range;
                //content.Text = student.Faculty.Name;
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
