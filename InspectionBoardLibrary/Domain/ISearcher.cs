using InspectionBoardLibrary.Database.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Domain.Searchers
{
    public interface ISearcher<T>
        where T : class, IEntity
    {
        T Search(ObservableCollection<T> entities, string searchWord);         
    }
}
