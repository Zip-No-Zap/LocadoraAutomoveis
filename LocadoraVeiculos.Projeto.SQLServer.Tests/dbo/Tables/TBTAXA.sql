﻿CREATE TABLE [dbo].[TBTAXA] (
    [ID]        UNIQUEIDENTIFIER NOT NULL,
    [DESCRICAO] VARCHAR (150)    NOT NULL,
    [TIPO]      VARCHAR (50)     NOT NULL,
    [VALOR]     REAL             NOT NULL,
    CONSTRAINT [PK_TBTAXA_1] PRIMARY KEY CLUSTERED ([ID] ASC)
);

