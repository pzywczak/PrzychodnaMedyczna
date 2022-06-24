USE [master]
GO
/****** Object:  Database [PrzychodniaLekarska]    Script Date: 24.06.2022 09:21:26 ******/
CREATE DATABASE [PrzychodniaLekarska]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'strConn', FILENAME = N'C:\Users\Piotr\PrzychodniaLekarska.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'strConn_log', FILENAME = N'C:\Users\Piotr\PrzychodniaLekarska_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PrzychodniaLekarska] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PrzychodniaLekarska].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PrzychodniaLekarska] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PrzychodniaLekarska] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PrzychodniaLekarska] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PrzychodniaLekarska] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PrzychodniaLekarska] SET ARITHABORT OFF 
GO
ALTER DATABASE [PrzychodniaLekarska] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PrzychodniaLekarska] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PrzychodniaLekarska] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PrzychodniaLekarska] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PrzychodniaLekarska] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PrzychodniaLekarska] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PrzychodniaLekarska] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PrzychodniaLekarska] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PrzychodniaLekarska] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PrzychodniaLekarska] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PrzychodniaLekarska] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PrzychodniaLekarska] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PrzychodniaLekarska] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PrzychodniaLekarska] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PrzychodniaLekarska] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PrzychodniaLekarska] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [PrzychodniaLekarska] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PrzychodniaLekarska] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PrzychodniaLekarska] SET  MULTI_USER 
GO
ALTER DATABASE [PrzychodniaLekarska] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PrzychodniaLekarska] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PrzychodniaLekarska] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PrzychodniaLekarska] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PrzychodniaLekarska] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PrzychodniaLekarska] SET QUERY_STORE = OFF
GO
USE [PrzychodniaLekarska]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [PrzychodniaLekarska]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 24.06.2022 09:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lekarze]    Script Date: 24.06.2022 09:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lekarze](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImieINazwisko] [nvarchar](max) NULL,
	[Adres] [nvarchar](max) NULL,
	[Specjalizacja] [nvarchar](max) NULL,
	[USERID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Medicos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacjenci]    Script Date: 24.06.2022 09:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacjenci](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImieINazwisko] [nvarchar](max) NULL,
	[Adres] [nvarchar](max) NULL,
	[Telefon] [nvarchar](max) NULL,
	[USERID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Pacientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uzytkownicy]    Script Date: 24.06.2022 09:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uzytkownicy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](max) NULL,
	[Haslo] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wizyty]    Script Date: 24.06.2022 09:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wizyty](
	[Id] [int] NOT NULL,
	[Data] [nvarchar](max) NULL,
	[Godzina] [nvarchar](max) NULL,
	[TypWizyty] [nvarchar](max) NULL,
	[CzyOdbyta] [nvarchar](max) NULL,
	[Id_pacjenta] [int] NULL,
	[Id_lekarza] [int] NULL,
 CONSTRAINT [PK_Wizyty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioId]    Script Date: 24.06.2022 09:21:26 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioId] ON [dbo].[Lekarze]
(
	[USERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioId]    Script Date: 24.06.2022 09:21:26 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioId] ON [dbo].[Pacjenci]
(
	[USERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Lekarze]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Medicos_dbo.Usuarios_UsuarioId] FOREIGN KEY([USERID])
REFERENCES [dbo].[Uzytkownicy] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lekarze] CHECK CONSTRAINT [FK_dbo.Medicos_dbo.Usuarios_UsuarioId]
GO
ALTER TABLE [dbo].[Pacjenci]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Pacientes_dbo.Usuarios_UsuarioId] FOREIGN KEY([USERID])
REFERENCES [dbo].[Uzytkownicy] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pacjenci] CHECK CONSTRAINT [FK_dbo.Pacientes_dbo.Usuarios_UsuarioId]
GO
USE [master]
GO
ALTER DATABASE [PrzychodniaLekarska] SET  READ_WRITE 
GO
