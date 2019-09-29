using System;
using System.Collections.Generic;

namespace TESApi.Models
{
    public partial class Eval
    {
        public string EmpNo { get; set; }
        public string RegNo { get; set; }
        public string CourseNo { get; set; }
        public string Discipline { get; set; }
        public string SemesterNo { get; set; }
        public int QuestionDesc { get; set; }
        public string AnswerDesc { get; set; }
        public int? AnswerMarks { get; set; }
        public int EvalId { get; set; }

        public virtual QuestionAnswer QuestionDescNavigation { get; set; }
    }
}
