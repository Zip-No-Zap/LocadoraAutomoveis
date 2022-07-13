CREATE TABLE [dbo].[TBFUNCIONARIO] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [login]        VARCHAR (50)     NOT NULL,
    [senha]        VARCHAR (50)     NOT NULL,
    [salario]      REAL             NOT NULL,
    [dataAdmissao] SMALLDATETIME    NOT NULL,
    [nome]         VARCHAR (150)    NOT NULL,
    [perfil]       VARCHAR (50)     NOT NULL,
    [cidade]       VARCHAR (70)     NOT NULL,
    [estado]       VARCHAR (50)     NOT NULL
);

