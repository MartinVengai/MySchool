using System.ComponentModel.DataAnnotations;

namespace MySchool.Controllers.Resources
{
    public class AddressResource
    {
        [Required]
        [StringLength(255)]
        public string Street { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }

        [StringLength(255)]
        public string Country { get; set; }

        [Required]
        [StringLength(10)]
        public string Zip { get; set; }
    }
}