CREATE TABLE [dbo].[TBCONDUTOR] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [ClienteId]     UNIQUEIDENTIFIER NULL,
    [Nome]          VARCHAR (100)    NOT NULL,
    [Cpf]           VARCHAR (20)     NOT NULL,
    [Email]         VARCHAR (100)    NOT NULL,
    [Endereco]      VARCHAR (100)    NOT NULL,
    [Telefone]      VARCHAR (20)     NOT NULL,
    [Cnh]           VARCHAR (20)     NOT NULL,
    [VencimentoCnh] DATE             NOT NULL,
    CONSTRAINT [PK_TBCONDUTOR] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBCONDUTOR_TBCLIENTE_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[TBCLIENTE] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TBCONDUTOR_ClienteId]
    ON [dbo].[TBCONDUTOR]([ClienteId] ASC);

