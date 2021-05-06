using InspectionBoardLibrary.Models.Database;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspectionBoardLibrary.Models.DatabaseModels
{
    public class Journal : IEntity
    {
        public int Id { get; set; }
        public Subject Subject { get; set; }
        public Student Student { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        public byte Mark { get; set; }
    }
}
