using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MySchool.Core.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateEnrolled { get; set; }
        public Address Address { get; set; }
        public int ClassSectionId { get; set; }
        public ClassSection ClassSection { get; set; }
        public ICollection<Photo> Photos { get; set; }

        public Student()
        {
            Photos = new Collection<Photo>();
        }
    }
}
