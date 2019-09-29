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
    public class CustomEvaluationController : ControllerBase
    {
        private readonly biitDbNewContext _context;

        public CustomEvaluationController(biitDbNewContext context)
        {
            _context = context;
        }

        // GET: api/CustomEvaluation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomEvaluation>>> GetCustomEvaluation()
        {
            return await _context.CustomEvaluation.Include(t=>t.G).ToListAsync();
        }

        // GET: api/CustomEvaluation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomEvaluation>> GetCustomEvaluation(int id)
        {
            var customEvaluation = await _context.CustomEvaluation.FindAsync(id);

            if (customEvaluation == null)
            {
                return NotFound();
            }

            return customEvaluation;
        }

        // PUT: api/CustomEvaluation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomEvaluation(int id, CustomEvaluation customEvaluation)
        {
            if (id != customEvaluation.Id)
            {
                return BadRequest();
            }

            _context.Entry(customEvaluation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomEvaluationExists(id))
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

        // POST: api/CustomEvaluation
        [HttpPost]
        public async Task<ActionResult<List<CustomEvaluation>>> PostCustomEvaluation(CustomEvaluation customEvaluation)
        {
            _context.CustomEvaluation.Add(customEvaluation);
            await _context.SaveChangesAsync();

            return await _context.CustomEvaluation.Include(t=>t.G).ToListAsync();
        }

        // DELETE: api/CustomEvaluation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CustomEvaluation>>> DeleteCustomEvaluation(int id)
        {
            var customEvaluation = await _context.CustomEvaluation.FindAsync(id);
            if (customEvaluation == null)
            {
                return NotFound();
            }

            _context.CustomEvaluation.Remove(customEvaluation);
            await _context.SaveChangesAsync();

            return await _context.CustomEvaluation.Include(t => t.G).ToListAsync();
        }

        private bool CustomEvaluationExists(int id)
        {
            return _context.CustomEvaluation.Any(e => e.Id == id);
        }
    }
}
