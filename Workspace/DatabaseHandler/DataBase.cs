using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Workspace.DatabaseHandler;
using Workspace.Models;

namespace Workspace.DBHandler
{
    public static class DataBase
    {
        private static readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

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

        public static void AddApplicant(Applicant applicant)
        {
            using (ApplicantContext context = new ApplicantContext())
            {
                context.Applicants.Add(applicant);
                context.SaveChanges();
            }
        }

        public static void DeleteApplicant(int id)
        {
            var applicant = new Applicant { ID = id };

            using (ApplicantContext context = new ApplicantContext())
            {
                context.Applicants.Attach(applicant);
                context.Applicants.Remove(applicant);
                context.SaveChanges();
            }
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT COUNT(*) no, P2.ID FROM Applicants P1 JOIN Applicants P2 ON P1.ID <= P2.ID GROUP BY P2.ID;", connection);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public static void EditApplicant(Applicant a)
        {
            using (ApplicantContext context = new ApplicantContext())
            {
                var applicant = context.Applicants.Where(c => c.ID == a.ID).FirstOrDefault();
                applicant.Location = a.Location;
                applicant.Mark = a.Mark;
                applicant.Name = a.Name;
                applicant.Speciality = a.Speciality;
                applicant.BirthDate = a.BirthDate;
                context.SaveChanges();
            }
        }

        public static ObservableCollection<Applicant> GetApplicants()
        {
            using (ApplicantContext context = new ApplicantContext())
            {
                return new ObservableCollection<Applicant>(context.Applicants.ToList<Applicant>());
            }
        }

        public static List<User> GetUsers()
        {
            using (UserContext context = new UserContext())
            {
                return new List<User>(context.Users.ToList<User>());
            }
        }

        public static List<string> GetSpecialities()
        {
            using (ApplicantContext context = new ApplicantContext())
            {
                var temp = context.Applicants.ToList<Applicant>();
                var list = new List<string>();
                foreach (var item in temp)
                {
                    if (!list.Contains(item.Speciality))
                    {
                        list.Add(item.Speciality);
                    }
                }
                return list; 
            }
        }
    }
}
