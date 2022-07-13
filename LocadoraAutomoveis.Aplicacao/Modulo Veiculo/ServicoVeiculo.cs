using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Veiculo;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraAutomoveis.Aplicacao.Modulo_Veiculo
{
    public class ServicoVeiculo
    {
        readonly RepositorioVeiculoEmBancoDados repositorioVeiculo;
        ValidadorVeiculo validadorVeiculo;

        public ServicoVeiculo(RepositorioVeiculoEmBancoDados repositorioVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public Result<Veiculo> Inserir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando inserir Veículo... {@veiculo}", veiculo);

            var resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {

                    Log.Logger.Warning("Falha ao tentar inserir Veículo. {VeiculoId} -> Motivo: {erro}", veiculo.Id, erro.Message);

                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioVeiculo.Inserir(veiculo);

                Log.Logger.Information("Veículo inserido com sucesso. {@veiculo}", veiculo);


                return Result.Ok(veiculo);
            }

            catch (Exception ex)
            {
                string msgErro = "Falha ao tentar inserir Veículo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Veiculo> Editar(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando editar Grupo de Veículo... {@veiculo}", veiculo);

            Result resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {

                    Log.Logger.Warning("Falha ao tentar editar Grupo de Veículo. {GrupoVeiculoId} -> Motivo: {erro}", veiculo.Id, erro.Message);

                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioVeiculo.Editar(veiculo);

                Log.Logger.Information("Veículo . {VeiculoId} editado com sucesso", veiculo.Id);


                return Result.Ok(veiculo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha ao tentar editar Veículo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando excluir Veículo... {@veiculo}", veiculo);

            try
            {
                repositorioVeiculo.Excluir(veiculo);

                Log.Logger.Information("Veiculo {VeiculoId} excluído com sucesso", veiculo.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o Veiculo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);

            }
        }

        public Result<List<Veiculo>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioVeiculo.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os veiculos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Veiculo> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioVeiculo.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o veiculo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", id);

                return Result.Fail(msgErro);
            }
        }

        public Result Validar(Veiculo veiculo)
        {
            var validadorVeiculo = new ValidadorVeiculo();

            var resultadoValidacao = validadorVeiculo.Validate(veiculo);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation
            {

                erros.Add(new Error(item.ErrorMessage));
            }

            if (PlacaDuplicada(veiculo))
                erros.Add(new Error("'Placa' duplicada"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool PlacaDuplicada(Veiculo veiculo)
        {
            repositorioVeiculo.Sql_selecao_por_parametro = @"SELECT  

                                                                V.[ID],
                                                                V.[MODELO], 
                                                                V.[PLACA], 
                                                                V.[COR], 
                                                                V.[ANO],
                                                                V.[TIPOCOMBUSTIVEL],
                                                                V.[CAPACIDADETANQUE],
                                                                V.[STATUS],
                                                                V.[QUILOMETRAGEMATUAL],
                                                                V.[FOTO],
                                                                V.[IDGRUPOVEICULO],

                                                                GV.[NOMEGRUPO]

                                                            FROM TBVEICULO AS V
                                                            INNER JOIN TBGRUPOVEICULO AS GV

                                                                ON V.IDGRUPOVEICULO = GV.ID

                                                            WHERE V.PLACA = @PLACAVEICULO";

            repositorioVeiculo.PropriedadeParametro = "PLACAVEICULO";

            var veiculoEncontrado = repositorioVeiculo.SelecionarPorParametro(repositorioVeiculo.PropriedadeParametro, veiculo);

            return veiculoEncontrado != null &&
                   veiculoEncontrado.Placa.Equals(veiculo.Placa) &&
                  !veiculoEncontrado.Id.Equals(veiculo.Id);
        }

    }
}
        

