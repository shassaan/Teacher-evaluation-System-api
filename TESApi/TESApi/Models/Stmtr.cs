using System;
using System.Collections.Generic;

namespace TESApi.Models
{
    public partial class Stmtr
    {
        public Stmtr()
        {
            Accgpa = new HashSet<Accgpa>();
            Crsdtl = new HashSet<Crsdtl>();
            GroupStudents = new HashSet<GroupStudents>();
        }

        public string RegNo { get; set; }
        public string AppNo { get; set; }
        public string StFirstname { get; set; }
        public string StLastname { get; set; }
        public string StMiddlename { get; set; }
        public string FatherName { get; set; }
        public string StEmail { get; set; }
        public string Sex { get; set; }
        public string UaarRegNo { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime BirthDate { get; set; }
        public string NicNo { get; set; }
        public string PrAddress { get; set; }
        public string PrCity { get; set; }
        public string PerAddress { get; set; }
        public string PerCity { get; set; }
        public string EmTelno { get; set; }
        public string PerTelno { get; set; }
        public string AdStatus { get; set; }
        public string Sess { get; set; }
        public string Pref1 { get; set; }
        public string Pref2 { get; set; }
        public DateTime? AdmDate { get; set; }
        public string SemesterNo { get; set; }
        public string Remarks { get; set; }
        public string StStatus { get; set; }
        public string UserId { get; set; }
        public string AccStatus { get; set; }
        public string StAssets { get; set; }
        public string WhomStatus { get; set; }
        public string FinStatus { get; set; }
        public string FinalCourse { get; set; }
        public string EnrlStatus { get; set; }
        public string Domicile { get; set; }
        public string DegreeReceived { get; set; }
        public string DegNo { get; set; }
        public string Year { get; set; }
        public string Sos { get; set; }
        public string Section { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Accgpa> Accgpa { get; set; }
        public virtual ICollection<Crsdtl> Crsdtl { get; set; }
        public virtual ICollection<GroupStudents> GroupStudents { get; set; }
    }
}
