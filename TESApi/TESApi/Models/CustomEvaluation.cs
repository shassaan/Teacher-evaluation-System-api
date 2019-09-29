using System;
using System.Collections.Generic;

namespace TESApi.Models
{
    public partial class CustomEvaluation
    {
        public int Id { get; set; }
        public int? Gid { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Groups G { get; set; }
    }
}
