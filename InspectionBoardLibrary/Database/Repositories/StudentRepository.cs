using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Domain;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
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
