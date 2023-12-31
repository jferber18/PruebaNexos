USE [master]
GO
/****** Object:  Database [PruebaNexos]    Script Date: 14/08/2023 2:49:40 ******/
CREATE DATABASE [PruebaNexos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PruebaNexos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PruebaNexos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PruebaNexos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PruebaNexos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PruebaNexos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PruebaNexos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PruebaNexos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PruebaNexos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PruebaNexos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PruebaNexos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PruebaNexos] SET ARITHABORT OFF 
GO
ALTER DATABASE [PruebaNexos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PruebaNexos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PruebaNexos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PruebaNexos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PruebaNexos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PruebaNexos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PruebaNexos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PruebaNexos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PruebaNexos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PruebaNexos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PruebaNexos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PruebaNexos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PruebaNexos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PruebaNexos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PruebaNexos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PruebaNexos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PruebaNexos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PruebaNexos] SET RECOVERY FULL 
GO
ALTER DATABASE [PruebaNexos] SET  MULTI_USER 
GO
ALTER DATABASE [PruebaNexos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PruebaNexos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PruebaNexos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PruebaNexos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PruebaNexos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PruebaNexos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PruebaNexos] SET QUERY_STORE = OFF
GO
USE [PruebaNexos]
GO
/****** Object:  Table [dbo].[TblAutoresLibros]    Script Date: 14/08/2023 2:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblAutoresLibros](
	[IdAutorLibro] [int] IDENTITY(1,1) NOT NULL,
	[IdLibro] [int] NOT NULL,
	[Nombres] [varchar](500) NOT NULL,
	[Apellidos] [varchar](500) NOT NULL,
	[CiudadProcedencia] [varchar](20) NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[FechaCreación] [datetime] NOT NULL,
 CONSTRAINT [PK_TblAutoresLibros] PRIMARY KEY CLUSTERED 
(
	[IdAutorLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblConfigLimit]    Script Date: 14/08/2023 2:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblConfigLimit](
	[IdConfig] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionConfig] [varchar](200) NOT NULL,
	[Limite] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_TblConfigLimit] PRIMARY KEY CLUSTERED 
(
	[IdConfig] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblGeneros]    Script Date: 14/08/2023 2:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblGeneros](
	[IdGenero] [int] IDENTITY(1,1) NOT NULL,
	[NombreGenero] [varchar](200) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_TblGeneros] PRIMARY KEY CLUSTERED 
(
	[IdGenero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblLibros]    Script Date: 14/08/2023 2:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblLibros](
	[IdLibro] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](max) NOT NULL,
	[Año] [int] NOT NULL,
	[IdGenero] [int] NOT NULL,
	[NumeroPaginas] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_TblLibros] PRIMARY KEY CLUSTERED 
(
	[IdLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblAutoresLibros] ON 

INSERT [dbo].[TblAutoresLibros] ([IdAutorLibro], [IdLibro], [Nombres], [Apellidos], [CiudadProcedencia], [FechaNacimiento], [Email], [FechaCreación]) VALUES (1, 1, N'JOSUE', N'FERNANDEZ BERDUGO', N'Fundación,magdalena', CAST(N'1999-02-05' AS Date), N'jferber18@gamil.com', CAST(N'2023-08-13T00:00:00.000' AS DateTime))
INSERT [dbo].[TblAutoresLibros] ([IdAutorLibro], [IdLibro], [Nombres], [Apellidos], [CiudadProcedencia], [FechaNacimiento], [Email], [FechaCreación]) VALUES (2, 5, N'prueb1', N'prueba12', N'Fundación,magdalena', CAST(N'2023-05-20' AS Date), N'jferber18@gamil.com', CAST(N'2023-08-13T16:01:25.447' AS DateTime))
INSERT [dbo].[TblAutoresLibros] ([IdAutorLibro], [IdLibro], [Nombres], [Apellidos], [CiudadProcedencia], [FechaNacimiento], [Email], [FechaCreación]) VALUES (3, 5, N'prueb2', N'prueba22', N'Fundación,magdalena', CAST(N'2023-05-22' AS Date), N'jferber18@gamil.com', CAST(N'2023-08-13T16:01:25.447' AS DateTime))
INSERT [dbo].[TblAutoresLibros] ([IdAutorLibro], [IdLibro], [Nombres], [Apellidos], [CiudadProcedencia], [FechaNacimiento], [Email], [FechaCreación]) VALUES (4, 6, N'Josue', N'Feranández berdugo', N'Fundación,magdalena', CAST(N'2023-05-20' AS Date), N'jferber18@gamil.com', CAST(N'2023-08-13T16:50:17.603' AS DateTime))
INSERT [dbo].[TblAutoresLibros] ([IdAutorLibro], [IdLibro], [Nombres], [Apellidos], [CiudadProcedencia], [FechaNacimiento], [Email], [FechaCreación]) VALUES (5, 6, N'María camila', N'Fernandez berdugo', N'Medellin,Antioquia', CAST(N'2023-05-22' AS Date), N'jferber18@gamil.com', CAST(N'2023-08-13T16:50:17.603' AS DateTime))
SET IDENTITY_INSERT [dbo].[TblAutoresLibros] OFF
GO
SET IDENTITY_INSERT [dbo].[TblConfigLimit] ON 

INSERT [dbo].[TblConfigLimit] ([IdConfig], [DescripcionConfig], [Limite], [Activo]) VALUES (1, N'Cantidad Permitida', 5, 1)
SET IDENTITY_INSERT [dbo].[TblConfigLimit] OFF
GO
SET IDENTITY_INSERT [dbo].[TblGeneros] ON 

INSERT [dbo].[TblGeneros] ([IdGenero], [NombreGenero], [Activo]) VALUES (1, N'Prueba1', 1)
INSERT [dbo].[TblGeneros] ([IdGenero], [NombreGenero], [Activo]) VALUES (2, N'Prueba2', 1)
INSERT [dbo].[TblGeneros] ([IdGenero], [NombreGenero], [Activo]) VALUES (4, N'Prueba3', 1)
SET IDENTITY_INSERT [dbo].[TblGeneros] OFF
GO
SET IDENTITY_INSERT [dbo].[TblLibros] ON 

INSERT [dbo].[TblLibros] ([IdLibro], [Titulo], [Año], [IdGenero], [NumeroPaginas], [FechaCreacion]) VALUES (1, N'prueba', 2023, 1, 12, CAST(N'2023-04-12T00:00:00.000' AS DateTime))
INSERT [dbo].[TblLibros] ([IdLibro], [Titulo], [Año], [IdGenero], [NumeroPaginas], [FechaCreacion]) VALUES (2, N'Prueba de api 1', 2023, 1, 200, CAST(N'2023-08-13T15:54:48.770' AS DateTime))
INSERT [dbo].[TblLibros] ([IdLibro], [Titulo], [Año], [IdGenero], [NumeroPaginas], [FechaCreacion]) VALUES (3, N'Prueba de api 1', 2023, 1, 200, CAST(N'2023-08-13T15:56:40.120' AS DateTime))
INSERT [dbo].[TblLibros] ([IdLibro], [Titulo], [Año], [IdGenero], [NumeroPaginas], [FechaCreacion]) VALUES (4, N'Prueba de api 1', 2023, 1, 200, CAST(N'2023-08-13T15:57:22.910' AS DateTime))
INSERT [dbo].[TblLibros] ([IdLibro], [Titulo], [Año], [IdGenero], [NumeroPaginas], [FechaCreacion]) VALUES (5, N'Prueba de api 1', 2023, 1, 200, CAST(N'2023-08-13T16:01:23.147' AS DateTime))
INSERT [dbo].[TblLibros] ([IdLibro], [Titulo], [Año], [IdGenero], [NumeroPaginas], [FechaCreacion]) VALUES (6, N'Prueba de api 2', 2023, 1, 250, CAST(N'2023-08-13T16:50:15.610' AS DateTime))
SET IDENTITY_INSERT [dbo].[TblLibros] OFF
GO
ALTER TABLE [dbo].[TblAutoresLibros]  WITH CHECK ADD  CONSTRAINT [FK_TblAutoresLibros_TblLibros] FOREIGN KEY([IdLibro])
REFERENCES [dbo].[TblLibros] ([IdLibro])
GO
ALTER TABLE [dbo].[TblAutoresLibros] CHECK CONSTRAINT [FK_TblAutoresLibros_TblLibros]
GO
ALTER TABLE [dbo].[TblLibros]  WITH CHECK ADD  CONSTRAINT [FK_TblLibros_TblGeneros] FOREIGN KEY([IdGenero])
REFERENCES [dbo].[TblGeneros] ([IdGenero])
GO
ALTER TABLE [dbo].[TblLibros] CHECK CONSTRAINT [FK_TblLibros_TblGeneros]
GO
USE [master]
GO
ALTER DATABASE [PruebaNexos] SET  READ_WRITE 
GO
