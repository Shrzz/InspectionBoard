using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InspectionBoardLibrary.Models
{
    public class MenuItem 
    {
        public string Name { get; set; }
        public string Region { get; set; }

        public MenuItem(string name, string region)
        {
            Name = name;
            Region = region;
        }
    }
}
