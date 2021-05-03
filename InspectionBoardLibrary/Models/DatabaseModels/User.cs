using InspectionBoardLibrary.Models.Database;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
