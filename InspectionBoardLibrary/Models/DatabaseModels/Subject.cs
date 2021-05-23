using InspectionBoardLibrary.Models.Database;
using System.Text;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Subject : AbstractEntity
    { 
        public string Name { get; set; }
        public int LectoryHours { get; set; }
        public int LaboratoryHours { get; set; }

        public override string GetDescription()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Идентификатор: {Id}\n");
            sb.Append($"Имя пользователя: {Name}\n");
            sb.Append($"Количество лекционных часов: {LectoryHours}\n");
            sb.Append($"Количество лабораторных и практических часов:{LaboratoryHours}");

            return sb.ToString();
        }
    }
}
