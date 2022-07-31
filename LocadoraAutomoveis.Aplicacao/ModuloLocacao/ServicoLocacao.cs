using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;


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

            if (LocacaoDuplicada(locacao))
                erros.Add(new Error("Locacao duplicada"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        #region privates

        private bool LocacaoDuplicada(Locacao plano)
        {
            //var planoEncontrado = repositorioLocacao.SelecionarPorValor(plano.ValorDiario_Diario);

            //return planoEncontrado != null &&
            //       planoEncontrado.Grupo.Nome.Equals(plano.Grupo.Nome) &&
            //       planoEncontrado.ValorDiario_Diario.Equals(plano.ValorDiario_Diario) &&
            //       planoEncontrado.ValorPorKm_Diario.Equals(plano.ValorPorKm_Diario) &&

            //       planoEncontrado.ValorDiario_Livre.Equals(plano.ValorDiario_Livre) &&

            //       planoEncontrado.ValorDiario_Controlado.Equals(plano.ValorDiario_Controlado) &&
            //       planoEncontrado.ValorPorKm_Controlado.Equals(plano.ValorPorKm_Controlado) &&
            //       planoEncontrado.LimiteQuilometragem_Controlado.Equals(plano.LimiteQuilometragem_Controlado) &&

            //      !planoEncontrado.Id.Equals(plano.Id);
            return false;
        }

        #endregion
    }
}
