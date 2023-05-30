CREATE DATABASE Kutuphane
GO
USE [Kutuphane]
GO
/****** Object:  Table [dbo].[Table_giris]    Script Date: 30.05.2023 10:45:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_giris](
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Table_giris] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_kitaplar]    Script Date: 30.05.2023 10:45:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_kitaplar](
	[ad] [nvarchar](50) NOT NULL,
	[yazar] [nvarchar](50) NOT NULL,
	[tür] [nvarchar](50) NOT NULL,
	[durum] [nvarchar](50) NULL,
 CONSTRAINT [PK_Table_kitaplar] PRIMARY KEY CLUSTERED 
(
	[ad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Table_giris] ([username], [password]) VALUES (N'admin', N'1234')
GO
