using System;
using System.Collections.Generic;

namespace TESApi.Models
{
    public partial class Accgpa
    {
        public string RegNo { get; set; }
        public string SemesterNo { get; set; }
        public string CharWork { get; set; }
        public string SynInt { get; set; }
        public decimal? QPrev { get; set; }
        public decimal? QCurrSem { get; set; }
        public decimal? QTotal { get; set; }
        public decimal? CrPrev { get; set; }
        public decimal? CrCurrSem { get; set; }
        public decimal? CrTotal { get; set; }
        public decimal? Cgpa { get; set; }
        public string UserId { get; set; }
        public string Section { get; set; }
        public string SemStatus { get; set; }
        public int? SemC { get; set; }
        public int? DropCount { get; set; }

        public virtual Stmtr RegNoNavigation { get; set; }
        public virtual Semmtr SemesterNoNavigation { get; set; }
    }
}
