CREATE TABLE [dbo].[TBPLANO] (
    [Id]                             UNIQUEIDENTIFIER NOT NULL,
    [GrupoVeiculoId]                 UNIQUEIDENTIFIER NOT NULL,
    [ValorDiario_Diario]             FLOAT (53)       NOT NULL,
    [ValorPorKm_Diario]              FLOAT (53)       NOT NULL,
    [ValorDiario_Livre]              FLOAT (53)       NOT NULL,
    [ValorDiario_Controlado]         FLOAT (53)       NOT NULL,
    [ValorPorKm_Controlado]          FLOAT (53)       NOT NULL,
    [LimiteQuilometragem_Controlado] FLOAT (53)       NOT NULL,
    CONSTRAINT [PK_TBPLANO] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBPLANO_TBGRUPOVEICULO_GrupoVeiculoId] FOREIGN KEY ([GrupoVeiculoId]) REFERENCES [dbo].[TBGRUPOVEICULO] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_TBPLANO_GrupoVeiculoId]
    ON [dbo].[TBPLANO]([GrupoVeiculoId] ASC);

