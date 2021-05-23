using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models.Database
{
    public class AbstractEntity : IEntity
    {
        public int Id { get; set; }

        public virtual string GetShortDescription()
        {
            return "abstract entity description";
        }

        public virtual string GetFullDescription()
        {
            return "description of abstract entity and it's related entities";
        }

        public string GetValidString(IEntity o, string empty, string propName)
        {
            var result = o is null ? empty : empty + o.GetType().GetProperty(propName).GetValue(o);
            return result + "\n";
        }
    }
}
