using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Taxa;
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
            var resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
                repositorioTaxa.Inserir(taxa);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa taxa)
        {
            var resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
                repositorioTaxa.Editar(taxa);

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Taxa taxa)
        {
            var resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
                repositorioTaxa.Excluir(taxa);

            return resultadoValidacao;
        }

        public List<Taxa> SelecionarTodos()
        {
            return repositorioTaxa.SelecionarTodos();
        }

        public Taxa SelecionarPorId(int id)
        {
            return repositorioTaxa.SelecionarPorId(id);
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
            repositorioTaxa.Sql_selecao_por_parametro = @"SELECT * FROM TBTAXA WHERE DESCRICAO = @DESCRICAO";

            repositorioTaxa.PropriedadeDominioAValidarParametro = "descricao";

            var TaxaEncontrado = repositorioTaxa.SelecionarPorParametro(repositorioTaxa.PropriedadeDominioAValidarParametro, taxa);

            return TaxaEncontrado != null &&
                   TaxaEncontrado.Descricao.Equals(taxa.Descricao) &&
                  !TaxaEncontrado.Id.Equals(taxa.Id);
        }

        #endregion
    }
}
