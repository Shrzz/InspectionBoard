using InspectionBoardLibrary.Models.DatabaseModels;
using System.Collections.ObjectModel;
using System.Linq;

namespace InspectionBoardLibrary.Domain.Searchers
{
    public class StudentSearcher : Searcher<Student>
    {
        public StudentSearcher(ObservableCollection<Student> entities, string searchWord) : base(entities, searchWord)
        {

        }

        public override Student Search()
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
