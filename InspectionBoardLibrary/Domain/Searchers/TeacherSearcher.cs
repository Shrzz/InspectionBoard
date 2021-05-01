using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Domain.Searchers
{
    public class TeacherSearcher : Searcher<Teacher>
    {
        public TeacherSearcher(ObservableCollection<Teacher> entities, string searchWord) : base(entities, searchWord)
        {

        }

        public override Teacher Search()
        {
            return entities.FirstOrDefault(t => t.Id.ToString().ToLower().Contains(searchWord.ToLower()) ||
                                                                 t.Name.ToString().ToLower().Contains(searchWord.ToLower()) ||
                                                                 t.Surname.ToString().ToLower().Contains(searchWord.ToLower()) ||
                                                                 t.Patronymic.ToString().ToLower().Contains(searchWord.ToLower())
                ) ?? entities.FirstOrDefault();
        }
    }
}
