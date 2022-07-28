CREATE TABLE [dbo].[TBVEICULO] (
    [Id]                 UNIQUEIDENTIFIER NOT NULL,
    [Modelo]             VARCHAR (250)    NOT NULL,
    [Placa]              VARCHAR (10)     NOT NULL,
    [Cor]                VARCHAR (50)     NOT NULL,
    [Ano]                INT              NOT NULL,
    [TipoCombustivel]    VARCHAR (50)     NOT NULL,
    [CapacidadeTanque]   FLOAT (53)       NOT NULL,
    [GrupoPertencenteId] UNIQUEIDENTIFIER NULL,
    [StatusVeiculo]      VARCHAR (50)     NOT NULL,
    [QuilometragemAtual] INT              NOT NULL,
    [Foto]               VARBINARY (MAX)  NOT NULL,
    CONSTRAINT [PK_TBVEICULO] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBVEICULO_TBGRUPOVEICULO_GrupoPertencenteId] FOREIGN KEY ([GrupoPertencenteId]) REFERENCES [dbo].[TBGRUPOVEICULO] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TBVEICULO_GrupoPertencenteId]
    ON [dbo].[TBVEICULO]([GrupoPertencenteId] ASC);

