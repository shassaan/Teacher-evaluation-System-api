using System;
using System.Collections.Generic;

namespace TESApi.Models
{
    public partial class TemplateType
    {
        public int Id { get; set; }
        public int? Tid { get; set; }
        public string AssignTo { get; set; }

        public virtual Templates T { get; set; }
    }
}
