using InspectionBoardLibrary.Models.Database;
using System.Text;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class User : AbstractEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public override string GetShortDescription()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Идентификатор: {Id}\n");
            sb.Append($"Имя пользователя: {Username}\n");
            sb.Append($"Пароль: {Password}\n");
            sb.Append("\n");

            return sb.ToString();
        }

        public override string GetFullDescription()
        {
            return GetShortDescription();
        }
    }
}
