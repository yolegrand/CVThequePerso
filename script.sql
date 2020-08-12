USE [master]
GO
/****** Object:  Database [CVThequeCore]    Script Date: 29-07-20 11:07:37 ******/
CREATE DATABASE [CVThequeCore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CVThequeCore', FILENAME = N'C:\Users\jevra\CVThequeCore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CVThequeCore_log', FILENAME = N'C:\Users\jevra\CVThequeCore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CVThequeCore] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CVThequeCore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CVThequeCore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CVThequeCore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CVThequeCore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CVThequeCore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CVThequeCore] SET ARITHABORT OFF 
GO
ALTER DATABASE [CVThequeCore] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CVThequeCore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CVThequeCore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CVThequeCore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CVThequeCore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CVThequeCore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CVThequeCore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CVThequeCore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CVThequeCore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CVThequeCore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CVThequeCore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CVThequeCore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CVThequeCore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CVThequeCore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CVThequeCore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CVThequeCore] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [CVThequeCore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CVThequeCore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CVThequeCore] SET  MULTI_USER 
GO
ALTER DATABASE [CVThequeCore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CVThequeCore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CVThequeCore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CVThequeCore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CVThequeCore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CVThequeCore] SET QUERY_STORE = OFF
GO
USE [CVThequeCore]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [CVThequeCore]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 29-07-20 11:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LanguageLevel]    Script Date: 29-07-20 11:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LanguageLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_LanguageLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Level]    Script Date: 29-07-20 11:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Level](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Level] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 29-07-20 11:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[LoginByUsernamePassword]    Script Date: 29-07-20 11:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      <Author,,Asma Khalid>  
-- Create date: <Create Date,,15-Mar-2016>  
-- Description: <Description,,You are Allow to Distribute this Code>  
-- =============================================  
CREATE PROCEDURE [dbo].[LoginByUsernamePassword]   
    @username varchar(50),  
    @password varchar(50)  
AS  
BEGIN  
    SELECT id, username, password  
    FROM Login  
    WHERE username = @username  
    AND password = @password  
END  
  
GO
USE [master]
GO
ALTER DATABASE [CVThequeCore] SET  READ_WRITE 
GO
