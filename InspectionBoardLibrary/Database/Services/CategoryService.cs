using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Services
{
    public class CategoryService : IDatabaseService<Category>
    {
        public async Task AddAsync(Category o)
        {
            using (ExamContext context = new ExamContext())
            {
                context.Categories.Add(o);
                await context.SaveChangesAsync();
            }
        }

        public Task EditAsync(Category o)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> Select()
        {
            throw new NotImplementedException();
        }

        public List<int> SelectIds()
        {
            throw new NotImplementedException();
        }

        public bool TableIsEmpty()
        {
            using (ExamContext context = new ExamContext())
            {
                return !context.Categories.Any();
            }
        }
    }
}
