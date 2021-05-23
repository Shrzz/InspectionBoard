using InspectionBoardLibrary.Models.Database;
using System.Text;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Subject : AbstractEntity
    { 
        public string Name { get; set; }
        public int LectoryHours { get; set; }
        public int LaboratoryHours { get; set; }

        public override string GetShortDescription()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Идентификатор: {Id}\n");
            sb.Append($"Имя пользователя: {Name}\n");
            sb.Append($"Количество лекционных часов: {LectoryHours}\n");
            sb.Append($"Количество лабораторных \nи практических часов: {LaboratoryHours}\n");
            sb.Append("\n");

            return sb.ToString();
        }

        public override string GetFullDescription()
        {
            return GetShortDescription();
        }
    }
}
