using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.Enums;
using System.Text;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Student : AbstractEntity
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public EducationForm EducationForm { get; set; }
        public Group Group { get; set; }

        public override string GetDescription()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Идентификатор: {Id}\n");
            sb.Append($"Фамилия: {Surname}\n");
            sb.Append($"Имя: {Name}\n");
            sb.Append($"Отчество: {Patronymic}\n");
            sb.Append($"Форма образования: {EducationForm}\n");
            sb.Append(GetValidString(Group, $"Группа: ", "Name"));
            return sb.ToString();
        }
    }
}
