using System;
using System.Collections.Generic;

namespace TESApi.Models
{
    public partial class Groups
    {
        public Groups()
        {
            CustomEvaluation = new HashSet<CustomEvaluation>();
            GroupStudents = new HashSet<GroupStudents>();
        }

        public int GId { get; set; }
        public string GName { get; set; }
        public int? TId { get; set; }

        public virtual Templates T { get; set; }
        public virtual ICollection<CustomEvaluation> CustomEvaluation { get; set; }
        public virtual ICollection<GroupStudents> GroupStudents { get; set; }
    }
}
