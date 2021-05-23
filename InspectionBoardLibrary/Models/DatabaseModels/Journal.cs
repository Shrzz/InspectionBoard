using InspectionBoardLibrary.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Journal : AbstractEntity
    {
        public Subject Subject { get; set; }
        public Student Student { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        public byte Mark { get; set; }

        public override string GetDescription()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Идентификатор: {Id}\n");
            sb.Append(GetValidString(Subject, "Предмет: ", "Name"));
            sb.Append(GetValidString(Student, "Студент: ", "Surname"));
            sb.Append($"Дата: {Date}\n");
            sb.Append($"Оценка: {Mark}\n");

            return sb.ToString();
        }
    }
}
