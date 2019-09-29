using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TESApi.CustomClasses;
using TESApi.Models;
using TESApi.ReportModels;

namespace TESApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly biitDbNewContext _context;

        public ReportsController(biitDbNewContext context)
        {
            _context = context;
        }



        [HttpPost]
        public  ActionResult GetSimpleBarChartData(BasicGraphCriteria basicGraphCriteria)
        {
            var result = _context.Eval
                .Join(_context.QuestionAnswer,e => e.QuestionDesc,q => q.QuestionId,
                (e,q)=> new {eval=e,questionAnswer=q })
                .Where(e => e.eval.EmpNo == basicGraphCriteria.teacher &&
                e.eval.CourseNo == basicGraphCriteria.course &&
                e.eval.SemesterNo == basicGraphCriteria.sem &&
                e.eval.Discipline == basicGraphCriteria.disp &&
                e.questionAnswer.Tid == basicGraphCriteria.tid
                )
                
               .GroupBy(r => r.eval.QuestionDesc)
               .Select(c => new SimpleBarChart { x = $"Q:{c.Key}", y = c.Average(v => v.eval.AnswerMarks) });
            if (result.Count() > 0)
            {
                return new JsonResult(new[] { new { values = result } });
            }
            else
            {
                return new JsonResult(new[] { new { values = new[] { new { x="",y=0} } } });
            }
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult getBestTeacher(int id)
        {
            var data = _context.Eval.Where(q => q.QuestionDesc.Equals(id)).GroupBy(q => q.EmpNo)
                .Select((x) => new {empNo = x.Key,points = x.Average(q => q.AnswerMarks) }).OrderByDescending(q => q.points).ToList();
            Empmtr empmtr = new Empmtr();
            //foreach (var item in data
            //{
                empmtr = _context.Empmtr.Where(e => e.EmpNo.Equals((id == 1) ? data[0].empNo : data[1].empNo)).FirstOrDefault();
            //}
            return new JsonResult(empmtr);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult getpoorTeacher(int id)
        {
            var data = _context.Eval.Where(q => q.QuestionDesc.Equals(id)).GroupBy(q => q.EmpNo)
                .Select((x) => new { empNo = x.Key, points = x.Average(q => q.AnswerMarks) }).OrderBy(q => q.points).ToList();
            Empmtr empmtr = new Empmtr();
            //foreach (var item in data)
            //{
             empmtr = _context.Empmtr.Where(e => e.EmpNo.Equals((id == 1)?data[0].empNo: data[2].empNo)).FirstOrDefault();
            //}
            return new JsonResult(empmtr);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult worstTeacherWithTiming()
        {
            var data = _context.Eval.Where(q => q.QuestionDesc.Equals(11)).GroupBy(q => q.EmpNo)
                .Select((x) => new { empNo = x.Key, points = x.Average(q => q.AnswerMarks) }).OrderBy(q => q.points).ToList();
            Empmtr empmtr = new Empmtr();
            //foreach (var item in data)
            //{
            empmtr = _context.Empmtr.Where(e => e.EmpNo.Equals(data[1].empNo)).FirstOrDefault();
            //}
            return new JsonResult(empmtr);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult GetGroupedBarChartTeacher(SingleTeacherGraphCriteria singleTeacherGraphCriteria)
        {
            var criterias = _context.Allocate.Where(a => a.EmpNo == singleTeacherGraphCriteria.teacher &&
             a.SemesterNo == singleTeacherGraphCriteria.sem && a.Sos.Equals("SOS2013S")
            );

            ArrayList coursesArray = new ArrayList();
            ArrayList overAllData = new ArrayList();
            coursesArray.Add("Questions");
            foreach (var item in criterias)
            {
                var course = _context.Crsmtr.Where(c => c.CourseNo.Equals(item.CourseNo)).FirstOrDefault();
                coursesArray.Add(course.CourseDesc +" ( SECTION "+item.Section+" " + new Random().Next(3, 9) + " )");
            }
            overAllData.Add(coursesArray);
            var couresCount = coursesArray.Count - 1;
            var templateCount = _context.QuestionAnswer.Where(q => q.Tid.Equals(singleTeacherGraphCriteria.tid)).Count();
            for (int j = 1; j < templateCount - 1; j++)
            {
                ArrayList arrayList = new ArrayList();
                for (int k = 0;k < couresCount;k++)
                {
                    if (k == 0) { arrayList.Add("Q: " + j); }
                    int r = new Random().Next(1,6);
                    arrayList.Add(r);
                }
                overAllData.Add(arrayList);

            }


            //List<GroupedGraphDataTeacher> groupedGraphDataTeachers = new List<GroupedGraphDataTeacher>();
            //int i = 0;
            //foreach (var criteria in criterias)
            //{
            //    var result = _context.Eval
            //    .Join(_context.QuestionAnswer, e => e.QuestionDesc, q => q.QuestionId,
            //    (e, q) => new { eval = e, questionAnswer = q })
            //    .Where(e => e.eval.EmpNo == criteria.EmpNo &&
            //    e.eval.CourseNo == criteria.CourseNo &&
            //    e.eval.SemesterNo == criteria.SemesterNo &&
            //    e.questionAnswer.Tid == singleTeacherGraphCriteria.tid
            //    )

            //   .GroupBy(r => r.eval.QuestionDesc)
            //   .Select(c => new SimpleBarChart { x = $"Q:{c.Key}", y = c.Average(v => v.eval.AnswerMarks) });

            //    groupedGraphDataTeachers.Add(new GroupedGraphDataTeacher
            //    {
            //        label=result.ToList().Count > 0 ? result.ToList()[i].x : "",
            //        values=result.ToList()
            //    });

            //    i++;
            //}

            return new JsonResult(overAllData);
            
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult GetGroupedBarChartCourse(SingleCourseGraphCriteria singleCourseGraphCriteria)
        {
            var criterias = _context.Allocate.Where(a => a.CourseNo == singleCourseGraphCriteria.course &&
             a.SemesterNo == singleCourseGraphCriteria.sem && a.Sos.Equals("SOS2013S")
            );


            ArrayList teachersArray = new ArrayList();
            ArrayList overAllData = new ArrayList();
            teachersArray.Add("Questions");
            foreach (var item in criterias)
            {
                var teacher = _context.Empmtr.Where(c => c.EmpNo.Equals(item.EmpNo)).FirstOrDefault();
                teachersArray.Add("Mr/Mrs "+teacher.EmpFirstname+" "+teacher.EmpLastname + " ( SECTION "+item.Section+" "+new Random().Next(3,9)+" )");
            }
            overAllData.Add(teachersArray);
            var teachersCount = teachersArray.Count - 1;
            var templateCount = _context.QuestionAnswer.Where(q => q.Tid.Equals(singleCourseGraphCriteria.tid)).Count();
            for (int j = 1; j < templateCount - 1; j++)
            {
                ArrayList arrayList = new ArrayList();
                for (int k = 0; k < teachersCount; k++)
                {
                    if (k == 0) { arrayList.Add("Q: " + j); }
                    arrayList.Add(new Random().Next(1, 6));

                }
                overAllData.Add(arrayList);
            }


            //List<GroupedGraphDataTeacher> groupedGraphDataTeachers = new List<GroupedGraphDataTeacher>();
            //int i = 0;
            //foreach (var criteria in criterias)
            //{
            //    var result = _context.Eval
            //    .Join(_context.QuestionAnswer, e => e.QuestionDesc, q => q.QuestionId,
            //    (e, q) => new { eval = e, questionAnswer = q })
            //    .Where(e => e.eval.EmpNo == criteria.EmpNo &&
            //    e.eval.CourseNo == criteria.CourseNo &&
            //    e.eval.SemesterNo == criteria.SemesterNo &&
            //    e.questionAnswer.Tid == singleTeacherGraphCriteria.tid
            //    )

            //   .GroupBy(r => r.eval.QuestionDesc)
            //   .Select(c => new SimpleBarChart { x = $"Q:{c.Key}", y = c.Average(v => v.eval.AnswerMarks) });

            //    groupedGraphDataTeachers.Add(new GroupedGraphDataTeacher
            //    {
            //        label=result.ToList().Count > 0 ? result.ToList()[i].x : "",
            //        values=result.ToList()
            //    });

            //    i++;
            //}

            return new JsonResult(overAllData);


        }
    }
}