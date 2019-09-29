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
    public class OptionsController : ControllerBase
    {
        private readonly biitDbNewContext _context;

        public OptionsController(biitDbNewContext context)
        {
            _context = context;
        }
        //Scaffold-DbContext "Server=localhost;Database=biitDbNew;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
        // GET: api/Options
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Options>>> GetOptions()
        {
            return await _context.Options.ToListAsync();
        }

        // GET: api/Options/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Options>>> GetOptions(int id)
        {
            var options = await _context.Options.Where(o => o.Tid == id).ToListAsync();

            if (options == null)
            {
                return NotFound();
            }

            return options;
        }

        // PUT: api/Options/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOptions(int id, Options options)
        {
            if (id != options.Id)
            {
                return BadRequest();
            }

            _context.Entry(options).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionsExists(id))
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

        // POST: api/Options
        [HttpPost]
        public async Task<ActionResult<Options>> PostOptions(Options options)
        {
            _context.Options.Add(options);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOptions", new { id = options.Id }, options);
        }

        // DELETE: api/Options/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Options>> DeleteOptions(int id)
        {
            var options = await _context.Options.FindAsync(id);
            if (options == null)
            {
                return NotFound();
            }

            _context.Options.Remove(options);
            await _context.SaveChangesAsync();

            return options;
        }

        private bool OptionsExists(int id)
        {
            return _context.Options.Any(e => e.Id == id);
        }
    }
}
