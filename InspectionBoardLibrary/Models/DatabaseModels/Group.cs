using InspectionBoardLibrary.Models.Database;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Group : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
    }
}
