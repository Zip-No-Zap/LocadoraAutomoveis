using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;

namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente
{
    public class RepositorioClienteEmBancoDados : RepositorioBase<Cliente, MapeadorCliente, ValidadorCliente>
    {
        protected override string Sql_insercao => @"INSERT INTO TBCLIENTE 
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

        protected override string Sql_edicao => @"UPDATE [TBCLIENTE] SET 

                                                        [NOME] = @NOME,
                                                        [CPF] = @CPF,
                                                        [CNPJ] = @CNPJ,
                                                        [ENDERECO] = @ENDERECO,
                                                        [TIPOCLIENTE] = @TIPOCLIENTE,
                                                        [EMAIL] = @EMAIL,
                                                        [TELEFONE] = @TELEFONE

                                                WHERE
		                                                ID = @ID";

        protected override string Sql_exclusao => @"DELETE FROM TBCLIENTE WHERE ID = @ID;";
        protected override string Sql_selecao_por_id => @"SELECT * FROM TBCLIENTE WHERE ID = @ID";

        protected override string Sql_selecao_todos => @"SELECT * FROM TBCLIENTE";
    }
}
