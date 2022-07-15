using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Taxa;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraAutomoveis.Aplicacao.Modulo_Taxa
{
    public class ServicoTaxa
    {
        readonly RepositorioTaxaEmBancoDados repositorioTaxa;
        ValidadorTaxa validadorTaxa;

        public ServicoTaxa(RepositorioTaxaEmBancoDados repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
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
                Log.Logger.Information("Taxa inserida com sucesso. {@taxa}", taxa);


                return Result.Ok(taxa);
            }
            catch (Exception ex)
            {
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

                Log.Logger.Information("Taxa. {taxaId} editado com sucesso", taxa.Id);


                return Result.Ok(taxa);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha ao tentar editar Taxa";

                Log.Logger.Error(ex, msgErro + "{taxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando excluir Taxa... {@taxa}", taxa);

            try
            {
                repositorioTaxa.Excluir(taxa);

                Log.Logger.Information("taxa {taxaId} excluída com sucesso", taxa.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o Taxa";

                Log.Logger.Error(ex, msgErro + "{taxa}", taxa.Id);

                return Result.Fail(msgErro);

            }
        }

        public Result<List<Taxa>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioTaxa.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos as Taxas";

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
            repositorioTaxa.Sql_selecao_por_parametro = @"SELECT * FROM TBTAXA WHERE DESCRICAO = @DESCRICAOTAXA";

            repositorioTaxa.PropriedadeParametro = "DESCRICAOTAXA";

            var TaxaEncontrado = repositorioTaxa.SelecionarPorParametro(repositorioTaxa.PropriedadeParametro, taxa);

            return TaxaEncontrado != null &&
                   TaxaEncontrado.Descricao.Equals(taxa.Descricao) &&
                  !TaxaEncontrado.Id.Equals(taxa.Id);
        }

        #endregion
    }
}
