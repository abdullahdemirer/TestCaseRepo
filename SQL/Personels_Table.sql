USE [TSKBTestCaseDb]
GO

/****** Object:  Table [dbo].[Personels]    Script Date: 5.08.2023 18:42:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Personels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationNumber] [nvarchar](50) NOT NULL,
	[PersonelName] [nvarchar](50) NOT NULL,
	[PersonelSurname] [nvarchar](50) NOT NULL,
	[Department] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[Mail] [nvarchar](100) NOT NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[MobilePhoneNumber] [nvarchar](10) NOT NULL,
	[HomePhoneNumber] [nvarchar](10) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Personelss] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Personels]  WITH CHECK ADD  CONSTRAINT [FK_Personels_Departments] FOREIGN KEY([Department])
REFERENCES [dbo].[Departments] ([Id])
GO

ALTER TABLE [dbo].[Personels] CHECK CONSTRAINT [FK_Personels_Departments]
GO


