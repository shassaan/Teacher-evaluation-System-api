using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TESApi.Models;

namespace TESApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {
        private readonly biitDbNewContext _context;

        public TemplatesController(biitDbNewContext context)
        {
            _context = context;
        }

        // GET: api/Templates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Templates>>> GetTemplates()
        {
            //Thread.Sleep(5000);
            return await _context.Templates.OrderByDescending
                (t => t.Id).ToListAsync();
        }

        

        // GET: api/Templates/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTemplates(string id)
        {
            if (Regex.IsMatch(id, "^(BIIT)[0-9]{3}$"))
            {
                //teacher
                var template = _context.TemplateType.Where(t => t.AssignTo.Equals("Teacher")).FirstOrDefault();
                var templateToReturn = _context.Templates.Where(t => t.Id.Equals(template.Tid)).Include(t => t.QuestionAnswer).Include(r => r.Options).FirstOrDefault();
                return new JsonResult(templateToReturn);
            }
            else if (Regex.IsMatch(id, "^[0-9]{4}[-]{1}(ARID)[-]{1}[0-9]{4}$"))
            {
                //students
                var groupStd = _context.GroupStudents.Where(s => s.StId.Equals(id)).FirstOrDefault();
                if (groupStd != null)
                {
                    //groupStudent
                    var group = _context.Groups.Where(s => s.GId == groupStd.Gid).FirstOrDefault();
                    var groupTemplate = _context.Templates.Where(g => g.Id.Equals(group.TId)).Include(t => t.QuestionAnswer).Include(r => r.Options).FirstOrDefault() ;
                    return new JsonResult(groupTemplate);
                }
                else
                {
                    //normalStudent
                    var template = _context.TemplateType.Where(t => t.AssignTo.Equals("Student")).FirstOrDefault();
                    var templateToReturn = _context.Templates.Where(t => t.Id.Equals(template.Tid)).Include(t => t.QuestionAnswer).Include(r => r.Options).FirstOrDefault();
                    return new JsonResult(templateToReturn);
                }

            }

            

            return new JsonResult(null);
        }

        // PUT: api/Templates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemplates(int id, Templates templates)
        {
            if (id != templates.Id)
            {
                return BadRequest();
            }

            _context.Entry(templates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemplatesExists(id))
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

        // POST: api/Templates
        [HttpPost]
        public async Task<ActionResult<Templates>> PostTemplates(Templates templates)
        {
            _context.Templates.Add(templates);
            await _context.SaveChangesAsync();

            return RedirectToAction("GetTemplates");
        }

        // DELETE: api/Templates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Templates>> DeleteTemplates(int id)
        {
            var templates = await _context.Templates.FindAsync(id);
            if (templates == null)
            {
                return NotFound();
            }

            _context.Templates.Remove(templates);
            await _context.SaveChangesAsync();

            return templates;
        }

        private bool TemplatesExists(int id)
        {
            return _context.Templates.Any(e => e.Id == id);
        }
    }
}
