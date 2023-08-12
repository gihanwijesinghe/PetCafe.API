using System.ComponentModel.DataAnnotations;

namespace PetCafe.API.Data
{
    public class Employee
    {
        [Key]
        [StringLength(9)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(8)]
        public int Phone { get; set; }

        [Required]
        public EmployeeGender EmployeeGender { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        public Cafe? Cafe { get; set; }
        public Guid? CafeId { get; set; }


    }

    public enum EmployeeGender
    {
        None = 0,
        Male = 1,
        Female = 2,
    }
}
