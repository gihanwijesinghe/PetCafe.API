using PetCafe.API.APIModels;
using PetCafe.API.Data;

namespace PetCafe.API.Helpers
{
    public class CafeMapper
    {
        public IQueryable<CafeResponse> CafeDbToApi(IQueryable<Cafe> cafes)
        {
            return cafes.Select(c => new CafeResponse
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Location = c.Location,
                EmployeesCount = c.Employees.Count(),
            });
        }
    }
}
