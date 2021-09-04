using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using training.Models;

namespace training.modes
{
    public class Student
    {
        
        public int Id
        {
            get;
            set;
        } 
        public string Name
        {
            get;
            set;
        }
        public double Gpa
        {
            get;
            set;
        }
        public ICollection<StudentCourse> Courses { get; set; }






    }
}
