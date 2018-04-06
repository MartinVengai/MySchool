using System;
using System.ComponentModel.DataAnnotations;

namespace MySchool.Controllers.Resources
{
    public class SaveStudentResource
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(6)]
        public string Sex { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [Required]
        [StringLength(255)]
        public string IdNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateEnrolled { get; set; }

        public AddressResource Address { get; set; }

        [Required]
        public int ClassSectionId { get; set; }
    }
}
