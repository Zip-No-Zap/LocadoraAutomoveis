using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;


namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Funcionario
{
    public class RepositorioFuncionarioEmBancoDados : RepositorioBase<Funcionario, MapeadorFuncionario, ValidadorFuncionario>
    {

        protected override string Sql_insercao
        {
            get => @"INSERT INTO TBFUNCIONARIO 
                                    (
                                            [NOME],    
                                            [LOGIN],
                                            [SENHA],
                                            [SALARIO],
                                            [DATAADMISSAO],
                                            [CIDADE],
                                            [ESTADO],
                                            [PERFIL]
                                    )
                                    VALUES
                                    (
                                            @NOME,
                                            @LOGIN,
                                            @SENHA,
                                            @SALARIO,
                                            @DATAADMISSAO,
                                            @CIDADE,
                                            @ESTADO,
                                            @PERFIL

                                    );SELECT SCOPE_IDENTITY();";
        }
        protected override string Sql_edicao
        {
            get =>
                                @"UPDATE [TBFUNCIONARIO] SET 

                                    [NOME] = @NOME,    
	                                [LOGIN] = @LOGIN,
                                    [SENHA] = @SENHA,
                                    [SALARIO] = @SALARIO,
                                    [DATAADMISSAO] = @DATAADMISSAO,
                                    [CIDADE] = @CIDADE,
                                    [ESTADO] = @ESTADO

                               WHERE
		                             ID = @ID";
        }
        protected override string Sql_exclusao
        {
            get => @"DELETE FROM TBFUNCIONARIO WHERE ID = @ID;";
        }
        protected override string Sql_selecao_por_id 
        { 
            get => @"SELECT * FROM TBFUNCIONARIO WHERE ID = @ID";
        }
        protected override string Sql_selecao_todos 
        { 
            get => @"SELECT * FROM TBFUNCIONARIO";
        }


        protected override bool VerificarDuplicidade(Funcionario entidade)
        {
            var funcs = SelecionarTodos();

            foreach (Funcionario f in funcs)
            {
                if (f.Login == entidade.Login)
                {
                    return true;
                }

                if(f.Nome == entidade.Nome)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
