using InspectionBoardLibrary.Database;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.DataSeeder
{
    public class DataSeeder
    {
        public async void AddAdminUser()
        {
            User u = new User();
            u.Username = "admin";
            u.Password = "admin";
            await Dbc.AddUser(u);
        }

        public async void AddStudent()
        {
            Student s = new Student();
            s.Id = 0;
            s.Name = "Студент1";
            s.Surname = "Фамилия1";
            s.Patronymic = "Отчество1";
            s.Retakes = null;
            s.Exams = null;
            Faculty faculty = new Faculty();
            faculty.Name = "Факультет1";            
            s.Faculty = faculty;
            EducationForm form = new EducationForm();
            form.Form = "Бюджетная";
            s.EducationForm = form;
            await Dbc.AddStudent(s);
        }
    }
}
