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
    public class SemestersController : ControllerBase
    {
        private readonly biitDbNewContext _context;

        public SemestersController(biitDbNewContext context)
        {
            _context = context;
        }

        // GET: api/Semesters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Semmtr>>> GetSemmtr()
        {
            return await _context.Semmtr.ToListAsync();
        }

        // GET: api/Semesters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Semmtr>> GetSemmtr(string id)
        {
            var semmtr = await _context.Semmtr.FindAsync(id);

            if (semmtr == null)
            {
                return NotFound();
            }

            return semmtr;
        }

        // PUT: api/Semesters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSemmtr(string id, Semmtr semmtr)
        {
            if (id != semmtr.SemesterNo)
            {
                return BadRequest();
            }

            _context.Entry(semmtr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SemmtrExists(id))
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

        // POST: api/Semesters
        [HttpPost]
        public async Task<ActionResult<Semmtr>> PostSemmtr(Semmtr semmtr)
        {
            _context.Semmtr.Add(semmtr);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SemmtrExists(semmtr.SemesterNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSemmtr", new { id = semmtr.SemesterNo }, semmtr);
        }

        // DELETE: api/Semesters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Semmtr>> DeleteSemmtr(string id)
        {
            var semmtr = await _context.Semmtr.FindAsync(id);
            if (semmtr == null)
            {
                return NotFound();
            }

            _context.Semmtr.Remove(semmtr);
            await _context.SaveChangesAsync();

            return semmtr;
        }

        private bool SemmtrExists(string id)
        {
            return _context.Semmtr.Any(e => e.SemesterNo == id);
        }
    }
}
