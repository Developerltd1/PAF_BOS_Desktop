USE [master]
GO
/****** Object:  Database [AAA_PAF_BOS]    Script Date: 2020-05-01 10:54:31 AM ******/
CREATE DATABASE [AAA_PAF_BOS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AAA_PAF_BOS', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AAA_PAF_BOS.mdf' , SIZE = 9408KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AAA_PAF_BOS_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AAA_PAF_BOS_log.ldf' , SIZE = 2368KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AAA_PAF_BOS] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AAA_PAF_BOS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AAA_PAF_BOS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET ARITHABORT OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AAA_PAF_BOS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AAA_PAF_BOS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AAA_PAF_BOS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AAA_PAF_BOS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET RECOVERY FULL 
GO
ALTER DATABASE [AAA_PAF_BOS] SET  MULTI_USER 
GO
ALTER DATABASE [AAA_PAF_BOS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AAA_PAF_BOS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AAA_PAF_BOS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AAA_PAF_BOS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AAA_PAF_BOS] SET DELAYED_DURABILITY = DISABLED 
GO
USE [AAA_PAF_BOS]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[AttendanceID] [int] IDENTITY(1,1) NOT NULL,
	[Cadet_ID] [int] NOT NULL,
	[EntryDate] [datetime] NULL CONSTRAINT [DF_Attendance_EntryDate]  DEFAULT (getdate()),
	[BookOUT] [datetime] NULL,
	[BOOKIN] [datetime] NULL,
	[AttendanceSession_ID] [int] NULL,
 CONSTRAINT [PK_tblBookInOut] PRIMARY KEY CLUSTERED 
(
	[AttendanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AttendanceSessions]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttendanceSessions](
	[AttendanceSessionID] [int] IDENTITY(1,1) NOT NULL,
	[EntryDateTime] [datetime] NOT NULL CONSTRAINT [DF_AttendanceSessions_EntryDateTime]  DEFAULT (getdate()),
	[AllowedCheckOUTDateTime] [datetime] NOT NULL,
	[AllowedCheckINDateTime] [datetime] NOT NULL,
	[Cadet_ID] [int] NULL CONSTRAINT [DF_AttendanceSessions_Cadit_ID]  DEFAULT ((0)),
	[User_ID] [int] NOT NULL,
 CONSTRAINT [PK_tblOpenBookOut] PRIMARY KEY CLUSTERED 
(
	[AttendanceSessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CadetCourses]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CadetCourses](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](50) NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cadets]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cadets](
	[CadetID] [int] IDENTITY(1,1) NOT NULL,
	[EntryDateTime] [datetime] NULL CONSTRAINT [DF_Cadets_EntryDateTime]  DEFAULT (getdate()),
	[Batch] [varchar](20) NULL,
	[CadetName] [varchar](50) NOT NULL,
	[CadetFatherName] [varchar](50) NOT NULL,
	[PAKNumber] [varchar](50) NOT NULL,
	[Address] [varchar](200) NULL,
	[CNIC] [varchar](15) NULL,
	[BloodGroup] [varchar](12) NOT NULL,
	[ContactNumber] [varchar](50) NOT NULL,
	[MobileNumber] [varchar](11) NOT NULL,
	[Picture] [varchar](max) NOT NULL,
	[RFIDCardNumber] [varchar](25) NOT NULL,
	[LFMD] [varchar](max) NULL,
	[RFMD] [varchar](max) NULL,
	[LThumbImage] [varchar](max) NULL,
	[RThumbImage] [varchar](max) NULL,
	[SQN_User_ID] [int] NULL,
	[Course_ID] [int] NULL,
	[Tape_ID] [int] NULL,
	[CreatedBy_User_ID] [int] NULL,
	[Role_ID] [int] NULL,
	[LastActivityDateTime] [datetime] NULL,
 CONSTRAINT [PK_tblRegistration] PRIMARY KEY CLUSTERED 
(
	[CadetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Cadets_1] UNIQUE NONCLUSTERED 
(
	[RFIDCardNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CadetSearchPermissions]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CadetSearchPermissions](
	[UserPermissionID] [int] IDENTITY(1,1) NOT NULL,
	[Cadet_ID] [int] NULL,
	[User_ID] [int] NULL,
 CONSTRAINT [PK_UserPermissions] PRIMARY KEY CLUSTERED 
(
	[UserPermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CadetsHistory]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CadetsHistory](
	[CadetHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[Cadet_ID] [int] NULL,
	[EntryDateTime] [datetime] NULL CONSTRAINT [DF_CadetsHistory_EntryDateTime]  DEFAULT (getdate()),
	[Batch] [varchar](20) NULL,
	[CadetName] [varchar](50) NOT NULL,
	[CadetFatherName] [varchar](50) NOT NULL,
	[PAKNumber] [varchar](50) NOT NULL,
	[Address] [varchar](200) NULL,
	[CNIC] [varchar](15) NULL,
	[BloodGroup] [varchar](12) NOT NULL,
	[ContactNumber] [varchar](50) NOT NULL,
	[MobileNumber] [varchar](11) NOT NULL,
	[Picture] [varchar](max) NOT NULL,
	[RFIDCardNumber] [varchar](25) NOT NULL,
	[LFMD] [varchar](max) NULL,
	[RFMD] [varchar](max) NULL,
	[LThumbImage] [varchar](max) NULL,
	[RThumbImage] [varchar](max) NULL,
	[SQN_User_ID] [int] NULL,
	[Course_ID] [int] NULL,
	[Tape_ID] [int] NULL,
	[CreatedBy_User_ID] [int] NULL,
	[Role_ID] [int] NULL,
 CONSTRAINT [PK_CadetsHistory] PRIMARY KEY CLUSTERED 
(
	[CadetHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CadetTapes]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CadetTapes](
	[TapeID] [int] IDENTITY(1,1) NOT NULL,
	[TapeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tapes] PRIMARY KEY CLUSTERED 
(
	[TapeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Forms]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Forms](
	[FormID] [int] IDENTITY(1,1) NOT NULL,
	[FormName] [varchar](200) NOT NULL,
	[FormDisplayName] [varchar](200) NOT NULL,
	[FormDisplayDetails] [varchar](300) NULL,
 CONSTRAINT [PK_Forms] PRIMARY KEY CLUSTERED 
(
	[FormID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoginRoles]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoginRoles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Role] [varchar](50) NOT NULL,
	[RoleDetails] [varchar](50) NULL,
 CONSTRAINT [PK_tblRole] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoginUsers]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoginUsers](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[EntryDateTime] [datetime] NOT NULL CONSTRAINT [DF_Users_EntryDateTime]  DEFAULT (getdate()),
	[FullName] [varchar](200) NULL,
	[Designation] [varchar](50) NULL,
	[PAKNumber] [varchar](50) NULL,
	[UserName] [varchar](50) NOT NULL,
	[UserPassword] [varchar](50) NOT NULL,
	[IsActive] [bit] NULL CONSTRAINT [DF_Users_IsActive]  DEFAULT ((1)),
	[SeniorOfficer_User_ID] [int] NULL,
	[UserPicture] [varchar](100) NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_LoginUsers] UNIQUE NONCLUSTERED 
(
	[PAKNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoginUsersRoles]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginUsersRoles](
	[UserRoleID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Role_ID] [int] NOT NULL,
 CONSTRAINT [PK_tblUserRole] PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PunishmentCategories]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PunishmentCategories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Punishments]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Punishments](
	[PunishmentID] [int] IDENTITY(1,1) NOT NULL,
	[EntryDateTime] [datetime] NOT NULL CONSTRAINT [DF_CadetPunishments_EntryDateTime]  DEFAULT (getdate()),
	[Cadet_ID] [int] NOT NULL,
	[Category_ID] [int] NOT NULL,
	[User_ID] [int] NOT NULL,
	[Role_ID] [int] NOT NULL,
	[Remarks] [varchar](1000) NOT NULL,
	[IsSpecialWaiver] [bit] NOT NULL,
	[IsPunishCompleted] [bit] NULL,
 CONSTRAINT [PK_tblCondition] PRIMARY KEY CLUSTERED 
(
	[PunishmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PunishmentsHistory]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PunishmentsHistory](
	[PunishmentHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[Punishment_ID] [int] NOT NULL,
	[EntryDateTime] [datetime] NOT NULL CONSTRAINT [DF_Table_1_EntryDateTime]  DEFAULT (getdate()),
	[Cadet_ID] [int] NOT NULL,
	[Category_ID] [int] NOT NULL,
	[Remarks] [varchar](1000) NOT NULL,
	[IsSpecialWaiver] [bit] NOT NULL,
	[IsPunishCompleted] [bit] NULL,
	[User_ID] [int] NULL,
	[Role_ID] [int] NULL,
 CONSTRAINT [PK_PunishmentsHistory] PRIMARY KEY CLUSTERED 
(
	[PunishmentHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RolesPermission]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolesPermission](
	[RolePermissionID] [int] IDENTITY(1,1) NOT NULL,
	[Form_ID] [int] NOT NULL,
	[Role_ID] [int] NOT NULL,
 CONSTRAINT [PK_RolesPermission] PRIMARY KEY CLUSTERED 
(
	[RolePermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Cadets]    Script Date: 2020-05-01 10:54:31 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Cadets] ON [dbo].[Cadets]
(
	[PAKNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Users]    Script Date: 2020-05-01 10:54:31 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users] ON [dbo].[LoginUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AttendanceReport]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AttendanceReport]
(
  @CadetID INT,
  @FromDate DateTime,
  @ToDate DateTime,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY 
		IF @CadetID = 0
			BEGIN
				SELECT     Cadets.CadetName, Cadets.PAKNumber,u.FullName,u.Designation, Attendance.BookOUT, Attendance.BOOKIN, AttendanceSessions.AllowedCheckOUTDateTime, AttendanceSessions.AllowedCheckINDateTime
				FROM       Attendance 
				INNER JOIN Cadets ON Attendance.Cadet_ID = Cadets.CadetID 
				INNER JOIN LoginUsers u ON u.UserID = Cadets.SQN_User_ID
				INNER JOIN AttendanceSessions ON Attendance.AttendanceSession_ID = AttendanceSessions.AttendanceSessionID
				WHERE EntryDate BETWEEN @FromDate AND @ToDate
			END
		ELSE 
			BEGIN
					SELECT        Cadets.CadetName, Cadets.PAKNumber, u.Designation, Attendance.BookOUT, Attendance.BOOKIN, AttendanceSessions.AllowedCheckOUTDateTime, AttendanceSessions.AllowedCheckINDateTime
					FROM          Attendance 
								  INNER JOIN Cadets ON Attendance.Cadet_ID = Cadets.CadetID 
								  INNER JOIN LoginUsers u ON u.UserID = Cadets.SQN_User_ID
								  INNER JOIN
								  AttendanceSessions ON Attendance.AttendanceSession_ID = AttendanceSessions.AttendanceSessionID
					WHERE EntryDate BETWEEN @FromDate AND @ToDate
					AND Cadets.CadetID=@CadetID
			END
 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[CheckPunsihment]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckPunsihment]
(
  @CadetID INT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY 
   IF EXISTS(Select TOP(1) * From Punishments p WHERE  p.Cadet_ID = @CadetID AND (p.IsSpecialWaiver = 1 OR p.IsPunishCompleted = 1) ORDER BY PunishmentID DESC )
		BEGIN
				SELECT   TOP(1) pp.Cadet_ID
				FROM    Punishments  pp
				 WHERE  pp.Cadet_ID = @CadetID
		END
	ELSE
		BEGIN
			SET @Status = 0
			SET @StatusDetails =  'Not Allowed. Please Contact to Your Officer'
		END
 
		SET @Status = 1
		SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_AddCadetPermission]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_AddCadetPermission]
(
	@UserID INT,
	@CadetID INT,
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	--IF NOT EXISTS (SELECT TOP(1) * FROM CadetSearchPermissions)
	IF(@CadetID  is not null AND  @UserID is not null)
		BEGIN
			IF NOT EXISTS (SELECT * FROM CadetSearchPermissions WHERE Cadet_ID = @CadetID AND [User_ID] = @UserID)
				BEGIN
					INSERT INTO CadetSearchPermissions(User_ID,CADET_ID) VALUES (@UserID,@CadetID)
				END
			ELSE
				BEGIN
				     SET @StatusDetails = 'ROW EXISTS,IGNORED'
				END
		END
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_AuthenticateUser]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_AuthenticateUser]
(
  @Role VARCHAR(50),
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	SELECT f.FormName,f.FormDisplayName, r.Role,r.RoleID FROM RolesPermission rp
	INNER JOIN Forms f ON f.FormID = rp.Form_ID
	INNER JOIN LoginRoles r ON r.RoleID = rp.Role_ID
	WHERE rp.Role_ID IN (SELECT RoleID FROM LoginRoles rr WHERE rr.Role = @Role)
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_CompareUNameUPassToGetRole]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CompareUNameUPassToGetRole]
(
	@RoleID int out,
	@UserName varchar(50),
	@UserPassword varchar(50),
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
AS
BEGIN
	BEGIN TRY
	
	DECLARE @uID int
	SET @uID = (SELECT UserID from LoginUsers where UserName = @UserName and UserPassword = @UserPassword)
	
	
	IF(@uID is not null)
	 BEGIN
		SET @RoleID = (select Role_ID from LoginUsersRoles where [User_ID] =@uID )
	 END
	ELSE
		SET @RoleID = 0
		
		SET @Status = 1
		SET @StatusDetails = 'SUCCESS'
	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_CreateAttendance]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CreateAttendance]
(
  @Cadet_ID int, 
  @SessionInformation VARCHAR(50) OUTPUT,
  @AttendanceType VARCHAR(20) OUTPUT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY

			DECLARE @ActivityTime DATETIME
			SET @ActivityTime = GETDATE()

			DECLARE @Delay INT
			SET @Delay = 2 --mints

			DECLARE @LastActivity DATETIME
			SELECT @LastActivity=LastActivityDateTime FROM Cadets WHERE CadetID=@Cadet_ID

			DECLARE @AttendanceSessionID INT
			SELECT TOP(1) @AttendanceSessionID = AttendanceSessionID FROM AttendanceSessions 
			WHERE @ActivityTime BETWEEN AllowedCheckOUTDateTime AND AllowedCheckINDateTime
			AND Cadet_ID=@Cadet_ID
			
			--Check Delay
			IF @LastActivity IS NOT NULL
			BEGIN
				SET @LastActivity = (SELECT DATEADD(MINUTE,@Delay,@LastActivity)) 
				IF @LastActivity>@ActivityTime
				BEGIN
					SET @AttendanceType = ''
					SET	@SessionInformation = 'ALREADY CHECKED'
					SET @Status = 1
					SET @StatusDetails = 'SUCCESS'
					RETURN
				END
			END

			---SESSION CHECKING
			IF @AttendanceSessionID IS NULL
			BEGIN
				SET @AttendanceType = ''
			    SET	@SessionInformation = 'INVALID SESSION'
				SET @Status = 1
				SET @StatusDetails = 'SUCCESS'
				RETURN
			END

	DECLARE @RecordExist int
	set @RecordExist = (Select top 1 P.PunishmentID From Punishments p WHERE  p.Cadet_ID = @Cadet_ID AND (p.IsSpecialWaiver = 1 OR p.IsPunishCompleted = 1) ORDER BY PunishmentID DESC)
	
	-- if Punishment TURE
    IF EXISTS(Select TOP(1) * From Punishments p WHERE  p.Cadet_ID = @Cadet_ID AND (p.IsSpecialWaiver = 1 OR p.IsPunishCompleted = 1) ORDER BY PunishmentID DESC ) 
			OR @RecordExist IS NULL
		BEGIN
			IF EXISTS( SELECT TOP(1) * FROM Attendance WHERE Cadet_ID=@Cadet_ID AND BOOKIN IS NULL)
			BEGIN
			--CHECK IN
				UPDATE  Attendance 
				SET BOOKIN = @ActivityTime,
				AttendanceSession_ID = @AttendanceSessionID
				WHERE Cadet_ID=@Cadet_ID  
				
				SET @AttendanceType = 'BOOK IN'
			    SET	@SessionInformation = 'VALID SESSION'
			END -- CHECK IN
			ELSE 
			BEGIN
			--CHECK OUT
				INSERT INTO Attendance(Cadet_ID,BookOUT,AttendanceSession_ID)

				VALUES(@Cadet_ID,@ActivityTime,@AttendanceSessionID) 
				SET @AttendanceType = 'BOOK OUT'
			    SET	@SessionInformation = 'VALID SESSION'
			END -- CHECK OUT
				 
				 --Update Cadet Last Activity
				 UPDATE Cadets SET LastActivityDateTime=@ActivityTime WHERE CadetID=@Cadet_ID
		END
	-- else ?
	   ELSE
	      BEGIN
	          SET @AttendanceType = ''
	   	  	  SET	@SessionInformation = 'Pending Punishment Cant allowed Book OUT' 
	   	  	  SET @Status = 0
	   	  	  SET @StatusDetails = ''
	   	  	  RETURN
	      END
	  
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'

END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_CreateAttendanceUpdated]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CreateAttendanceUpdated]
(
  @Cadet_ID int, 
  @SessionInformation VARCHAR(50) OUTPUT,
  @AttendanceType VARCHAR(20) OUTPUT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
---kamran code
-- kamra code ent

			DECLARE @ActivityTime DATETIME
			SET @ActivityTime = GETDATE()

			DECLARE @Delay INT
			SET @Delay = 1 --mints

			DECLARE @LastActivity DATETIME
			SELECT @LastActivity=LastActivityDateTime FROM Cadets WHERE CadetID=@Cadet_ID

			DECLARE @AttendanceSessionID INT
			SELECT TOP(1) @AttendanceSessionID = AttendanceSessionID FROM AttendanceSessions 
			WHERE @ActivityTime BETWEEN AllowedCheckOUTDateTime AND AllowedCheckINDateTime
			AND Cadet_ID=@Cadet_ID
			
			select * from Attendance
			--Check wheather
			 Declare @AttendenceExist as int=0
			 set @AttendenceExist=(select Top 1 Count(*) from Attendance where Cadet_ID=@Cadet_ID and AttendanceSession_ID=(select Top 1 S.AttendanceSessionID from AttendanceSessions as S where S.Cadet_ID=@Cadet_ID order by S.AttendanceSessionID desc) and BOOKIN is null )
			 if	@AttendenceExist>0
				begin
					Declare @BookIN as varchar(50)
					set @BookIN=(select Top 1 BOOKIN from Attendance where Cadet_ID=@Cadet_ID and AttendanceSession_ID=(select Top 1 S.AttendanceSessionID from AttendanceSessions as S where S.Cadet_ID=@Cadet_ID order by S.AttendanceSessionID desc) and BOOKIN is null order by AttendanceID desc)
					if @BookIN is not null
					begin

					SET @AttendanceType = ''
							SET	@SessionInformation = 'SESSION EXPIRE'
							SET @Status = 1
							SET @StatusDetails = 'Failure'
							RETURN;
				End
			 End
			 else if (select Count(*) from Attendance where  Cadet_ID=@Cadet_ID and AttendanceSession_ID=(select Top 1 S.AttendanceSessionID from AttendanceSessions as S where S.Cadet_ID=@Cadet_ID order by S.AttendanceSessionID desc) and BOOKIN is not null )>0
			 begin
			 SET @AttendanceType = ''
							SET	@SessionInformation = 'SESSION EXPIRE'
							SET @Status = 1
							SET @StatusDetails = 'Failure'
							RETURN;
			 End
			--Check Delay
			IF @LastActivity IS NOT NULL
			BEGIN
				SET @LastActivity = (SELECT DATEADD(MINUTE,@Delay,@LastActivity)) 
				IF @LastActivity>@ActivityTime
				BEGIN
					SET @AttendanceType = ''
					SET	@SessionInformation = 'ALREADY CHECKED'
					SET @Status = 1
					SET @StatusDetails = 'SUCCESS'
					RETURN
				END
			END

			---SESSION CHECKING
			IF (select Top 1 S.AttendanceSessionID from AttendanceSessions as S where S.Cadet_ID=@Cadet_ID order by S.AttendanceSessionID desc) IS NULL
			BEGIN
				SET @AttendanceType = ''
			    SET	@SessionInformation = 'INVALID SESSION'
				SET @Status = 1
				SET @StatusDetails = 'SUCCESS'
				RETURN
			END

	DECLARE @RecordExist int
	set @RecordExist = (Select top 1 P.PunishmentID From Punishments p WHERE  p.Cadet_ID = @Cadet_ID AND (p.IsSpecialWaiver = 1 OR p.IsPunishCompleted = 1) ORDER BY PunishmentID DESC)
	
	if Exists((Select top 1 P.PunishmentID From Punishments p WHERE  p.Cadet_ID = @Cadet_ID AND (p.IsSpecialWaiver = 0 and p.IsPunishCompleted = 0) ORDER BY PunishmentID DESC))
	begin
	SET @AttendanceType = ''
	   	  	  SET	@SessionInformation = 'PENDING PUNISHMENT CANNOT ALLOWED BOOK OUT' 
	   	  	  SET @Status = 0
	   	  	  SET @StatusDetails = ''
	return
	End
	else		
	begin
	declare @SessionID as int =(select Top 1 S.AttendanceSessionID from AttendanceSessions as S where S.Cadet_ID=@Cadet_ID order by S.AttendanceSessionID desc)
			
	IF EXISTS( SELECT TOP(1) * FROM Attendance WHERE Cadet_ID=@Cadet_ID and AttendanceSession_ID=((select Top 1 S.AttendanceSessionID from AttendanceSessions as S where S.Cadet_ID=@Cadet_ID order by S.AttendanceSessionID desc)) AND BOOKIN IS NULL order by AttendanceID desc)
			BEGIN
			--CHECK IN
				UPDATE  Attendance 
				SET BOOKIN = @ActivityTime
				--,AttendanceSession_ID = @SessionID
				WHERE Cadet_ID=@Cadet_ID  and AttendanceSession_ID=@SessionID
				
				SET @AttendanceType = 'BOOK IN'
			    SET	@SessionInformation = 'VALID SESSION'
			END -- CHECK IN
			ELSE
				BEGIN
			--CHECK OUT
				INSERT INTO Attendance(Cadet_ID,BookOUT,AttendanceSession_ID)

				VALUES(@Cadet_ID,@ActivityTime,@SessionID) 
				SET @AttendanceType = 'BOOK OUT'
			    SET	@SessionInformation = 'VALID SESSION'
			END -- CHECK OUT
				 
				 --Update Cadet Last Activity
				 UPDATE Cadets SET LastActivityDateTime=@ActivityTime WHERE CadetID=@Cadet_ID
	End



	-- if Punishment TURE
 --   IF EXISTS(Select TOP(1) * From Punishments p WHERE  p.Cadet_ID = @Cadet_ID AND (p.IsSpecialWaiver = 1 OR p.IsPunishCompleted = 1) ORDER BY PunishmentID DESC ) 
	--		OR @RecordExist IS NULL
	--	BEGIN
	--		IF EXISTS( SELECT TOP(1) * FROM Attendance WHERE Cadet_ID=@Cadet_ID AND BOOKIN IS NULL)
	--		BEGIN
	--		--CHECK IN
	--			UPDATE  Attendance 
	--			SET BOOKIN = @ActivityTime,
	--			AttendanceSession_ID = @AttendanceSessionID
	--			WHERE Cadet_ID=@Cadet_ID  
				
	--			SET @AttendanceType = 'BOOK IN'
	--		    SET	@SessionInformation = 'VALID SESSION'
	--		END -- CHECK IN
	--		ELSE 
	--		BEGIN
	--		--CHECK OUT
	--			INSERT INTO Attendance(Cadet_ID,BookOUT,AttendanceSession_ID)

	--			VALUES(@Cadet_ID,@ActivityTime,@AttendanceSessionID) 
	--			SET @AttendanceType = 'BOOK OUT'
	--		    SET	@SessionInformation = 'VALID SESSION'
	--		END -- CHECK OUT
				 
	--			 --Update Cadet Last Activity
	--			 UPDATE Cadets SET LastActivityDateTime=@ActivityTime WHERE CadetID=@Cadet_ID
	--	END
	---- else ?
	--   ELSE
	--      BEGIN
	--          SET @AttendanceType = ''
	--   	  	  SET	@SessionInformation = 'Pending Punishment Cant allowed Book OUT' 
	--   	  	  SET @Status = 0
	--   	  	  SET @StatusDetails = ''
	--   	  	  RETURN
	--      END
	  
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'

END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteAttendance]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteAttendance]
(
  @AttendanceID int,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
begin

BEGIN TRY 
	 DELETE FROM Attendance 
	 WHERE AttendanceID =@AttendanceID
	 
	 SET @Status = 1
	 SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	 SET @Status = 0
	 SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End


GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteAttendanceSessionHistory]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteAttendanceSessionHistory]
(
  @AttendanceSessionHistoryID int,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
AS
BEGIN
Begin try
	DELETE FROM AttendanceSessionHistory 
	WHERE AttendanceSessionHistoryID =@AttendanceSessionHistoryID
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
    SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
 END CATCH
End



GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteAttendanceSessions]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteAttendanceSessions]
(
  @AttendanceSessionID int,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
AS
BEGIN
BEGIN TRY
	DELETE FROM AttendanceSessions 
	Where  AttendanceSessionID = @AttendanceSessionID
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
   SET @Status = 0
   SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End



GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteCadetCourses]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteCadetCourses]
(
  @CourseID int,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	Delete from CadetCourses 
	WHERE CourseID =@CourseID
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
  	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
 END CATCH
End

GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteCadetPermission]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteCadetPermission]
(
	@UserID INT,
	@CadetID INT,
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	DELETE FROM CadetSearchPermissions WHERE User_ID=@UserID AND CADET_ID=@CadetID
	
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteCadets]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteCadets]
(
  @CadetID int,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	DELETE  FROM Cadets 
	WHERE CadetID = @CadetID
	
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End

GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteCadetsHistory]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteCadetsHistory]
(
  @CadetHistoryID int,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY 
	 DELETE FROM CadetsHistory 
	 WHERE CadetHistoryID = @CadetHistoryID
	 
	 SET @Status = 1
	 SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	 SET @Status = 0
	 SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteCadetTapes]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteCadetTapes]
(
  @TapeID int,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	 DELETE from CadetTapes 
	 WHERE TapeID = @TapeID
	 
	 SET @Status = 1
	 SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	 SET @Status = 0
	 SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End



GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteLoginRoles]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteLoginRoles]
(@RoleID int)
as
Begin
begin try
Delete from LoginRoles Where RoleID = @RoleID
 END TRY
 BEGIN CATCH
    SELECT   ERROR_NUMBER() AS ErrorNumber  
            ,ERROR_SEVERITY() AS ErrorSeverity  
            ,ERROR_STATE() AS ErrorState  
            ,ERROR_PROCEDURE() AS ErrorProcedure  
            ,ERROR_LINE() AS ErrorLine  
            ,ERROR_MESSAGE() AS ErrorMessage;  
 END CATCH
End



GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteLoginUser]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteLoginUser]
(
  @UserID int,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	DELETE FROM LoginUsers 
	WHERE UserID = @UserID
		 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End



GO
/****** Object:  StoredProcedure [dbo].[usp_DeletePunishmentCategories]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeletePunishmentCategories]
(
  @CategoryID int,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
Begin
BEGIN TRY
	 DELETE FROM PunishmentCategories 
	 WHERE CategoryID =@CategoryID
	 
	 SET @Status = 1
	 SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	 SET @Status = 0
	 SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End



GO
/****** Object:  StoredProcedure [dbo].[usp_DeletePunishments]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeletePunishments]
(
  @PunishmentID int,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	DELETE  FROM Punishments 
	WHERE PunishmentID = @PunishmentID
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	 SET @Status = 0
	 SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End



GO
/****** Object:  StoredProcedure [dbo].[usp_DeletePunishmentsHistory]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeletePunishmentsHistory]
(
  @PunishmentHistoryID int,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	DELETE FROM PunishmentsHistory WHERE PunishmentHistoryID = @PunishmentHistoryID
	 
	 SET @Status = 1
	 SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	 SET @Status = 0
	 SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End



GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllCadetByCourse]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetAllCadetByCourse]
(
  @CourseID INT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
Begin
BEGIN TRY

	SELECT * from Cadets cx
	WHERE cx.Course_ID = @CourseID
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH	
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetAssignForms]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetAssignForms]
(
  @RoleID INT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
    
	SELECT rp.Form_ID ,f.FormDisplayName as 'Form Name',f.FormDisplayDetails 'Detail' from RolesPermission rp 
	INNER JOIN Forms f ON f.FormID = rp.Form_ID
	WHERE rp.Role_ID = @RoleID
	
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End



GO
/****** Object:  StoredProcedure [dbo].[usp_GetAssignFormsPermissionToUser]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetAssignFormsPermissionToUser]
(
  @UesrID INT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
   
SELECT        c.CadetID, c.CadetName, c.PAKNumber, cc.CourseName, ct.TapeName, c.CNIC, LoginUsers.FullName as 'SQN'
FROM            CadetSearchPermissions AS cs INNER JOIN
                         Cadets AS c ON c.CadetID = cs.Cadet_ID INNER JOIN
                         CadetTapes AS ct ON ct.TapeID = c.Tape_ID INNER JOIN
                         CadetCourses AS cc ON cc.CourseID = c.Course_ID INNER JOIN
                         LoginUsers ON c.SQN_User_ID = LoginUsers.UserID
WHERE        (cs.User_ID IN
                             (SELECT        UserID
                               FROM            LoginUsers AS uu
                               WHERE        (cs.User_ID = @UesrID)))
	
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End



GO
/****** Object:  StoredProcedure [dbo].[usp_GetAttendance]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetAttendance]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY 
    SELECT * FROM Attendance a
	INNER JOIN Cadets c ON c.CadetID = a.Cadet_ID
	INNER JOIN AttendanceSessionHistory ash ON ash.AttendanceSessionHistoryID = a.CheckINAttendanceSessionHistory_ID
	INNER JOIN LoginUsers lu ON lu.UserID = c.CreatedBy_User_ID --Confimation
	INNER JOIN CadetCourses cc ON cc.CourseID = c.Course_ID
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[usp_GetAttendanceSessionHistory]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetAttendanceSessionHistory]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
AS
BEGIN
BEGIN TRY
	SELECT * FROM AttendanceSessionHistory
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End



GO
/****** Object:  StoredProcedure [dbo].[usp_GetAttendanceSessions]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetAttendanceSessions]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
AS
BEGIN
BEGIN TRY
	SELECT * FROM AttendanceSessions
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End



GO
/****** Object:  StoredProcedure [dbo].[usp_GetCadetCourses]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCadetCourses]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
Begin
BEGIN TRY
	--SELECT -1 AS 'CourseID','-- Select Course --' AS CourseName
	--UNION
	SELECT 0 AS 'CourseID','ALL' AS CourseName
	UNION
	SELECT cc.CourseID,cc.CourseName FROM CadetCourses cc
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH	
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetCadetCoursesByTape]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCadetCoursesByTape]
(
  @TapeID INT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
Begin
BEGIN TRY
SELECT c.CadetID,c.CadetName, c.PAKNumber, cx.CadetName as 'Senior Officer', cc.CourseName, c.ContactNumber from Cadets c
					INNER JOIN CadetTapes ct  ON ct.TapeID = c.Tape_ID
					INNER JOIN CadetCourses  cc  ON cc.CourseID = c.Course_ID
					INNER JOIN Cadets cx  ON cx.CadetID = c.SQN_User_ID
				    Where c.Tape_ID = @TapeID
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH	
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetCadetCoursesByTape1]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCadetCoursesByTape1]
(
  @TapeID INT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
Begin
BEGIN TRY

SELECT cc.CourseID ,cc.CourseName from Cadets  c
INNER JOIN CadetCourses cc  ON c.Course_ID = cc.CourseID
				     Where c.Tape_ID = @TapeID

	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH	
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetCadetDataForAttendanceSession]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCadetDataForAttendanceSession]
(
  @UserID INT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
Begin
BEGIN TRY


SELECT        c.CadetID, c.CadetName, c.PAKNumber, u.FullName AS 'Senior Officer', cc.CourseName, c.ContactNumber, c.CNIC, ct.TapeName, cc.CourseName AS Expr1
FROM            Cadets AS c INNER JOIN
                         CadetTapes AS ct ON ct.TapeID = c.Tape_ID INNER JOIN
                         CadetCourses AS cc ON cc.CourseID = c.Course_ID INNER JOIN
                         LoginUsers AS u ON U.UserID = c.SQN_User_ID
WHERE        (c.CadetID IN
                             (SELECT        Cadet_ID
                               FROM            CadetSearchPermissions
                               WHERE        (User_ID = @UserID)))
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH	
End

 

GO
/****** Object:  StoredProcedure [dbo].[usp_GetCadetIdAndName]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCadetIdAndName]
AS
BEGIN
	SELECT c.CadetID,c.CadetName FROM Cadets c
END

GO
/****** Object:  StoredProcedure [dbo].[usp_GetCadetPermissionByCourse]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCadetPermissionByCourse]
(
  @CourseID INT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
Begin
BEGIN TRY
SELECT c.CadetID, c.PAKNumber, c.CadetName, ct.TapeName, c.Picture   from Cadets c
					INNER JOIN CadetTapes ct  ON ct.TapeID = c.Tape_ID
					INNER JOIN CadetCourses  cc  ON cc.CourseID = c.Course_ID
				    Where c.Course_ID = @CourseID
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH	
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetCadetPermissionByTape]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCadetPermissionByTape]
(
  @TapeID INT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
Begin
BEGIN TRY
SELECT c.CadetID,c.CadetName, c.PAKNumber, cc.CourseName, c.Picture from Cadets c
					INNER JOIN CadetTapes ct  ON ct.TapeID = c.Tape_ID
					INNER JOIN CadetCourses  cc  ON cc.CourseID = c.Course_ID
				    Where c.Tape_ID = @TapeID
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH	
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetCadetRoles]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCadetRoles]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	SELECT r.RoleID,r.[Role] from LoginRoles r WHERE [Role] = 'SeniorCadet' OR [Role] = 'JuniorCadet' 
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End



GO
/****** Object:  StoredProcedure [dbo].[usp_GetCadets]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCadets]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	SELECT * FROM Cadets
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetCadetsByTapeAndCourseID]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCadetsByTapeAndCourseID]
(
  @AllowedForUser INT,
  @SQNID INT,
  @CourseID INT,
  @TapeID INT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
Begin
BEGIN TRY
 




IF (@CourseID = 0 AND @TapeID =0 AND @SQNID = 0)
	BEGIN
			SELECT c.CadetID,c.CadetName,c.PAKNumber,cc.CourseName,c.CNIC,ct.TapeName,u.FullName as 'SQN' from Cadets c
					INNER JOIN CadetTapes ct  ON ct.TapeID = c.Tape_ID
					INNER JOIN CadetCourses  cc  ON cc.CourseID = c.Course_ID 
					INNER JOIN LoginUsers u  ON u.UserID = c.SQN_User_ID
					WHERE c.CadetID NOT IN (SELECT Cadet_ID FROM CadetSearchPermissions WHERE User_ID = @AllowedForUser)
	END
IF  (@CourseID != 0 AND  @TapeID != 0 AND @SQNID != 0)
	BEGIN 
		SELECT c.CadetID,c.CadetName,c.PAKNumber,cc.CourseName,c.CNIC,ct.TapeName,u.FullName as 'SQN' from Cadets c
						INNER JOIN CadetTapes ct  ON ct.TapeID = c.Tape_ID
						INNER JOIN CadetCourses  cc  ON cc.CourseID = c.Course_ID
						INNER JOIN LoginUsers u  ON u.UserID = c.SQN_User_ID
						Where cc.CourseID = @CourseID AND ct.TapeID=@TapeID AND c.SQN_User_ID = @SQNID
						AND c.CadetID NOT IN (SELECT Cadet_ID FROM CadetSearchPermissions WHERE User_ID =@AllowedForUser)
	 END 
--ELSE
    IF (@CourseID != 0 AND @TapeID != 0)
	BEGIN
			SELECT c.CadetID,c.CadetName,c.PAKNumber,cc.CourseName,c.CNIC,ct.TapeName,u.FullName as 'SQN' from Cadets c
					INNER JOIN CadetTapes ct  ON ct.TapeID = c.Tape_ID
					INNER JOIN CadetCourses  cc  ON cc.CourseID = c.Course_ID 
					INNER JOIN LoginUsers u  ON u.UserID = c.SQN_User_ID
					WHERE c.CadetID NOT IN (SELECT Cadet_ID FROM CadetSearchPermissions WHERE User_ID =@AllowedForUser)
	END
--ELSE
	IF (@TapeID != 0)
	 BEGIN 
		SELECT c.CadetID,c.CadetName,c.PAKNumber,cc.CourseName,c.CNIC,ct.TapeName,u.FullName as 'SQN' from Cadets c
						INNER JOIN CadetTapes ct  ON ct.TapeID = c.Tape_ID
						INNER JOIN CadetCourses  cc  ON cc.CourseID = c.Course_ID
						INNER JOIN LoginUsers u  ON u.UserID = c.SQN_User_ID
						Where c.Tape_ID = @TapeID
						AND c.CadetID NOT IN (SELECT Cadet_ID FROM CadetSearchPermissions WHERE User_ID =@AllowedForUser)
	 END
	--ELSE
	  IF (@CourseID != 0)
		BEGIN
			SELECT c.CadetID,c.CadetName,c.PAKNumber,cc.CourseName,c.CNIC,ct.TapeName,u.FullName as 'SQN' from Cadets c
						INNER JOIN CadetTapes ct  ON ct.TapeID = c.Tape_ID
						INNER JOIN CadetCourses  cc  ON cc.CourseID = c.Course_ID
						INNER JOIN LoginUsers u  ON u.UserID = c.SQN_User_ID
						Where cc.CourseID = @CourseID
						AND c.CadetID NOT IN (SELECT Cadet_ID FROM CadetSearchPermissions WHERE User_ID =@AllowedForUser)
		END  
	-- ELSE 
	IF (@SQNID != 0)
	 BEGIN
	 	SELECT c.CadetID,c.CadetName,c.PAKNumber,cc.CourseName,c.CNIC,ct.TapeName,u.FullName as 'SQN' from Cadets c
	 					INNER JOIN CadetTapes ct  ON ct.TapeID = c.Tape_ID
	 					INNER JOIN CadetCourses  cc  ON cc.CourseID = c.Course_ID
						INNER JOIN LoginUsers u  ON u.UserID = c.SQN_User_ID
	 					Where c.SQN_User_ID = @SQNID 
						AND c.CadetID NOT IN (SELECT Cadet_ID FROM CadetSearchPermissions WHERE User_ID =@AllowedForUser)
	 END
	 --ELSE 
	 IF  (@CourseID != 0 AND  @TapeID != 0)
		BEGIN 
			SELECT c.CadetID,c.CadetName,c.PAKNumber,cc.CourseName,c.CNIC,ct.TapeName,u.FullName as 'SQN' from Cadets c
							INNER JOIN CadetTapes ct  ON ct.TapeID = c.Tape_ID
							INNER JOIN CadetCourses  cc  ON cc.CourseID = c.Course_ID
							INNER JOIN LoginUsers u  ON u.UserID = c.SQN_User_ID
							Where cc.CourseID = @CourseID AND ct.TapeID=@TapeID
							AND c.CadetID NOT IN (SELECT Cadet_ID FROM CadetSearchPermissions WHERE User_ID =@AllowedForUser)
		END
	 --ELSE 
	  
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH	
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetCadetSearchPermissions]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCadetSearchPermissions]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY 
	SELECT * FROM CadetSearchPermissions
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetCadetsHistory]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCadetsHistory]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY 
	SELECT * FROM CadetsHistory
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_GetCadetsPunishmentInformation]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCadetsPunishmentInformation] --'0','12345',true,'ok'
(
  @PAKNumber VARCHAR(200),
  @RFIDCardNumber VARCHAR(200),
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY


SELECT c.PAKNumber ,c.RFIDCardNumber, c.CadetName, r.[Role],c.ContactNumber,c.MobileNumber,c.[Address],cc.CourseName,t.TapeName,c.Picture,c.CadetID,c.Role_ID,c.CadetName as 'Senior'
	FROM Cadets c
	INNER JOIN LoginRoles r on r.RoleID = c.Role_ID
	INNER JOIN CadetCourses cc on cc.CourseID = c.Course_ID
	INNER JOIN CadetTapes t on t.TapeID = c.Tape_ID
	--INNER JOIN Cadets cs on cs.SQN_User_ID = c.CadetID
	WHERE  c.PAKNumber = @PAKNumber OR  c.RFIDCardNumber = @RFIDCardNumber

	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetCadetSQN]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetCadetSQN]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	--SELECT -1 AS UserID ,'-- Select SQN --' AS FullName
	--UNION
	SELECT 0 AS UserID ,'ALL' AS FullName
	UNION
	SELECT u.UserID,u.FullName FROM LoginUsers u WHERE u.Designation LIKE '%SQN%'
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_GetCadetTapes]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCadetTapes]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	--SELECT -1 AS TapeID,'-- Select Tape --' AS TapeName
	--UNION
	SELECT 0 AS TapeID,'ALL' AS TapeName
	UNION
	SELECT * FROM CadetTapes
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_GetCreatedSessionByCheckOUTDate]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetCreatedSessionByCheckOUTDate]
(
  @AllowedCheckOUTDateTime datetime,
  @TOAllowedCheckOUTDateTime datetime
)
as 


SELECT        AttendanceSessions.AllowedCheckOUTDateTime, AttendanceSessions.AllowedCheckINDateTime , LoginUsers.FullName as CreatedBy
FROM            AttendanceSessions INNER JOIN
                         LoginUsers ON AttendanceSessions.User_ID = LoginUsers.UserID
GROUP BY AttendanceSessions.AllowedCheckOUTDateTime, AttendanceSessions.AllowedCheckINDateTime, AttendanceSessions.User_ID, LoginUsers.FullName
HAVING         (AttendanceSessions.AllowedCheckOUTDateTime BETWEEN @AllowedCheckOUTDateTime AND @TOAllowedCheckOUTDateTime)





GO
/****** Object:  StoredProcedure [dbo].[usp_GetForms]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetForms]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	SELECT f.FormID, f.FormName as 'Forms', f.FormDisplayName as 'Form Name',f.FormDisplayDetails 'Detail' from Forms f 
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End



GO
/****** Object:  StoredProcedure [dbo].[usp_GetLoginRoles]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetLoginRoles]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	SELECT 0 as RoleID, '-- Select Role --' as Role, 'RoleDetails' as RoleDetails
	UNION
	SELECT * from LoginRoles
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End



GO
/****** Object:  StoredProcedure [dbo].[usp_GetLoginUser]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetLoginUser]
(
  @UserName  VARCHAR(50),
  @UserPassword  VARCHAR(50),
  @LoginRoleID INT OUTPUT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
    DECLARE @LoginUserID INT
	SET @LoginUserID = (SELECT UserID FROM LoginUsers  WHERE UserName = @UserName AND UserPassword = @UserPassword)
	IF(@LoginUserID is not null)
		BEGIN
			SET @LoginRoleID = (SELECT UserRoleID FROM LoginUsersRoles ur  WHERE ur.[User_ID] = @LoginUserID)
		END
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_GetLoginUsersRoles]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetLoginUsersRoles]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY 
	SELECT * FROM LoginUsersRoles
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_GetMainDashBoardData]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetMainDashBoardData]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	
	SELECT COUNT(Role) AS 'Sqn' FROM LoginRoles ur
	INNER JOIN LoginUsersRoles r ON  r.Role_ID = ur.RoleID
	WHERE ur.Role = 'Sqn' 
	
	SELECT COUNT(Role) AS 'WC' FROM LoginUsersRoles ur
	INNER JOIN LoginRoles r ON  r.RoleID = ur.Role_ID
	WHERE r.Role = 'WC' 
	
	SELECT COUNT(*) AS 'TotalCadet' FROM Cadets 
	
	SELECT COUNT(*) AS 'SeniorCadet' FROM Cadets ur
	INNER JOIN LoginRoles r ON  r.RoleID = ur.Role_ID
	WHERE r.Role = 'SeniorCadet' 
	
	SELECT COUNT(*) AS 'JuniorCadet' FROM Cadets ur
	INNER JOIN LoginRoles r ON  r.RoleID = ur.Role_ID
	WHERE r.Role = 'JuniorCadet' 
	
	SELECT COUNT(*) AS 'English' FROM Cadets c
	INNER JOIN CadetCourses cc ON  cc.CourseID = c.Course_ID
	WHERE cc.CourseName = 'English'
	
	SELECT COUNT(*) AS 'Urdu' FROM Cadets c
	INNER JOIN CadetCourses cc ON  cc.CourseID = c.Course_ID
	WHERE cc.CourseName = 'Urdu'
	
	SELECT COUNT(*) AS 'Computer' FROM Cadets c
	INNER JOIN CadetCourses cc ON  cc.CourseID = c.Course_ID
	WHERE cc.CourseName = 'Computer'
	
	SELECT COUNT(*) AS 'Science' FROM Cadets c
	INNER JOIN CadetCourses cc ON  cc.CourseID = c.Course_ID
	WHERE cc.CourseName = 'Science'	
	
	SELECT COUNT(*) AS 'PakStudy' FROM Cadets c
	INNER JOIN CadetCourses cc ON  cc.CourseID = c.Course_ID
	WHERE cc.CourseName = 'Pak Study'
	
	SELECT COUNT(*) AS 'Maths' FROM Cadets c
	INNER JOIN CadetCourses cc ON  cc.CourseID = c.Course_ID
	WHERE cc.CourseName = 'Maths'

	
	DECLARE @Date1 Datetime
	SET @Date1 = CONVERT(date, GETDATE())
	SELECT COUNT(*) AS 'DailyAttendance'FROM Attendance WHERE @Date1 = @Date1

	SELECT COUNT(BookOUT) AS 'BOOKOUT',COUNT(BookIN) AS 'BOOKIN' FROM Attendance a
	INNER JOIN Cadets c ON  c.CadetID = a.Cadet_ID

		 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetPakNo_AND_RFIDNo_EXIST]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetPakNo_AND_RFIDNo_EXIST]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
   --SELECT COUNT(c.PAKNumber),COUNT(c.RFIDCardNumber) from CADETS c
	 SELECT c.PAKNumber , c.RFIDCardNumber from CADETS c 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End



GO
/****** Object:  StoredProcedure [dbo].[usp_GetPunishmentCategories]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetPunishmentCategories]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY 
	SELECT * FROM PunishmentCategories
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_GetPunishments]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetPunishments]
(
  @PakNo VARCHAR(200),
  @RFIDCardNumber VARCHAR(200),
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY 
	--SELECT * FROM Punishments 

	SELECT p.PunishmentID,pc.CategoryID,pc.CategoryName as 'Punishment Type',p.Remarks,p.IsSpecialWaiver as 'Special Waiver',IsPunishCompleted  as  'Punish Completed'
	FROM Punishments p
	INNER JOIN PunishmentCategories pc ON pc.CategoryID = p.Category_ID
	--WHERE p.Cadet_ID = (4)
	WHERE p.Cadet_ID = (Select CadetID from Cadets c Where c.PAKNumber = @PakNo OR c.RFIDCardNumber = @RFIDCardNumber)
	AND IsPunishCompleted = 0
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_GetPunishmentsHistory]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetPunishmentsHistory]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY 
	SELECT * FROM PunishmentsHistory
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_GetSeniorOfficerByFullName]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetSeniorOfficerByFullName]
(
  @UserID int,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	--SELECT 0 as [UserID], '-- Seect Designation --' as Designation   WHERE UserID = @UserID
	--UNION
	SELECT UserID, Designation from LoginUsers  WHERE UserID = @UserID
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End



GO
/****** Object:  StoredProcedure [dbo].[usp_GetSeniorOfficerByUserID]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetSeniorOfficerByUserID]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
    SELECT -1 as UserID, '-- Select Officer --' as FullName, 'Designation' as Designation 
	UNION
	SELECT  UserID,FullName,Designation from LoginUsers  
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End



GO
/****** Object:  StoredProcedure [dbo].[usp_GetTapeByCourse]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetTapeByCourse]
(
  @CourseID INT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
Begin
BEGIN TRY
        SELECT 0 AS 'TapeID','-- Select Tape --' AS TapeName
	    UNION
	 --   SELECT 0 AS 'TapeID','-- ALL --' AS TapeName
		--UNION
		SELECT  ct.TapeID ,ct.TapeName from Cadets c
		INNER JOIN CadetTapes ct  ON ct.TapeID = c.Tape_ID
		Where c.Course_ID = @CourseID
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH	
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetUserDesignation]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetUserDesignation]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	SELECT 0 as UserID, '-- Select Designation --' as FullName, 'Designation' as Designation
	UNION
	SELECT u.UserID,u.FullName,u.Designation FROM LoginUsers u
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertAttendanceSessions]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertAttendanceSessions]
(
  @AllowedCheckOUTDateTime datetime,
  @AllowedCheckINDateTime datetime, 
  @Cadet_ID int, --AllowNull
  @User_ID int, 
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRANSACTION
	BEGIN TRY

		IF NOT EXISTS(SELECT TOP(1) * FROM AttendanceSessions WHERE AllowedCheckINDateTime=@AllowedCheckINDateTime AND AllowedCheckOUTDateTime=@AllowedCheckOUTDateTime AND Cadet_ID=@Cadet_ID)
		
		BEGIN
			--AttendanceSessions
			INSERT into AttendanceSessions(AllowedCheckOUTDateTime,AllowedCheckINDateTime,Cadet_ID,[User_ID])
			VALUES(@AllowedCheckOUTDateTime,@AllowedCheckINDateTime,@Cadet_ID,@User_ID) 

			SET @Status = 1
			SET @StatusDetails = 'SUCCESS'
		END

		ELSE
			BEGIN
				SET @Status = 1
				SET @StatusDetails = 'SUCCESS'
			END
	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
COMMIT TRANSACTION
END



GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCadet_with_CadetHistory]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertCadet_with_CadetHistory]
( 
	@Batch varchar(20),
	@CadetName  varchar(50),
	@CadetFatherName varchar(50),
	@PAKNumber varchar(50),
	@Address varchar(200),
	@CNIC varchar(15),
	@BloodGroup varchar(12),
	@ContactNumber varchar(50),
	@MobileNumber varchar(11),
	@Picture varchar(MAX),
	@RFIDCardNumber varchar(25),
	@LFMD varchar(max),
	@RFMD varchar(max),
	@LThumbImage varchar(MAX),
	@RThumbImage varchar(MAX),
	@SQN_User_ID int,
	@Course_ID int,
	@Tape_ID int,
	@CreatedBy_User_ID int,
	@Role_ID int,
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
Begin
BEGIN TRANSACTION
	BEGIN TRY 		
	--Cadets
		INSERT INTO Cadets (Batch,CadetName,CadetFatherName,PAKNumber,[Address],CNIC,BloodGroup,ContactNumber,MobileNumber,Picture,RFIDCardNumber,LFMD,RFMD,LThumbImage,RThumbImage,SQN_User_ID,Course_ID,Tape_ID,CreatedBy_User_ID,Role_ID)
		VALUES (@Batch,@CadetName,@CadetFatherName,@PAKNumber,@Address,@CNIC,@BloodGroup,@ContactNumber,@MobileNumber,@Picture,@RFIDCardNumber,@LFMD,@RFMD,@LThumbImage,@RThumbImage,@SQN_User_ID,@Course_ID,@Tape_ID,@CreatedBy_User_ID,@Role_ID)
		
		DECLARE @Cadet_ID INT
		SET @Cadet_ID = SCOPE_IDENTITY()
	
	--CadetsHistory
		IF(@Cadet_ID is not null)
			BEGIN
				INSERT INTO CadetsHistory(Cadet_ID,Batch,CadetName,CadetFatherName,PAKNumber,[Address],CNIC,BloodGroup,ContactNumber,MobileNumber,Picture,RFIDCardNumber,LFMD,RFMD,LThumbImage,RThumbImage,SQN_User_ID,Course_ID,Tape_ID,CreatedBy_User_ID,Role_ID)
				VALUES (@Cadet_ID,@Batch,@CadetName,@CadetFatherName,@PAKNumber,@Address,@CNIC,@BloodGroup,@ContactNumber,@MobileNumber,@Picture,@RFIDCardNumber,@LFMD,@RFMD,@LThumbImage,@RThumbImage,@SQN_User_ID,@Course_ID,@Tape_ID,@CreatedBy_User_ID,@Role_ID)
			END
		ELSE
			BEGIN
				SET @Cadet_ID = 0
			END
	
		SET @Status = 1
		SET @StatusDetails = 'SUCCESS'
		COMMIT TRANSACTION

	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
		ROLLBACK
	END CATCH 
END



GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCadetCourses]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertCadetCourses]
(
	@CourseName varchar(50),
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
--INSERT into CadetCourses (CourseName) VALUES ('Urdu')
	INSERT into CadetCourses (CourseName) VALUES (@CourseName)
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCadetFromExcel_with_CadetHistory]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertCadetFromExcel_with_CadetHistory]
( 
	--@Batch varchar(20),
	@CadetName  varchar(50),
	@CadetFatherName varchar(50),
	@PAKNumber varchar(50),
	@Address varchar(200),
	@CNIC varchar(15),
	@BloodGroup varchar(12),
	@ContactNumber varchar(50),
	@MobileNumber varchar(11),
	--@Picture varchar(MAX),
	@RFIDCardNumber varchar(25),
	--@LFMD varchar(max),
	--@RFMD varchar(max),
	--@LThumbImage varchar(MAX),
	--@RThumbImage varchar(MAX),
	@SQN_User_ID int,
	@Course_ID int,
	@Tape_ID int,
	@CreatedBy_User_ID int,
	@Role_ID int,
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
Begin
BEGIN TRANSACTION
	BEGIN TRY 		
	--Cadets
		INSERT INTO Cadets (Batch,CadetName,CadetFatherName,PAKNumber,[Address],CNIC,BloodGroup,ContactNumber,MobileNumber,Picture,RFIDCardNumber,LFMD,RFMD,LThumbImage,RThumbImage,SQN_User_ID,Course_ID,Tape_ID,CreatedBy_User_ID,Role_ID)
		VALUES ('null',@CadetName,@CadetFatherName,@PAKNumber,@Address,@CNIC,@BloodGroup,@ContactNumber,@MobileNumber,'null',@RFIDCardNumber,'null','null','null','null',@SQN_User_ID,@Course_ID,@Tape_ID,@CreatedBy_User_ID,@Role_ID)
		
		DECLARE @Cadet_ID INT
		SET @Cadet_ID = SCOPE_IDENTITY()
	
	--CadetsHistory
		IF(@Cadet_ID is not null)
			BEGIN
				INSERT INTO CadetsHistory(Cadet_ID,Batch,CadetName,CadetFatherName,PAKNumber,[Address],CNIC,BloodGroup,ContactNumber,MobileNumber,Picture,RFIDCardNumber,LFMD,RFMD,LThumbImage,RThumbImage,SQN_User_ID,Course_ID,Tape_ID,CreatedBy_User_ID,Role_ID)
				VALUES (@Cadet_ID,'null',@CadetName,@CadetFatherName,@PAKNumber,@Address,@CNIC,@BloodGroup,@ContactNumber,@MobileNumber,'null',@RFIDCardNumber,'null','null','null','null',@SQN_User_ID,@Course_ID,@Tape_ID,@CreatedBy_User_ID,@Role_ID)
			END
		ELSE
			BEGIN
				SET @Cadet_ID = 0
			END
	
		SET @Status = 1
		SET @StatusDetails = 'SUCCESS'
		COMMIT TRANSACTION

	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
		ROLLBACK
	END CATCH 
END



GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCadetsHistory]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertCadetsHistory]
(
	@Cadet_ID int,
	@EntryDateTime datetime,
	@Batch varchar(20),
	@CadetName  varchar(50),
	@CadetFatherName varchar(50),
	@PAKNumber varchar(50),
	@Address varchar(200),
	@CNIC varchar(15),
	@BloodGroup varchar(12),
	@ContactNumber varchar(50),
	@MobileNumber varchar(11),
	@Picture varchar(100),
	@RFIDCardNumber varchar(25),
	@LFMD varchar(max),
	@RFMD varchar(max),
	@LThumbImage varchar(100),
	@RThumbImage varchar(100),
	@SQN_User_ID int,
	@Course_ID int,
	@Tape_ID int,
	@CreatedBy_User_ID int,
	@Role_ID int,
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY 
	INSERT INTO CadetsHistory (Cadet_ID,EntryDateTime,Batch,CadetName,CadetFatherName,PAKNumber,[Address],CNIC,BloodGroup,ContactNumber,MobileNumber,Picture,RFIDCardNumber,LFMD,RFMD,LThumbImage,RThumbImage,SQN_User_ID,Course_ID,Tape_ID,CreatedBy_User_ID,Role_ID)
	VALUES (@Cadet_ID,@EntryDateTime,@Batch,@CadetName,@CadetFatherName,@PAKNumber,@Address,@CNIC,@BloodGroup,@ContactNumber,@MobileNumber,@Picture,@RFIDCardNumber,@LFMD,@RFMD,@LThumbImage,@RThumbImage,@SQN_User_ID,@Course_ID,@Tape_ID,@CreatedBy_User_ID,@Role_ID)
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCadetTapes]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertCadetTapes]
(
	@TapeName varchar(50),
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	INSERT INTO CadetTapes(TapeName) VALUES (@TapeName)
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_InsertLoginRoles]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertLoginRoles]
(
	@Role varchar(50),
	@RoleDetails varchar(50),
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	INSERT into LoginRoles([Role],[RoleDetails]) VALUES (@Role,@RoleDetails)
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_InsertPunishmentCategories]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertPunishmentCategories]
(
	@CategoryName varchar(50),
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	INSERT INTO PunishmentCategories (CategoryName) VALUES (@CategoryName)
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_InsertPunishments_with_PunishmentsHistory]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertPunishments_with_PunishmentsHistory]
(
	@Cadet_ID int,
	@Category_ID int,
	@Remarks varchar(1000),
	@IsSpecialWaiver bit,
	@IsPunishCompleted bit,
	@User_ID INT,
	@Role_ID INT,
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRANSACTION
BEGIN TRY
	--Punishments
	INSERT INTO Punishments (Cadet_ID,Category_ID,[User_ID],Role_ID,Remarks,IsSpecialWaiver,IsPunishCompleted) 
	VALUES (@Cadet_ID,@Category_ID,@User_ID,@Role_ID,@Remarks,@IsSpecialWaiver,@IsPunishCompleted)
	
	DECLARE @Punishment_ID INT
	SET @Punishment_ID = SCOPE_IDENTITY()
	
	--PunishmentsHistory
	IF(@Punishment_ID is not null)
		BEGIN
			INSERT INTO PunishmentsHistory(Punishment_ID,Cadet_ID,Category_ID,Remarks,IsSpecialWaiver,IsPunishCompleted,[User_ID],Role_ID)
			VALUES(@Punishment_ID,@Cadet_ID,@Category_ID,@Remarks,@IsSpecialWaiver,@IsPunishCompleted,@USER_ID,@Role_ID)
		END
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
COMMIT TRANSACTION
END



GO
/****** Object:  StoredProcedure [dbo].[usp_InsertPunishmentsHistory]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertPunishmentsHistory]
(
	@Cadet_ID int,
	@Category_ID int,
	@Remarks varchar(1000),
	@IsSpecialWaiver bit,
	@IsPunishCompleted bit,
	@User_ID int,
	@Role_ID int,
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	INSERT INTO PunishmentsHistory(Cadet_ID,Category_ID,Remarks,IsSpecialWaiver,IsPunishCompleted,[User_ID],Role_ID)
	VALUES(@Cadet_ID,@Category_ID,@Remarks,@IsSpecialWaiver,@IsPunishCompleted,@USER_ID,@Role_ID)
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END




GO
/****** Object:  StoredProcedure [dbo].[usp_InsertRegisterUser]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertRegisterUser]
(	
	@FullName varchar(200),
	@Designation varchar(50),
	@PAKNumber varchar(50),
	@UserName varchar(50),
	@UserPassword varchar(50),
	@IsActive bit,
	@SeniorOfficer_User_ID int,
	@UserPicture varchar(100),
	@Role_ID int,
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
	
)
as
BEGIN
BEGIN TRY
	--LoginUsers
	INSERT into LoginUsers(FullName,Designation,PAKNumber,UserName,UserPassword,IsActive,SeniorOfficer_User_ID,UserPicture)
	VALUES(@FullName,@Designation,@PAKNumber,@UserName,@UserPassword,@IsActive,@SeniorOfficer_User_ID,@UserPicture)
	 
	DECLARE @UserID INT
	SET @UserID = SCOPE_IDENTITY()

	--LoginUsersRoles
	IF(@UserID is not null)
		BEGIN
			INSERT INTO LoginUsersRoles([User_ID],Role_ID)
			VALUES(@UserID,@Role_ID)
		END

	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_InsertRolesPermission]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertRolesPermission]
(
  --@FormName VARCHAR(100),
  --@FormDisplayName VARCHAR(100),
  --@Role VARCHAR(100),
  @Form_ID INT,
  @Role_ID INT,
  --@RoleDetails VARCHAR(100),
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRANSACTION
BEGIN TRY
    
	--RolePermission
	IF(@Form_ID  is not null AND  @Role_ID is not null)
	BEGIN
	IF not Exists (select * from RolesPermission where Role_ID=@Role_ID and Form_ID =@Form_ID)
			INSERT INTO RolesPermission (Form_ID,Role_ID)
			VALUES(@Form_ID,@Role_ID)
	END
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
COMMIT TRANSACTION
End



GO
/****** Object:  StoredProcedure [dbo].[usp_RemoveCadetPermission]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_RemoveCadetPermission]
(
	@UserID INT,
	@CadetID INT,
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	--IF NOT EXISTS (SELECT TOP(1) * FROM CadetSearchPermissions)
	IF(@CadetID  is not null AND  @UserID is not null)
		BEGIN
			IF EXISTS (SELECT * FROM CadetSearchPermissions WHERE Cadet_ID = @CadetID AND [User_ID] = @UserID)
				BEGIN
					DELETE FROM CadetSearchPermissions WHERE Cadet_ID = @CadetID AND [User_ID] = @UserID
				END
		END
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_RemoveRolesPermission]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_RemoveRolesPermission]
(
  @Form_ID INT,
  @Role_ID INT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRANSACTION
BEGIN TRY
    
	--RolePermission
	IF(@Form_ID  is not null AND  @Role_ID is not null)
	BEGIN
	IF Exists(select * from RolesPermission where Role_ID=@Role_ID and Form_ID =@Form_ID)
			DELETE FROM RolesPermission Where Form_ID = @Form_ID AND Role_ID = @Role_ID
	END
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
COMMIT TRANSACTION
End



GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateAttendanceSessionHistory]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateAttendanceSessionHistory]
(
	@AttendanceSessionHistoryID int,
	@AttendanceSession_ID int,
	@AllowedCheckOUTDateTime datetime,
	@AllowedCheckINDateTime datetime,
	@Cadet_ID int, --AllowNull
	@User_ID int,
	@Role_ID int,
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	UPDATE AttendanceSessionHistory 
	SET   AttendanceSession_ID=@AttendanceSession_ID,AllowedCheckOUTDateTime=@AllowedCheckOUTDateTime,
		  @AllowedCheckINDateTime=@AllowedCheckINDateTime,Cadet_ID=@Cadet_ID,[User_ID]=@User_ID,Role_ID=@Role_ID 
	WHERE AttendanceSessionHistoryID =@AttendanceSessionHistoryID
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateCadet_with_InsertCadetHistory]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateCadet_with_InsertCadetHistory]
(
	@Cadet_ID int,
	@EntryDateTime datetime,
	@Batch varchar(20),
	@CadetName  varchar(50),
	@CadetFatherName varchar(50),
	@PAKNumber varchar(50),
	@Address varchar(200),
	@CNIC varchar(15),
	@BloodGroup varchar(12),
	@ContactNumber varchar(50),
	@MobileNumber varchar(11),
	@Picture varchar(100),
	@RFIDCardNumber varchar(25),
	@LFMD varchar(max),
	@RFMD varchar(max),
	@LThumbImage varchar(100),
	@RThumbImage varchar(100),
	@SQN_User_ID int,
	@Course_ID int,
	@Tape_ID int,
	@CreatedBy_User_ID int,
	@Role_ID int,
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRANSACTION	
	BEGIN TRY 

		--Cadets 
		UPDATE Cadets 
		SET    EntryDateTime=@EntryDateTime, Batch=@Batch, CadetName=@CadetName, CadetFatherName=@CadetFatherName, PAKNumber=@PAKNumber, [Address]=@Address, 
			   CNIC=@CNIC, BloodGroup=@BloodGroup, ContactNumber=@ContactNumber, MobileNumber=@MobileNumber, Picture=@Picture, RFIDCardNumber=@RFIDCardNumber, 
			   LFMD=@LFMD, RFMD=@RFMD, LThumbImage=@LThumbImage, RThumbImage=@RThumbImage,
			   SQN_User_ID=@SQN_User_ID, Course_ID=@Course_ID, Tape_ID=@Tape_ID, CreatedBy_User_ID=@CreatedBy_User_ID, Role_ID=@Role_ID 
		WHERE  CadetID = @Cadet_ID
			 
		--CadetsHistory
		INSERT INTO CadetsHistory (Cadet_ID,Batch,CadetName,CadetFatherName,PAKNumber,[Address],CNIC,BloodGroup,ContactNumber,MobileNumber,Picture,RFIDCardNumber,LFMD,RFMD,LThumbImage,RThumbImage,SQN_User_ID,Course_ID,Tape_ID,CreatedBy_User_ID,Role_ID)
		VALUES (@Cadet_ID,@Batch,@CadetName,@CadetFatherName,@PAKNumber,@Address,@CNIC,@BloodGroup,@ContactNumber,@MobileNumber,@Picture,@RFIDCardNumber,@LFMD,@RFMD,@LThumbImage,@RThumbImage,@SQN_User_ID,@Course_ID,@Tape_ID,@CreatedBy_User_ID,@Role_ID)
		
		SET @Status = 1
		SET @StatusDetails = 'SUCCESS'
	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
COMMIT TRANSACTION
END



GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateCadetCourses]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateCadetCourses]
(
	@CourseID int,
	@CourseName varchar(50),
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
Begin
BEGIN TRY
	UPDATE CadetCourses 
	SET    CourseName = @CourseName 
	WHERE  CourseID =@CourseID
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateCadetsHistory]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateCadetsHistory]
(
@CadetHistoryID int,
@Cadet_ID int,
@EntryDateTime datetime,
@Batch varchar(20),
@CadetName  varchar(50),
@CadetFatherName varchar(50),
@PAKNumber varchar(50),
@Address varchar(200),
@CNIC varchar(15),
@BloodGroup varchar(12),
@ContactNumber varchar(50),
@MobileNumber varchar(11),
@Picture varchar(100),
@RFIDCardNumber varchar(25),
@LFMD varchar(max),
@RFMD varchar(max),
@LThumbImage varchar(100),
@RThumbImage varchar(100),
@SQN_User_ID int,
@Course_ID int,
@Tape_ID int,
@CreatedBy_User_ID int,
@Role_ID int,
@Status BIT OUTPUT,
@StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY 
	UPDATE CadetsHistory 
	SET	   Cadet_ID=@Cadet_ID,EntryDateTime=@EntryDateTime, Batch=@Batch, CadetName=@CadetName, CadetFatherName=@CadetFatherName, PAKNumber=@PAKNumber,
		   [Address]=@Address, CNIC=@CNIC, BloodGroup=@BloodGroup, ContactNumber=@ContactNumber, MobileNumber=@MobileNumber, Picture=@Picture,
		   RFIDCardNumber=@RFIDCardNumber, LFMD=@LFMD, RFMD=@RFMD, LThumbImage=@LThumbImage, RThumbImage=@RThumbImage,
		   SQN_User_ID=@SQN_User_ID, Course_ID=@Course_ID, Tape_ID=@Tape_ID, CreatedBy_User_ID=@CreatedBy_User_ID, Role_ID=@Role_ID 
	WHERE  CadetHistoryID = @CadetHistoryID
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateCadetTapes]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateCadetTapes]
(
@TapeID int,
@TapeName varchar(50),
@Status BIT OUTPUT,
@StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY 
	UPDATE CadetTapes 
	SET	   TapeName=@TapeName 
	WHERE  TapeID = @TapeID
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateLoginRoles]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateLoginRoles]
(
	@RoleID int,
	@Role varchar(50),
	@RoleDetails varchar(50),
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
Begin
BEGIN TRY
	UPDATE LoginRoles 
	SET    [Role] = @Role,[RoleDetails]=@RoleDetails  
	WHERE  RoleID = @RoleID
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateLoginUser]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateLoginUser]
(
	@EntryDateTime datetime,
	@FullName varchar(200),
	@Designation varchar(50),
	@PAKNumber varchar(50),
	@UserName varchar(50),
	@UserPassword varchar(50),
	@IsActive bit,
	@SeniorOfficer_User_ID int,
	@UserID INT,
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
	UPDATE LoginUsers 
	SET EntryDateTime=@EntryDateTime,FullName=@FullName,Designation=@Designation,PAKNumber=@PAKNumber,UserName=@UserName,
	UserPassword=@UserPassword,IsActive=@IsActive,SeniorOfficer_User_ID=@SeniorOfficer_User_ID
	WHERE UserID = @UserID
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_UpdatePunishmentCategories]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdatePunishmentCategories]
(
	@CategoryID int,
	@CategoryName varchar(50),
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
Begin
BEGIN TRY
	UPDATE PunishmentCategories 
	SET	   CategoryName = @CategoryName  
	WHERE  CategoryID =@CategoryID
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_UpdatePunishments_with_InsertPunishmentsHistory]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdatePunishments_with_InsertPunishmentsHistory]
(
	@PunishmentID int,
	@Cadet_ID int,
	@Category_ID int,
	@Remarks varchar(1000),
	@IsSpecialWaiver bit,
	@IsPunishCompleted bit,
	@USER_ID int,
	@Role_ID int,
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRANSACTION	
	BEGIN TRY 

		--Punishments 
		UPDATE Punishments 
		SET Cadet_ID=@Cadet_ID,Category_ID=@Category_ID,[User_ID]=@USER_ID,Role_ID=@Role_ID,Remarks=@Remarks,IsSpecialWaiver=@IsSpecialWaiver,IsPunishCompleted=@IsPunishCompleted
		WHERE PunishmentID = @PunishmentID

		--SELECT p.Cadet_ID, p.Category_ID,p.Remarks,p.IsSpecialWaiver,p.IsPunishCompleted FROM Punishments p
		--PunishmentsHistory
		INSERT INTO PunishmentsHistory([Punishment_ID],Cadet_ID,Category_ID,Remarks,IsSpecialWaiver,IsPunishCompleted,[User_ID],Role_ID)
		VALUES(@PunishmentID,@Cadet_ID,@Category_ID,@Remarks,@IsSpecialWaiver,@IsPunishCompleted,@USER_ID,@Role_ID)
		
		SET @Status = 1
		SET @StatusDetails = 'SUCCESS'
	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
COMMIT TRANSACTION
END

GO
/****** Object:  StoredProcedure [dbo].[usp_UpdatePunishmentsHistory]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdatePunishmentsHistory]
(
	@PunishmentHistoryID int,
	@Punishment_ID int,
	@Cadet_ID int,
	@Category_ID int,
	@Remarks varchar(1000),
	@IsSpecialWaiver bit,
	@IsPunishCompleted bit,
	@User_ID int,
	@Role_ID int,
	@Status BIT OUTPUT,
	@StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
 BEGIN TRY
	UPDATE PunishmentsHistory 
	SET    Punishment_ID=@Punishment_ID, Cadet_ID=@Cadet_ID,Category_ID=@Category_ID,Remarks=@Remarks,IsSpecialWaiver=@IsSpecialWaiver,IsPunishCompleted=@IsPunishCompleted
	WHERE  PunishmentHistoryID = @PunishmentHistoryID
	 
	SET @Status = 1
	SET @StatusDetails = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_UsersLogin_With_Roles]    Script Date: 2020-05-01 10:54:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UsersLogin_With_Roles]
(
  @uName VARCHAR(50),
  @uPassword VARCHAR(50),
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY 

IF EXISTS(SELECT * FROM LoginUsers WHERE UserName=@uName AND UserPassword=@uPassword) 
	BEGIN
		SELECT u.[UserID], u.UserName,u.UserPassword ,r.RoleID,r.[Role] FROM LoginUsersRoles ur 
		INNER JOIN LoginUsers u ON u.UserID = ur.[User_ID]
		INNER JOIN LoginRoles r ON r.RoleID = ur.Role_ID
		WHERE  u.UserName = @uName AND u.UserPassword = @uPassword

		SET @Status = 1
		SET @StatusDetails = 'SUCCESS'
	END
ELSE
	BEGIN
		SET @Status = 0
		SET @StatusDetails = 'Authentication Failed !!!'
	END
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
USE [master]
GO
ALTER DATABASE [AAA_PAF_BOS] SET  READ_WRITE 
GO
