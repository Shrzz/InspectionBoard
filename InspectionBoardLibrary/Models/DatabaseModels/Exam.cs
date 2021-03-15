using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public ExamType ExamType { get; set; }
        public ExamForm ExamForm { get; set; }
        public DateTime Date { get; set; }
        public int Mark { get; set; }
    }
}
