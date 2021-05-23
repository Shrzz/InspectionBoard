using InspectionBoardLibrary.Models.Database;
using System.Text;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Teacher : AbstractEntity
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Category { get; set; }

        public override string GetShortDescription()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Преподаватель: \n");
            sb.Append($"Идентификатор: {Id}\n");
            sb.Append($"Фамилия: {Surname}\n");
            sb.Append($"Имя: {Name}\n");
            sb.Append($"Отчество: {Patronymic}\n");
            sb.Append($"Категория: {Category}\n");
            sb.Append("\n");

            return sb.ToString();
        }

        public override string GetFullDescription()
        {
            return GetShortDescription();
        }
    }
}
