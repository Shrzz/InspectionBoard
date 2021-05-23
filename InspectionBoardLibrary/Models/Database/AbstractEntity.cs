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

        public virtual string GetDescription()
        {
            return "abstract entity";
        }

        public string GetValidString(IEntity o, string empty, string propName)
        {
            var result = o is null ? empty : empty + o.GetType().GetProperty(propName).GetValue(o);
            return result + "\n";
        }
    }
}
