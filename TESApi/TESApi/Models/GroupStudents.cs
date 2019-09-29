using System;
using System.Collections.Generic;

namespace TESApi.Models
{
    public partial class GroupStudents
    {
        public int Id { get; set; }
        public string StId { get; set; }
        public int? Gid { get; set; }

        public virtual Groups G { get; set; }
        public virtual Stmtr St { get; set; }
    }
}
