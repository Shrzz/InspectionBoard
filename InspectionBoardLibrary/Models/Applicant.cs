using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models
{
    public class Applicant: IComparable<Applicant>
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string BirthDate { get; set; }
        public string Mark { get; set; }
        public string Speciality { get; set; }

        public Applicant()
        {

        }

        public Applicant(int ID)
        {
            this.ID = ID;
        }

        public Applicant(int id, string name, string location, string birthDate, string mark, string speciality)
        {
            ID = id;
            Name = name;
            Location = location;
            BirthDate = birthDate;
            Mark = mark;
            Speciality = speciality;
        }

        public Applicant(string name, string location, string birthDate, string mark, string speciality)
        {
            Name = name;
            Location = location;
            BirthDate = birthDate;
            Mark = mark;
            Speciality = speciality;
        }

        public int CompareTo(Applicant other)
        {
            if (int.Parse(this.Mark) > int.Parse(other.Mark))
                return 1;
            if (int.Parse(this.Mark) < int.Parse(other.Mark))
                return -1;
            else return 0;
        }

    }
}
