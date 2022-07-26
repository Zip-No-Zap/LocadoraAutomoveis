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

        public Result<Locacao> Inserir(Locacao plano)
        {
            Log.Logger.Debug("Tentando inserir Locacao... {@plano}", plano);

            var resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {

                    Log.Logger.Warning("Falha ao tentar inserir Locacao. {plano} -> Motivo: {erro}", plano.Id, erro.Message);

                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Inserir(plano);  // RepositorioLocacaoOrm

                contextoPersistOrm.GravarDados(); // LocadoraAutomoviesDbContext / SaveChanges()

                Log.Logger.Information("Locacao inserido com sucesso. {@plano}", plano);

                return Result.Ok(plano);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha ao tentar inserir Locacao";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", plano.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> Editar(Locacao plano)
        {
            Log.Logger.Debug("Tentando editar Locacao... {@grupo}", plano);

            Result resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {

                    Log.Logger.Warning("Falha ao tentar editar Locacao. {planoId} -> Motivo: {erro}", plano.Id, erro.Message);

                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Editar(plano);

                contextoPersistOrm.GravarDados();

                Log.Logger.Information("Locacao. {planoId} editado com sucesso", plano.Id);

                return Result.Ok(plano);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha ao tentar editar Locacao";

                Log.Logger.Error(ex, msgErro + "{planoId}", plano.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Locacao plano)
        {
            Log.Logger.Debug("Tentando excluir Locacao... {@grupo}", plano);

            try
            {
                repositorioLocacao.Excluir(plano);

                contextoPersistOrm.GravarDados();

                Log.Logger.Information("plano {planoId} excluído com sucesso", plano.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o Locacao";

                Log.Logger.Error(ex, msgErro + "{planoId}", plano.Id);

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
                string msgErro = "Falha no sistema ao tentar selecionar todos os planos";

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
                string msgErro = "Falha no sistema ao tentar selecionar o plano";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", id);

                return Result.Fail(msgErro);
            }
        }

        public Result Validar(Locacao plano)
        {

            validadorLocacao = new ValidadorLocacao();

            var resultadoValidacao = validadorLocacao.Validate(plano);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (LocacaoDuplicada(plano))
                erros.Add(new Error("Locacao de Cobrança duplicado"));

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
