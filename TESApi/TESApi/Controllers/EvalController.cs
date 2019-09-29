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
    public class EvalController : ControllerBase
    {
        private readonly biitDbNewContext _context;

        public EvalController(biitDbNewContext context)
        {
            _context = context;
        }

        // GET: api/Eval
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eval>>> GetEval()
        {
            return await _context.Eval.ToListAsync();
        }

        // GET: api/Eval/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Eval>> GetEval(int id)
        {
            var eval = await _context.Eval.FindAsync(id);

            if (eval == null)
            {
                return NotFound();
            }

            return eval;
        }

        // PUT: api/Eval/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEval(int id, Eval eval)
        {
            if (id != eval.EvalId)
            {
                return BadRequest();
            }

            _context.Entry(eval).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvalExists(id))
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

        // POST: api/Eval
        [HttpPost]
        public async Task<ActionResult<Eval>> PostEval(EvaluationData eval)
        {

            foreach (var qusetion in eval.Questions)
            {
                string[] ans = qusetion.value.Split(";");
                _context.Eval.Add(new Eval
                {
                    EmpNo = eval.EmpNo,
                    RegNo = eval.RegNo,
                    CourseNo = eval.CourseNo,
                    Discipline = eval.Discipline,
                    SemesterNo = eval.SemesterNo,
                    AnswerDesc = ans[1].Trim(),
                    AnswerMarks = int.Parse(ans[0].Trim()),
                    QuestionDesc = int.Parse(qusetion.key.Trim())
                });
                await _context.SaveChangesAsync();
            }
            


            return CreatedAtAction("GetEval", new { id = 0}, eval);
        }

        // DELETE: api/Eval/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Eval>> DeleteEval(int id)
        {
            var eval = await _context.Eval.FindAsync(id);
            if (eval == null)
            {
                return NotFound();
            }

            _context.Eval.Remove(eval);
            await _context.SaveChangesAsync();

            return eval;
        }

        private bool EvalExists(int id)
        {
            return _context.Eval.Any(e => e.EvalId == id);
        }
    }

    
}
