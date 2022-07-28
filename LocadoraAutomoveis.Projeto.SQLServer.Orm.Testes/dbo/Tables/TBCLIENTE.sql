CREATE TABLE [dbo].[TBCLIENTE] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Nome]        VARCHAR (100)    NOT NULL,
    [Cpf]         VARCHAR (20)     NULL,
    [Cnpj]        VARCHAR (20)     NULL,
    [Email]       VARCHAR (100)    NOT NULL,
    [Endereco]    VARCHAR (100)    NOT NULL,
    [Telefone]    VARCHAR (20)     NOT NULL,
    [TipoCliente] NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_TBCLIENTE] PRIMARY KEY CLUSTERED ([Id] ASC)
);

