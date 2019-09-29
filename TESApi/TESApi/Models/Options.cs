using System;
using System.Collections.Generic;

namespace TESApi.Models
{
    public partial class Options
    {
        public int Id { get; set; }
        public string OptionText { get; set; }
        public int? OptionRating { get; set; }
        public int? Tid { get; set; }

        public virtual Templates T { get; set; }
    }
}
