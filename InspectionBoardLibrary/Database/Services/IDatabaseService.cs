using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Services
{
    public interface IDatabaseService<T>
    {
        List<int> SelectIds();
        List<T> Select();
        Task EditAsync(T o);
        Task AddAsync(T o);
        Task RemoveAsync(int id);
    }
}
