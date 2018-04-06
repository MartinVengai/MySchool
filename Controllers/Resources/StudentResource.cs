using System;

namespace MySchool.Controllers.Resources
{
    public class StudentResource
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
        public AddressResource Address { get; set; }
        public KeyValuePairResource Class { get; set; }
        public KeyValuePairResource ClassSection { get; set; }
    }
}
