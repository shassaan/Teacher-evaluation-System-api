using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TESApi.CustomClasses
{
    public class BasicGraphCriteria
    {
        public string teacher { get; set; }
        public string disp { get; set; }
        public string sem { get; set; }
        public string course { get; set; }
        public int tid { get; set; }
    }

    public class StudentCriteria
    {
        public string enrollmentStatus { get; set; }
        public int[] age { get; set; }
        public string[] gender { get; set; }
        public string[] discipline { get; set; }
        public int gid { get; set; }
    }

    public class SingleTeacherGraphCriteria
    {
        public string teacher { get; set; }
        public string sem { get; set; }
        public int tid { get; set; }
    }

    public class SingleCourseGraphCriteria
    {
        public string course { get; set; }
        public string sem { get; set; }
        public int tid { get; set; }
    }

    public class AllocationCriteria
    {
        public string disp { get; set; }
        public string semester { get; set; }
        public string section { get; set; }
        public string SOS { get; set; }
    }
}
