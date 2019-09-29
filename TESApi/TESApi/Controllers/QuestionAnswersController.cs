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
    public class QuestionAnswersController : ControllerBase
    {
        private readonly biitDbNewContext _context;

        public QuestionAnswersController(biitDbNewContext context)
        {
            _context = context;
        }

        // GET: api/QuestionAnswers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionAnswer>>> GetQuestionAnswer()
        {
            return await _context.QuestionAnswer.ToListAsync();
        }
        // GET: api/QuestionAnswers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<QuestionAnswer>>> GetQuestionAnswer(int id)
        {
            var questionAnswer = await _context.QuestionAnswer.Where(t => t.Tid == id).ToListAsync();

            if (questionAnswer == null)
            {
                return NotFound();
            }

            return questionAnswer;
        }

        // PUT: api/QuestionAnswers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionAnswer(int id, QuestionAnswer questionAnswer)
        {
            if (id != questionAnswer.QuestionId)
            {
                return BadRequest();
            }

            _context.Entry(questionAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionAnswerExists(id))
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

        // POST: api/QuestionAnswers
        [HttpPost]
        public async Task<ActionResult<IEnumerable<QuestionAnswer>>> PostQuestionAnswer(QuestionAnswer questionAnswer)
        {
            questionAnswer.QuestionId = (_context.QuestionAnswer.Count()) + 1;
            _context.QuestionAnswer.Add(questionAnswer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QuestionAnswerExists(questionAnswer.QuestionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction("GetQuestionAnswer", new { id = questionAnswer.Tid });
        }

        // DELETE: api/QuestionAnswers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuestionAnswer>> DeleteQuestionAnswer(int id)
        {
            var questionAnswer = await _context.QuestionAnswer.FindAsync(id);
            if (questionAnswer == null)
            {
                return NotFound();
            }

            _context.QuestionAnswer.Remove(questionAnswer);
            await _context.SaveChangesAsync();

            return questionAnswer;
        }

        private bool QuestionAnswerExists(int id)
        {
            return _context.QuestionAnswer.Any(e => e.QuestionId == id);
        }
    }
}
