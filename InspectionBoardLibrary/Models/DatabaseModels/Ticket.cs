using InspectionBoardLibrary.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Ticket : AbstractEntity
    { 
        public Subject Subject { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
        public int Number { get; set; }

        public override string GetShortDescription()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Билет: \n");
            sb.Append($"Идентификатор: {Id}\n");
            sb.Append(GetValidString(Subject, "Предмет: ", "Name"));
            sb.Append(GetValidString(User, "Создано пользователем: ", "Username"));
            sb.Append($"Текст билета: {Text}\n");
            sb.Append($"Номер билета: {Number}\n");
            sb.Append("\n");

            return sb.ToString();
        }

        public override string GetFullDescription()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(GetShortDescription());
            sb.Append(Subject.GetShortDescription());
            sb.Append(User.GetShortDescription());

            return sb.ToString();
        }
    }
}
