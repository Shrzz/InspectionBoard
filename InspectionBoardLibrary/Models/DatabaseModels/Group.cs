using InspectionBoardLibrary.Models.Database;
using System.Collections.Generic;
using System.Text;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Group : AbstractEntity
    {
        public string Name { get; set; }
        public string Faculty { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public override string GetShortDescription()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Группа: ");
            sb.Append($"Идентификатор: {Id}\n");
            sb.Append($"Код группы: {Name}\n");
            sb.Append($"Факультет: {Faculty}\n");
            sb.Append("\n");

            return sb.ToString();
        }

        public override string GetFullDescription()
        {
            return GetShortDescription();
        }

    }
}
