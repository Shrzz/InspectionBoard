using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.Enums;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public EducationForm EducationForm { get; set; }
        public Group Group { get; set; }

    }
}
