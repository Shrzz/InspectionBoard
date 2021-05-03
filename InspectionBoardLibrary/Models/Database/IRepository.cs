using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models.Database
{
    public interface IRepository<T> where T : class, IEntity
    {
        ISearcher<T> Searcher { get; set; }
        Task<ObservableCollection<T>> Select();
        Task<T> SelectSingle(int id);
        Task<T> SelectFirst();
        Task<T> Add(T entity);
        Task<T> Remove(int id);
        Task<T> Update(T entity);
        Task<ObservableCollection<int>> SelectIds();
    }
}
