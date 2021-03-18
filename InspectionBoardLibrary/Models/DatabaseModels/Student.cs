using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Student 
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public Faculty Faculty { get; set; }
        public EducationForm EducationForm { get; set; }

        public List<Exam> Exams { get; set; }
        public List<Retake> Retakes { get; set; }
    }
}
