using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Infra.BancoDados.Modulo_GrupoVeiculo;
using System.Collections.Generic;

namespace LocadoraAutomoveis.Aplicacao.Modulo_GrupoVeiculo
{
    public class ServicoGrupoVeiculo
    {
        readonly RepositorioGrupoVeiculoEmBancoDados repositorioGrupoVeiculo;
        ValidadorGrupoVeiculo validadorGrupoVeiculo;


        public ServicoGrupoVeiculo(RepositorioGrupoVeiculoEmBancoDados repositorioGrupoVeiculo)
        {
            this.repositorioGrupoVeiculo = repositorioGrupoVeiculo;
        }

        public ValidationResult Inserir(GrupoVeiculo grupoVeiculo)
        {
            var resultadoValidacao = Validar(grupoVeiculo);

            if (resultadoValidacao.IsValid)
                repositorioGrupoVeiculo.Inserir(grupoVeiculo);

            return resultadoValidacao;
        }

        public ValidationResult Editar(GrupoVeiculo grupoVeiculo)
        {
            var resultadoValidacao = Validar(grupoVeiculo);

            if (resultadoValidacao.IsValid)
                repositorioGrupoVeiculo.Editar(grupoVeiculo);

            return resultadoValidacao;
        }

        public ValidationResult Excluir(GrupoVeiculo grupoVeiculo)
        {
            var resultadoValidacao = Validar(grupoVeiculo);

            if (resultadoValidacao.IsValid)
                repositorioGrupoVeiculo.Excluir(grupoVeiculo);

            return resultadoValidacao;
        }

        public List<GrupoVeiculo> SelecionarTodos()
        {
            return repositorioGrupoVeiculo.SelecionarTodos();
        }

        public GrupoVeiculo SelecionarPorId(int id)
        {
            return repositorioGrupoVeiculo.SelecionarPorId(id);
        }

        public ValidationResult Validar(GrupoVeiculo grupoVeiculo)
        {
            validadorGrupoVeiculo = new ValidadorGrupoVeiculo();

            var resultadoValidacao = validadorGrupoVeiculo.Validate(grupoVeiculo);

            if (NomeDuplicado(grupoVeiculo))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "'Nome' duplicado"));


            return resultadoValidacao;
        }


        #region privates

        private bool NomeDuplicado(GrupoVeiculo grupoVeiculo)
        {
            repositorioGrupoVeiculo.Sql_selecao_por_parametro = @"SELECT * FROM TBGRUPOVEICULO WHERE NOMEGRUPO = @NOME";
            repositorioGrupoVeiculo.PropriedadeDominioAValidar = "Nome";

            var funcionarioEncontrado = repositorioGrupoVeiculo.SelecionarPorParametro(repositorioGrupoVeiculo.PropriedadeDominioAValidar, grupoVeiculo);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Nome.Equals(grupoVeiculo.Nome) &&
                  !funcionarioEncontrado.Id.Equals(grupoVeiculo.Id);
        }

        #endregion
    }
}
