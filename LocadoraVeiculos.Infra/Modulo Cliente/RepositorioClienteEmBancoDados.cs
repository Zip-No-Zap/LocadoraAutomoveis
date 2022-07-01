﻿using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;

namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente
{
    public class RepositorioClienteEmBancoDados : RepositorioBase<Cliente, MapeadorCliente, ValidadorCliente>
    {
        protected override string Sql_insercao => 
            @"INSERT INTO TBCLIENTE 
            (
                [NOME],    
                [CPF],
                [CNPJ],   
                [ENDERECO],
                [TIPOCLIENTE],
                [EMAIL],
                [TELEFONE]  
            )
            VALUES
            (
                @NOME,    
                @CPF,
                @CNPJ,   
                @ENDERECO,
                @TIPOCLIENTE,
                @EMAIL,
                @TELEFONE

            );SELECT SCOPE_IDENTITY();";

        protected override string Sql_edicao => 
            @"UPDATE [TBCLIENTE] 
            SET 
                    [NOME] = @NOME,
                    [CPF] = @CPF,
                    [CNPJ] = @CNPJ,
                    [ENDERECO] = @ENDERECO,
                    [TIPOCLIENTE] = @TIPOCLIENTE,
                    [EMAIL] = @EMAIL,
                    [TELEFONE] = @TELEFONE

            WHERE
		            ID = @ID";

        protected override string Sql_exclusao =>
            @"DELETE FROM TBCLIENTE
                WHERE
                ID = @ID;";
        protected override string Sql_selecao_por_id =>
            @"SELECT 
                [ID] CLIENTE_ID,
                [NOME] CLIENTE_NOME,    
                [CPF] CLIENTE_CPF,
                [CNPJ] CLIENTE_CNPJ,   
                [ENDERECO] CLIENTE_ENDERECO,
                [TIPOCLIENTE] CLIENTE_TIPOCLIENTE,
                [EMAIL] CLIENTE_EMAIL,
                [TELEFONE] CLIENTE_TELEFONE
            FROM 
                [TBCLIENTE]
            WHERE 
                [ID] = @ID";

        protected override string Sql_selecao_todos => 
            @"SELECT 
                [ID] CLIENTE_ID,
                [NOME] CLIENTE_NOME,    
                [CPF] CLIENTE_CPF,
                [CNPJ] CLIENTE_CNPJ,   
                [ENDERECO] CLIENTE_ENDERECO,
                [TIPOCLIENTE] CLIENTE_TIPOCLIENTE,
                [EMAIL] CLIENTE_EMAIL,
                [TELEFONE] CLIENTE_TELEFONE
            FROM 
                [TBCLIENTE]";


        protected override bool VerificarDuplicidade(Cliente entidade)
        {
            var clientes = SelecionarTodos();

            foreach (Cliente c in clientes)
            {
                if (entidade.Cpf != "-" && c.Cpf == entidade.Cpf  ) 
                    return true;

                if (entidade.Cnpj != "-" && c.Cnpj == entidade.Cnpj)
                    return true;
            }

            return false;
        }
    }
}
