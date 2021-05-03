using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models.Searchers
{
    public class TeacherSearcher : ISearcher<Teacher>
    {
        public Teacher Search(ObservableCollection<Teacher> entities, string searchWord)
        {
            return entities.FirstOrDefault(t => t.Id.ToString().ToLower().Contains(searchWord.ToLower()) ||
                                                                 t.Name.ToString().ToLower().Contains(searchWord.ToLower()) ||
                                                                 t.Surname.ToString().ToLower().Contains(searchWord.ToLower()) ||
                                                                 t.Patronymic.ToString().ToLower().Contains(searchWord.ToLower())
                ) ?? entities.FirstOrDefault();
        }
    }
}
