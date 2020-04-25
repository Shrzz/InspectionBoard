using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Workspace.Models;

namespace Workspace.DBHandler
{
    public static class DataBase
    {
        private static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);




        public static List<string> GetSpecialitiesList()
        {
            connection.Open();
            List<string> specs = new List<string>();
            SqlCommand command = new SqlCommand("select TABLE_NAME from iboard_db.information_schema.tables", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    specs.Add(reader.GetString(0));
                }
            }
            connection.Close();
            return specs; 
        }

        public static void AddApplicant(string specName, Applicant applicant)
        {
            using (ApplicantContext context = new ApplicantContext())
            {
                context.Applicants.Add(applicant);
                context.SaveChanges();
            }


               /* connection.Open();
            SqlCommand command = new SqlCommand($"INSERT {specName} (ID, Name, BirthDate, Location, Mark, Speciality) VALUES " +
                $"({applicant.ID},{applicant.Name},{applicant.BirthDate},{applicant.Location},{applicant.Mark},{applicant.Speciality})", connection);
            command.ExecuteNonQuery();
            connection.Close();*/
        }

        public static void DeleteApplicant(string specName, Applicant applicant)
        {
            connection.Open();
            SqlCommand command = new SqlCommand($"DELETE {specName} WHERE ID = {applicant.ID}");
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static ObservableCollection<Applicant> GetApplicants(string speciality)
        {
            connection.Open();
            ObservableCollection<Applicant> applicants = new ObservableCollection<Applicant>();
            SqlCommand command = new SqlCommand($"SELECT * FROM {speciality}", connection);
            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Applicant a = new Applicant();
                    while (reader.Read())
                    {
                        a.ID = reader.GetInt32(0);
                        a.Name = reader.GetString(1);
                        a.Location = reader.GetString(2);
                        a.BirthDate = reader.GetString(3);
                        a.Mark = reader.GetString(4);
                        a.Speciality = reader.GetString(5);
                    }
                    applicants.Add(a);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
            return applicants;
        } 

        public static void AddApplicant(string name, string location, string birthDate, string mark, string speciality)
        {

        }
    }
}
