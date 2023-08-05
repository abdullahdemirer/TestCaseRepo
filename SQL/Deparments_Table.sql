USE [TSKBTestCaseDb]
GO

/****** Object:  Table [dbo].[Departments]    Script Date: 5.08.2023 18:43:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentCode] [nvarchar](5) NOT NULL,
	[DepartmentName] [nvarchar](150) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Departmentss] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


