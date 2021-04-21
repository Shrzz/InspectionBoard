using InspectionBoardLibrary.Models.DatabaseModels;
using System.Collections.ObjectModel;
using System.Linq;

namespace InspectionBoardLibrary.Domain.Searchers
{
    public class SubjectSearcher : Searcher<Subject>
    {
        public SubjectSearcher(ObservableCollection<Subject> entities, string searchWord) : base(entities, searchWord)
        {

        }

        public override Subject Search()
        {
            return entities.FirstOrDefault(s => s.Id.ToString().ToLower().Contains(searchWord.ToLower()) ||
                                                                 s.Name.ToString().ToLower().Contains(searchWord.ToLower())
                ) ?? entities.FirstOrDefault();
        }
    }
}
