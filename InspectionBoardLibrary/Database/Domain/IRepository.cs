using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Domain
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<ObservableCollection<T>> Select();
        Task<T> SelectSingle(int id);
        Task<T> SelectFirst();
        Task<T> Add(T entity);
        Task<T> Remove(int id);
        Task<T> Update(T entity);
        Task<ObservableCollection<int>> SelectIds();
    }
}
