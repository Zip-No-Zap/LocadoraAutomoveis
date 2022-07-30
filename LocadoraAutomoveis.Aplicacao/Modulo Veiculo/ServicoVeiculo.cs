using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloVeiculo;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using System;
using LocadoraAutomoveis.Infra.Orm.ModuloLocacao;

namespace LocadoraAutomoveis.Aplicacao.Modulo_Veiculo
{
    public class ServicoVeiculo
    {
        readonly RepositorioVeiculoOrm repositorioVeiculo;
        readonly RepositorioLocacaoOrm repositorioLocacao;
        readonly IContextoPersistencia contextoPersistOrm;
        ValidadorVeiculo validadorVeiculo;

        public ServicoVeiculo(RepositorioVeiculoOrm repositorioVeiculo, IContextoPersistencia contextoPersistOrm, RepositorioLocacaoOrm repositorioLocacao)
        {
            this.repositorioVeiculo = repositorioVeiculo;
            this.contextoPersistOrm = contextoPersistOrm;
            this.repositorioLocacao = repositorioLocacao;
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

                contextoPersistOrm.GravarDados();

                Log.Logger.Information("Veículo inserido com sucesso. {@veiculo}", veiculo);


                return Result.Ok(veiculo);
            }

            catch (Exception ex)
            {
                contextoPersistOrm.DesfazerAlteracoes();

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

                contextoPersistOrm.GravarDados();

                Log.Logger.Information("Veículo . {VeiculoId} editado com sucesso", veiculo.Id);


                return Result.Ok(veiculo);
            }
            catch (Exception ex)
            {
                contextoPersistOrm.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar editar Veículo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando excluir Veículo... {@veiculo}", veiculo);

            if (VerificarRelacionamento(veiculo) == false)
            {
                try
                {
                    repositorioVeiculo.Excluir(veiculo);

                    contextoPersistOrm.GravarDados();

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
            else
            {
                string msgErro = "O veículo está relacionado à outra tabela e não pode ser excluído";

                Log.Logger.Error(msgErro + "{Veiculo}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Veiculo>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioVeiculo.SelecionarTodos(true));
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
            var veiculoEncontrado = repositorioVeiculo.SelecionarPorPlaca(veiculo.Placa);

            return veiculoEncontrado != null &&
                   veiculoEncontrado.Placa.Equals(veiculo.Placa) &&
                  !veiculoEncontrado.Id.Equals(veiculo.Id);
        }

        private bool VerificarRelacionamento(Veiculo veiculo)
        {
            bool resultado = false;

            var locacoes = repositorioLocacao.SelecionarTodos();

            resultado = locacoes.Any(x => x.VeiculoLocacao.Equals(veiculo));

            return resultado;
        }
    }
}
        

