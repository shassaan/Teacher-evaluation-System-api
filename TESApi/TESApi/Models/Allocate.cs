using System;
using System.Collections.Generic;

namespace TESApi.Models
{
    public partial class Allocate
    {
        public string EmpNo { get; set; }
        public string CourseNo { get; set; }
        public string SemesterNo { get; set; }
        public string Section { get; set; }
        public string Discipline { get; set; }
        public string Sos { get; set; }
        public string Lec1Dt { get; set; }
        public string Lec2Dt { get; set; }
        public string Lec3Dt { get; set; }
        public int SemC { get; set; }
        public int AllId { get; set; }
    }
}
