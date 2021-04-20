using InspectionBoardLibrary.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Exam 
    {
        public int Id { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? Date { get; set; } 
        public ExamType ExamType { get; set; }
        public ExamForm ExamForm { get; set; }
    }
}
