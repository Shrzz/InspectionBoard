using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Repositories
{
    public class StudentRepository : EfRepository<Student, ExamContext>
    {
        public StudentRepository(ExamContext context) : base(context)
        {
            
        }

        public override async Task<ObservableCollection<Student>> SelectAsync()
        {
            return new ObservableCollection<Student>(await context.Set<Student>().Include(e => e.Group).OrderBy(e => e.Id).ToListAsync());
        }

        internal bool TableIsEmpty()
        {
            return !context.Students.Any();
        }

        public async Task<ObservableCollection<Group>> SelectGroupsAsync()
        {
            return new ObservableCollection<Group>(await context.Groups.ToListAsync());
        }


    }
}
