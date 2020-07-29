USE [master]
GO

IF DB_ID('ConsultasDB') IS NOT NULL
  set noexec on               -- prevent creation when already exists

/****** Object:  Database [ConsultasDB]    Script Date: 29/07/2020 12:30:09 ******/
CREATE DATABASE [ConsultasDB];
GO

USE [ConsultasDB]
GO

/****** Object:  Table [dbo].[Alunos]    Script Date: 29/07/2020 12:31:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Alunos](
	[AlunoId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_Alunos] PRIMARY KEY CLUSTERED 
(
	[AlunoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

