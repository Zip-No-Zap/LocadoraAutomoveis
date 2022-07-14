CREATE TABLE [dbo].[TBCLIENTE] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [cpf]         VARCHAR (20)     NOT NULL,
    [cnpj]        VARCHAR (20)     NOT NULL,
    [endereco]    VARCHAR (150)    NOT NULL,
    [tipoCliente] VARCHAR (50)     NOT NULL,
    [email]       VARCHAR (50)     NOT NULL,
    [telefone]    VARCHAR (30)     NOT NULL,
    [nome]        VARCHAR (150)    NOT NULL,
    CONSTRAINT [PK_TBCLIENTE] PRIMARY KEY CLUSTERED ([Id] ASC)
);

