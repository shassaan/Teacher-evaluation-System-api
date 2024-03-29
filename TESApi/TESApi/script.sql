USE [master]
GO
/****** Object:  Database [biitDbNew]    Script Date: 9/29/2019 2:31:05 PM ******/
CREATE DATABASE [biitDbNew]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NuModule', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\NuModule.mdf' , SIZE = 157696KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NuModule_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\NuModule_log.ldf' , SIZE = 45631808KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [biitDbNew] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [biitDbNew].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [biitDbNew] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [biitDbNew] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [biitDbNew] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [biitDbNew] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [biitDbNew] SET ARITHABORT OFF 
GO
ALTER DATABASE [biitDbNew] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [biitDbNew] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [biitDbNew] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [biitDbNew] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [biitDbNew] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [biitDbNew] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [biitDbNew] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [biitDbNew] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [biitDbNew] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [biitDbNew] SET  DISABLE_BROKER 
GO
ALTER DATABASE [biitDbNew] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [biitDbNew] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [biitDbNew] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [biitDbNew] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [biitDbNew] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [biitDbNew] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [biitDbNew] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [biitDbNew] SET RECOVERY FULL 
GO
ALTER DATABASE [biitDbNew] SET  MULTI_USER 
GO
ALTER DATABASE [biitDbNew] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [biitDbNew] SET DB_CHAINING OFF 
GO
ALTER DATABASE [biitDbNew] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [biitDbNew] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [biitDbNew] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [biitDbNew] SET QUERY_STORE = OFF
GO
USE [biitDbNew]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [biitDbNew]
GO
/****** Object:  Table [dbo].[Accgpa]    Script Date: 9/29/2019 2:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accgpa](
	[REG_NO] [varchar](14) NOT NULL,
	[SEMESTER_NO] [varchar](12) NOT NULL,
	[CHAR_WORK] [char](1) NULL,
	[SYN_INT] [char](1) NULL,
	[Q_PREV] [decimal](5, 2) NULL,
	[Q_CURR_SEM] [decimal](5, 2) NULL,
	[Q_TOTAL] [decimal](6, 2) NULL,
	[CR_PREV] [decimal](6, 2) NULL,
	[CR_CURR_SEM] [decimal](6, 2) NULL,
	[CR_TOTAL] [decimal](6, 2) NULL,
	[CGPA] [decimal](6, 2) NULL,
	[USER_ID] [varchar](10) NULL,
	[SECTION] [char](1) NOT NULL,
	[SEM_STATUS] [char](10) NULL,
	[SemC] [int] NULL,
	[dropCount] [int] NULL,
 CONSTRAINT [PK_Accgpa_1] PRIMARY KEY CLUSTERED 
(
	[REG_NO] ASC,
	[SEMESTER_NO] ASC,
	[SECTION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AggScore]    Script Date: 9/29/2019 2:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AggScore](
	[COURSE_NO] [varchar](9) NOT NULL,
	[DISCIPLINE] [varchar](20) NOT NULL,
	[AGG_MIDTERM] [nvarchar](3) NULL,
	[AGG_ASSI] [nvarchar](3) NULL,
	[AGG_FINAL] [nvarchar](3) NULL,
	[AGG_PRACA] [nvarchar](3) NULL,
	[AGG_PRACB] [decimal](5, 2) NULL,
	[AGG_PRACC] [decimal](5, 2) NULL,
	[AGG_PRACD] [decimal](5, 2) NULL,
	[AGG_PRACE] [decimal](5, 2) NULL,
	[SOS] [char](8) NOT NULL,
 CONSTRAINT [PK_AggScore] PRIMARY KEY CLUSTERED 
(
	[COURSE_NO] ASC,
	[DISCIPLINE] ASC,
	[SOS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ALLOCATE]    Script Date: 9/29/2019 2:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ALLOCATE](
	[EMP_NO] [char](7) NOT NULL,
	[COURSE_NO] [varchar](9) NOT NULL,
	[SEMESTER_NO] [varchar](12) NOT NULL,
	[SECTION] [char](1) NOT NULL,
	[DISCIPLINE] [varchar](20) NOT NULL,
	[SOS] [char](8) NOT NULL,
	[LEC1_DT] [char](20) NULL,
	[LEC2_DT] [char](20) NULL,
	[LEC3_DT] [char](20) NULL,
	[SemC] [int] NOT NULL,
	[all_id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[all_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Crsdtl]    Script Date: 9/29/2019 2:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Crsdtl](
	[Course_no] [varchar](9) NOT NULL,
	[ATTEMPT_NO] [nvarchar](1) NOT NULL,
	[REG_NO] [varchar](14) NOT NULL,
	[Emp_no] [char](7) NOT NULL,
	[SEMESTER_NO] [varchar](12) NOT NULL,
	[Course_acw] [char](1) NULL,
	[SECTION] [char](1) NOT NULL,
	[Final_score] [decimal](5, 2) NULL,
	[Midterm_score] [decimal](5, 2) NULL,
	[Assi_score] [decimal](5, 2) NULL,
	[Prac_score] [decimal](5, 2) NULL,
	[Grade] [char](12) NULL,
	[Q_points] [decimal](5, 2) NULL,
	[USER_ID] [varchar](50) NULL,
	[DISCIPLINE] [varchar](20) NOT NULL,
	[PRACA] [decimal](5, 2) NULL,
	[PRACB] [decimal](5, 2) NULL,
	[PRACC] [decimal](5, 2) NULL,
	[PRACD] [decimal](5, 2) NULL,
	[PRACE] [decimal](5, 2) NULL,
	[SOS] [char](8) NOT NULL,
	[pGrade] [char](1) NULL,
	[Mid_att] [char](1) NULL,
	[Fin_att] [char](1) NULL,
 CONSTRAINT [PK_Crsdtl_1] PRIMARY KEY CLUSTERED 
(
	[Course_no] ASC,
	[ATTEMPT_NO] ASC,
	[REG_NO] ASC,
	[SEMESTER_NO] ASC,
	[DISCIPLINE] ASC,
	[SOS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRSMTR]    Script Date: 9/29/2019 2:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRSMTR](
	[Course_no] [varchar](9) NOT NULL,
	[Discipline] [varchar](20) NOT NULL,
	[Course_desc] [varchar](80) NULL,
	[Credit_hrs] [char](10) NULL,
	[Course_type] [char](15) NULL,
	[SOS] [char](8) NOT NULL,
	[SOS_DESC] [char](50) NOT NULL,
	[ELective_course] [int] NULL,
	[Old_SOS] [char](8) NULL,
 CONSTRAINT [PK_CRSMTR] PRIMARY KEY CLUSTERED 
(
	[Course_no] ASC,
	[Discipline] ASC,
	[SOS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[customEvaluation]    Script Date: 9/29/2019 2:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customEvaluation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[gid] [int] NULL,
	[endDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EMPMTR]    Script Date: 9/29/2019 2:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPMTR](
	[Emp_no] [char](7) NOT NULL,
	[Emp_firstname] [varchar](12) NULL,
	[Emp_lastname] [varchar](12) NULL,
	[Emp_middle] [varchar](12) NULL,
	[Dsgn_no] [char](55) NULL,
	[Per_address] [varchar](70) NULL,
	[Per_city] [varchar](20) NULL,
	[Pr_address] [varchar](70) NULL,
	[Pr_city] [varchar](20) NULL,
	[Res_telno] [varchar](20) NULL,
	[Emp_email] [varchar](30) NULL,
	[Joining_date] [datetime] NULL,
	[Resign_date] [datetime] NULL,
	[Status] [char](15) NULL,
	[NIC] [char](15) NULL,
	[password] [char](200) NULL,
 CONSTRAINT [pk_emp_no] PRIMARY KEY CLUSTERED 
(
	[Emp_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Eval]    Script Date: 9/29/2019 2:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eval](
	[Emp_no] [char](7) NOT NULL,
	[Reg_No] [nvarchar](50) NOT NULL,
	[Course_no] [varchar](9) NOT NULL,
	[Discipline] [varchar](20) NOT NULL,
	[Semester_no] [nvarchar](100) NOT NULL,
	[Question_Desc] [int] NOT NULL,
	[Answer_Desc] [nvarchar](50) NULL,
	[Answer_Marks] [int] NULL,
	[eval_id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[eval_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[groups]    Script Date: 9/29/2019 2:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[groups](
	[gId] [int] IDENTITY(1,1) NOT NULL,
	[gName] [char](200) NULL,
	[tId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[gId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[groupStudents]    Script Date: 9/29/2019 2:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[groupStudents](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[stId] [varchar](14) NULL,
	[gid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[options]    Script Date: 9/29/2019 2:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[options](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[optionText] [char](50) NULL,
	[optionRating] [int] NULL,
	[tid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Question_Answer]    Script Date: 9/29/2019 2:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question_Answer](
	[Question_ID] [int] NOT NULL,
	[Question] [nvarchar](max) NULL,
	[Description] [varchar](30) NULL,
	[tid] [int] NULL,
 CONSTRAINT [PK_Question_Answer] PRIMARY KEY CLUSTERED 
(
	[Question_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SEMMTR]    Script Date: 9/29/2019 2:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEMMTR](
	[Semester_no] [varchar](12) NOT NULL,
	[Semester_desc] [varchar](20) NULL,
	[Start_date] [datetime] NULL,
	[End_date] [datetime] NULL,
 CONSTRAINT [pk_semester_no] PRIMARY KEY CLUSTERED 
(
	[Semester_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[STMTR]    Script Date: 9/29/2019 2:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STMTR](
	[Reg_No] [varchar](14) NOT NULL,
	[App_no] [char](12) NOT NULL,
	[St_firstname] [varchar](25) NULL,
	[St_lastname] [varchar](25) NULL,
	[St_middlename] [varchar](25) NULL,
	[Father_name] [varchar](50) NULL,
	[St_email] [varchar](30) NULL,
	[Sex] [char](1) NULL,
	[Uaar_reg_no] [char](12) NULL,
	[Marital_status] [char](1) NULL,
	[Birth_date] [datetime] NOT NULL,
	[Nic_no] [char](20) NULL,
	[Pr_address] [varchar](100) NULL,
	[Pr_city] [varchar](20) NULL,
	[Per_address] [varchar](100) NULL,
	[Per_city] [varchar](20) NULL,
	[Em_telno] [varchar](20) NULL,
	[Per_telno] [varchar](20) NULL,
	[Ad_status] [varchar](20) NULL,
	[Sess] [char](1) NULL,
	[Pref_1] [varchar](12) NULL,
	[Pref_2] [varchar](12) NULL,
	[Adm_date] [datetime] NULL,
	[Semester_no] [char](6) NULL,
	[Remarks] [varchar](40) NULL,
	[St_status] [char](9) NULL,
	[USER_ID] [varchar](50) NULL,
	[Acc_status] [char](9) NULL,
	[St_assets] [nvarchar](10) NULL,
	[Whom_STATUS] [varchar](20) NULL,
	[Fin_status] [varchar](20) NULL,
	[Final_course] [varchar](12) NULL,
	[Enrl_status] [char](12) NULL,
	[DOMICILE] [varchar](30) NULL,
	[Degree_Received] [char](3) NULL,
	[Deg_No] [char](7) NULL,
	[Year] [char](4) NULL,
	[SOS] [char](10) NULL,
	[Section] [char](1) NULL,
	[password] [char](300) NULL,
 CONSTRAINT [pk_reg_no] PRIMARY KEY CLUSTERED 
(
	[Reg_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[templates]    Script Date: 9/29/2019 2:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[templates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tName] [char](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[templateType]    Script Date: 9/29/2019 2:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[templateType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tid] [int] NULL,
	[assignTo] [char](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Crsdtl] ADD  CONSTRAINT [def]  DEFAULT ((0.00)) FOR [Prac_score]
GO
ALTER TABLE [dbo].[Crsdtl] ADD  CONSTRAINT [def_Midatt]  DEFAULT ('P') FOR [Mid_att]
GO
ALTER TABLE [dbo].[Crsdtl] ADD  CONSTRAINT [def_Finatt]  DEFAULT ('P') FOR [Fin_att]
GO
ALTER TABLE [dbo].[STMTR] ADD  DEFAULT ('123') FOR [password]
GO
ALTER TABLE [dbo].[Accgpa]  WITH CHECK ADD  CONSTRAINT [fk_semno1] FOREIGN KEY([SEMESTER_NO])
REFERENCES [dbo].[SEMMTR] ([Semester_no])
GO
ALTER TABLE [dbo].[Accgpa] CHECK CONSTRAINT [fk_semno1]
GO
ALTER TABLE [dbo].[Accgpa]  WITH NOCHECK ADD  CONSTRAINT [fk1_reg_no] FOREIGN KEY([REG_NO])
REFERENCES [dbo].[STMTR] ([Reg_No])
GO
ALTER TABLE [dbo].[Accgpa] CHECK CONSTRAINT [fk1_reg_no]
GO
ALTER TABLE [dbo].[AggScore]  WITH CHECK ADD  CONSTRAINT [fk_courseAggs] FOREIGN KEY([COURSE_NO], [DISCIPLINE], [SOS])
REFERENCES [dbo].[CRSMTR] ([Course_no], [Discipline], [SOS])
GO
ALTER TABLE [dbo].[AggScore] CHECK CONSTRAINT [fk_courseAggs]
GO
ALTER TABLE [dbo].[Crsdtl]  WITH CHECK ADD  CONSTRAINT [fk_CRSDIS] FOREIGN KEY([Course_no], [DISCIPLINE], [SOS])
REFERENCES [dbo].[CRSMTR] ([Course_no], [Discipline], [SOS])
GO
ALTER TABLE [dbo].[Crsdtl] CHECK CONSTRAINT [fk_CRSDIS]
GO
ALTER TABLE [dbo].[Crsdtl]  WITH CHECK ADD  CONSTRAINT [fk_reg] FOREIGN KEY([REG_NO])
REFERENCES [dbo].[STMTR] ([Reg_No])
GO
ALTER TABLE [dbo].[Crsdtl] CHECK CONSTRAINT [fk_reg]
GO
ALTER TABLE [dbo].[Crsdtl]  WITH CHECK ADD  CONSTRAINT [fk_semno] FOREIGN KEY([SEMESTER_NO])
REFERENCES [dbo].[SEMMTR] ([Semester_no])
GO
ALTER TABLE [dbo].[Crsdtl] CHECK CONSTRAINT [fk_semno]
GO
ALTER TABLE [dbo].[customEvaluation]  WITH CHECK ADD FOREIGN KEY([gid])
REFERENCES [dbo].[groups] ([gId])
GO
ALTER TABLE [dbo].[Eval]  WITH CHECK ADD  CONSTRAINT [FK_Eval_Question_Answer] FOREIGN KEY([Question_Desc])
REFERENCES [dbo].[Question_Answer] ([Question_ID])
GO
ALTER TABLE [dbo].[Eval] CHECK CONSTRAINT [FK_Eval_Question_Answer]
GO
ALTER TABLE [dbo].[groups]  WITH CHECK ADD FOREIGN KEY([tId])
REFERENCES [dbo].[templates] ([id])
GO
ALTER TABLE [dbo].[groupStudents]  WITH CHECK ADD FOREIGN KEY([stId])
REFERENCES [dbo].[STMTR] ([Reg_No])
GO
ALTER TABLE [dbo].[groupStudents]  WITH CHECK ADD FOREIGN KEY([gid])
REFERENCES [dbo].[groups] ([gId])
GO
ALTER TABLE [dbo].[options]  WITH CHECK ADD FOREIGN KEY([tid])
REFERENCES [dbo].[templates] ([id])
GO
ALTER TABLE [dbo].[Question_Answer]  WITH CHECK ADD FOREIGN KEY([tid])
REFERENCES [dbo].[templates] ([id])
GO
ALTER TABLE [dbo].[templateType]  WITH CHECK ADD FOREIGN KEY([tid])
REFERENCES [dbo].[templates] ([id])
GO
/****** Object:  StoredProcedure [dbo].[sp_Teachers_Semester_wise_evaluation]    Script Date: 9/29/2019 2:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[sp_Teachers_Semester_wise_evaluation] 
(
@Employee_No as varchar(250) = null,
--@SemesterRange as varchar(max) = null,
@QuestionID as varchar(10) = null,
@sem_range1 as varchar(250) = null,
@sem_range2 as varchar(250) = null,
@sem_range3 as varchar(250) = null,
@sem_stu_1 as int = null,
--@sem_stu_2 as varchar(250) = null,
--@sem_stu_3 as varchar(250) = null,

@print as int = null

)
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

Declare @QuesID varchar(6)
Declare @Ques varchar(MAX)
Declare  @Exc1 int
Declare  @Exc2 int
Declare  @Exc3 int
Declare  @Good1 int
Declare  @Good2 int
Declare  @Good3 int
Declare  @Avrg1 int
Declare  @Avrg2 int
Declare  @Avrg3 int
Declare  @BeAvg1 int
Declare  @BeAvg2 int
Declare  @BeAvg3 int
Declare  @Poor1 int
Declare  @Poor2 int
Declare  @Poor3 int

Declare @semester varchar(MAX)

Declare @query as nvarchar(max)

set @query = ''


set @QuesID =(SELECT DISTINCT Question_Answer.Question_ID
FROM         Eval INNER JOIN
                      Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN
                      EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no
                      
						where Eval.Emp_no=@Employee_No
					  -- and Eval.Course_no='CS-701' 
						--and Eval.Semester_no in ('2013SE','2013SM') 
					   
					  and Question_Answer.Question_ID=@QuestionID)


set @Ques = (select distinct Question_Answer.Question  from 
  Eval INNER JOIN 
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN  
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no 
   where Eval.Emp_no=@Employee_No
  -- and Eval.Course_no='CS-701' 
    --and Eval.Semester_no in ('2013SE','2013SM') 
   
  and Question_Answer.Question_ID=@QuestionID)


set @Exc1 = (select COUNT(*) as Excellent1
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
    where Eval.Emp_no=@Employee_No 
   --and Eval.Course_no='CS-701'  
and Eval.Semester_no =@sem_range1 
 
   and Question_Answer.Question_ID=@QuestionID   
   and Answer_Desc='Excellent' )
   
   
   set @Exc2 = (select COUNT(*) as Excellent2
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
    where Eval.Emp_no=@Employee_No 
   --and Eval.Course_no='CS-701'  
and Eval.Semester_no = @sem_range2
 
   and Question_Answer.Question_ID=@QuestionID   
   and Answer_Desc='Excellent' )
   
   
   set @Exc3 = (select COUNT(*) as Excellent3
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
    where Eval.Emp_no=@Employee_No 
   --and Eval.Course_no='CS-701'  
and Eval.Semester_no = @sem_range3
 
   and Question_Answer.Question_ID=@QuestionID  
   and Answer_Desc='Excellent' )
   
   
set @Good1 = (select COUNT(*) 
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  

    where Eval.Emp_no=@Employee_No 
   --and Eval.Course_no='CS-701'  
   and Eval.Semester_no =@sem_range1
   and Question_Answer.Question_ID=@QuestionID   
   and Answer_Desc='Good')
   
   set @Good2 = (select COUNT(*) 
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  

    where Eval.Emp_no=@Employee_No
   --and Eval.Course_no='CS-701'  
   and Eval.Semester_no = @sem_range2
   and Question_Answer.Question_ID=@QuestionID   
   and Answer_Desc='Good')
   
   set @Good3 = (select COUNT(*) 
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  

    where Eval.Emp_no=@Employee_No 
   --and Eval.Course_no='CS-701'  
   and Eval.Semester_no =@sem_range3
   and Question_Answer.Question_ID=@QuestionID  
   and Answer_Desc='Good')
   
set @Avrg1 = (select COUNT(*) 
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  

   where Eval.Emp_no=@Employee_No 
   --and Eval.Course_no='CS-701'  
  and Eval.Semester_no =@sem_range1
   and Question_Answer.Question_ID=@QuestionID   
   and Answer_Desc='Average'  
   )
   
set @Avrg2 = (select COUNT(*) 
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  

   where Eval.Emp_no=@Employee_No 
   --and Eval.Course_no='CS-701'  
  and Eval.Semester_no =@sem_range2
   and Question_Answer.Question_ID=@QuestionID   
   and Answer_Desc='Average'  
   )
   
set @Avrg3 = (select COUNT(*) 
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  

   where Eval.Emp_no=@Employee_No 
   --and Eval.Course_no='CS-701'  
  and Eval.Semester_no =@sem_range3
   and Question_Answer.Question_ID=@QuestionID   
   and Answer_Desc='Average'  
   )   
   
set @BeAvg1 = (select COUNT(*)  
FROM    Eval INNER JOIN    
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
   where Eval.Emp_no=@Employee_No 
   --and Eval.Course_no='CS-701'  
 and Eval.Semester_no =@sem_range1
   and Question_Answer.Question_ID=@QuestionID   
      
   and Answer_Desc='Below Average'  
   )
   
set @BeAvg2 = (select COUNT(*)  
FROM    Eval INNER JOIN    
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
   where Eval.Emp_no=@Employee_No
   --and Eval.Course_no='CS-701'  
 and Eval.Semester_no =@sem_range2
   and Question_Answer.Question_ID=@QuestionID   
      
   and Answer_Desc='Below Average'  
   ) 
   
set @BeAvg3 = (select COUNT(*)  
FROM    Eval INNER JOIN    
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
   where Eval.Emp_no=@Employee_No 
   --and Eval.Course_no='CS-701'  
 and Eval.Semester_no =@sem_range3
   and Question_Answer.Question_ID=@QuestionID   
      
   and Answer_Desc='Below Average'  
   )   
   
set @Poor1 =(select COUNT(*)
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
  where Eval.Emp_no=@Employee_No
   --and Eval.Course_no='CS-701'  
  and Eval.Semester_no =@sem_range1
   
   and Question_Answer.Question_ID=@QuestionID   
   and Answer_Desc='Poor'  
   )   
   
set @Poor2 =(select COUNT(*)
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
  where Eval.Emp_no=@Employee_No
   --and Eval.Course_no='CS-701'  
  and Eval.Semester_no =@sem_range2
   
   and Question_Answer.Question_ID=@QuestionID  
   and Answer_Desc='Poor'  
   )  
   
set @Poor3 =(select COUNT(*)
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
  where Eval.Emp_no=@Employee_No 
   --and Eval.Course_no='CS-701'  
  and Eval.Semester_no =@sem_range3
   
   and Question_Answer.Question_ID=@QuestionID   
   and Answer_Desc='Poor'  
   )                                                                            

--set @query = @query + '             
--Select ''' + @Ques + ''' as Question ,''' +isnull( convert(varchar(250),@Exc1),0) +''' as Excellent1,''' + isnull(convert(varchar(250),@Exc2),0) +''' as Excellent2,''' + isnull(convert(varchar(250),@Exc3),0) +''' as Excellent3,''' 
--+isnull(convert(varchar(250),@Good1),0)+''' as Good1,''' +isnull(convert(varchar(250),@Good2),0)+''' as Good2,'''+isnull(convert(varchar(250),@Good3),0)+''' as Good3,'''
--+isnull(convert(varchar(250),@Avrg1),0)+''' as Average1,''' +isnull(convert(varchar(250),@Avrg2),0)+''' as Average2,'''+isnull(convert(varchar(250),@Avrg3),0)+''' as Average3,'''
--+isnull(convert(varchar(250),@BeAvg1),0)+''' as BelowAverage1,'''+isnull(convert(varchar(250),@BeAvg2),0)+''' as BelowAverage2,'''+isnull(convert(varchar(250),@BeAvg3),0)+''' as BelowAverage3,'''
--+isnull(convert(varchar(250),@Poor1),0)+''' as Poor1,'''+isnull(convert(varchar(250),@Poor2),0)+''' as Poor2,'''+isnull(convert(varchar(250),@Poor3),0)+''' as Poor3'
----,
--(@Exc*5)+(@Good*4)+(@Avrg*3)+(@BeAvg*2)+(@Poor*1) as Total,
--((@Exc*5)+(@Good*4)+(@Avrg*3)+(@BeAvg*2)+(@Poor*1))/5 as Average

 Select @QuesID as QuesID, @Ques as Question,
            
             ((@Exc1*5)+(@Good1*4)+(@Avrg1*3)+(@BeAvg1*2)+(@Poor1*1))/@sem_stu_1 as Average_Sem1,
             ((@Exc2*5)+(@Good2*4)+(@Avrg2*3)+(@BeAvg2*2)+(@Poor2*1))/@sem_stu_1 as Average_Sem2,
             ((@Exc3*5)+(@Good3*4)+(@Avrg3*3)+(@BeAvg3*2)+(@Poor3*1))/@sem_stu_1 as Average_Sem3
             
             
             
             
--if(@sem_range1!=null)            
--begin             

--end    

--if(@print = 1)
--begin
--print @query
--end
--else            
--begin	
--exec sp_executesql @query
--end

END



GO
/****** Object:  StoredProcedure [dbo].[sp_Teachers_Subject_wise_evaluation]    Script Date: 9/29/2019 2:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_Teachers_Subject_wise_evaluation]

@Sem_No as varchar(60) = null,
@Course_No as varchar(200) = null,	
@QuestionID as varchar(10) = null,
@Employee_No1 as varchar(250) = null,
@Employee_No2 as varchar(250) = null,
@Employee_No3 as varchar(250) = null,
@sem_stu_Total as int = null,
@print as int = null


AS
BEGIN

	SET NOCOUNT ON;

Declare @QuesID varchar(6)
Declare @Ques varchar(MAX)
Declare  @Exc1 int
Declare  @Exc2 int
Declare  @Exc3 int
Declare  @Good1 int
Declare  @Good2 int
Declare  @Good3 int
Declare  @Avrg1 int
Declare  @Avrg2 int
Declare  @Avrg3 int
Declare  @BeAvg1 int
Declare  @BeAvg2 int
Declare  @BeAvg3 int
Declare  @Poor1 int
Declare  @Poor2 int
Declare  @Poor3 int
Declare @semester varchar(MAX)


Declare @query as nvarchar(max)




set @QuesID =(SELECT DISTINCT Question_Answer.Question_ID
FROM         Eval INNER JOIN
                      Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN
                      EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no
                  	 where Eval.Emp_no=@Employee_No1
					   and Eval.Course_no=@Course_No 
					 and Eval.Semester_no = @Sem_No 
					  and Question_Answer.Question_ID=@QuestionID)


set @Ques = (select distinct Question_Answer.Question  from 
  Eval INNER JOIN 
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN  
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no 
   where  Eval.Course_no=@Course_No  
    and Eval.Semester_no = @Sem_No 
   and Question_Answer.Question_ID=@QuestionID)


set @Exc1 = (select COUNT(*) as Excellent1
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
    where Eval.Emp_no=@Employee_No1 
   
   and Eval.Course_no=@Course_No   
    and Eval.Semester_no = @Sem_No 
   and Question_Answer.Question_ID=@QuestionID   
   and Answer_Desc='Excellent' )
   
   
   set @Exc2 = (select COUNT(*) as Excellent2
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
    where Eval.Emp_no=@Employee_No2
   
   and Eval.Course_no=@Course_No   
    and Eval.Semester_no = @Sem_No 
   and Question_Answer.Question_ID=@QuestionID   
   and Answer_Desc='Excellent' )
   
   
   set @Exc3 = (select COUNT(*) as Excellent3
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
   where Eval.Emp_no=@Employee_No3
   
   and Eval.Course_no=@Course_No   
    and Eval.Semester_no = @Sem_No 
   and Question_Answer.Question_ID=@QuestionID  
   and Answer_Desc='Excellent' )
   
   
set @Good1 = (select COUNT(*) 
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
 where Eval.Emp_no=@Employee_No1 
   
   and Eval.Course_no=@Course_No   
    and Eval.Semester_no = @Sem_No 
   and Question_Answer.Question_ID=@QuestionID   
   and Answer_Desc='Good')
   
   set @Good2 = (select COUNT(*) 
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
 where Eval.Emp_no=@Employee_No2 
   
   and Eval.Course_no=@Course_No   
    and Eval.Semester_no = @Sem_No   
   and Question_Answer.Question_ID=@QuestionID   
   and Answer_Desc='Good')
   
   set @Good3 = (select COUNT(*) 
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
 where Eval.Emp_no=@Employee_No3
   
   and Eval.Course_no=@Course_No 
    and Eval.Semester_no = @Sem_No    
   and Question_Answer.Question_ID=@QuestionID  
   and Answer_Desc='Good')
   
set @Avrg1 = (select COUNT(*) 
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
 where Eval.Emp_no=@Employee_No1 
  
   and Eval.Course_no=@Course_No   
    and Eval.Semester_no = @Sem_No 
   and Question_Answer.Question_ID=@QuestionID   
   and Answer_Desc='Average'  
   )
   
set @Avrg2 = (select COUNT(*) 
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
 where Eval.Emp_no=@Employee_No2 
   
   and Eval.Course_no=@Course_No  
    and Eval.Semester_no = @Sem_No  
   and Question_Answer.Question_ID=@QuestionID   
   and Answer_Desc='Average'  
   )
   
set @Avrg3 = (select COUNT(*) 
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
  where Eval.Emp_no=@Employee_No3 
   
   and Eval.Course_no=@Course_No     
    and Eval.Semester_no = @Sem_No 
   and Question_Answer.Question_ID=@QuestionID   
   and Answer_Desc='Average'  
   )   
   
set @BeAvg1 = (select COUNT(*)  
FROM    Eval INNER JOIN    
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
   where Eval.Emp_no=@Employee_No1 
   
   and Eval.Course_no=@Course_No  
    and Eval.Semester_no = @Sem_No  
   and Question_Answer.Question_ID=@QuestionID   
      
   and Answer_Desc='Below Average'  
   )
   
set @BeAvg2 = (select COUNT(*)  
FROM    Eval INNER JOIN    
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
   where Eval.Emp_no=@Employee_No2 
   
   and Eval.Course_no=@Course_No    
    and Eval.Semester_no = @Sem_No 
   and Question_Answer.Question_ID=@QuestionID   
      
   and Answer_Desc='Below Average'  
   ) 
   
set @BeAvg3 = (select COUNT(*)  
FROM    Eval INNER JOIN    
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
   where Eval.Emp_no=@Employee_No3
   
   and Eval.Course_no=@Course_No   
    and Eval.Semester_no = @Sem_No 
   and Question_Answer.Question_ID=@QuestionID   
      
   and Answer_Desc='Below Average'  
   )   
   
set @Poor1 =(select COUNT(*)
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
  where Eval.Emp_no=@Employee_No1 
   
   and Eval.Course_no=@Course_No    
    and Eval.Semester_no = @Sem_No 
   and Question_Answer.Question_ID=@QuestionID   
   and Answer_Desc='Poor'  
   )   
   
set @Poor2 =(select COUNT(*)
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
   where Eval.Emp_no=@Employee_No2 
   
   and Eval.Course_no=@Course_No    
    and Eval.Semester_no = @Sem_No  
   and Question_Answer.Question_ID=@QuestionID  
   and Answer_Desc='Poor'  
   )  
   
set @Poor3 =(select COUNT(*)
FROM    Eval INNER JOIN   
   Question_Answer ON Eval.Question_Desc = Question_Answer.Question_ID INNER JOIN   
   EMPMTR ON Eval.Emp_no = EMPMTR.Emp_no  
  where Eval.Emp_no=@Employee_No3 
   
   and Eval.Course_no=@Course_No   
    and Eval.Semester_no = @Sem_No 
   and Question_Answer.Question_ID=@QuestionID   
   and Answer_Desc='Poor'  
   )                          
    
    
    
    
 Select @QuesID as QuesID, @Ques as Question,
            
             ((@Exc1*5)+(@Good1*4)+(@Avrg1*3)+(@BeAvg1*2)+(@Poor1*1))/@sem_stu_Total as Average_Teacher1,
             ((@Exc2*5)+(@Good2*4)+(@Avrg2*3)+(@BeAvg2*2)+(@Poor2*1))/@sem_stu_Total as Average_Teacher2,
             ((@Exc3*5)+(@Good3*4)+(@Avrg3*3)+(@BeAvg3*2)+(@Poor3*1))/@sem_stu_Total as Average_Teacher3
             
  
  
  
END



GO
USE [master]
GO
ALTER DATABASE [biitDbNew] SET  READ_WRITE 
GO
