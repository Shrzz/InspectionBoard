using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InspectionBoardLibrary.Database.Domain;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace InspectionBoardLibrary.Database.Repositories
{
    public class GroupRepository : EfRepository<Group, ExamContext>
    {
        public GroupRepository(ExamContext context) : base(context)
        {

        }

        internal bool TableIsEmpty()
        {
            return !context.Groups.Any();
        }
    }
}
