CREATE TABLE [dbo].[TBFUNCIONARIO] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Nome]         VARCHAR (120)    NOT NULL,
    [Login]        VARCHAR (50)     NOT NULL,
    [Senha]        VARCHAR (50)     NOT NULL,
    [Salario]      FLOAT (53)       NOT NULL,
    [DataAdmissao] DATE             NOT NULL,
    [Cidade]       VARCHAR (150)    NOT NULL,
    [Estado]       VARCHAR (2)      NOT NULL,
    [Perfil]       VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_TBFUNCIONARIO] PRIMARY KEY CLUSTERED ([Id] ASC)
);

