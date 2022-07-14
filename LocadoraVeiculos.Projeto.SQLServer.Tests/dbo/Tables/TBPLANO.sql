CREATE TABLE [dbo].[TBPLANO] (
    [ID]                             UNIQUEIDENTIFIER NOT NULL,
    [GRUPO_ID]                       UNIQUEIDENTIFIER NOT NULL,
    [VALORDIARIO_DIARIO]             REAL             NOT NULL,
    [VALORPORKM_DIARIO]              REAL             NOT NULL,
    [LIMITEQUILOMETRAGEM_CONTROLADO] INT              NOT NULL,
    [VALORDIARIO_CONTROLADO]         INT              NOT NULL,
    [VALORPORKM_CONTROLADO]          INT              NOT NULL,
    [VALORDIARIO_LIVRE]              INT              NOT NULL,
    CONSTRAINT [PK_TBPLANO_1] PRIMARY KEY CLUSTERED ([ID] ASC)
);

