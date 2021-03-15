using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Lectory_hours { get; set; }
        public int Laboratory_hours { get; set; }

        public List<Exam> Exams { get; set; }
    }
}
