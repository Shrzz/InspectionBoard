using InspectionBoardLibrary.Models.Database;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Subject : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LectoryHours { get; set; }
        public int LaboratoryHours { get; set; }
    }
}
