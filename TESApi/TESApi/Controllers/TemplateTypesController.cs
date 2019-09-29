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
    public class TemplateTypesController : ControllerBase
    {
        private readonly biitDbNewContext _context;

        public TemplateTypesController(biitDbNewContext context)
        {
            _context = context;
        }

        // GET: api/TemplateTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TemplateType>>> GetTemplateType()
        {
            return await _context.TemplateType.Include(t => t.T).ToListAsync();
        }

        // GET: api/TemplateTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TemplateType>> GetTemplateType(int id)
        {
            var templateType = await _context.TemplateType.FindAsync(id);

            if (templateType == null)
            {
                return NotFound();
            }

            return templateType;
        }

        // PUT: api/TemplateTypes/5
        [HttpPut]
        public async Task<IActionResult> PutTemplateType(AssignTemplates assignTemplates)
        {
            var templateType = _context.TemplateType.Where(t => t.AssignTo.StartsWith(assignTemplates.assignTo)).FirstOrDefault();
            templateType.Tid = assignTemplates.tid;

            _context.Entry(templateType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok();
        }

        // POST: api/TemplateTypes
        [HttpPost]
        public async Task<ActionResult<TemplateType>> PostTemplateType(TemplateType templateType)
        {
            _context.TemplateType.Add(templateType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TemplateTypeExists(templateType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTemplateType", new { id = templateType.Id }, templateType);
        }

        // DELETE: api/TemplateTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TemplateType>> DeleteTemplateType(int id)
        {
            var templateType = await _context.TemplateType.FindAsync(id);
            if (templateType == null)
            {
                return NotFound();
            }

            _context.TemplateType.Remove(templateType);
            await _context.SaveChangesAsync();

            return templateType;
        }

        private bool TemplateTypeExists(int id)
        {
            return _context.TemplateType.Any(e => e.Id == id);
        }
    }

    public class AssignTemplates
    {
        public int? tid { get; set; }
        public string assignTo { get; set; }
    }
}
