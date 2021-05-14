using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolWebApplication.Models;

namespace SchoolWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoursController : ControllerBase
    {
        private readonly DBSchoolContext _context;

        public HoursController(DBSchoolContext context)
        {
            _context = context;
        }

        // GET: api/Hours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hour>>> GetHours()
        {
            return await _context.Hours.ToListAsync();
        }

        // GET: api/Hours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hour>> GetHour(int id)
        {
            var hour = await _context.Hours.FindAsync(id);

            if (hour == null)
            {
                return NotFound();
            }

            return hour;
        }

        // PUT: api/Hours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHour(int id, Hour hour)
        {
            if (id != hour.Id)
            {
                return BadRequest();
            }

            _context.Entry(hour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HourExists(id))
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

        // POST: api/Hours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hour>> PostHour(Hour hour)
        {
            _context.Hours.Add(hour);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHour", new { id = hour.Id }, hour);
        }

        // DELETE: api/Hours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHour(int id)
        {
            var hour = await _context.Hours.FindAsync(id);
            if (hour == null)
            {
                return NotFound();
            }

            _context.Hours.Remove(hour);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HourExists(int id)
        {
            return _context.Hours.Any(e => e.Id == id);
        }
    }
}
