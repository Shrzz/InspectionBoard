using InspectionBoardLibrary.Database.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Subject : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LectoryHours { get; set; }
        public int LaboratoryHours { get; set; }
    }
}
