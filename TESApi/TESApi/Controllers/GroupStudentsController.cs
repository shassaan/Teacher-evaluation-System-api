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
    public class GroupStudentsController : ControllerBase
    {
        private readonly biitDbNewContext _context;

        public GroupStudentsController(biitDbNewContext context)
        {
            _context = context;
        }

        // GET: api/GroupStudents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupStudents>>> GetGroupStudents()
        {
            return await _context.GroupStudents.ToListAsync();
        }

        // GET: api/GroupStudents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GroupStudents>>> GetGroupStudents(int id)
        {
            var groupStudents = await _context.GroupStudents.Where(g => g.Gid == id).Include(s => s.St).ToListAsync();

            if (groupStudents == null)
            {
                return NotFound();
            }

            return groupStudents;
        }

        // PUT: api/GroupStudents/5
        [HttpPut("{id}")]
        public ActionResult<List<GroupStudents>> PutGroupStudents(int id, Stmtr std)
        {

           var toBeDeleted =  _context.GroupStudents.Where(g => g.Gid == id && g.StId == std.RegNo).FirstOrDefault();
            _context.GroupStudents.Remove(toBeDeleted);
            _context.SaveChanges();

            return _context.GroupStudents.Where(g => g.Gid == id).Include(s => s.St).ToList();
            
        }

        // POST: api/GroupStudents
        [HttpPost]
        public async Task<ActionResult<List<GroupStudents>>> PostGroupStudents(StudentCriteria studentCriteria)
        {
            var requiredStudents = _context.Stmtr.Where(s => s.EnrlStatus.Equals(studentCriteria.enrollmentStatus)
                && s.BirthDate.Year >= (DateTime.Now.Year - studentCriteria.age[1]) &&
                s.BirthDate.Year <= (DateTime.Now.Year - studentCriteria.age[0])
                //s.Sex.Equals(studentCriteria.gender[0]) || s.BirthDate.Year <= (DateTime.Now.Year - studentCriteria.age[0]) ||
                //s.Sex.Equals(studentCriteria.gender[1]) || s.FinalCourse.Equals(studentCriteria.discipline[0]) ||
                //s.FinalCourse.Equals(studentCriteria.discipline[1]) || s.FinalCourse.Equals(studentCriteria.discipline[2]) ||
                //s.FinalCourse.Equals(studentCriteria.discipline[3])
            );

            List<Stmtr> stmtrs = new List<Stmtr>();
            stmtrs.AddRange(requiredStudents.ToList());
            List<Stmtr> genderFilteredstmtrs = new List<Stmtr>();
            List<Stmtr> dispFilteredStmtrs = new List<Stmtr>();
            foreach (var gender in studentCriteria.gender)
            {
                genderFilteredstmtrs.AddRange(stmtrs.Where(s => s.Sex.Equals(gender)).ToList());
            }

            stmtrs = genderFilteredstmtrs;

            foreach (var disp in studentCriteria.discipline)
            {
                dispFilteredStmtrs.AddRange(stmtrs.Where(s => s.FinalCourse.Equals(disp)).ToList());
            }

            stmtrs = dispFilteredStmtrs;

            foreach (var student in stmtrs)
            {
                _context.GroupStudents.Add(new GroupStudents { StId = student.RegNo, Gid = studentCriteria.gid });
            }

            await _context.SaveChangesAsync();
            var groupStudents = _context.GroupStudents.Where(g => g.Gid == studentCriteria.gid).Include(s => s.St).ToList();
            return groupStudents;
        }

        // DELETE: api/GroupStudents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupStudents>> DeleteGroupStudents(int id)
        {
            var groupStudents = await _context.GroupStudents.FindAsync(id);
            if (groupStudents == null)
            {
                return NotFound();
            }

            _context.GroupStudents.Remove(groupStudents);
            await _context.SaveChangesAsync();

            return groupStudents;
        }

        private bool GroupStudentsExists(int id)
        {
            return _context.GroupStudents.Any(e => e.Id == id);
        }
    }

    
}
