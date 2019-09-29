using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TESApi.Models
{
    public partial class biitDbNewContext : DbContext
    {
        public biitDbNewContext()
        {
        }

        public biitDbNewContext(DbContextOptions<biitDbNewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accgpa> Accgpa { get; set; }
        public virtual DbSet<AggScore> AggScore { get; set; }
        public virtual DbSet<Allocate> Allocate { get; set; }
        public virtual DbSet<Crsdtl> Crsdtl { get; set; }
        public virtual DbSet<Crsmtr> Crsmtr { get; set; }
        public virtual DbSet<CustomEvaluation> CustomEvaluation { get; set; }
        public virtual DbSet<Empmtr> Empmtr { get; set; }
        public virtual DbSet<Eval> Eval { get; set; }
        public virtual DbSet<GroupStudents> GroupStudents { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Options> Options { get; set; }
        public virtual DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        public virtual DbSet<Semmtr> Semmtr { get; set; }
        public virtual DbSet<Stmtr> Stmtr { get; set; }
        public virtual DbSet<TemplateType> TemplateType { get; set; }
        public virtual DbSet<Templates> Templates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=biitDbNew;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Accgpa>(entity =>
            {
                entity.HasKey(e => new { e.RegNo, e.SemesterNo, e.Section })
                    .HasName("PK_Accgpa_1");

                entity.Property(e => e.RegNo)
                    .HasColumnName("REG_NO")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.SemesterNo)
                    .HasColumnName("SEMESTER_NO")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Section)
                    .HasColumnName("SECTION")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Cgpa)
                    .HasColumnName("CGPA")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.CharWork)
                    .HasColumnName("CHAR_WORK")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CrCurrSem)
                    .HasColumnName("CR_CURR_SEM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.CrPrev)
                    .HasColumnName("CR_PREV")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.CrTotal)
                    .HasColumnName("CR_TOTAL")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DropCount).HasColumnName("dropCount");

                entity.Property(e => e.QCurrSem)
                    .HasColumnName("Q_CURR_SEM")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.QPrev)
                    .HasColumnName("Q_PREV")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.QTotal)
                    .HasColumnName("Q_TOTAL")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.SemStatus)
                    .HasColumnName("SEM_STATUS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SynInt)
                    .HasColumnName("SYN_INT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.RegNoNavigation)
                    .WithMany(p => p.Accgpa)
                    .HasForeignKey(d => d.RegNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk1_reg_no");

                entity.HasOne(d => d.SemesterNoNavigation)
                    .WithMany(p => p.Accgpa)
                    .HasForeignKey(d => d.SemesterNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_semno1");
            });

            modelBuilder.Entity<AggScore>(entity =>
            {
                entity.HasKey(e => new { e.CourseNo, e.Discipline, e.Sos });

                entity.Property(e => e.CourseNo)
                    .HasColumnName("COURSE_NO")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Discipline)
                    .HasColumnName("DISCIPLINE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sos)
                    .HasColumnName("SOS")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AggAssi)
                    .HasColumnName("AGG_ASSI")
                    .HasMaxLength(3);

                entity.Property(e => e.AggFinal)
                    .HasColumnName("AGG_FINAL")
                    .HasMaxLength(3);

                entity.Property(e => e.AggMidterm)
                    .HasColumnName("AGG_MIDTERM")
                    .HasMaxLength(3);

                entity.Property(e => e.AggPraca)
                    .HasColumnName("AGG_PRACA")
                    .HasMaxLength(3);

                entity.Property(e => e.AggPracb)
                    .HasColumnName("AGG_PRACB")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.AggPracc)
                    .HasColumnName("AGG_PRACC")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.AggPracd)
                    .HasColumnName("AGG_PRACD")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.AggPrace)
                    .HasColumnName("AGG_PRACE")
                    .HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.Crsmtr)
                    .WithOne(p => p.AggScore)
                    .HasForeignKey<AggScore>(d => new { d.CourseNo, d.Discipline, d.Sos })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_courseAggs");
            });

            modelBuilder.Entity<Allocate>(entity =>
            {
                entity.HasKey(e => e.AllId)
                    .HasName("PK__ALLOCATE__357E6AF3FCC8209B");

                entity.ToTable("ALLOCATE");

                entity.Property(e => e.AllId).HasColumnName("all_id");

                entity.Property(e => e.CourseNo)
                    .IsRequired()
                    .HasColumnName("COURSE_NO")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Discipline)
                    .IsRequired()
                    .HasColumnName("DISCIPLINE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmpNo)
                    .IsRequired()
                    .HasColumnName("EMP_NO")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Lec1Dt)
                    .HasColumnName("LEC1_DT")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lec2Dt)
                    .HasColumnName("LEC2_DT")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lec3Dt)
                    .HasColumnName("LEC3_DT")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Section)
                    .IsRequired()
                    .HasColumnName("SECTION")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SemesterNo)
                    .IsRequired()
                    .HasColumnName("SEMESTER_NO")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Sos)
                    .IsRequired()
                    .HasColumnName("SOS")
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Crsdtl>(entity =>
            {
                entity.HasKey(e => new { e.CourseNo, e.AttemptNo, e.RegNo, e.SemesterNo, e.Discipline, e.Sos })
                    .HasName("PK_Crsdtl_1");

                entity.Property(e => e.CourseNo)
                    .HasColumnName("Course_no")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.AttemptNo)
                    .HasColumnName("ATTEMPT_NO")
                    .HasMaxLength(1);

                entity.Property(e => e.RegNo)
                    .HasColumnName("REG_NO")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.SemesterNo)
                    .HasColumnName("SEMESTER_NO")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Discipline)
                    .HasColumnName("DISCIPLINE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sos)
                    .HasColumnName("SOS")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AssiScore)
                    .HasColumnName("Assi_score")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.CourseAcw)
                    .HasColumnName("Course_acw")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EmpNo)
                    .IsRequired()
                    .HasColumnName("Emp_no")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.FinAtt)
                    .HasColumnName("Fin_att")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.FinalScore)
                    .HasColumnName("Final_score")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Grade)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.MidAtt)
                    .HasColumnName("Mid_att")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.MidtermScore)
                    .HasColumnName("Midterm_score")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PGrade)
                    .HasColumnName("pGrade")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PracScore)
                    .HasColumnName("Prac_score")
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Praca)
                    .HasColumnName("PRACA")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Pracb)
                    .HasColumnName("PRACB")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Pracc)
                    .HasColumnName("PRACC")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Pracd)
                    .HasColumnName("PRACD")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Prace)
                    .HasColumnName("PRACE")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.QPoints)
                    .HasColumnName("Q_points")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Section)
                    .IsRequired()
                    .HasColumnName("SECTION")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.RegNoNavigation)
                    .WithMany(p => p.Crsdtl)
                    .HasForeignKey(d => d.RegNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reg");

                entity.HasOne(d => d.SemesterNoNavigation)
                    .WithMany(p => p.Crsdtl)
                    .HasForeignKey(d => d.SemesterNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_semno");

                entity.HasOne(d => d.Crsmtr)
                    .WithMany(p => p.Crsdtl)
                    .HasForeignKey(d => new { d.CourseNo, d.Discipline, d.Sos })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CRSDIS");
            });

            modelBuilder.Entity<Crsmtr>(entity =>
            {
                entity.HasKey(e => new { e.CourseNo, e.Discipline, e.Sos });

                entity.ToTable("CRSMTR");

                entity.Property(e => e.CourseNo)
                    .HasColumnName("Course_no")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Discipline)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sos)
                    .HasColumnName("SOS")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CourseDesc)
                    .HasColumnName("Course_desc")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.CourseType)
                    .HasColumnName("Course_type")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreditHrs)
                    .HasColumnName("Credit_hrs")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ElectiveCourse).HasColumnName("ELective_course");

                entity.Property(e => e.OldSos)
                    .HasColumnName("Old_SOS")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SosDesc)
                    .IsRequired()
                    .HasColumnName("SOS_DESC")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomEvaluation>(entity =>
            {
                entity.ToTable("customEvaluation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("date");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.HasOne(d => d.G)
                    .WithMany(p => p.CustomEvaluation)
                    .HasForeignKey(d => d.Gid)
                    .HasConstraintName("FK__customEvalu__gid__11007AA7");
            });

            modelBuilder.Entity<Empmtr>(entity =>
            {
                entity.HasKey(e => e.EmpNo)
                    .HasName("pk_emp_no");

                entity.ToTable("EMPMTR");

                entity.Property(e => e.EmpNo)
                    .HasColumnName("Emp_no")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DsgnNo)
                    .HasColumnName("Dsgn_no")
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.EmpEmail)
                    .HasColumnName("Emp_email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmpFirstname)
                    .HasColumnName("Emp_firstname")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.EmpLastname)
                    .HasColumnName("Emp_lastname")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.EmpMiddle)
                    .HasColumnName("Emp_middle")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.JoiningDate)
                    .HasColumnName("Joining_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nic)
                    .HasColumnName("NIC")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PerAddress)
                    .HasColumnName("Per_address")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.PerCity)
                    .HasColumnName("Per_city")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PrAddress)
                    .HasColumnName("Pr_address")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.PrCity)
                    .HasColumnName("Pr_city")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ResTelno)
                    .HasColumnName("Res_telno")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ResignDate)
                    .HasColumnName("Resign_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Eval>(entity =>
            {
                entity.Property(e => e.EvalId).HasColumnName("eval_id");

                entity.Property(e => e.AnswerDesc)
                    .HasColumnName("Answer_Desc")
                    .HasMaxLength(50);

                entity.Property(e => e.AnswerMarks).HasColumnName("Answer_Marks");

                entity.Property(e => e.CourseNo)
                    .IsRequired()
                    .HasColumnName("Course_no")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Discipline)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmpNo)
                    .IsRequired()
                    .HasColumnName("Emp_no")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionDesc).HasColumnName("Question_Desc");

                entity.Property(e => e.RegNo)
                    .IsRequired()
                    .HasColumnName("Reg_No")
                    .HasMaxLength(50);

                entity.Property(e => e.SemesterNo)
                    .IsRequired()
                    .HasColumnName("Semester_no")
                    .HasMaxLength(100);

                entity.HasOne(d => d.QuestionDescNavigation)
                    .WithMany(p => p.Eval)
                    .HasForeignKey(d => d.QuestionDesc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Eval_Question_Answer");
            });

            modelBuilder.Entity<GroupStudents>(entity =>
            {
                entity.ToTable("groupStudents");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.StId)
                    .HasColumnName("stId")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.HasOne(d => d.G)
                    .WithMany(p => p.GroupStudents)
                    .HasForeignKey(d => d.Gid)
                    .HasConstraintName("FK__groupStuden__gid__0E240DFC");

                entity.HasOne(d => d.St)
                    .WithMany(p => p.GroupStudents)
                    .HasForeignKey(d => d.StId)
                    .HasConstraintName("FK__groupStude__stId__0D2FE9C3");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.GId)
                    .HasName("PK__groups__DCD9092096A1DE16");

                entity.ToTable("groups");

                entity.Property(e => e.GId).HasColumnName("gId");

                entity.Property(e => e.GName)
                    .HasColumnName("gName")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TId).HasColumnName("tId");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.TId)
                    .HasConstraintName("FK__groups__tId__0A537D18");
            });

            modelBuilder.Entity<Options>(entity =>
            {
                entity.ToTable("options");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OptionRating).HasColumnName("optionRating");

                entity.Property(e => e.OptionText)
                    .HasColumnName("optionText")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tid).HasColumnName("tid");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.Options)
                    .HasForeignKey(d => d.Tid)
                    .HasConstraintName("FK__options__tid__7740A8A4");
            });

            modelBuilder.Entity<QuestionAnswer>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.ToTable("Question_Answer");

                entity.Property(e => e.QuestionId)
                    .HasColumnName("Question_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Tid).HasColumnName("tid");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.QuestionAnswer)
                    .HasForeignKey(d => d.Tid)
                    .HasConstraintName("FK__Question_An__tid__642DD430");
            });

            modelBuilder.Entity<Semmtr>(entity =>
            {
                entity.HasKey(e => e.SemesterNo)
                    .HasName("pk_semester_no");

                entity.ToTable("SEMMTR");

                entity.Property(e => e.SemesterNo)
                    .HasColumnName("Semester_no")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.EndDate)
                    .HasColumnName("End_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SemesterDesc)
                    .HasColumnName("Semester_desc")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnName("Start_date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Stmtr>(entity =>
            {
                entity.HasKey(e => e.RegNo)
                    .HasName("pk_reg_no");

                entity.ToTable("STMTR");

                entity.Property(e => e.RegNo)
                    .HasColumnName("Reg_No")
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccStatus)
                    .HasColumnName("Acc_status")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.AdStatus)
                    .HasColumnName("Ad_status")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AdmDate)
                    .HasColumnName("Adm_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.AppNo)
                    .IsRequired()
                    .HasColumnName("App_no")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate)
                    .HasColumnName("Birth_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DegNo)
                    .HasColumnName("Deg_No")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.DegreeReceived)
                    .HasColumnName("Degree_Received")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Domicile)
                    .HasColumnName("DOMICILE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmTelno)
                    .HasColumnName("Em_telno")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EnrlStatus)
                    .HasColumnName("Enrl_status")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.FatherName)
                    .HasColumnName("Father_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FinStatus)
                    .HasColumnName("Fin_status")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FinalCourse)
                    .HasColumnName("Final_course")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatus)
                    .HasColumnName("Marital_status")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NicNo)
                    .HasColumnName("Nic_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('123')");

                entity.Property(e => e.PerAddress)
                    .HasColumnName("Per_address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PerCity)
                    .HasColumnName("Per_city")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PerTelno)
                    .HasColumnName("Per_telno")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PrAddress)
                    .HasColumnName("Pr_address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrCity)
                    .HasColumnName("Pr_city")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pref1)
                    .HasColumnName("Pref_1")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Pref2)
                    .HasColumnName("Pref_2")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Section)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SemesterNo)
                    .HasColumnName("Semester_no")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Sess)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Sos)
                    .HasColumnName("SOS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StAssets)
                    .HasColumnName("St_assets")
                    .HasMaxLength(10);

                entity.Property(e => e.StEmail)
                    .HasColumnName("St_email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StFirstname)
                    .HasColumnName("St_firstname")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StLastname)
                    .HasColumnName("St_lastname")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StMiddlename)
                    .HasColumnName("St_middlename")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StStatus)
                    .HasColumnName("St_status")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.UaarRegNo)
                    .HasColumnName("Uaar_reg_no")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WhomStatus)
                    .HasColumnName("Whom_STATUS")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Year)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TemplateType>(entity =>
            {
                entity.ToTable("templateType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssignTo)
                    .HasColumnName("assignTo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Tid).HasColumnName("tid");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.TemplateType)
                    .HasForeignKey(d => d.Tid)
                    .HasConstraintName("FK__templateTyp__tid__6CC31A31");
            });

            modelBuilder.Entity<Templates>(entity =>
            {
                entity.ToTable("templates");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TName)
                    .HasColumnName("tName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
