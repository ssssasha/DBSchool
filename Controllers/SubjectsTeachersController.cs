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
    public class SubjectsTeachersController : ControllerBase
    {
        private readonly DBSchoolContext _context;

        public SubjectsTeachersController(DBSchoolContext context)
        {
            _context = context;
        }

        // GET: api/SubjectsTeachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectsTeacher>>> GetSubjectsTeachers()
        {
            return await _context.SubjectsTeachers.ToListAsync();
        }

        // GET: api/SubjectsTeachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectsTeacher>> GetSubjectsTeacher(int id)
        {
            var subjectsTeacher = await _context.SubjectsTeachers.FindAsync(id);

            if (subjectsTeacher == null)
            {
                return NotFound();
            }

            return subjectsTeacher;
        }

        // PUT: api/SubjectsTeachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjectsTeacher(int id, SubjectsTeacher subjectsTeacher)
        {
            if (id != subjectsTeacher.Id)
            {
                return BadRequest();
            }

            _context.Entry(subjectsTeacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectsTeacherExists(id))
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

        // POST: api/SubjectsTeachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubjectsTeacher>> PostSubjectsTeacher(SubjectsTeacher subjectsTeacher)
        {
            _context.SubjectsTeachers.Add(subjectsTeacher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubjectsTeacher", new { id = subjectsTeacher.Id }, subjectsTeacher);
        }

        // DELETE: api/SubjectsTeachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectsTeacher(int id)
        {
            var subjectsTeacher = await _context.SubjectsTeachers.FindAsync(id);
            if (subjectsTeacher == null)
            {
                return NotFound();
            }

            _context.SubjectsTeachers.Remove(subjectsTeacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubjectsTeacherExists(int id)
        {
            return _context.SubjectsTeachers.Any(e => e.Id == id);
        }
    }
}
