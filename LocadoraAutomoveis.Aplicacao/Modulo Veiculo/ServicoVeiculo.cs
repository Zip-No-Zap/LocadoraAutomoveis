using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Veiculo;
using Serilog;
using System.Collections.Generic;

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

        public ValidationResult Inserir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando inserir Veículo... {@veiculo}", veiculo);
            var resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculo.Inserir(veiculo);
                Log.Logger.Information("Veículo inserido com sucesso. {@veiculo}", veiculo);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    Log.Logger.Warning("Falha ao tentar inserir Veículo. {VeiculoModelo} -> Motivo: {erro}", veiculo.Modelo, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando editar Veículo... {@veiculo}", veiculo);
            var resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculo.Editar(veiculo);
                Log.Logger.Information("Veículo editado com sucesso. {@veiculo}", veiculo);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    Log.Logger.Warning("Falha ao tentar editar Veículo. {VeiculoModelo} -> Motivo: {erro}", veiculo.Modelo, erro.ErrorMessage);


            return resultadoValidacao;
        }

        public void Excluir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando excluir Veículo... {@veiculo}", veiculo);
            repositorioVeiculo.Excluir(veiculo);

            var veiculoExcluido = SelecionarPorId(veiculo.Id);

            if (veiculoExcluido == null)
                Log.Logger.Information("Veiculo excluído com sucesso. {@veiculo} -> ", veiculo);
            else
                Log.Logger.Warning("Falha ao excluír Veículo. {Veiculo} -> Motivo: {erro}", veiculo);
        }

        public List<Veiculo> SelecionarTodos()
        {
            Log.Logger.Debug("Tentando obter todos Veiculo...");

            var veiculos = repositorioVeiculo.SelecionarTodos();

            if (veiculos.Count > 0)
            {
                Log.Logger.Information("Todos os veiculos foram obtidos com sucesso. {VeiculosCount}", veiculos.Count);
                return veiculos;
            }
            else
            {
                Log.Logger.Warning("Falha ao tentar obter todos Veiculo. {VeiculosCount} -> ", veiculos.Count);
                return veiculos;
            }
        }

        public Veiculo SelecionarPorId(int id)
        {
            Log.Logger.Debug("Tentando obter um veiculo...");

            var veiculo = repositorioVeiculo.SelecionarPorId(id);

            if (veiculo != null)
            {
                Log.Logger.Information("Veículo foi obtido com sucesso.");
                return veiculo;
            }
            else
            {
                Log.Logger.Warning("Falha ao tentar obter um veículo. {Veiculo}");
                return veiculo;
            }
        }

        public ValidationResult Validar(Veiculo veiculo)
        {
            validadorVeiculo = new ValidadorVeiculo();

            var resultadoValidacao = validadorVeiculo.Validate(veiculo);

            if (PlacaDuplicada(veiculo))
                resultadoValidacao.Errors.Add(new ValidationFailure("Placa", "'Placa' duplicada"));

            return resultadoValidacao;
        }

        #region privates

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

        #endregion
    }
}
