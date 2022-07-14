
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;


namespace LocadoraVeiculos.Infra.BancoDados.Modulo_GrupoVeiculo
{
    public class RepositorioGrupoVeiculoEmBancoDados : RepositorioBase<GrupoVeiculo, MapeadorGrupoVeiculo, ValidadorGrupoVeiculo>
    {
        protected override string Sql_insercao => @"INSERT INTO TBGRUPOVEICULO 
                                                    (
                                                        [ID],  
                                                        [NOMEGRUPO]   
                                                    )
                                                    VALUES
                                                    (
                                                        @ID,
                                                        @NOMEGRUPO

                                                    );";

        protected override string Sql_edicao => @"UPDATE [TBGRUPOVEICULO] SET 

                                                         [NOMEGRUPO] = @NOMEGRUPO    
                                                  WHERE
                                                          ID = @ID";

        protected override string Sql_exclusao => @"DELETE FROM TBGRUPOVEICULO WHERE ID = @ID;";

        protected override string Sql_selecao_por_id => @"SELECT 
                                                        [ID] GRUPO_ID,
                                                        [NOMEGRUPO] GRUPO_NOME
                                                        FROM 
                                                            [TBGRUPOVEICULO] 
                                                        WHERE 
                                                            ID = @ID";

        protected override string Sql_selecao_todos => @"SELECT 
                                                            [ID] GRUPO_ID,
                                                            [NOMEGRUPO] GRUPO_NOME    
                                                        FROM 
                                                            [TBGRUPOVEICULO]";


    }
}
