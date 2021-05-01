using InspectionBoardLibrary.Models.DatabaseModels;
using System.Collections.ObjectModel;
using System.Linq;

namespace InspectionBoardLibrary.Domain.Searchers
{
    public class SubjectSearcher : ISearcher<Subject>
    {
        public Subject Search(ObservableCollection<Subject> entities, string searchWord)
        {
            return entities.FirstOrDefault(s => s.Id.ToString().ToLower().Contains(searchWord.ToLower()) ||
                                                                 s.Name.ToString().ToLower().Contains(searchWord.ToLower())
                ) ?? entities.FirstOrDefault();
        }
    }
}
