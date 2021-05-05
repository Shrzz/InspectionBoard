using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Exam : IEntity
    {
        public int Id { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        [Column(TypeName = "datetime2")]
        public Ticket Ticket { get; set; }
        public DateTime? Date { get; set; }
        public ExamType ExamType { get; set; }
        public ExamForm ExamForm { get; set; }
    }
}
