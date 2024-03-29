USE [master]
GO
/****** Object:  Database [Management System]    Script Date: 21-08-2019 11:44:42 ******/
CREATE DATABASE [Management System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Management System', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Management System.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Management System_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Management System_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Management System] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Management System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Management System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Management System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Management System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Management System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Management System] SET ARITHABORT OFF 
GO
ALTER DATABASE [Management System] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Management System] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Management System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Management System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Management System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Management System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Management System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Management System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Management System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Management System] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Management System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Management System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Management System] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Management System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Management System] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Management System] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Management System] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Management System] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Management System] SET  MULTI_USER 
GO
ALTER DATABASE [Management System] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Management System] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Management System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Management System] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Management System] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Management System] SET QUERY_STORE = OFF
GO
USE [Management System]
GO
/****** Object:  Table [dbo].[Assignment]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignment](
	[AssignmentId] [int] IDENTITY(1,1) NOT NULL,
	[AssignmentName] [varchar](50) NOT NULL,
	[Path] [varchar](max) NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[FacultyId] [int] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[modifiedOn] [datetime] NOT NULL,
	[deletedOn] [datetime] NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Assignment] PRIMARY KEY CLUSTERED 
(
	[AssignmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[BranchId] [int] IDENTITY(1,1) NOT NULL,
	[BranchName] [varchar](50) NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[modifiedOn] [datetime] NOT NULL,
	[deletedOn] [datetime] NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED 
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exception]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exception](
	[ExceptionId] [int] IDENTITY(1,1) NOT NULL,
	[ExceptionNumber] [int] NOT NULL,
	[ExceptionMessage] [varchar](max) NULL,
	[ExceptionUrl] [varchar](50) NULL,
	[ExceptionMethod] [varchar](50) NOT NULL,
	[createdOn] [datetime] NULL,
	[modifiedOn] [datetime] NULL,
	[deletedOn] [datetime] NOT NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Exception] PRIMARY KEY CLUSTERED 
(
	[ExceptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[FacultyId] [int] IDENTITY(1,1) NOT NULL,
	[FacultyName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Mobile] [varchar](50) NOT NULL,
	[FacultyGuid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Active] [bit] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[modifiedOn] [datetime] NOT NULL,
	[deletedOn] [datetime] NULL,
	[isDeleted] [bit] NOT NULL,
	[SubjectId] [int] NOT NULL,
 CONSTRAINT [PK_Faculty] PRIMARY KEY CLUSTERED 
(
	[FacultyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Homework]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Homework](
	[HomeworkId] [int] IDENTITY(1,1) NOT NULL,
	[HomeworkName] [varchar](50) NOT NULL,
	[Path] [varchar](max) NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[StudentId] [int] NOT NULL,
	[FacultyId] [int] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[modifiedOn] [datetime] NOT NULL,
	[deletedOn] [datetime] NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Homework] PRIMARY KEY CLUSTERED 
(
	[HomeworkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Mobile] [varchar](50) NOT NULL,
	[StudentGuid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Active] [bit] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[modifiedOn] [datetime] NOT NULL,
	[deletedOn] [datetime] NULL,
	[isDeleted] [bit] NOT NULL,
	[BranchId] [int] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [varchar](50) NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[modifiedOn] [datetime] NOT NULL,
	[deletedOn] [datetime] NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Assignment] ADD  CONSTRAINT [DF_Assignment_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[Branch] ADD  CONSTRAINT [DF_Branch_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[Exception] ADD  CONSTRAINT [DF_Exception_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[Faculty] ADD  CONSTRAINT [DF_Faculty_FacultyGuid]  DEFAULT (newid()) FOR [FacultyGuid]
GO
ALTER TABLE [dbo].[Faculty] ADD  CONSTRAINT [DF_Faculty_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[Faculty] ADD  CONSTRAINT [DF_Faculty_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[Homework] ADD  CONSTRAINT [DF_Homework_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_StudentGuid]  DEFAULT (newid()) FOR [StudentGuid]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[Subject] ADD  CONSTRAINT [DF_Subject_idDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[Assignment]  WITH CHECK ADD  CONSTRAINT [FK_Assignment_Faculty] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculty] ([FacultyId])
GO
ALTER TABLE [dbo].[Assignment] CHECK CONSTRAINT [FK_Assignment_Faculty]
GO
ALTER TABLE [dbo].[Faculty]  WITH CHECK ADD  CONSTRAINT [FK_Faculty_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
GO
ALTER TABLE [dbo].[Faculty] CHECK CONSTRAINT [FK_Faculty_Subject]
GO
ALTER TABLE [dbo].[Homework]  WITH CHECK ADD  CONSTRAINT [FK_Homework_Faculty] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculty] ([FacultyId])
GO
ALTER TABLE [dbo].[Homework] CHECK CONSTRAINT [FK_Homework_Faculty]
GO
ALTER TABLE [dbo].[Homework]  WITH CHECK ADD  CONSTRAINT [FK_Homework_Student1] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[Homework] CHECK CONSTRAINT [FK_Homework_Student1]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Branch] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branch] ([BranchId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Branch]
GO
/****** Object:  StoredProcedure [dbo].[Assignment_Delete]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Assignment_Delete](
@AssignmentId int
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	UPDATE Assignment
	SET isDeleted = 1,
	deletedOn = GETUTCDATE()
	WHERE AssignmentId = @AssignmentId
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT Error_Message() AS ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Assignment_Insert]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Assignment_Insert](
@AssignmentId int out,
@AssignmentName varchar(50),
@Path varchar(MAX),
@Type varchar(50),
@FacultyId int
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	INSERT INTO Assignment(AssignmentName, Path, Type, FacultyId, createdOn, modifiedOn) 
					VALUES(@AssignmentName, @Path, @Type, @FacultyId, GETUTCDATE(), GETUTCDATE())
	SET @AssignmentId = SCOPE_IDENTITY()
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT Error_Message() AS ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Assignment_Read]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Assignment_Read]
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	SELECT * FROM Assignment
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT Error_Message() AS ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Assignment_ReadById]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Assignment_ReadById](
@AssignmentId int
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	SELECT * FROM Assignment WHERE AssignmentId = @AssignmentId
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT Error_Message() AS ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Assignment_Update]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Assignment_Update](
@AssignmentId int,
@AssignmentName varchar(50),
@Path varchar(50),
@Type varchar(50),
@FacultyId int
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	UPDATE Assignment
	SET AssignmentName = @AssignmentName,
	Path = @Path,
	Type = @Type,
	FacultyId = @FacultyId,
	modifiedOn = GETUTCDATE()
	WHERE @FacultyId = SCOPE_IDENTITY()
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT Error_Message() AS ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Branch_Delete]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Branch_Delete](
@BranchId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	BEGIN TRY
	BEGIN TRANSACTION
	UPDATE Branch
	SET isDeleted = 1,
	deletedOn = GETUTCDATE()
	WHERE BranchId = @BranchId
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT Error_Message() AS ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Branch_Insert]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Branch_Insert](
@BranchId int out,
@BranchName varchar(50)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	BEGIN TRY
	BEGIN TRANSACTION
	INSERT INTO Branch(BranchName, createdOn, modifiedOn) 
					VALUES(@BranchName, GETUTCDATE(), GETUTCDATE())
	SET @BranchId = SCOPE_IDENTITY()
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT Error_Message() AS ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Branch_Read]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Branch_Read] 
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	SELECT * FROM Branch
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT ERROR_MESSAGE() as ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Branch_ReadById]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Branch_ReadById](
@BranchId int
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	SELECT * FROM Branch WHERE BranchId = @BranchId
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT
	ERROR_MESSAGE() as ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Branch_Update]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Branch_Update](
@BranchId int,
@BranchName varchar(50)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	BEGIN TRY
	BEGIN TRANSACTION
	UPDATE Branch
	SET BranchName = @BranchName,
	modifiedOn = GETUTCDATE()
	WHERE BranchId = @BranchId
	COMMIT
	END TRY
	BEGIN CATCH
	SELECT ERROR_MESSAGE() as ErrorMessage;
	ROLLBACK TRANSACTION
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Exception_Insert]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Exception_Insert](
@ExceptionNumber varchar(50),
@ExceptionMessage varchar(max),
@ExceptionUrl varchar(50),
@ExceptionMethod varchar(50)
)  
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	INSERT INTO Exception(ExceptionNumber, ExceptionMessage, ExceptionUrl, ExceptionMethod, createdOn, modifiedOn) 
					VALUES(@ExceptionNumber, @ExceptionMessage, @ExceptionUrl, @ExceptionMethod, GETUTCDATE(), GETUTCDATE())
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT Error_Message() AS ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Exception_Read]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Exception_Read]
AS
BEGIN
	BEGIN TRY
	BEGIN TRANSACTION
	SELECT * FROM Exception
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT
	ERROR_MESSAGE() as ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Exception_ReadById]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Exception_ReadById](
@ExceptionId int
)
AS
BEGIN
	BEGIN TRY
	BEGIN TRANSACTION
	SELECT * FROM Exception WHERE ExceptionId = @ExceptionId
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT
	ERROR_MESSAGE() as ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Faculty_Activate]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Faculty_Activate](
@FacultyGuid uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	UPDATE Faculty
	SET Active = 1
	WHERE FacultyGuid = @FacultyGuid
	COMMIT
	END TRY
	BEGIN CATCH
	SELECT ERROR_MESSAGE() as ErrorMessage;
	ROLLBACK TRANSACTION
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Faculty_Delete]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Faculty_Delete](
@FacultyId int
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	UPDATE Faculty
	SET isDeleted = 1,
	deletedOn = GETUTCDATE()
	WHERE FacultyId = @FacultyId
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT Error_Message() AS ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Faculty_Insert]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Faculty_Insert](
@FacultyId int out,
@FacultyName varchar(50),
@Email varchar(50),
@Password varchar(50),
@Mobile varchar(50),
@FacultyGuid uniqueidentifier,
@SubjectId int
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	INSERT INTO Faculty(FacultyName, Email, Password, Mobile, createdOn, modifiedOn, FacultyGuid, SubjectId) 
					VALUES(@FacultyName, @Email, @Password, @Mobile, GETUTCDATE(), GETUTCDATE(), @FacultyGuid, @SubjectId)
	SET @FacultyId = SCOPE_IDENTITY()
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT Error_Message() AS ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Faculty_Login]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Faculty_Login](
@Email varchar(50),
@Password varchar(50)
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	SELECT * FROM Faculty
	WHERE Email = @Email
	AND Password = @Password
	AND isDeleted = 0
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT Error_Message() AS ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Faculty_Read]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Faculty_Read] 
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	SELECT * FROM Faculty
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT
	ERROR_MESSAGE() as ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Faculty_ReadById]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Faculty_ReadById](
@FacultyId int
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	SELECT * FROM Faculty WHERE FacultyId = @FacultyId
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT
	ERROR_MESSAGE() as ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Faculty_Update]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Faculty_Update](
@FacultyId int,
@FacultyName varchar(50),
@Email varchar(50),
@Password varchar(50),
@Mobile varchar(50)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	BEGIN TRY
	BEGIN TRANSACTION
	UPDATE Faculty
	SET FacultyName = @FacultyName,
	Email = @Email,
	Password = @Password,
	Mobile = @Mobile,
	modifiedOn = GETUTCDATE()
	WHERE FacultyId = @FacultyId
	COMMIT
	END TRY
	BEGIN CATCH
	SELECT ERROR_MESSAGE() as ErrorMessage;
	ROLLBACK TRANSACTION
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Homework_Delete]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Homework_Delete](
@HomeworkId int
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
					UPDATE Homework
					SET isDeleted = 1, deletedOn = GETUTCDATE()
					WHERE HomeworkId = @HomeworkId
	COMMIT;
	END TRY
	BEGIN CATCH
			SELECT
					Error_Message() AS ErrorMessage;
			ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Homework_Insert]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Homework_Insert](
@HomeworkId int out,
@HomeworkName varchar(50),
@Path varchar(MAX),
@Type varchar(50),
@StudentId int,
@FacultyId int
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
					INSERT INTO Homework
									(HomeworkName, Path, Type, StudentId, FacultyId, CreatedOn, ModifiedOn)
					VALUES
									(@HomeworkName, @Path, @Type, @StudentId, @FacultyId, GETUTCDATE(), GETUTCDATE())
					SET @HomeworkId = SCOPE_IDENTITY()
	COMMIT;
	END TRY
	BEGIN CATCH
			SELECT
					Error_Message() AS ErrorMessage;
			ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Homework_Read]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Homework_Read]
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
					SELECT * FROM Homework
	COMMIT;
	END TRY
	BEGIN CATCH
			SELECT
					Error_Message() AS ErrorMessage;
			ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Homework_ReadById]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Homework_ReadById](
@HomeworkId int
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
					SELECT * FROM Homework
					WHERE HomeworkId = @HomeworkId
	COMMIT;
	END TRY
	BEGIN CATCH
			SELECT
					Error_Message() AS ErrorMessage;
			ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Homework_Update]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Homework_Update](
@HomeworkId int,
@HomeworkName varchar(50),
@Path varchar(MAX),
@Type varchar(50),
@StudentId int,
@FacultyId int
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
					UPDATE Homework
					SET HomeworkName = @HomeworkName, Path = @Path, Type = @Type, StudentId = @StudentId, FacultyId = @FacultyId, ModifiedOn = GETUTCDATE()
					WHERE HomeworkId = @HomeworkId
	COMMIT;
	END TRY
	BEGIN CATCH
			SELECT
					Error_Message() AS ErrorMessage;
			ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Student_Activate]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Student_Activate](
@StudentGuid uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	UPDATE Student
	SET Active = 1
	WHERE StudentGuid = @StudentGuid
	COMMIT
	END TRY
	BEGIN CATCH
	SELECT ERROR_MESSAGE() as ErrorMessage;
	ROLLBACK TRANSACTION
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Student_Delete]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Student_Delete](
@StudentId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	BEGIN TRY
	BEGIN TRANSACTION
	UPDATE Student
	SET isDeleted = 1,
	deletedOn = GETUTCDATE()
	WHERE StudentId = @StudentId
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT Error_Message() AS ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Student_Insert]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Student_Insert](
@StudentId int output,
@StudentName varchar(50),
@Email varchar(50),
@Password varchar(50),
@Mobile varchar(50),
@StudentGuid uniqueidentifier,
@BranchId int
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	INSERT INTO Student(StudentName, Email, Password, Mobile, createdOn, modifiedOn, StudentGuid, BranchId) 
					VALUES(@StudentName, @Email, @Password, @Mobile, GETUTCDATE(), GETUTCDATE(), @StudentGuid, @BranchId)
	SET @StudentId = SCOPE_IDENTITY();
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT Error_Message() AS ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Student_Login]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Student_Login](
@Email varchar(50),
@Password varchar(50)
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	SELECT * FROM Student
	WHERE Email = @Email
	AND Password = @Password
	AND isDeleted = 0
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT Error_Message() AS ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Student_Read]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Student_Read] 
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	SELECT * FROM Student
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT
	ERROR_MESSAGE() as ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Student_ReadById]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Student_ReadById](
@StudentId int
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	SELECT * FROM Student WHERE StudentId = @StudentId
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT
	ERROR_MESSAGE() as ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Student_Update]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Student_Update](
@StudentId int,
@StudentName varchar(50),
@Email varchar(50),
@Password varchar(50),
@Mobile varchar(50)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	BEGIN TRY
	BEGIN TRANSACTION
	UPDATE Student
	SET StudentName = @StudentName,
	Email = @Email,
	Password = @Password,
	Mobile = @Mobile,
	modifiedOn = GETUTCDATE()
	WHERE StudentId = @StudentId
	COMMIT
	END TRY
	BEGIN CATCH
	SELECT ERROR_MESSAGE() as ErrorMessage;
	ROLLBACK TRANSACTION
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Subject_Delete]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Subject_Delete](
@SubjectId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	BEGIN TRY
	BEGIN TRANSACTION
	UPDATE Subject
	SET isDeleted = 1,
	deletedOn = GETUTCDATE()
	WHERE SubjectId = @SubjectId
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT Error_Message() AS ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Subject_Insert]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Subject_Insert](
@SubjectId int out,
@SubjectName varchar(50)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	BEGIN TRY
	BEGIN TRANSACTION
	INSERT INTO Subject(SubjectName, createdOn, modifiedOn) 
					VALUES(@SubjectName, GETUTCDATE(), GETUTCDATE())
	SET @SubjectId = SCOPE_IDENTITY()
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT Error_Message() AS ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[Subject_Read]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Subject_Read] 
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	SELECT * FROM Subject
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT
	ERROR_MESSAGE() as ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Subject_ReadById]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Subject_ReadById](
@SubjectId int
)
AS
BEGIN
	SET NOCOUNT OFF;
	BEGIN TRY
	BEGIN TRANSACTION
	SELECT * FROM Subject WHERE SubjectId = @SubjectId
	COMMIT;
	END TRY
	BEGIN CATCH
	SELECT
	ERROR_MESSAGE() as ErrorMessage;
	ROLLBACK TRANSACTION;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Subject_Update]    Script Date: 21-08-2019 11:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Subject_Update](
@SubjectId int,
@SubjectName varchar(50)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	BEGIN TRY
	BEGIN TRANSACTION
	UPDATE Subject
	SET SubjectName = @SubjectName,
	modifiedOn = GETUTCDATE()
	WHERE SubjectId = @SubjectId
	COMMIT
	END TRY
	BEGIN CATCH
	SELECT ERROR_MESSAGE() as ErrorMessage;
	ROLLBACK TRANSACTION
	END CATCH
END
GO
USE [master]
GO
ALTER DATABASE [Management System] SET  READ_WRITE 
GO
