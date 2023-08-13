using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCafe.API.APIModels;
using PetCafe.API.Data;
using PetCafe.API.Helpers;

namespace PetCafe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly CafeDbContext _context;
        private readonly EmployeeMapper _mapper;

        public EmployeesController(CafeDbContext context, EmployeeMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeResponse>>> GetEmployees([FromQuery] EmployeeFilter filter)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }

            var employeesQuery = _context.Employees.Include(c => c.Cafe).OrderBy(c => c.StartDate) as IQueryable<Employee>;

            if (filter != null && !string.IsNullOrEmpty(filter.Cafe))
            {
                employeesQuery = employeesQuery.Where(c => c.CafeId.HasValue && c.Cafe.Name.ToLower() == filter.Cafe.ToLower());

            }

            return await _mapper.EmployeeDbToApi(employeesQuery).ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(string id)
        {
          if (_context.Employees == null)
          {
              return NotFound();
          }
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(string id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeePost employee)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'CafeDbContext.Employees'  is null.");
            }

            if (employee == null)
            {
                return BadRequest("Cannot find body");
            }

            var phone = employee.Phone.ToString();
            if (phone.Length != 8 || !(phone[0] == '8' || phone[0] == '9'))
            {
                return BadRequest("Phone number is incorrect");
            }

            var randomString = RandomStringGenerator.RandomString(7);
            var employeeIds = _context.Employees.Select(e => e.Id.Substring(2, 9));
            while (employeeIds.Contains(randomString))
            {
                randomString = RandomStringGenerator.RandomString(7);
            }

            Employee employeeDb = _mapper.EmployeeApiToDb(employee, randomString);
            _context.Employees.Add(employeeDb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeExists(employeeDb.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployee", new { id = employeeDb.Id }, new { id = employeeDb.Id});
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(string id)
        {
            return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
