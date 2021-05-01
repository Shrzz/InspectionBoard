using InspectionBoardLibrary.Models.DatabaseModels;
using System.Collections.ObjectModel;
using System.Linq;

namespace InspectionBoardLibrary.Domain.Searchers
{
    public class StudentSearcher : ISearcher<Student>
    {
        public Student Search(ObservableCollection<Student> entities, string searchWord)
        {
            return entities.FirstOrDefault(s => s.Id.ToString().ToLower().Contains(searchWord.ToLower()) ||
                                                                  s.Name.ToString().ToLower().Contains(searchWord.ToLower()) ||
                                                                  s.Surname.ToString().ToLower().Contains(searchWord.ToLower()) ||
                                                                  s.Patronymic.ToString().ToLower().Contains(searchWord.ToLower()) ||
                                                                  s.Group.Name.ToLower().Contains(searchWord.ToLower())
                 ) ?? entities.FirstOrDefault();
        }
    }
}
