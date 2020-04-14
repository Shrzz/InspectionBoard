using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Models;

namespace Workspace.DBHandler
{
    public static class DataBase
    {
        private static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);




        public static List<string> GetSpecialitiesList()
        {
            connection.Open();
            string temp = "";
            SqlCommand command = new SqlCommand("select TABLE_NAME from iboard_db.information_schema.tables", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    temp += reader.GetString(0) + " ";
                }
            }
            connection.Close();
            string[] specs = temp.Split(' ');
            return specs.ToList<string>(); 
        }

        public static void DeleteSpeciality(string specName)
        {

        }

        public static List<string> GetApplicants(string speciality)
        {
            string result = "";
            connection.Open();
            
            SqlCommand command = new SqlCommand($"SELECT * FROM {speciality}", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result += reader.GetString(0) + " ";
                }
            }
            connection.Close();
            string[] temp = result.Split(' ');
            return temp.ToList<string>();
        } 
    }
}
