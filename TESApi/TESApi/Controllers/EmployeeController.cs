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
    public class EmployeeController : ControllerBase
    {
        private readonly biitDbNewContext _context;

        public EmployeeController(biitDbNewContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empmtr>>> GetEmpmtr()
        {
            return await _context.Empmtr.ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empmtr>> GetEmpmtr(string id)
        {
            var empmtr = await _context.Empmtr.FindAsync(id);

            if (empmtr == null)
            {
                return NotFound();
            }

            return empmtr;
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpmtr(string id, Empmtr empmtr)
        {
            if (id != empmtr.EmpNo)
            {
                return BadRequest();
            }

            _context.Entry(empmtr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpmtrExists(id))
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

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<Empmtr>> PostEmpmtr(Empmtr empmtr)
        {
            _context.Empmtr.Add(empmtr);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmpmtrExists(empmtr.EmpNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmpmtr", new { id = empmtr.EmpNo }, empmtr);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Empmtr>> DeleteEmpmtr(string id)
        {
            var empmtr = await _context.Empmtr.FindAsync(id);
            if (empmtr == null)
            {
                return NotFound();
            }

            _context.Empmtr.Remove(empmtr);
            await _context.SaveChangesAsync();

            return empmtr;
        }

        private bool EmpmtrExists(string id)
        {
            return _context.Empmtr.Any(e => e.EmpNo == id);
        }
    }
}
