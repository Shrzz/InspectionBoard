using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models
{
    public class Retake
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public DateTime DateTime { get; set; }

    }
}
