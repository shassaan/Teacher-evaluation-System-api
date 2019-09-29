using System;
using System.Collections.Generic;

namespace TESApi.Models
{
    public partial class Templates
    {
        public Templates()
        {
            Groups = new HashSet<Groups>();
            Options = new HashSet<Options>();
            QuestionAnswer = new HashSet<QuestionAnswer>();
            TemplateType = new HashSet<TemplateType>();
        }

        public int Id { get; set; }
        public string TName { get; set; }

        public virtual ICollection<Groups> Groups { get; set; }
        public virtual ICollection<Options> Options { get; set; }
        public virtual ICollection<QuestionAnswer> QuestionAnswer { get; set; }
        public virtual ICollection<TemplateType> TemplateType { get; set; }
    }
}
