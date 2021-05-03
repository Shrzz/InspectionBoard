using InspectionBoardLibrary.Models.Database;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Teacher : IEntity
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Category { get; set; }

    }
}
