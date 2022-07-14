CREATE TABLE [dbo].[TBVEICULO] (
    [ID]                 UNIQUEIDENTIFIER NOT NULL,
    [MODELO]             VARCHAR (70)     NOT NULL,
    [PLACA]              VARCHAR (10)     NOT NULL,
    [COR]                VARCHAR (50)     NOT NULL,
    [ANO]                INT              NOT NULL,
    [TIPOCOMBUSTIVEL]    VARCHAR (50)     NOT NULL,
    [CAPACIDADETANQUE]   REAL             NOT NULL,
    [STATUS]             VARCHAR (50)     NOT NULL,
    [QUILOMETRAGEMATUAL] INT              NOT NULL,
    [FOTO]               VARBINARY (MAX)  NOT NULL,
    [IDGRUPOVEICULO]     INT              NOT NULL,
    CONSTRAINT [PK_TBVEICULO_1] PRIMARY KEY CLUSTERED ([ID] ASC)
);

