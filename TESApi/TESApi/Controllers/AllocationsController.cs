using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TESApi.CustomClasses;
using TESApi.Models;

namespace TESApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocationsController : ControllerBase
    {
        private readonly biitDbNewContext _context;

        public AllocationsController(biitDbNewContext context)
        {
            _context = context;
        }

        // GET: api/Allocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Allocate>>> GetAllocate()
        {
            return await _context.Allocate.ToListAsync();
        }

        // GET: api/Allocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Allocate>> GetAllocate(int id)
        {
            var allocate = await _context.Allocate.FindAsync(id);

            if (allocate == null)
            {
                return NotFound();
            }

            return allocate;
        }

        // PUT: api/Allocations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllocate(int id, Allocate allocate)
        {
            if (id != allocate.AllId)
            {
                return BadRequest();
            }

            _context.Entry(allocate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllocateExists(id))
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

        // POST: api/Allocations
        [HttpPost]
        public async Task<ActionResult> PostAllocate(AllocationCriteria allocationCriteria)
        {

            if (allocationCriteria.disp.Equals("Teacher"))
            {
                var currentCourse = _context.Allocate.Join(_context.Empmtr, a => a.EmpNo, e => e.EmpNo, (a, e) => new
                {
                    a,
                    e
                })
           .Join(_context.Crsmtr, p => p.a.CourseNo, c => c.CourseNo, (p, c) => new { p, c })
           .Where(d => d.c.Sos.Equals("SOS2013S") && d.p.a.SemesterNo.Equals("2019SM"));
           ;
                return new JsonResult(currentCourse);
            }
            var currentCourses = _context.Allocate.Join(_context.Empmtr, a => a.EmpNo, e => e.EmpNo, (a, e) => new
            {
                a,
                e
            })
           .Join(_context.Crsmtr, p => p.a.CourseNo, c => c.CourseNo, (p, c) => new { p, c })
           .Where(d => d.p.a.Discipline.Equals(allocationCriteria.disp) && d.p.a.SemesterNo.Equals(allocationCriteria.semester) && d.p.a.Section.Equals(allocationCriteria.section) && d.c.Discipline.Equals(allocationCriteria.disp) && d.c.Sos.Equals(allocationCriteria.SOS)).Take(6)
           ;
            return new JsonResult(currentCourses);

            //return CreatedAtAction("GetAllocate", new { id = allocate.AllId }, allocate);
        }

        // DELETE: api/Allocations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Allocate>> DeleteAllocate(int id)
        {
            var allocate = await _context.Allocate.FindAsync(id);
            if (allocate == null)
            {
                return NotFound();
            }

            _context.Allocate.Remove(allocate);
            await _context.SaveChangesAsync();

            return allocate;
        }

        private bool AllocateExists(int id)
        {
            return _context.Allocate.Any(e => e.AllId == id);
        }
    }
}
