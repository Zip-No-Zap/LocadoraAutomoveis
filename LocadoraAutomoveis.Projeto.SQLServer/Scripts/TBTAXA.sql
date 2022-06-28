﻿
USE [LocadoraAutomoveisDB]
GO

/****** Object:  Table [dbo].[TBTAXA]    Script Date: 27/06/2022 21:15:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[TBTAXA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRICAO] [varchar](150) NOT NULL,
	[TIPO] [varchar](50) NOT NULL,
	[VALOR] [real] NOT NULL,
 CONSTRAINT [PK_TBTAXA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


