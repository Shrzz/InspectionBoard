using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Journal
    {
        public int Id { get; set; }
        public Subject Subject { get; set; }
        public Student Student { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        public byte Mark { get; set; }
    }
}
