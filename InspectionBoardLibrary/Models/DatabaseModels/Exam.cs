using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.Enums;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Exam : AbstractEntity
    { 
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        [Column(TypeName = "datetime2")]
        public Ticket Ticket { get; set; }
        public DateTime? Date { get; set; }
        public ExamType ExamType { get; set; }
        public ExamForm ExamForm { get; set; }

        public override string GetShortDescription()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Экзамен: ");
            sb.Append("Идентификатор: {Id}\n");
            sb.Append(GetValidString(Subject, $"Предмет: ", "Name"));
            sb.Append(GetValidString(Teacher, $"Преподаватель: ", "Surname"));
            sb.Append(GetValidString(Student, $"Студент: ", "Surname"));
            sb.Append(GetValidString(Ticket, $"Билет: ", "Number"));
            sb.Append($"Дата проведения: {Date}\n");
            sb.Append($"Тип экзамена: {ExamType}\n");
            sb.Append($"Форма проведения экзамена: {ExamForm}\n");

            return sb.ToString();
        }

        public override string GetFullDescription()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(GetShortDescription());
            sb.Append(Subject.GetShortDescription());
            sb.Append(Teacher.GetShortDescription());
            sb.Append(Student.GetShortDescription());
            sb.Append(Ticket.GetShortDescription());

            return sb.ToString();
        }
    }
}
