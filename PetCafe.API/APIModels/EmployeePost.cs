using PetCafe.API.Data;
using System.ComponentModel.DataAnnotations;

namespace PetCafe.API.APIModels
{
    public class EmployeePost : EmployeeBase
    {
        [Required]
        public EmployeeGender Gender { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public Guid? CafeId { get; set; }
    }
}
