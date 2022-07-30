using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloLocacao;
using LocadoraAutomoveis.Infra.Orm.ModuloTaxa;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraAutomoveis.Aplicacao.Modulo_Taxa
{
    public class ServicoTaxa
    {
        readonly RepositorioTaxaOrm repositorioTaxa;
        readonly RepositorioLocacaoOrm repositorioLocacao;
        readonly IContextoPersistencia contextoPersistOrm;
        ValidadorTaxa validadorTaxa;

        public ServicoTaxa(RepositorioTaxaOrm repositorioTaxa, IContextoPersistencia contextoPersistOrm, RepositorioLocacaoOrm repositorioLocacao)
        {
            this.repositorioTaxa = repositorioTaxa;
            this.contextoPersistOrm = contextoPersistOrm;
            this.repositorioLocacao = repositorioLocacao;
        }

        public Result<Taxa> Inserir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando inserir Taxa... {@taxa}", taxa);

            var resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {

                    Log.Logger.Warning("Falha ao tentar inserir Taxa. {Taxa} -> Motivo: {erro}", taxa.Id, erro.Message);

                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioTaxa.Inserir(taxa);

                contextoPersistOrm.GravarDados();

                Log.Logger.Information("Taxa inserida com sucesso. {@taxa}", taxa);


                return Result.Ok(taxa);
            }
            catch (Exception ex)
            {
                contextoPersistOrm.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar inserir Taxa";

                Log.Logger.Error(ex, msgErro + "{taxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Taxa> Editar(Taxa taxa)
        {
            Log.Logger.Debug("Tentando editar Taxa... {@taxa}", taxa);

            Result resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {

                    Log.Logger.Warning("Falha ao tentar editar Taxa. {taxaId} -> Motivo: {erro}", taxa.Id, erro.Message);

                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioTaxa.Editar(taxa);

                contextoPersistOrm.GravarDados();

                Log.Logger.Information("Taxa. {taxaId} editado com sucesso", taxa.Id);


                return Result.Ok(taxa);
            }
            catch (Exception ex)
            {
                contextoPersistOrm.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar editar Taxa";

                Log.Logger.Error(ex, msgErro + "{taxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando excluir Taxa... {@taxa}", taxa);

            if (VerificarRelacionamento(taxa) == false)
            {

                try
                {
                    repositorioTaxa.Excluir(taxa);

                    contextoPersistOrm.GravarDados();

                    Log.Logger.Information("taxa {taxaId} excluída com sucesso", taxa.Id);

                    return Result.Ok();
                }
                catch (Exception ex)
                {
                    contextoPersistOrm.DesfazerAlteracoes();

                    string msgErro = "Falha no sistema ao tentar excluir Taxa";

                    Log.Logger.Error(ex, msgErro + "{taxa}", taxa.Id);

                    return Result.Fail(msgErro);
                }
            }
            else
            {
                string msgErro = "A taxa está relacionada à outra tabela e não pode ser excluída";

                Log.Logger.Error(msgErro + "{GrupoVeiculo}", taxa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Taxa>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioTaxa.SelecionarTodos(false));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todas as Taxas";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Taxa> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioTaxa.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", id);

                return Result.Fail(msgErro);
            }
        }

        public Result Validar(Taxa taxa)
        {
            validadorTaxa = new ValidadorTaxa();

            var resultadoValidacao = validadorTaxa.Validate(taxa);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (DescricaoDuplicado(taxa))
                erros.Add(new Error("'Descrição' duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        #region privates
       
        private bool DescricaoDuplicado(Taxa taxa)
        {
            var TaxaEncontrado = repositorioTaxa.SelecionarPorDescricao(taxa.Descricao);

            return TaxaEncontrado != null &&
                   TaxaEncontrado.Descricao.Equals(taxa.Descricao) &&
                  !TaxaEncontrado.Id.Equals(taxa.Id);
        }

        private bool VerificarRelacionamento(Taxa taxa)
        {
            bool resultado = false;

            var locacoes = repositorioLocacao.SelecionarTodos();
          
            resultado = locacoes.Any(x => x.ItensTaxa.Equals(taxa));

            return resultado;
        }

        #endregion
    }
}
