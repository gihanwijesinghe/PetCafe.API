using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCafe.API.APIModels;
using PetCafe.API.Data;
using PetCafe.API.Helpers;

namespace PetCafe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafesController : ControllerBase
    {
        private readonly ILogger<CafesController> _logger;
        private readonly CafeDbContext _context;
        private readonly CafeMapper _mapper;

        public CafesController(ILogger<CafesController> logger, CafeDbContext context, CafeMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Cafes1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CafeResponse>>> GetCafes([FromQuery] CafeFilter filter)
        {
            if (_context.Cafes == null)
            {
                return NotFound();
            }

            var cafesQuery = _context.Cafes.OrderByDescending(c => c.Employees.Count()) as IQueryable<Cafe>;

            if (filter != null && !string.IsNullOrEmpty(filter.Location))
            {
                cafesQuery = cafesQuery.Where(c => c.Location.ToLower() == filter.Location.ToLower());

            }

            return await _mapper.CafeDbToApi(cafesQuery).ToListAsync();
        }

        // GET: api/Cafes1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cafe>> GetCafe(Guid id)
        {
            if (_context.Cafes == null)
            {
                return NotFound();
            }
            var cafe = await _context.Cafes.FindAsync(id);

            if (cafe == null)
            {
                return NotFound();
            }

            return cafe;
        }

        // PUT: api/Cafes1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCafe(Guid id, Cafe cafe)
        {
            if (id != cafe.Id)
            {
                return BadRequest();
            }

            _context.Entry(cafe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CafeExists(id))
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

        // POST: api/Cafes1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cafe>> PostCafe(Cafe cafe)
        {
            if (_context.Cafes == null)
            {
                return Problem("Entity set 'CafeDbContext.Cafes'  is null.");
            }
            _context.Cafes.Add(cafe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCafe", new { id = cafe.Id }, cafe);
        }

        // DELETE: api/Cafes1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCafe(Guid id)
        {
            if (_context.Cafes == null)
            {
                return NotFound();
            }
            var cafe = await _context.Cafes.FindAsync(id);
            if (cafe == null)
            {
                return NotFound();
            }

            _context.Cafes.Remove(cafe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CafeExists(Guid id)
        {
            return (_context.Cafes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
