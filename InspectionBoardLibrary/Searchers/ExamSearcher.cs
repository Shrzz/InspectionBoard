using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Domain.Searchers
{
    public class ExamSearcher : ISearcher<Exam>
    {
        public Exam Search(ObservableCollection<Exam> entities, string searchWord)
        {
            return entities.FirstOrDefault(e => e.Id.ToString().ToLower().Contains(searchWord.ToLower()) ||
                                                                 e.Student.Surname.ToString().ToLower().Contains(searchWord.ToLower()) ||
                                                                 e.Teacher.Surname.ToString().ToLower().Contains(searchWord.ToLower()) ||
                                                                 e.Date.ToString().ToLower().Contains(searchWord.ToLower())
                ) ?? entities.FirstOrDefault();
        }
    }
}
