using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Taxa;
using Serilog;
using System.Collections.Generic;

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

        public ValidationResult Inserir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando inserir Taxa... {@taxa}", taxa);
            var resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Inserir(taxa);
                Log.Logger.Information("Taxa inserida com sucesso. {@taxa}", taxa);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    Log.Logger.Warning("Falha ao tentar inserir Taxa. {TaxaDescricao} -> Motivo: {erro}", taxa.Descricao, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa taxa)
        {
            var resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Editar(taxa);
                Log.Logger.Information("Taxa editada com sucesso. {@taxa}", taxa);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    Log.Logger.Warning("Falha ao tentar editar Taxa. {TaxaDescricao} -> Motivo: {erro}", taxa.Descricao, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Taxa taxa)
        {
            var resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Excluir(taxa);
                Log.Logger.Information("Taxa excluída com sucesso. {@taxa}", taxa);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    Log.Logger.Warning("Falha ao tentar excluir Taxa. {TaxaDescricao} -> Motivo: {erro}", taxa.Descricao, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public List<Taxa> SelecionarTodos()
        {
            Log.Logger.Debug("Tentando obter todos as taxas...");

            var taxas = repositorioTaxa.SelecionarTodos();

            if (taxas.Count > 0)
            {
                Log.Logger.Information("Todos as taxas foram obtidas com sucesso. {TaxaCount}", taxas.Count);
                return taxas;
            }
            else
            {
                Log.Logger.Warning("Falha ao tentar obter todos as taxas. {TaxaCount} -> ", taxas.Count);
                return taxas;
            }
        }

        public Taxa SelecionarPorId(int id)
        {
            Log.Logger.Debug("Tentando obter uma taxa...");

            var taxa = repositorioTaxa.SelecionarPorId(id);

            if (taxa != null)
            {
                Log.Logger.Information("Taxa foi obtida com sucesso.");
                return taxa;
            }
            else
            {
                Log.Logger.Warning("Falha ao tentar obter uma taxa. {Taxa}");
                return taxa;
            }
        }

        public ValidationResult Validar(Taxa taxa)
        {
            validadorTaxa = new ValidadorTaxa();

            var resultadoValidacao = validadorTaxa.Validate(taxa);

            if (DescricaoDuplicado(taxa))
                resultadoValidacao.Errors.Add(new ValidationFailure("Descricao", "'Descrição' duplicado"));

            return resultadoValidacao;
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
