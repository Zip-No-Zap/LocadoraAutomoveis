using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using System.Collections.Generic;
using FluentValidation.Results;
using FluentResults;
using System.Linq;
using Serilog;
using System;


namespace LocadoraAutomoveis.Aplicacao.ModuloLocacao
{
    public class ServicoLocacao
    {
        readonly RepositorioLocacaoOrm repositorioLocacao;
        readonly IContextoPersistencia contextoPersistOrm;
        ValidadorLocacao validadorLocacao;

        public ServicoLocacao(RepositorioLocacaoOrm repositorioLocacao, IContextoPersistencia contextoPersistOrm)
        {
            this.repositorioLocacao = repositorioLocacao;
            this.contextoPersistOrm = contextoPersistOrm;
        }

        public Result<Locacao> Inserir(Locacao locacao)
        {
            Log.Logger.Debug("Tentando inserir Locaçãao... {@locacao}", locacao);

            var resultadoValidacao = Validar(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {

                    Log.Logger.Warning("Falha ao tentar inserir Locação. {locacao} -> Motivo: {erro}", locacao.Id, erro.Message);

                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Inserir(locacao);  // RepositorioLocacaoOrm

                contextoPersistOrm.GravarDados(); // LocadoraAutomoviesDbContext / SaveChanges()

                Log.Logger.Information("Locacao inserido com sucesso. {@locacao}", locacao);

                return Result.Ok(locacao);
            }
            catch (Exception ex)
            {
         //       contextoPersistOrm.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar inserir Locação";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> Editar(Locacao locacao)
        {
            Log.Logger.Debug("Tentando editar Locação... {@locacao}", locacao);

            Result resultadoValidacao = Validar(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {

                    Log.Logger.Warning("Falha ao tentar editar Locação. {locaocaoId} -> Motivo: {erro}", locacao.Id, erro.Message);

                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Editar(locacao);

                contextoPersistOrm.GravarDados();

                Log.Logger.Information("Locacao. {locacaoId} editado com sucesso", locacao.Id);

                return Result.Ok(locacao);
            }
            catch (Exception ex)
            {
                contextoPersistOrm.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar editar Locacao";

                Log.Logger.Error(ex, msgErro + "{locacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Locacao locacao)
        {
            Log.Logger.Debug("Tentando excluir Locação... {@locacao}", locacao);

            try
            {
                repositorioLocacao.Excluir(locacao);

                contextoPersistOrm.GravarDados();

                Log.Logger.Information("locação {locacaoId} excluída com sucesso", locacao.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistOrm.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar excluir a lcoação";

                Log.Logger.Error(ex, msgErro + "{locacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Locacao>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarTodos(true));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todas as locações";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar a locação";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", id);

                return Result.Fail(msgErro);
            }
        }

        public Result Validar(Locacao locacao)
        {

            validadorLocacao = new ValidadorLocacao();

            var resultadoValidacao = validadorLocacao.Validate(locacao);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (ClienteDuplicado(locacao))
                erros.Add(new Error("Cliente duplicado"));

            if (CondutorDuplicado(locacao))
                erros.Add(new Error("Condutor duplicado"));

            if (VeiculoDuplicado(locacao))
                erros.Add(new Error("Veículo duplicado"));

            if (CnhVencido(locacao))
                erros.Add(new Error("CNH vencido"));

            if (VeiculoIndisponivel(locacao))
                erros.Add(new Error($"Veículo indisponível para locação. Status: {locacao.VeiculoLocacao.StatusVeiculo}"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        #region privates

        private bool ClienteDuplicado(Locacao locacao)
        {
            var clienteEncontrado = repositorioLocacao.SelecionarPorCliente(locacao.ClienteLocacao);

            return clienteEncontrado != null &&
                   clienteEncontrado.ClienteLocacao.Equals(locacao.ClienteLocacao) &&
                  !clienteEncontrado.Id.Equals(locacao.Id);
        }

        private bool CondutorDuplicado(Locacao locacao)
        {
            var condutorEncontrado = repositorioLocacao.SelecionarPorCondutor(locacao.CondutorLocacao);

            return condutorEncontrado != null &&
                   condutorEncontrado.CondutorLocacao.Equals(locacao.CondutorLocacao) &&
                  !condutorEncontrado.Id.Equals(locacao.Id);
        }

        private bool VeiculoDuplicado(Locacao locacao)
        {
            var veiculoEncontrado = repositorioLocacao.SelecionarPorVeiculo(locacao.VeiculoLocacao);

            return veiculoEncontrado != null &&
                   veiculoEncontrado.VeiculoLocacao.Equals(locacao.VeiculoLocacao) &&
                  !veiculoEncontrado.Id.Equals(locacao.Id);
        }

        private bool CnhVencido(Locacao locacao)
        {
            var locacaoEncontrada = repositorioLocacao.SelecionarPorCondutor(locacao.CondutorLocacao);

            if (locacaoEncontrada != null && locacaoEncontrada.CondutorLocacao.VencimentoCnh < DateTime.Today)
                return true;

            return false;
        }

        private bool VeiculoIndisponivel(Locacao locacao)
        {
            var locacaoEncontrada = repositorioLocacao.SelecionarPorVeiculo(locacao.VeiculoLocacao);

            if (locacaoEncontrada != null && locacaoEncontrada.VeiculoLocacao.StatusVeiculo != "Disponível")
                return true;

            return false;
        }

        #endregion
    }
}
