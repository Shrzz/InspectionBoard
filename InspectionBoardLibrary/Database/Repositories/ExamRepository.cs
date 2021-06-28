using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Repositories
{
    public class ExamRepository : EfRepository<Exam, ExamContext>
    {
        public ExamRepository(ExamContext context) : base(context)
        {
           
        }

        public override async Task<ObservableCollection<Exam>> SelectAsync()
        {
            var list = await context.Set<Exam>().Include(e => e.Student).Include(e => e.Student.Group).Include(e => e.Subject).Include(e => e.Teacher).ToListAsync();
            return new ObservableCollection<Exam>(list);
        }   

        public async Task<ObservableCollection<Student>> SelectStudents()
        {
            var collection = await context.Students.AsNoTracking().Include(e => e.Group).ToListAsync();
            return new ObservableCollection<Student>(collection);
        }

        public async Task<ObservableCollection<Teacher>> SelectTeachers()
        {
            var collection = await context.Teachers.AsNoTracking().ToListAsync();
            return new ObservableCollection<Teacher>(collection);
        }

        public async Task<ObservableCollection<Subject>> SelectSubjects()
        {
            var collection = await context.Subjects.AsNoTracking().ToListAsync();
            return new ObservableCollection<Subject>(collection);
        }
    
        public DbSet<Student> GetStudentsSet()
        {
            return context.Students;
        }

        public DbSet<Teacher> GetTEachersSet()
        {
            return context.Teachers;
        }

        public DbSet<Subject> GetSubjectsSet()
        {
            return context.Subjects;
        }
    }

}
