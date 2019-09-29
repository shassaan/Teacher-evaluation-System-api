using System;
using System.Collections.Generic;

namespace TESApi.Models
{
    public partial class QuestionAnswer
    {
        public QuestionAnswer()
        {
            Eval = new HashSet<Eval>();
        }

        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Description { get; set; }
        public int? Tid { get; set; }

        public virtual Templates T { get; set; }
        public virtual ICollection<Eval> Eval { get; set; }
    }
}
