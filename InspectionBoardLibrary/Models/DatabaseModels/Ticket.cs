using InspectionBoardLibrary.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public Subject Subject { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
        public int Number { get; set; }
    }
}
