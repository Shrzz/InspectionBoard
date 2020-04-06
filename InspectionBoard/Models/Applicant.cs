using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.Models
{
    public class Applicant
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string BirthDate { get; set; }
        public string Mark { get; set; }
        public string Speciality { get; set; }

        public Applicant()
        {

        }

        public Applicant(int id, string name, string location, string birthDate, string mark, string speciality)
        {
            ID = id;
            Name = name;
            BirthDate = birthDate;
            Location = location;
            Mark = mark;
            Speciality = speciality;
        }

    }
}
