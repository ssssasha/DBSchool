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
    public class NumbersHoursDaysController : ControllerBase
    {
        private readonly DBSchoolContext _context;

        public NumbersHoursDaysController(DBSchoolContext context)
        {
            _context = context;
        }

        // GET: api/NumbersHoursDays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NumbersHoursDay>>> GetNumbersHoursDays()
        {
            return await _context.NumbersHoursDays.ToListAsync();
        }

        // GET: api/NumbersHoursDays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NumbersHoursDay>> GetNumbersHoursDay(int id)
        {
            var numbersHoursDay = await _context.NumbersHoursDays.FindAsync(id);

            if (numbersHoursDay == null)
            {
                return NotFound();
            }

            return numbersHoursDay;
        }

        // PUT: api/NumbersHoursDays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNumbersHoursDay(int id, NumbersHoursDay numbersHoursDay)
        {
            if (id != numbersHoursDay.Id)
            {
                return BadRequest();
            }

            _context.Entry(numbersHoursDay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NumbersHoursDayExists(id))
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

        // POST: api/NumbersHoursDays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NumbersHoursDay>> PostNumbersHoursDay(NumbersHoursDay numbersHoursDay)
        {
            _context.NumbersHoursDays.Add(numbersHoursDay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNumbersHoursDay", new { id = numbersHoursDay.Id }, numbersHoursDay);
        }

        // DELETE: api/NumbersHoursDays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNumbersHoursDay(int id)
        {
            var numbersHoursDay = await _context.NumbersHoursDays.FindAsync(id);
            if (numbersHoursDay == null)
            {
                return NotFound();
            }

            _context.NumbersHoursDays.Remove(numbersHoursDay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NumbersHoursDayExists(int id)
        {
            return _context.NumbersHoursDays.Any(e => e.Id == id);
        }
    }
}
