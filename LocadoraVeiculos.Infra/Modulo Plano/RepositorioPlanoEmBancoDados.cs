using LocadoraVeiculos.Dominio.Modulo_Plano;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;


namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Plano
{
    public class RepositorioPlanoEmBancoDados : RepositorioBase<Plano, MapeadorPlano, ValidadorPlano>
    {
        protected override string Sql_insercao =>
                                                @"INSERT INTO TBPLANO
                                                (
                                                        [GRUPO_ID],
                                                        [DESCRICAO],
                                                        [VALORDIARIO],
                                                        [VALORPORKM],
                                                        [LIMITEQUILOMETRAGEM]
                                                )
                                                VALUES
                                                (
                                                        @GRUPO_ID,
                                                        @DESCRICAO,
                                                        @VALORDIARIO,
                                                        @VALORPORKM,
                                                        @LIMITEQUILOMETRAGEM
                    
                                                ) SELECT SCOPE_IDENTITY(); ";

        protected override string Sql_edicao =>
                                                @"UPDATE [TBPLANO] SET 
                                                                                    
                                                         [GRUPO_ID] = @GRUPO_ID,  
                                                         [DESCRICAO] = @DESCRICAO,
                                                         [VALORDIARIO] = @VALORDIARIO,
                                                         [VALORPORKM] = @VALORPORKM,
                                                         [LIMITEQUILOMETRAGEM] = @LIMITEQUILOMETRAGEM  
                                                  WHERE
                                                          ID = @ID";

        protected override string Sql_exclusao => @"DELETE FROM TBPLANO WHERE ID = @ID";

        protected override string Sql_selecao_por_id => 
                                                        @"SELECT 
            
                                                            PLANO.[ID]
                                                            PLANO.[GRUPO_ID]
                                                            PLANO.[DESCRICAO]
                                                            PLANO.[VALORDIARIO]
                                                            PLANO.[VALORPORKM]
                                                            PLANO.[LIMITEKILOMETRAGEM]

                                                            GRUPO.[NOME] AS GRUPO_NOME
                         
                                                        FROM TBPLANO AS PLANO

                                                            INNER JOIN TBGRUPOVEICULO AS GRUPO 

                                                            ON PLANO.GRUPO_ID = GRUPO.ID

                                                        WHERE ID = @ID";

        protected override string Sql_selecao_todos => @"SELECT 
            
                                                        PLANO.[ID]
                                                        PLANO.[GRUPO_ID]
                                                        PLANO.[DESCRICAO]
                                                        PLANO.[VALORDIARIO]
                                                        PLANO.[VALORPORKM]
                                                        PLANO.[LIMITEKILOMETRAGEM]

                                                        GRUPO.[NOME] AS GRUPO_NOME
                         
                                                    FROM TBPLANO AS PLANO

                                                        INNER JOIN TBGRUPOVEICULO AS GRUPO 

                                                        ON PLANO.GRUPO_ID = GRUPO.ID";

    }
}
