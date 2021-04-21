using InspectionBoardLibrary.Database.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Group : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
    }
}
