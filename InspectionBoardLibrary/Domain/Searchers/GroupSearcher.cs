using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Domain.Searchers
{
    public class GroupSearcher : Searcher<Group>
    {
        public GroupSearcher(ObservableCollection<Group> entities, string searchWord) : base(entities, searchWord)
        {

        }

        public override Group Search()
        {
            return entities.FirstOrDefault(f => f.Name.ToLower().Contains(searchWord.ToLower())) ?? entities.FirstOrDefault();
        }
    }
}
