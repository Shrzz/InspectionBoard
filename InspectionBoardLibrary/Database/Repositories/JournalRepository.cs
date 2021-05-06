using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Repositories
{
    public class JournalRepository : EfRepository<Journal, ExamContext>
    {
        public JournalRepository(ExamContext context) : base(context)
        {

        }

        public async Task<ObservableCollection<Group>> SelectGroups()
        {
            var collection = await context.Groups.ToListAsync();
            return new ObservableCollection<Group>(collection);
        }

        public async Task<ObservableCollection<Subject>> SelectSubjects()
        {
            var collection = await context.Subjects.ToListAsync();
            return new ObservableCollection<Subject>(collection);
        }

        public async Task<ObservableCollection<Journal>> SelectCertainJournals(int groupId, int subjectId)
        {
            var collection = await context.Journals.Where(e => e.Student.Group.Id == groupId && e.Subject.Id == subjectId).OrderBy(e => e.Date).ToListAsync();
            return new ObservableCollection<Journal>(collection);
        }
    }
}
