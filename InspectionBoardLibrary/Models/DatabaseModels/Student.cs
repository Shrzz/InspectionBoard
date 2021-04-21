using InspectionBoardLibrary.Database;
using InspectionBoardLibrary.Database.Domain;
using InspectionBoardLibrary.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public EducationForm EducationForm { get; set; }
        public Group Group { get; set; }

    }
}
