using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TESApi.Models;
namespace TESApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly biitDbNewContext _context;

        public CoursesController(biitDbNewContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crsmtr>>> GetCrsmtr()
        {
            return await _context.Crsmtr.ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Crsmtr>> GetCrsmtr(string id)
        {
            var crsmtr = await _context.Crsmtr.FindAsync(id);

            if (crsmtr == null)
            {
                return NotFound();
            }

            return crsmtr;
        }

        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrsmtr(string id, Crsmtr crsmtr)
        {
            if (id != crsmtr.CourseNo)
            {
                return BadRequest();
            }

            _context.Entry(crsmtr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrsmtrExists(id))
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

        // POST: api/Courses
        [HttpPost]
        public async Task<ActionResult<Crsmtr>> PostCrsmtr(Crsmtr crsmtr)
        {
            _context.Crsmtr.Add(crsmtr);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CrsmtrExists(crsmtr.CourseNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCrsmtr", new { id = crsmtr.CourseNo }, crsmtr);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Crsmtr>> DeleteCrsmtr(string id)
        {
            var crsmtr = await _context.Crsmtr.FindAsync(id);
            if (crsmtr == null)
            {
                return NotFound();
            }

            _context.Crsmtr.Remove(crsmtr);
            await _context.SaveChangesAsync();

            return crsmtr;
        }

        private bool CrsmtrExists(string id)
        {
            return _context.Crsmtr.Any(e => e.CourseNo == id);
        }
    }
}
