using System.ComponentModel.DataAnnotations;

namespace PetCafe.API.Data
{
    public class Cafe
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
