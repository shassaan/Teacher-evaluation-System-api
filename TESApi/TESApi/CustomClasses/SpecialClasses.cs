
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TESApi.ReportModels;

namespace TESApi.CustomClasses
{
    public class GroupedGraphDataTeacher
    {
        public string label { get; set; }
        public List<SimpleBarChart> values { get; set; }
    }

    public class EvaluationData
    {
        public string EmpNo { get; set; }
        public string RegNo { get; set; }
        public string CourseNo { get; set; }
        public string Discipline { get; set; }
        public string SemesterNo { get; set; }
        public List<ResultData> Questions { get; set; }
    }

    public class ResultData
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    


    
}
