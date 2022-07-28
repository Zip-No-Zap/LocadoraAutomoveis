CREATE TABLE [dbo].[TBTAXA] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [Descricao] VARCHAR (100)    NOT NULL,
    [Valor]     FLOAT (53)       NOT NULL,
    [Tipo]      VARCHAR (20)     NOT NULL,
    CONSTRAINT [PK_TBTAXA] PRIMARY KEY CLUSTERED ([Id] ASC)
);

