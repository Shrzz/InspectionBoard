using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
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
        public override async Task<ObservableCollection<Student>> Select()
        {
            var list = await context.Set<Student>().Include(e => e.Group).ToListAsync();
            return new ObservableCollection<Student>(list);
        }

        internal bool TableIsEmpty()
        {
            return !context.Students.Any();
        }

        public async Task<ObservableCollection<Group>> SelectGroups()
        {
            var collection = await context.Groups.ToListAsync();
            return new ObservableCollection<Group>(collection);
        }

    }
}
