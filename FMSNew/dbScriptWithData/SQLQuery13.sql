USE [FacultyManagementSystem]
GO
/****** Object:  Table [dbo].[Tbl_Course]    Script Date: 26-02-2023 07:49:22 ******/
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
/****** Object:  Table [dbo].[Tbl_Department]    Script Date: 26-02-2023 07:49:22 ******/
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
/****** Object:  Table [dbo].[Tbl_Faculty]    Script Date: 26-02-2023 07:49:22 ******/
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
/****** Object:  Table [dbo].[tbl_Role]    Script Date: 26-02-2023 07:49:22 ******/
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
/****** Object:  Table [dbo].[Tbl_RoleMapping]    Script Date: 26-02-2023 07:49:22 ******/
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
/****** Object:  Table [dbo].[tbl_UserLogin]    Script Date: 26-02-2023 07:49:22 ******/
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
SET IDENTITY_INSERT [dbo].[Tbl_Course] ON 

GO
INSERT [dbo].[Tbl_Course] ([Course_ID], [Course_Name], [Course_Description], [createdOn], [updatedOn], [createdBy], [UpdatedBy]) VALUES (1, N'Science', N'Science', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Tbl_Course] ([Course_ID], [Course_Name], [Course_Description], [createdOn], [updatedOn], [createdBy], [UpdatedBy]) VALUES (2, N'Math', N'Mathematic', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Tbl_Course] ([Course_ID], [Course_Name], [Course_Description], [createdOn], [updatedOn], [createdBy], [UpdatedBy]) VALUES (4, N'English', N'English', CAST(N'2023-02-26 07:09:46.183' AS DateTime), CAST(N'2023-02-26 07:09:46.183' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Tbl_Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Department] ON 

GO
INSERT [dbo].[Tbl_Department] ([Dept_ID], [Dept_Name], [Description], [createdOn], [updatedOn], [createdBy], [UpdatedBy]) VALUES (4, N'Commerce', N'Commerce', CAST(N'2023-02-26 02:03:44.127' AS DateTime), CAST(N'2023-02-26 02:03:44.127' AS DateTime), NULL, NULL)
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
INSERT [dbo].[Tbl_Faculty] ([Faculty_ID], [Faculty_Name], [Faculty_Qualification], [Gender], [ContactNo], [Address], [Dept_ID], [Assign_Course_ID], [EmailID], [createdOn], [updatedOn], [createdBy], [UpdatedBy]) VALUES (6, N'Ali', N'MCA', N'M', N'654645654', N'rrgertret', 4, 1, N'ali@gmail.com', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Tbl_Faculty] ([Faculty_ID], [Faculty_Name], [Faculty_Qualification], [Gender], [ContactNo], [Address], [Dept_ID], [Assign_Course_ID], [EmailID], [createdOn], [updatedOn], [createdBy], [UpdatedBy]) VALUES (7, N'abc', N'bbb', N'b', N'7777', N'hh', 4, 1, N'abc@gmail.com', CAST(N'2023-02-26 07:11:05.417' AS DateTime), CAST(N'2023-02-26 07:11:05.417' AS DateTime), NULL, NULL)
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
SET IDENTITY_INSERT [dbo].[tbl_UserLogin] OFF
GO
/****** Object:  Index [uniqueEmail]    Script Date: 26-02-2023 07:49:22 ******/
ALTER TABLE [dbo].[tbl_UserLogin] ADD  CONSTRAINT [uniqueEmail] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetDepartment]    Script Date: 26-02-2023 07:49:22 ******/
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
