using PetCafe.API.APIModels;
using PetCafe.API.Data;

namespace PetCafe.API.Helpers
{
    public class EmployeeMapper
    {
        public IQueryable<EmployeeResponse> EmployeeDbToApi(IQueryable<Employee> employees)
        {
            return employees.Select(c => new EmployeeResponse
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                DaysWorked = (DateTime.Today.Date - c.StartDate.Date).Days+1,
                Cafe = c.CafeId.HasValue ? c.Cafe.Name : ""
            });
        }
    }
}
