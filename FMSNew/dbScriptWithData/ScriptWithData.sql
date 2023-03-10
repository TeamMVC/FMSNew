USE [master]
GO
/****** Object:  Database [FacultyManagementSystem]    Script Date: 26-02-2023 23:26:38 ******/
CREATE DATABASE [FacultyManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FacultyManagementSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\FacultyManagementSystem.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FacultyManagementSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\FacultyManagementSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FacultyManagementSystem] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FacultyManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FacultyManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FacultyManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FacultyManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FacultyManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FacultyManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FacultyManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [FacultyManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FacultyManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FacultyManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FacultyManagementSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [FacultyManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
USE [FacultyManagementSystem]
GO
/****** Object:  Table [dbo].[Tbl_BookPublish]    Script Date: 26-02-2023 23:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_BookPublish](
	[PublishID] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [varchar](200) NULL,
	[Publish_Date] [datetime] NULL,
	[FacultyID] [int] NULL,
 CONSTRAINT [PK_Tbl_BookPublish] PRIMARY KEY CLUSTERED 
(
	[PublishID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Course]    Script Date: 26-02-2023 23:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Course](
	[Course_ID] [int] IDENTITY(1,1) NOT NULL,
	[Course_Name] [varchar](200) NULL,
	[Course_Description] [varchar](1000) NULL,
	[createdOn] [datetime] NULL,
	[updatedOn] [datetime] NULL,
	[createdBy] [varchar](100) NULL,
	[UpdatedBy] [varchar](100) NULL,
 CONSTRAINT [PK_Tbl_Course] PRIMARY KEY CLUSTERED 
(
	[Course_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Department]    Script Date: 26-02-2023 23:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Department](
	[Dept_ID] [int] IDENTITY(1,1) NOT NULL,
	[Dept_Name] [varchar](200) NULL,
	[Description] [varchar](1000) NULL,
	[createdOn] [datetime] NULL,
	[updatedOn] [datetime] NULL,
	[createdBy] [varchar](100) NULL,
	[UpdatedBy] [varchar](100) NULL,
 CONSTRAINT [PK_Tbl_Department] PRIMARY KEY CLUSTERED 
(
	[Dept_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Faculty]    Script Date: 26-02-2023 23:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Faculty](
	[Faculty_ID] [int] IDENTITY(1,1) NOT NULL,
	[Faculty_Name] [varchar](200) NULL,
	[Faculty_Qualification] [varchar](1000) NULL,
	[Gender] [varchar](10) NULL,
	[ContactNo] [varchar](10) NULL,
	[Address] [varchar](250) NULL,
	[Dept_ID] [int] NULL,
	[Assign_Course_ID] [int] NULL,
	[EmailID] [varchar](50) NULL,
	[createdOn] [datetime] NULL,
	[updatedOn] [datetime] NULL,
	[createdBy] [varchar](100) NULL,
	[UpdatedBy] [varchar](100) NULL,
 CONSTRAINT [PK_Tbl_Faculty] PRIMARY KEY CLUSTERED 
(
	[Faculty_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Role]    Script Date: 26-02-2023 23:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_RoleMapping]    Script Date: 26-02-2023 23:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_RoleMapping](
	[RoleMappingID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_Tbl_RoleMapping] PRIMARY KEY CLUSTERED 
(
	[RoleMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_UserLogin]    Script Date: 26-02-2023 23:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[tbl_UserLogin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Passward] [varchar](50) NULL,
	[Status] [bit] NULL,
	[Center] [int] NULL,
	[RoleId] [int] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_tbl_UserLogin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_WorkExperience]    Script Date: 26-02-2023 23:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_WorkExperience](
	[WorkID] [int] IDENTITY(1,1) NOT NULL,
	[FacultyID] [int] NULL,
	[Course] [varchar](max) NULL,
	[Experience] [varchar](50) NULL,
	[Skills] [varchar](500) NULL,
 CONSTRAINT [PK_Tbl_WorkExperience] PRIMARY KEY CLUSTERED 
(
	[WorkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_BookPublish] ON 

GO
INSERT [dbo].[Tbl_BookPublish] ([PublishID], [BookName], [Publish_Date], [FacultyID]) VALUES (1, N'ABC', CAST(N'2022-12-12 00:00:00.000' AS DateTime), 3)
GO
INSERT [dbo].[Tbl_BookPublish] ([PublishID], [BookName], [Publish_Date], [FacultyID]) VALUES (2, NULL, CAST(N'2022-12-12 00:00:00.000' AS DateTime), 2)
GO
SET IDENTITY_INSERT [dbo].[Tbl_BookPublish] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Course] ON 

GO
INSERT [dbo].[Tbl_Course] ([Course_ID], [Course_Name], [Course_Description], [createdOn], [updatedOn], [createdBy], [UpdatedBy]) VALUES (1, N'Science', N'Science', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Tbl_Course] ([Course_ID], [Course_Name], [Course_Description], [createdOn], [updatedOn], [createdBy], [UpdatedBy]) VALUES (2, N'Math', N'Mathematic', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Tbl_Course] ([Course_ID], [Course_Name], [Course_Description], [createdOn], [updatedOn], [createdBy], [UpdatedBy]) VALUES (4, N'English', N'English', CAST(N'2023-02-26 07:09:46.183' AS DateTime), CAST(N'2023-02-26 07:09:46.183' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Tbl_Course] ([Course_ID], [Course_Name], [Course_Description], [createdOn], [updatedOn], [createdBy], [UpdatedBy]) VALUES (8, N'Hindi', N'Hindi', CAST(N'2023-02-26 20:08:23.353' AS DateTime), CAST(N'2023-02-26 20:08:23.353' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Tbl_Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Department] ON 

GO
INSERT [dbo].[Tbl_Department] ([Dept_ID], [Dept_Name], [Description], [createdOn], [updatedOn], [createdBy], [UpdatedBy]) VALUES (4, N'Commerce', N'Commerce', CAST(N'2023-02-26 02:03:44.127' AS DateTime), CAST(N'2023-02-26 02:03:44.127' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Tbl_Department] ([Dept_ID], [Dept_Name], [Description], [createdOn], [updatedOn], [createdBy], [UpdatedBy]) VALUES (6, N'Science', N'Science ', CAST(N'2023-02-26 20:07:46.713' AS DateTime), CAST(N'2023-02-26 20:07:46.713' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Tbl_Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Faculty] ON 

GO
INSERT [dbo].[Tbl_Faculty] ([Faculty_ID], [Faculty_Name], [Faculty_Qualification], [Gender], [ContactNo], [Address], [Dept_ID], [Assign_Course_ID], [EmailID], [createdOn], [updatedOn], [createdBy], [UpdatedBy]) VALUES (2, N'Ali', N'MCA', N'M', N'45345345', N'rrgertret', 4, NULL, NULL, CAST(N'2023-02-26 05:40:11.373' AS DateTime), CAST(N'2023-02-26 05:40:11.373' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Tbl_Faculty] ([Faculty_ID], [Faculty_Name], [Faculty_Qualification], [Gender], [ContactNo], [Address], [Dept_ID], [Assign_Course_ID], [EmailID], [createdOn], [updatedOn], [createdBy], [UpdatedBy]) VALUES (3, N'Ali', N'MCA', N'M', N'45345345', N'rrgertret', 4, NULL, NULL, CAST(N'2023-02-26 05:41:22.040' AS DateTime), CAST(N'2023-02-26 05:41:22.427' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Tbl_Faculty] ([Faculty_ID], [Faculty_Name], [Faculty_Qualification], [Gender], [ContactNo], [Address], [Dept_ID], [Assign_Course_ID], [EmailID], [createdOn], [updatedOn], [createdBy], [UpdatedBy]) VALUES (4, N'Ali1', N'MCA1', N'M', N'45345345', N'rrgertret', 4, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Tbl_Faculty] ([Faculty_ID], [Faculty_Name], [Faculty_Qualification], [Gender], [ContactNo], [Address], [Dept_ID], [Assign_Course_ID], [EmailID], [createdOn], [updatedOn], [createdBy], [UpdatedBy]) VALUES (5, N'Ali33', N'mca', N'm', N'2543534', N'dfsdfsdf', 4, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Tbl_Faculty] ([Faculty_ID], [Faculty_Name], [Faculty_Qualification], [Gender], [ContactNo], [Address], [Dept_ID], [Assign_Course_ID], [EmailID], [createdOn], [updatedOn], [createdBy], [UpdatedBy]) VALUES (7, N'abc', N'bbb', N'b', N'7777', N'hh', 4, 1, N'abc@gmail.com', CAST(N'2023-02-26 07:11:05.417' AS DateTime), CAST(N'2023-02-26 07:11:05.417' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Tbl_Faculty] ([Faculty_ID], [Faculty_Name], [Faculty_Qualification], [Gender], [ContactNo], [Address], [Dept_ID], [Assign_Course_ID], [EmailID], [createdOn], [updatedOn], [createdBy], [UpdatedBy]) VALUES (10, N'Namrata', N'MCA', N'F', N'8877999889', N'Abc', 4, 2, N'namrata@gmail.com', CAST(N'2023-02-26 20:09:55.777' AS DateTime), CAST(N'2023-02-26 20:09:55.777' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Tbl_Faculty] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Role] ON 

GO
INSERT [dbo].[tbl_Role] ([RoleId], [RoleName]) VALUES (1, N'Admin')
GO
INSERT [dbo].[tbl_Role] ([RoleId], [RoleName]) VALUES (2, N'Employee')
GO
SET IDENTITY_INSERT [dbo].[tbl_Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_RoleMapping] ON 

GO
INSERT [dbo].[Tbl_RoleMapping] ([RoleMappingID], [RoleID], [UserID]) VALUES (1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Tbl_RoleMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_UserLogin] ON 

GO
INSERT [dbo].[tbl_UserLogin] ([Id], [Name], [Email], [Passward], [Status], [Center], [RoleId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (1, N'Ritu', N'rits.vyas@gmail.com', N'12345', 1, 1, 1, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_UserLogin] ([Id], [Name], [Email], [Passward], [Status], [Center], [RoleId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (2, NULL, N'ali@gmail.com', N'12345', NULL, NULL, 2, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_UserLogin] ([Id], [Name], [Email], [Passward], [Status], [Center], [RoleId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (4, N'abc', N'abc@gmail.com', N'11111', NULL, NULL, 2, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_UserLogin] ([Id], [Name], [Email], [Passward], [Status], [Center], [RoleId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (5, NULL, NULL, N'', NULL, NULL, 2, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_UserLogin] ([Id], [Name], [Email], [Passward], [Status], [Center], [RoleId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (7, N'Namrata', N'namrata@gmail.com', N'12345', NULL, NULL, 2, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[tbl_UserLogin] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_WorkExperience] ON 

GO
INSERT [dbo].[Tbl_WorkExperience] ([WorkID], [FacultyID], [Course], [Experience], [Skills]) VALUES (1, 2, N'Maths,English', N'5', N'MCA')
GO
INSERT [dbo].[Tbl_WorkExperience] ([WorkID], [FacultyID], [Course], [Experience], [Skills]) VALUES (2, 2, N'Maths,English', N'5', N'MCA')
GO
SET IDENTITY_INSERT [dbo].[Tbl_WorkExperience] OFF
GO
/****** Object:  Index [uniqueEmail]    Script Date: 26-02-2023 23:26:38 ******/
ALTER TABLE [dbo].[tbl_UserLogin] ADD  CONSTRAINT [uniqueEmail] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetDepartment]    Script Date: 26-02-2023 23:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetDepartment]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * from Tbl_Department
END

GO
USE [master]
GO
ALTER DATABASE [FacultyManagementSystem] SET  READ_WRITE 
GO
