CREATE TABLE [dbo].[TBCLIENTE] (
    [id]          INT          NOT NULL,
    [cpf]         VARCHAR (11) NULL,
    [cnpj]        VARCHAR (14) NULL,
    [endereco]    VARCHAR (50) NOT NULL,
    [tipoCliente] VARCHAR (50) NOT NULL,
    [cnh]         VARCHAR (50) NOT NULL,
    [email]       VARCHAR (50) NOT NULL,
    [telefone]    VARCHAR (11) NOT NULL,
    [nome]        VARCHAR (50) NOT NULL
);

