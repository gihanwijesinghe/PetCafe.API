using PetCafe.API.Data;

namespace PetCafe.API.Helpers
{
    public class DataSeeder
    {
        public static async Task SeedCafes(CafeDbContext context)
        {
            if (!context.Cafes.Any())
            {
                var countries = new List<Cafe>
                {
                    new Cafe { 
                        Id = Guid.NewGuid(), 
                        Name = "Sizzle", 
                        Description = "European food", 
                        Location = "Colombo03",
                        Employees = new List<Employee>
                        {
                            new Employee
                            {
                                Id = "UI1234567",
                                Name = "Gihan",
                                Email = "gihan@gmail.com",
                                Phone = 81234567,
                                EmployeeGender = EmployeeGender.Male
                            }
                        }
                    },
                    new Cafe {
                        Id = Guid.NewGuid(),
                        Name = "MCDonald",
                        Description = "Burgers and food",
                        Location = "Colombo03",
                        Employees = new List<Employee>
                        {
                            new Employee
                            {
                                Id = "UI1234568",
                                Name = "Pradeep",
                                Email = "pradeep@gmail.com",
                                Phone = 81234568,
                                EmployeeGender = EmployeeGender.Male
                            },
                            new Employee
                            {
                                Id = "UI1234569",
                                Name = "Nuwan Sampath",
                                Email = "nuwan@gmail.com",
                                Phone = 81234569,
                                EmployeeGender = EmployeeGender.Male
                            }
                        }
                    },
                        
                    new Cafe { 
                        Id = Guid.NewGuid(),
                        Name = "PizzaHut", 
                        Description = "Pizzas and other", 
                        Location = "Colombo04",
                        Employees = new List<Employee>
                        {
                            new Employee
                            {
                                Id = "UI1234570",
                                Name = "Paba",
                                Email = "paba@gmail.com",
                                Phone = 81234570,
                                EmployeeGender = EmployeeGender.Female
                            }
                        }
                    },
                };

                context.AddRange(countries);
                await context.SaveChangesAsync();
            }
        }
    }
}
