using System;
using System.Collections.Generic;

namespace TESApi.Models
{
    public partial class AggScore
    {
        public string CourseNo { get; set; }
        public string Discipline { get; set; }
        public string AggMidterm { get; set; }
        public string AggAssi { get; set; }
        public string AggFinal { get; set; }
        public string AggPraca { get; set; }
        public decimal? AggPracb { get; set; }
        public decimal? AggPracc { get; set; }
        public decimal? AggPracd { get; set; }
        public decimal? AggPrace { get; set; }
        public string Sos { get; set; }

        public virtual Crsmtr Crsmtr { get; set; }
    }
}
