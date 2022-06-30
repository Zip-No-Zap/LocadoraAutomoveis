
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;


namespace LocadoraVeiculos.Infra.BancoDados.Modulo_GrupoVeiculo
{
    public class RepositorioGrupoVeiculoEmBancoDados : RepositorioBase<GrupoVeiculo, MapeadorGrupoVeiculo, ValidadorGrupoVeiculo>
    {
        protected override string Sql_insercao => @"INSERT INTO TBGRUPOVEICULO 
                                                    (
                                                        [NOMEGRUPO]   
                                                    )
                                                    VALUES
                                                    (
                                                        @NOMEGRUPO

                                                    );SELECT SCOPE_IDENTITY();";

        protected override string Sql_edicao => @"UPDATE [TBGRUPOVEICULO] SET 

                                                    [NOMEGRUPO] = @NOMEGRUPO    
                                               WHERE
                                                    ID = @ID";

        protected override string Sql_exclusao => @"DELETE FROM TBGRUPOVEICULO WHERE ID = @ID;";

        protected override string Sql_selecao_por_id => @"SELECT * FROM TBGRUPOVEICULO WHERE ID = @ID";

        protected override string Sql_selecao_todos => @"SELECT * FROM TBGRUPOVEICULO";

        protected override bool VerificarDuplicidade(GrupoVeiculo entidade)
        {
            var grupos = SelecionarTodos();

            foreach (GrupoVeiculo g in grupos)
            {
                if (g.Nome == entidade.Nome)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
