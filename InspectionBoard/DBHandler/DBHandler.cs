using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.DBHandler
{
    public class DBHandler
    {



        public List<string> GetGroupsList()
        {
            List<string> groups = new List<string>();
            //SELECT name FROM sys.databases  - из сервера
            //SELECT* FROM INFORMATION_SCHEMA.TABLES  - из бд
            return groups;

        } 



    }
}
