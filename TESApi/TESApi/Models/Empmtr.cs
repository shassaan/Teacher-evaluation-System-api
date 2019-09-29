using System;
using System.Collections.Generic;

namespace TESApi.Models
{
    public partial class Empmtr
    {
        public string EmpNo { get; set; }
        public string EmpFirstname { get; set; }
        public string EmpLastname { get; set; }
        public string EmpMiddle { get; set; }
        public string DsgnNo { get; set; }
        public string PerAddress { get; set; }
        public string PerCity { get; set; }
        public string PrAddress { get; set; }
        public string PrCity { get; set; }
        public string ResTelno { get; set; }
        public string EmpEmail { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? ResignDate { get; set; }
        public string Status { get; set; }
        public string Nic { get; set; }
        public string Password { get; set; }
    }
}
