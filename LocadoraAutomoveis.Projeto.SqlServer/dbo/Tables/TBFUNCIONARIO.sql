CREATE TABLE [dbo].[TBFUNCIONARIO] (
    [id]           INT           NOT NULL,
    [login]        VARCHAR (50)  NOT NULL,
    [senha]        VARCHAR (50)  NOT NULL,
    [salario]      REAL          NOT NULL,
    [dataAdmissao] SMALLDATETIME NOT NULL,
    [nome]         VARCHAR (50)  NOT NULL,
    [perfil]       VARCHAR (50)  NOT NULL,
    [cidade]       VARCHAR (50)  NOT NULL,
    [estado]       CHAR (2)      NOT NULL
);

