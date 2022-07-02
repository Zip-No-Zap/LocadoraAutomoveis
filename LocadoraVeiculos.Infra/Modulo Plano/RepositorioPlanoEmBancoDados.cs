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
                                                        [VALORDIARIO_DIARIO],
                                                        [VALORPORKM_DIARIO],

                                                        [VALORDIARIO_LIVRE],
                                                        
                                                        [VALORDIARIO_CONTROLADO],
                                                        [VALORPORKM_CONTROLADO],
                                                        [LIMITEQUILOMETRAGEM_CONTROLADO]
                                                )
                                                VALUES
                                                (
                                                        @GRUPO_ID,
                                                        @VALORDIARIO_DIARIO,
                                                        @VALORPORKM_DIARIO,

                                                        @VALORDIARIO_LIVRE,

                                                        @VALORDIARIO_CONTROLADO,
                                                        @VALORPORKM_CONTROLADO,
                                                        @LIMITEQUILOMETRAGEM_CONTROLADO
                    
                                                ) SELECT SCOPE_IDENTITY(); ";

        protected override string Sql_edicao =>
                                                @"UPDATE [TBPLANO] SET 
                                                                                    
                                                         [GRUPO_ID] = @GRUPO_ID,
                                                         [VALORDIARIO_DIARIO] = @VALORDIARIO_DIARIO,
                                                         [VALORPORKM_DIARIO] = @VALORPORKM_DIARIO,

                                                         [VALORDIARIO_LIVRE] = @VALORDIARIO_LIVRE,
                                                        
                                                         [VALORDIARIO_CONTROLADO] = @VALORDIARIO_CONTROLADO,
                                                         [VALORPORKM_CONTROLADO] = @VALORPORKM_CONTROLADO,
                                                         [LIMITEQUILOMETRAGEM_CONTROLADO] = @LIMITEQUILOMETRAGEM_CONTROLADO
                                                            
                                                  WHERE
                                                          ID = @ID";

        protected override string Sql_exclusao => @"DELETE FROM TBPLANO WHERE ID = @ID";

        protected override string Sql_selecao_por_id =>
                                                        @"SELECT 
            
                                                            PLANO.[ID],
                                                            PLANO.[GRUPO_ID],
                                                            PLANO.[VALORDIARIO_DIARIO],
                                                            PLANO.[VALORPORKM_DIARIO],
                                                 
                                                            PLANO.[VALORDIARIO_LIVRE],
                                               
                                                            PLANO.[VALORDIARIO_CONTROLADO],
                                                            PLANO.[VALORPORKM_CONTROLADO],
                                                            PLANO.[LIMITEQUILOMETRAGEM_CONTROLADO]
                                                            
                                                            GRUPO.[NOMEGRUPO] AS GRUPO_NOME
                         
                                                        FROM TBPLANO AS PLANO

                                                            INNER JOIN TBGRUPOVEICULO AS GRUPO 

                                                            ON PLANO.GRUPO_ID = GRUPO.ID

                                                        WHERE PLANO.ID = @ID";

        protected override string Sql_selecao_todos => @"SELECT 
            
                                                            PLANO.[ID],
                                                            PLANO.[GRUPO_ID],
                                                            PLANO.[VALORDIARIO_DIARIO],
                                                            PLANO.[VALORPORKM_DIARIO],
                                                 
                                                            PLANO.[VALORDIARIO_LIVRE],
                                               
                                                            PLANO.[VALORDIARIO_CONTROLADO],
                                                            PLANO.[VALORPORKM_CONTROLADO],
                                                            PLANO.[LIMITEQUILOMETRAGEM_CONTROLADO]

                                                            GRUPO.[NOMEGRUPO] AS GRUPO_NOME
                         
                                                        FROM TBPLANO AS PLANO

                                                            INNER JOIN TBGRUPOVEICULO AS GRUPO 

                                                            ON PLANO.GRUPO_ID = GRUPO.ID";

    }
}
