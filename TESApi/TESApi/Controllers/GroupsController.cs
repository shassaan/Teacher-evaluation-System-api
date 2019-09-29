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
    public class GroupsController : ControllerBase
    {
        private readonly biitDbNewContext _context;

        public GroupsController(biitDbNewContext context)
        {
            _context = context;
        }


        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Groups>>> GetGroups()
        {
            return await _context.Groups.Include(g => g.T).ToListAsync();
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Groups>> GetGroups(int id)
        {
            var groups = await _context.Groups.FindAsync(id);

            if (groups == null)
            {
                return NotFound();
            }

            return groups;
        }

        // PUT: api/Groups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroups(int id, Groups groups)
        {
            if (id != groups.GId)
            {
                return BadRequest();
            }

            _context.Entry(groups).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupsExists(id))
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

        // POST: api/Groups
        [HttpPost]
        public async Task<ActionResult<Groups>> PostGroups(Groups groups)
        {
            _context.Groups.Add(groups);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroups", new { id = groups.GId }, groups);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Groups>> DeleteGroups(int id)
        {

            var toBeDeleted = _context.GroupStudents.Where(g => g.Gid == id);
            _context.GroupStudents.RemoveRange(toBeDeleted);
            _context.SaveChanges();
            var groups = await _context.Groups.FindAsync(id);
            if (groups == null)
            {
                return NotFound();
            }

            _context.Groups.Remove(groups);
            await _context.SaveChangesAsync();

            return groups;
        }

        private bool GroupsExists(int id)
        {
            return _context.Groups.Any(e => e.GId == id);
        }
    }
}
