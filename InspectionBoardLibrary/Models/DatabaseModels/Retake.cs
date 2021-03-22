using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Retake 
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? DateTime { get; set; }

    }
}
