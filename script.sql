USE [master]
GO
/****** Object:  Database [CVTheque]    Script Date: 16-07-20 16:09:46 ******/
CREATE DATABASE [CVTheque]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CVTheque', FILENAME = N'C:\Users\jevra\CVTheque.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CVTheque_log', FILENAME = N'C:\Users\jevra\CVTheque_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CVTheque] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CVTheque].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CVTheque] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CVTheque] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CVTheque] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CVTheque] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CVTheque] SET ARITHABORT OFF 
GO
ALTER DATABASE [CVTheque] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CVTheque] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CVTheque] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CVTheque] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CVTheque] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CVTheque] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CVTheque] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CVTheque] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CVTheque] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CVTheque] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CVTheque] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CVTheque] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CVTheque] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CVTheque] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CVTheque] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CVTheque] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CVTheque] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CVTheque] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CVTheque] SET  MULTI_USER 
GO
ALTER DATABASE [CVTheque] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CVTheque] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CVTheque] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CVTheque] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CVTheque] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CVTheque] SET QUERY_STORE = OFF
GO
USE [CVTheque]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [CVTheque]
GO
/****** Object:  UserDefinedFunction [dbo].[SP_HashPassword]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[SP_HashPassword]
(
	@Password NVARCHAR(64)
)
RETURNS VARBINARY(32)
AS
BEGIN
DECLARE @PasswordWithNoise NVARCHAR(MAX)
SET @PasswordWithNoise = 'Salut'+@Password+'les amis!'
RETURN HASHBYTES('SHA2_256',@PasswordWithNoise)
END
GO
/****** Object:  Table [dbo].[City]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Zip] [int] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_City] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Zip] UNIQUE NONCLUSTERED 
(
	[Zip] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[Contact] [nvarchar](50) NOT NULL,
	[SectorId] [int] NOT NULL,
	[SocietyId] [int] NOT NULL,
	[City] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Client] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Education]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Education](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BeginDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[EducationLevel] [int] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Education] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EducationLevel]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EducationLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_EducationLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_EducationLevel] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Experience]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Experience](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BeginDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[ClientId] [int] NOT NULL,
	[IsDelete] [bit] NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Experience] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExperienceFunction]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExperienceFunction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExperienceId] [int] NOT NULL,
	[FunctionId] [int] NOT NULL,
 CONSTRAINT [PK_ExperienceFunction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExperienceKnowledge]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExperienceKnowledge](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExperienceId] [int] NOT NULL,
	[KnowledgeId] [int] NOT NULL,
 CONSTRAINT [PK_ExperienceKnowledge] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExperienceProgram]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExperienceProgram](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExperienceId] [int] NOT NULL,
	[ProgramId] [int] NOT NULL,
 CONSTRAINT [PK_ExperienceProgram] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Functions]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Functions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Functions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Functions] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Knowledge]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Knowledge](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[KnowledgeTypeId] [int] NOT NULL,
	[IsDelete] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Knowledge] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Knowledge] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KnowledgeType]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KnowledgeType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_KnowledgeType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_KnowledgeType] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Language] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LanguageLevel]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LanguageLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_LanguageLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_LanguageLevel] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Level]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Level](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Level] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Level] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nationality]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nationality](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Nationality] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Program]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Program](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ProgramTypeId] [int] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Program] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Program] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgramType]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_ProgramType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_ProgramType] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prospect]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prospect](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[Contact] [nvarchar](50) NOT NULL,
	[SectorId] [int] NOT NULL,
	[SocietyId] [int] NOT NULL,
	[City] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Prospect] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Prospect] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Roles] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sector]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sector](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Sector] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Sector] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Society]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Society](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[Contact] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Logo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Society] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Society] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserKnowledge]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserKnowledge](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[KnowledgeId] [int] NOT NULL,
	[LevelId] [int] NOT NULL,
 CONSTRAINT [PK_UserKnowledge] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLanguage]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLanguage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[LanguageId] [int] NOT NULL,
	[LanguageLevelId] [int] NOT NULL,
 CONSTRAINT [PK_UserLanguage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserNationality]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserNationality](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[NationalityId] [int] NOT NULL,
 CONSTRAINT [PK_UserNationality] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProgram]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProgram](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ProgramId] [int] NOT NULL,
	[LevelId] [int] NOT NULL,
 CONSTRAINT [PK_UserProgramId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[PersonalMail] [nvarchar](50) NOT NULL,
	[Phone] [int] NOT NULL,
	[PersonalPhone] [int] NOT NULL,
	[Street] [nvarchar](50) NOT NULL,
	[Number] [int] NOT NULL,
	[Box] [int] NULL,
	[Zip] [int] NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Licence] [bit] NOT NULL,
	[SocietyId] [int] NOT NULL,
	[PublicTransport] [bit] NOT NULL,
	[IsDelete] [bit] NULL,
	[Pass] [varbinary](32) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Mail] UNIQUE NONCLUSTERED 
(
	[Mail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_PersonalMail] UNIQUE NONCLUSTERED 
(
	[PersonalMail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_PersonalPhone] UNIQUE NONCLUSTERED 
(
	[PersonalPhone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_SectorID] FOREIGN KEY([SectorId])
REFERENCES [dbo].[Sector] ([Id])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_SectorID]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_SOcietyID] FOREIGN KEY([SocietyId])
REFERENCES [dbo].[Society] ([Id])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_SOcietyID]
GO
ALTER TABLE [dbo].[Education]  WITH NOCHECK ADD  CONSTRAINT [FK_UserID] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Education] CHECK CONSTRAINT [FK_UserID]
GO
ALTER TABLE [dbo].[Experience]  WITH CHECK ADD  CONSTRAINT [FK_ClientID] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Experience] CHECK CONSTRAINT [FK_ClientID]
GO
ALTER TABLE [dbo].[Experience]  WITH CHECK ADD  CONSTRAINT [FK_ExperienceUserID] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Experience] CHECK CONSTRAINT [FK_ExperienceUserID]
GO
ALTER TABLE [dbo].[ExperienceFunction]  WITH CHECK ADD  CONSTRAINT [FK_ExperienceFunctionId] FOREIGN KEY([FunctionId])
REFERENCES [dbo].[Functions] ([Id])
GO
ALTER TABLE [dbo].[ExperienceFunction] CHECK CONSTRAINT [FK_ExperienceFunctionId]
GO
ALTER TABLE [dbo].[ExperienceFunction]  WITH CHECK ADD  CONSTRAINT [FK_FunctionExperienceId] FOREIGN KEY([ExperienceId])
REFERENCES [dbo].[Experience] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExperienceFunction] CHECK CONSTRAINT [FK_FunctionExperienceId]
GO
ALTER TABLE [dbo].[ExperienceKnowledge]  WITH CHECK ADD  CONSTRAINT [FK_ExperienceKnowledgeId] FOREIGN KEY([KnowledgeId])
REFERENCES [dbo].[Knowledge] ([Id])
GO
ALTER TABLE [dbo].[ExperienceKnowledge] CHECK CONSTRAINT [FK_ExperienceKnowledgeId]
GO
ALTER TABLE [dbo].[ExperienceKnowledge]  WITH CHECK ADD  CONSTRAINT [FK_KnowledgeExperienceId] FOREIGN KEY([ExperienceId])
REFERENCES [dbo].[Experience] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExperienceKnowledge] CHECK CONSTRAINT [FK_KnowledgeExperienceId]
GO
ALTER TABLE [dbo].[ExperienceProgram]  WITH CHECK ADD  CONSTRAINT [FK_ExperienceProgramId] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[Program] ([Id])
GO
ALTER TABLE [dbo].[ExperienceProgram] CHECK CONSTRAINT [FK_ExperienceProgramId]
GO
ALTER TABLE [dbo].[ExperienceProgram]  WITH CHECK ADD  CONSTRAINT [FK_ProgramExperienceId] FOREIGN KEY([ExperienceId])
REFERENCES [dbo].[Experience] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExperienceProgram] CHECK CONSTRAINT [FK_ProgramExperienceId]
GO
ALTER TABLE [dbo].[Prospect]  WITH CHECK ADD  CONSTRAINT [FK_SectorID] FOREIGN KEY([SectorId])
REFERENCES [dbo].[Sector] ([Id])
GO
ALTER TABLE [dbo].[Prospect] CHECK CONSTRAINT [FK_SectorID]
GO
ALTER TABLE [dbo].[Prospect]  WITH CHECK ADD  CONSTRAINT [FK_SOcietyID] FOREIGN KEY([SocietyId])
REFERENCES [dbo].[Society] ([Id])
GO
ALTER TABLE [dbo].[Prospect] CHECK CONSTRAINT [FK_SOcietyID]
GO
ALTER TABLE [dbo].[UserKnowledge]  WITH CHECK ADD  CONSTRAINT [FK_KnowledgeId] FOREIGN KEY([KnowledgeId])
REFERENCES [dbo].[Knowledge] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserKnowledge] CHECK CONSTRAINT [FK_KnowledgeId]
GO
ALTER TABLE [dbo].[UserKnowledge]  WITH CHECK ADD  CONSTRAINT [FK_KnowledgeLevelId] FOREIGN KEY([LevelId])
REFERENCES [dbo].[Level] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserKnowledge] CHECK CONSTRAINT [FK_KnowledgeLevelId]
GO
ALTER TABLE [dbo].[UserKnowledge]  WITH CHECK ADD  CONSTRAINT [FK_UserKnowledge_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserKnowledge] CHECK CONSTRAINT [FK_UserKnowledge_UserId]
GO
ALTER TABLE [dbo].[UserLanguage]  WITH CHECK ADD  CONSTRAINT [FK_Language_LevelId] FOREIGN KEY([LanguageLevelId])
REFERENCES [dbo].[LanguageLevel] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLanguage] CHECK CONSTRAINT [FK_Language_LevelId]
GO
ALTER TABLE [dbo].[UserLanguage]  WITH CHECK ADD  CONSTRAINT [FK_LanguageId] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLanguage] CHECK CONSTRAINT [FK_LanguageId]
GO
ALTER TABLE [dbo].[UserLanguage]  WITH CHECK ADD  CONSTRAINT [FK_UserLanguage_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLanguage] CHECK CONSTRAINT [FK_UserLanguage_UserId]
GO
ALTER TABLE [dbo].[UserNationality]  WITH CHECK ADD  CONSTRAINT [FK_NationalityId] FOREIGN KEY([NationalityId])
REFERENCES [dbo].[Nationality] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserNationality] CHECK CONSTRAINT [FK_NationalityId]
GO
ALTER TABLE [dbo].[UserNationality]  WITH CHECK ADD  CONSTRAINT [FK_UserNationality_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserNationality] CHECK CONSTRAINT [FK_UserNationality_UserId]
GO
ALTER TABLE [dbo].[UserProgram]  WITH CHECK ADD  CONSTRAINT [FK_ProgramId] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[Program] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserProgram] CHECK CONSTRAINT [FK_ProgramId]
GO
ALTER TABLE [dbo].[UserProgram]  WITH CHECK ADD  CONSTRAINT [FK_ProgramLevelId] FOREIGN KEY([LevelId])
REFERENCES [dbo].[Level] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserProgram] CHECK CONSTRAINT [FK_ProgramLevelId]
GO
ALTER TABLE [dbo].[UserProgram]  WITH CHECK ADD  CONSTRAINT [FK_UserProgram_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserProgram] CHECK CONSTRAINT [FK_UserProgram_UserId]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_Role_RoleId]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_Role_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_Role_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_User_SocietyID] FOREIGN KEY([SocietyId])
REFERENCES [dbo].[Society] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_User_SocietyID]
GO
/****** Object:  StoredProcedure [dbo].[Add_SP_KnowledgeType]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_SP_KnowledgeType]
	@Name NVARCHAR(50),
	@IsDelete Bit
AS
	INSERT INTO KnowledgeType([Name], [IsDelete]) VALUES (@Name, @IsDelete)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[Add_SP_ProgramType]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_SP_ProgramType]
	@Name NVARCHAR(50),
	@IsDelete BIT
AS
	INSERT INTO ProgramType([Name], [IsDelete]) VALUES (@Name, @IsDelete)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_City]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_City]
	@Name NVARCHAR(50),
	@Zip int,
	@IsDelete Bit
AS
	INSERT INTO City ([Name], [IsDelete], [Zip]) VALUES (@Name,@IsDelete,@Zip)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Client]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_Client]
	@Name NVARCHAR(50),
	@Contact NVARCHAR,
	@City int,
	@SectorId int,
	@SocietyId INT,
	@IsDelete Bit
AS
	INSERT INTO Client ([Name], [IsDelete], [City], [Contact], [SectorId], [SocietyId]) VALUES (@Name,@IsDelete,(select City.Name from City where City.Id = @City), @Contact,@SectorId,@SocietyId)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_DevelopperEducation]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_DevelopperEducation]
	@BeginDate DateTime,
	@EndDate DateTime,
	@Name NVARCHAR(50),
	@EducationLevel INT
AS
	INSERT INTO Education (BeginDate, EndDate, Name, UserId, EducationLevel, IsDelete) VALUES (@BeginDate,@EndDate,@Name,
	(select top 1 u.Id from Users u order by u.Id Desc),@EducationLevel, 0)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_DevelopperExperience]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_DevelopperExperience]
	@BeginDate DateTime,
	@EndDate DateTime,
	@Description NVARCHAR(50),
	@ClientId INT,
	@FunctionId int,
	@KnowledgeId int,
	@UserId int
AS
	INSERT INTO Experience(BeginDate, EndDate, Description, UserId, ClientId, IsDelete) VALUES (@BeginDate,@EndDate,@Description,
	@UserId,@ClientId, 0)

	SELECT @@IDENTITY AS 'Identity'

	INSERT INTO ExperienceFunction (ExperienceId, FunctionId) values (@@IDENTITY, @FunctionId)

	INSERT INTO ExperienceKnowledge (ExperienceId, KnowledgeId) values ((select top 1 e.Id from Experience e order by e.Id Desc), @KnowledgeId)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Education]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_Education]
	@BeginDate DateTime,
	@EndDate DateTime,
	@Name NVARCHAR(50),
	@UserId int,
	@EducationLevel INT,
	@IsDelete BIT
AS
	INSERT INTO Education (BeginDate, EndDate, Name, UserId, EducationLevel, IsDelete) VALUES (@BeginDate,@EndDate,@Name,@UserId,@EducationLevel,@IsDelete)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_EducationLevel]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_EducationLevel]
	@Name NVARCHAR(50),
	@IsDelete Bit
AS
	INSERT INTO EducationLevel ([Name], [IsDelete]) VALUES (@Name,@IsDelete)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Experience]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_Experience]
	@BeginDate DateTime,
	@EndDate DateTime,
	@Description NVARCHAR(50),
	@ClientId int,
	@IsDelete BIT
AS
	INSERT INTO Experience (BeginDate, EndDate, Description, ClientId, IsDelete) VALUES (@BeginDate,@EndDate,@Description,@ClientId,@IsDelete)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Function]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_Function]
	@Name NVARCHAR(50),
	@IsDelete Bit
AS
	INSERT INTO Functions ([Name], [IsDelete]) VALUES (@Name,@IsDelete)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Knowledge]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_Knowledge]
	@Name NVARCHAR(50),
	@KnowledgeTypeId int,
	@IsDelete Bit
AS
	INSERT INTO Knowledge([Name], [KnowledgeTypeId], [IsDelete]) VALUES (@Name,@KnowledgeTypeId,@IsDelete)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Language]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_Language]
	@Name NVARCHAR(50),
	@IsDelete Bit
AS
	INSERT INTO Language ([Name], [IsDelete]) VALUES (@Name,@IsDelete)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_LanguageLevel]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_LanguageLevel]
	@Name NVARCHAR(50),
	@IsDelete Bit
AS
	INSERT INTO LanguageLevel(Name, IsDelete) VALUES (@Name,@IsDelete)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Level]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_Level]
	@Name NVARCHAR(50),
	@IsDelete Bit
AS
	INSERT INTO dbo.Level([Name], [IsDelete]) VALUES (@Name,@IsDelete)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Nationality]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_Nationality]
	@Name NVARCHAR(50),
	@IsDelete Bit
AS
	INSERT INTO Nationality([Name], [IsDelete]) VALUES (@Name,@IsDelete)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Program]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_Program]
	@Name NVARCHAR(50),
	@ProgramTypeId INT,
	@IsDelete Bit
AS
	INSERT INTO Program ([Name], [IsDelete], ProgramTypeId) VALUES (@Name,@IsDelete,@ProgramTypeId)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Prospect]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_Prospect]
	@Name NVARCHAR(50),
	@Contact NVARCHAR(50),
	@City NVARCHAR(50),
	@SectorId int,
	@SocietyId INT,
	@IsDelete Bit
AS
	INSERT INTO Prospect ([Name], [IsDelete], [City], [Contact], [SectorId], [SocietyId]) VALUES (@Name,@IsDelete,@City,@Contact,@SectorId,@SocietyId)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Role]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_Role]
	@Name NVARCHAR(50),
	@IsDelete Bit
AS
	INSERT INTO dbo.Roles([Name], [IsDelete]) VALUES (@Name,@IsDelete)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_School]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_School]
	@Name NVARCHAR(50),
	@IsDelete Bit
AS
	INSERT INTO dbo.School([Name], [IsDelete]) VALUES (@Name,@IsDelete)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Sector]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_Sector]
	@Name NVARCHAR(50),
	@IsDelete Bit
AS
	INSERT INTO Sector ([Name], [IsDelete]) VALUES (@Name,@IsDelete)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Society]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_Society]
	@Name NVARCHAR(50),
	@IsDelete Bit,
	@Contact NVARCHAR(50),
	@Logo NVARCHAR(50),
	@City NVARCHAR(50)
AS
	INSERT INTO Society ([Name], [IsDelete],  [City], [Contact], [Logo]) VALUES (@Name,@IsDelete,@City,@Contact,@Logo)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_User]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_User]
	@pass NVARCHAR(64)
AS
	INSERT INTO Users(Pass) values (dbo.SP_HashPassword(@pass))
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_UserKnowledge]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_UserKnowledge]
	@UserId int,
	@KnowledgeId int,
	@LevelId Bit
AS
	INSERT INTO UserKnowledge (LevelId, KnowledgeId, UserId) VALUES (@LevelId,@KnowledgeId,@UserId)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_UserLanguage]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_UserLanguage]
	@UserId int,
	@LanguageId int,
	@LanguageLevelId Bit
AS
	INSERT INTO UserLanguage (LanguageLevelId, LanguageId, UserId) VALUES (@LanguageLevelId,@LanguageId,@UserId)
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_UserProgram]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add_UserProgram]
	@UserId int,
	@ProgramId int,
	@LevelId Bit
AS
	INSERT INTO UserProgram (LevelId, ProgramId, UserId) VALUES (@LevelId,@ProgramId,@UserId)
GO
/****** Object:  StoredProcedure [dbo].[SP_Authentification]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Authentification]
	@Mail NVARCHAR(50),
	@Password NVARCHAR(32)
AS
Begin
	select u.Mail, u.Pass, u.FirstName, u.LastName from Users u where Mail = @Mail and Pass = dbo.SP_HashPassword(@Password);
End
GO
/****** Object:  StoredProcedure [dbo].[SP_CheckUser]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CheckUser]
	@Mail NVARCHAR(50),
	@Password NVARCHAR(32)
AS
Begin
	select u.Id, u.Mail, u.Pass, u.FirstName, u.LastName, u.SocietyId, r.Name as role from Users u join UserRole ur on u.Id = ur.UserId join Roles r on ur.RoleId = r.Id where Mail = @Mail and Pass = dbo.SP_HashPassword(@Password);
End
GO
/****** Object:  StoredProcedure [dbo].[SP_Create_CV]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Create_CV]
	@Firstname NVARCHAR(50),
	@Lastname  NVARCHAR(50),
	@Street NVARCHAR(50),
	@Number int,
	@City int,
	@PersonalPhone int,
	@PersonalMail NVARCHAR(50),
	@Phone int,
	@Mail NVARCHAR(50),
	@Zip int,
	@Box int,
	@Licence Bit,
	@PublicTransport Bit,
	@SocietyId int,
	@Nationality int
	/*@EducationBeginDate DateTime,
	@EducationEndDate DateTime,
	@Education NVARCHAR(50),
	@EducationLevel INT,
	@ExperienceBeginDate DateTime,
	@ExperienceEndDate DateTime,
	@Description NVARCHAR(50),
	@ClientId INT,
	@ProgramLevelId int,
	@ProgramId int,
	@KnowledgeId int,
	@KnowledgeLevelId int,
	@LanguageLevelId int,
	@LanguageId int,
	@FunctionId int*/
AS
	INSERT INTO Users (Mail, Phone, FirstName, LastName, Street, Number, City, PersonalPhone, PersonalMail, [Zip], Box, Licence, PublicTransport, SocietyId, IsDelete, Pass) 
	VALUES (@Mail, @Phone, @Firstname,@Lastname,@Street,@Number,(select City.Name from City where City.Id like @City),@PersonalPhone,@PersonalMail,@Zip,@Box,@Licence,@PublicTransport,@SocietyId, 0,dbo.SP_HashPassword('Provisoire'))
	SELECT @@IDENTITY AS 'Identity'


	INSERT INTO UserRole (UserId,RoleId) values (@@IDENTITY,(select Roles.Id from Roles where Roles.Name like 'Developper'))

	INSERT INTO UserNationality (NationalityId, UserId) values (@Nationality, (select top 1 u.Id from Users u order by u.Id Desc))

	/*INSERT INTO UserProgram (LevelId, ProgramId, UserId) values (@ProgramLevelId,@ProgramId,(select top 1 u.Id from Users u order by u.Id Desc))

	INSERT INTO UserKnowledge (LevelId, KnowledgeId, UserId) values (@KnowledgeLevelId,@KnowledgeId,(select top 1 u.Id from Users u order by u.Id Desc))

	INSERT INTO UserLanguage (LanguageId, LanguageLevelId, UserId) values (@LanguageId, @LanguageLevelId,(select top 1 u.Id from Users u order by u.Id Desc))
	
	INSERT INTO Education (BeginDate, EndDate, Name, UserId, EducationLevel, IsDelete) VALUES (@EducationBeginDate,@EducationEndDate,@Education,
	(select top 1 u.Id from Users u order by u.Id Desc),@EducationLevel, 0)

	INSERT INTO Experience(BeginDate, EndDate, Description, UserId, ClientId, IsDelete) VALUES (@ExperienceBeginDate,@ExperienceEndDate,@Description,
	(select top 1 u.Id from Users u order by u.Id Desc),@ClientId, 0)
	SELECT @@IDENTITY AS 'Identity'

	INSERT INTO ExperienceFunction (ExperienceId, FunctionId) values (@@IDENTITY, @FunctionId)

	INSERT INTO ExperienceKnowledge (ExperienceId, KnowledgeId) values ((select top 1 e.Id from Experience e order by e.Id Desc), @KnowledgeId)
	*/
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_City]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_City]
	@Id int,
	@Name NVARCHAR(50),
	@Zip INT,
	@IsDelete Bit
AS
	UPDATE City set Name = @Name, IsDelete = IsDelete, Zip = @Zip where Id = @Id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Client]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Client]
	@Id int,
	@Name NVARCHAR(50),
	@Contact NVARCHAR(50),
	@City int,
	@SectorId int,
	@SocietyId INT,
	@IsDelete Bit
AS
	UPDATE Client set Name = @Name, IsDelete = IsDelete, Contact = @Contact, City = (select City.Name from City where City.Id = @City) where Id = @Id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Education]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Education]
	@Id int,
	@BeginDate DateTime,
	@EndDate DateTime,
	@Name NVARCHAR(50),
	@UserId int,
	@EducationLevel INT,
	@IsDelete BIT
AS
	UPDATE Education set BeginDate = @BeginDate, EndDate = @EndDate, Name = @Name, UserId = @UserId, EducationLevel = @EducationLevel, IsDelete = IsDelete where Id = @Id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_EducationLevel]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_EducationLevel]
	@Id int,
	@Name NVARCHAR(50),
	@IsDelete Bit
AS
	UPDATE EducationLevel set Name = @Name, IsDelete = IsDelete where Id = @Id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Experience]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Experience]
	@Id int,
	@BeginDate DateTime,
	@EndDate DateTime,
	@Description NVARCHAR(50),
	@ClientId int,
	@IsDelete BIT
AS
	UPDATE Experience set BeginDate = @BeginDate, EndDate = @EndDate, Description = @Description, ClientId = @ClientId, IsDelete = IsDelete where Id = @Id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Function]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Function]
	@Id int,
	@Name NVARCHAR(50),
	@IsDelete Bit
AS
	UPDATE Functions set Name = @Name, IsDelete = IsDelete where Id = @Id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Knowledge]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Knowledge]
	@Id int,
	@Name NVARCHAR(50),
	@KnowledgeTypeId int,
	@IsDelete Bit
AS
	UPDATE Knowledge set Name = @Name, KnowledgeTypeId = @KnowledgeTypeId, IsDelete = IsDelete where Id = @Id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_KnowledgeType]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_KnowledgeType]
	@Id int,
	@Name NVARCHAR(50),
	@IsDelete BIT
AS
	UPDATE KnowledgeType set Name = @Name, IsDelete = @IsDelete where Id = @Id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Language]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Language]
	@Id int,
	@Name NVARCHAR(50),
	@IsDelete Bit
AS
	UPDATE Language set Name = @Name, IsDelete = IsDelete where Id = @Id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_LanguageLevel]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_LanguageLevel]
	@Id int,
	@Name NVARCHAR(50),
	@IsDelete Bit
AS
	UPDATE LanguageLevel set Name = @Name, IsDelete = @IsDelete where Id = @Id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Level]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Level]
	@Id int,
	@Name NVARCHAR(50),
	@IsDelete Bit
AS
	UPDATE Level set Name = @Name, IsDelete = IsDelete where Id = @Id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Nationality]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Nationality]
	@Id int,
	@Name NVARCHAR(50),
	@IsDelete Bit
AS
	UPDATE Nationality set Name = @Name, IsDelete = IsDelete where Id = @Id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Program]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Program]
	@Id int,
	@Name NVARCHAR(50),
	@ProgramTypeId INT,
	@IsDelete Bit
AS
	UPDATE Program set Name = @Name, ProgramTypeId = @ProgramTypeId, IsDelete = IsDelete where Id = @Id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_ProgramType]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_ProgramType]
	@Id int,
	@Name NVARCHAR(50),
	@IsDelete BIT
AS
	UPDATE ProgramType set Name = @Name, IsDelete = @IsDelete where Id = @Id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Prospect]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Prospect]
	@Id int,
	@Name NVARCHAR(50),
	@Contact NVARCHAR(50),
	@City NVARCHAR(50),
	@SectorId int,
	@SocietyId INT,
	@IsDelete Bit
AS
	UPDATE Prospect set Name = @Name, Contact = @Contact, City = @City, SectorId = @SectorId, SocietyId = @SocietyId, IsDelete = IsDelete where Id = @Id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Role]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Role]
	@Id int,
	@Name NVARCHAR(50),
	@IsDelete Bit
AS
	UPDATE Roles set Name = @Name, IsDelete = IsDelete where Id = @Id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Sector]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Sector]
	@Id int,
	@Name NVARCHAR(50),
	@IsDelete Bit
AS
	UPDATE Sector set Name = @Name, IsDelete = IsDelete where Id = @Id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Society]    Script Date: 16-07-20 16:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Society]
	@Id int,
	@Name NVARCHAR(50),
	@IsDelete Bit,
	@Contact NVARCHAR(50),
	@Logo NVARCHAR(50),
	@City NVARCHAR(50)
AS
	UPDATE Society set Name = @Name, IsDelete = IsDelete, Contact = @Contact, City = @City, Logo = @Logo where Id = @Id
RETURN 0
GO
USE [master]
GO
ALTER DATABASE [CVTheque] SET  READ_WRITE 
GO
