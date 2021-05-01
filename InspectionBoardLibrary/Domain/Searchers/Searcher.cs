using InspectionBoardLibrary.Database.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Domain.Searchers
{
    public abstract class Searcher<T>
        where T : class, IEntity
    {
        protected readonly ObservableCollection<T> entities;
        protected readonly string searchWord;

        public Searcher(ObservableCollection<T> entities, string searchWord)
        {
            this.entities = entities;
            this.searchWord = searchWord;
        }

        public abstract T Search();       
    }
}
