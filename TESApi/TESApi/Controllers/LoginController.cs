using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TESApi.CustomClasses;
using TESApi.Models;

namespace TESApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly biitDbNewContext _context;
        public LoginController(biitDbNewContext biitDbNewContext)
        {
            _context = biitDbNewContext;
        }
        // GET: api/Login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        public ActionResult Post(LoginCredentials credentials)
        {
            if (Regex.IsMatch(credentials.identity,"^(BIIT)[0-9]{3}$"))
            {
                //teacherLogin
                var emp = _context.Empmtr.Where(e => e.EmpNo.Equals(credentials.identity) && e.Password.Equals(credentials.password)).FirstOrDefault();
                if (emp != null)
                {
                    return new JsonResult(new { data=emp,type="teacher"});
                }
                else
                {
                    return new JsonResult(new { data = emp, type = "empty" });
                }
            }
            else if(Regex.IsMatch(credentials.identity,"^[0-9]{4}[-]{1}(ARID)[-]{1}[0-9]{4}$"))
            {
                var std = _context.Stmtr.Where(s => s.RegNo.Equals(credentials.identity) && s.Password.Equals(credentials.password)).FirstOrDefault();
                if (std != null)
                {
                    return new JsonResult(new { data = std, type = "student" });
                }
                else
                {
                    return new JsonResult(new { data = std, type = "empty" });

                }
            }

            return new JsonResult(new { data = "null", type = "empty" });
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
