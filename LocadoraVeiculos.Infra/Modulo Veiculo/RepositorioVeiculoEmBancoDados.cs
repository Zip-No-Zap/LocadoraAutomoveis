using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;


namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Veiculo
{
    public class RepositorioVeiculoEmBancoDados : RepositorioBase<Veiculo, MapeadorVeiculo, ValidadorVeiculo>
    {
        protected override string Sql_insercao => @"INSERT INTO [TBVEICULO]
                                                    (
                                                        [ID],
                                                        [MODELO],
                                                        [PLACA],
                                                        [COR],
                                                        [ANO],
                                                        [TIPOCOMBUSTIVEL],
                                                        [CAPACIDADETANQUE],
                                                        [STATUS],
                                                        [QUILOMETRAGEMATUAL],
                                                        [FOTO],
                                                        [IDGRUPOVEICULO]
                                                                        
                                                    )
                                                    VALUES
                                                    (
                                                        @ID,
                                                        @MODELO,
                                                        @PLACA,
                                                        @COR,
                                                        @ANO,
                                                        @TIPOCOMBUSTIVEL,
                                                        @CAPACIDADETANQUE,
                                                        @STATUS,
                                                        @QUILOMETRAGEMATUAL,
                                                        @FOTO,
                                                        @IDGRUPOVEICULO

                                                    );";

        protected override string Sql_edicao => @"UPDATE [TBVEICULO] SET 

                                                    [MODELO] = @MODELO,
                                                    [PLACA] = @PLACA,
                                                    [COR]  = @COR,
                                                    [ANO] = @ANO,
                                                    [TIPOCOMBUSTIVEL] = @TIPOCOMBUSTIVEL,
                                                    [CAPACIDADETANQUE] = @CAPACIDADETANQUE,
                                                    [STATUS] = @STATUS,
                                                    [QUILOMETRAGEMATUAL] = @QUILOMETRAGEMATUAL,
                                                    [FOTO] = @FOTO,
                                                    [IDGRUPOVEICULO] = @IDGRUPOVEICULO  

                                                  WHERE

                                                    ID = @ID";


        protected override string Sql_exclusao => @"DELETE FROM [TBVEICULO] WHERE ID = @ID;";

        protected override string Sql_selecao_por_id => @"SELECT  

                                                            VEICULO.[ID] VEICULO_ID,
                                                            VEICULO.[MODELO] VEICULO_MODELO, 
                                                            VEICULO.[PLACA] VEICULO_PLACA, 
                                                            VEICULO.[COR] VEICULO_COR, 
                                                            VEICULO.[ANO] VEICULO_ANO,
                                                            VEICULO.[TIPOCOMBUSTIVEL] VEICULO_TIPOCOMBUSTIVEL,
                                                            VEICULO.[CAPACIDADETANQUE] VEICULO_CAPACIDADETANQUE,
                                                            VEICULO.[STATUS] VEICULO_STATUS,
                                                            VEICULO.[QUILOMETRAGEMATUAL] VEICULO_QUILOMETRAGEMATUAL,
                                                            VEICULO.[FOTO] VEICULO_FOTO,
                                                            VEICULO.[IDGRUPOVEICULO] VEICULO_IDGRUPOVEICULO,

                                                            GRUPOVEICULO.[NOMEGRUPO] GRUPO_NOME

                                                        FROM TBVEICULO AS VEICULO
                                                        INNER JOIN TBGRUPOVEICULO AS GRUPOVEICULO

                                                            ON VEICULO.IDGRUPOVEICULO = GRUPOVEICULO.ID

                                                            WHERE V.ID = @ID";

        protected override string Sql_selecao_todos => @"SELECT  

                                                            VEICULO.[ID] VEICULO_ID,
                                                            VEICULO.[MODELO] VEICULO_MODELO, 
                                                            VEICULO.[PLACA] VEICULO_PLACA, 
                                                            VEICULO.[COR] VEICULO_COR, 
                                                            VEICULO.[ANO] VEICULO_ANO,
                                                            VEICULO.[TIPOCOMBUSTIVEL] VEICULO_TIPOCOMBUSTIVEL,
                                                            VEICULO.[CAPACIDADETANQUE] VEICULO_CAPACIDADETANQUE,
                                                            VEICULO.[STATUS] VEICULO_STATUS,
                                                            VEICULO.[QUILOMETRAGEMATUAL] VEICULO_QUILOMETRAGEMATUAL,
                                                            VEICULO.[FOTO] VEICULO_FOTO,
                                                            VEICULO.[IDGRUPOVEICULO] VEICULO_IDGRUPOVEICULO,

                                                            GRUPOVEICULO.[NOMEGRUPO] GRUPO_NOME

                                                        FROM [TBVEICULO] AS VEICULO
                                                        INNER JOIN [TBGRUPOVEICULO] AS GRUPOVEICULO

                                                            ON VEICULO.IDGRUPOVEICULO = GRUPOVEICULO.ID";

    }
}
