using System.ComponentModel.DataAnnotations;

namespace PetCafe.API.APIModels
{
    public class EmployeeBase
    {
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public int Phone { get; set; }
    }
}
