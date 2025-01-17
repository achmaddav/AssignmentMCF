USE [VLink]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/18/2024 2:49:32 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MsStorageLocations]    Script Date: 12/18/2024 2:49:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MsStorageLocations](
	[LocationId] [nvarchar](450) NOT NULL,
	[LocationName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MsStorageLocations] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MsUsers]    Script Date: 12/18/2024 2:49:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MsUsers](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_MsUsers] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrBpkbs]    Script Date: 12/18/2024 2:49:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrBpkbs](
	[BpkbNo] [nvarchar](450) NOT NULL,
	[AgreementNumber] [nvarchar](max) NOT NULL,
	[BranchId] [nvarchar](max) NOT NULL,
	[BpkbDate] [datetime2](7) NOT NULL,
	[FakturNo] [nvarchar](max) NOT NULL,
	[FakturDate] [datetime2](7) NOT NULL,
	[LocationId] [nvarchar](450) NOT NULL,
	[PoliceNo] [nvarchar](max) NOT NULL,
	[BpkbDateIn] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[LastUpdatedBy] [nvarchar](max) NOT NULL,
	[LastUpdatedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TrBpkbs] PRIMARY KEY CLUSTERED 
(
	[BpkbNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[TrBpkbs]  WITH CHECK ADD  CONSTRAINT [FK_TrBpkbs_MsStorageLocations_LocationId] FOREIGN KEY([LocationId])
REFERENCES [dbo].[MsStorageLocations] ([LocationId])
GO
ALTER TABLE [dbo].[TrBpkbs] CHECK CONSTRAINT [FK_TrBpkbs_MsStorageLocations_LocationId]
GO
