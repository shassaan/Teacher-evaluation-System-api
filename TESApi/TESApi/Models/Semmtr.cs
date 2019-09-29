using System;
using System.Collections.Generic;

namespace TESApi.Models
{
    public partial class Semmtr
    {
        public Semmtr()
        {
            Accgpa = new HashSet<Accgpa>();
            Crsdtl = new HashSet<Crsdtl>();
        }

        public string SemesterNo { get; set; }
        public string SemesterDesc { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Accgpa> Accgpa { get; set; }
        public virtual ICollection<Crsdtl> Crsdtl { get; set; }
    }
}
