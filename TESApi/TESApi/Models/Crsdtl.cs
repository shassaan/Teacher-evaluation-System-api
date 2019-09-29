using System;
using System.Collections.Generic;

namespace TESApi.Models
{
    public partial class Crsdtl
    {
        public string CourseNo { get; set; }
        public string AttemptNo { get; set; }
        public string RegNo { get; set; }
        public string EmpNo { get; set; }
        public string SemesterNo { get; set; }
        public string CourseAcw { get; set; }
        public string Section { get; set; }
        public decimal? FinalScore { get; set; }
        public decimal? MidtermScore { get; set; }
        public decimal? AssiScore { get; set; }
        public decimal? PracScore { get; set; }
        public string Grade { get; set; }
        public decimal? QPoints { get; set; }
        public string UserId { get; set; }
        public string Discipline { get; set; }
        public decimal? Praca { get; set; }
        public decimal? Pracb { get; set; }
        public decimal? Pracc { get; set; }
        public decimal? Pracd { get; set; }
        public decimal? Prace { get; set; }
        public string Sos { get; set; }
        public string PGrade { get; set; }
        public string MidAtt { get; set; }
        public string FinAtt { get; set; }

        public virtual Crsmtr Crsmtr { get; set; }
        public virtual Stmtr RegNoNavigation { get; set; }
        public virtual Semmtr SemesterNoNavigation { get; set; }
    }
}
