using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;


namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Veiculo
{
    public class RepositorioVeiculoEmBancoDados : RepositorioBase<Veiculo, MapeadorVeiculo, ValidadorVeiculo>
    {
        protected override string Sql_insercao => @"INSERT INTO TBVEICULO 
                                                    (
                                                        [MODELO],
                                                        [PLACA],
                                                        [COR],
                                                        [ANO],
                                                        [TIPOCOMBUSTIVEL],
                                                        [CAPACIDADETANQUE],
                                                        [STATUS],
                                                        [QUILOMETRAGEMATUAL],
                                                        [IDGRUPOVEICULO]
                                                                        
                                                    )
                                                    VALUES
                                                    (
                                                        @MODELO,
                                                        @PLACA,
                                                        @COR,
                                                        @ANO,
                                                        @TIPOCOMBUSTIVEL,
                                                        @CAPACIDADETANQUE,
                                                        @STATUS,
                                                        @QUILOMETRAGEMATUAL,
                                                        @IDGRUPOVEICULO

                                                    );SELECT SCOPE_IDENTITY();";

        protected override string Sql_edicao => @"UPDATE [TBVEICULO] SET 

                                                    [MODELO] = @MODELO,
                                                    [PLACA] = @PLACA,
                                                    [COR]  = @COR,
                                                    [ANO] = @ANO,
                                                    [TIPOCOMBUSTIVEL] = @TIPOCOMBUSTIVEL,
                                                    [CAPACIDADETANQUE] = @CAPACIDADETANQUE,
                                                    [STATUS] = @STATUS,
                                                    [QUILOMETRAGEMATUAL] = @QUILOMETRAGEMATUAL,
                                                    [IDGRUPOVEICULO] = @IDGRUPOVEICULO  
                                                  WHERE
                                                    ID = @ID";


        protected override string Sql_exclusao => @"DELETE FROM TBVEICULO WHERE ID = @ID;";

        protected override string Sql_selecao_por_id => @"SELECT  

                                                            V.[ID],
                                                            V.[MODELO], 
                                                            V.[PLACA], 
                                                            V.[COR], 
                                                            V.[ANO],
                                                            V.[TIPOCOMBUSTIVEL],
                                                            V.[CAPACIDADETANQUE],
                                                            V.[STATUS],
                                                            V.[QUILOMETRAGEMATUAL],
                                                            V.[GRUPOVEICULO_ID]

                                                        FROM TBVEICULO AS V
                                                        INNER JOIN TBGRUPOVEICULO AS GV

                                                            ON V.GRUPOVEICULO_ID = GV.ID
                                                            WHERE V.ID = @ID";

        protected override string Sql_selecao_todos => @"SELECT  

                                                            V.[ID],
                                                            V.[MODELO], 
                                                            V.[PLACA], 
                                                            V.[COR], 
                                                            V.[ANO],
                                                            V.[TIPOCOMBUSTIVEL],
                                                            V.[CAPACIDADETANQUE],
                                                            V.[STATUS],
                                                            V.[QUILOMETRAGEMATUAL],
                                                            V.[GRUPOVEICULO_ID]

                                                        FROM TBVEICULO AS V
                                                        INNER JOIN TBGRUPOVEICULO AS GV

                                                            ON V.GRUPOVEICULO_ID = GV.ID";

    }
}
