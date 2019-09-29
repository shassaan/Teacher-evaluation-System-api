using System;
using System.Collections.Generic;

namespace TESApi.Models
{
    public partial class Crsmtr
    {
        public Crsmtr()
        {
            Crsdtl = new HashSet<Crsdtl>();
        }

        public string CourseNo { get; set; }
        public string Discipline { get; set; }
        public string CourseDesc { get; set; }
        public string CreditHrs { get; set; }
        public string CourseType { get; set; }
        public string Sos { get; set; }
        public string SosDesc { get; set; }
        public int? ElectiveCourse { get; set; }
        public string OldSos { get; set; }

        public virtual AggScore AggScore { get; set; }
        public virtual ICollection<Crsdtl> Crsdtl { get; set; }
    }
}
