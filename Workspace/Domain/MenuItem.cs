using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Workspace.Domain
{
    public class MenuItem 
    {
        public string Name { get; }
        public string Region { get; }

        public MenuItem(string name, string region)
        {
            Name = name;
            Region = region;
        }
    }
}
