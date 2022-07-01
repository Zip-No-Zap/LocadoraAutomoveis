using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Plano;
using System.Collections.Generic;

namespace LocadoraAutomoveis.Aplicacao.Modulo_Plano
{
    public class ServicoPlano
    {
        readonly RepositorioPlanoEmBancoDados repositorioPlano;
        ValidadorPlano validadorPlano;

        public ServicoPlano(RepositorioPlanoEmBancoDados repositorioPlano)
        {
            this.repositorioPlano = repositorioPlano;
        }

        public ValidationResult Inserir(Plano plano)
        {
            var resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsValid)
                repositorioPlano.Inserir(plano);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Plano plano)
        {
            var resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsValid)
                repositorioPlano.Editar(plano);

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Plano plano)
        {
            var resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsValid)
                repositorioPlano.Excluir(plano);

            return resultadoValidacao;
        }

        public List<Plano> SelecionarTodos()
        {
            return repositorioPlano.SelecionarTodos();
        }

        public Plano SelecionarPorId(int id)
        {
            return repositorioPlano.SelecionarPorId(id);
        }

        public ValidationResult Validar(Plano plano)
        {
            validadorPlano = new ValidadorPlano();

            var resultadoValidacao = validadorPlano.Validate(plano);

            if (PlanoDuplicado(plano))
                resultadoValidacao.Errors.Add(new ValidationFailure("Plano", "'Plano' duplicado"));

            return resultadoValidacao;
        }

        #region privates
        private bool PlanoDuplicado(Plano plano)
        {
            repositorioPlano.Sql_selecao_por_parametro = @"SELECT * FROM TBPLANO WHERE DESCRICAO = @DESCRICAO";
            repositorioPlano.PropriedadeValidar = "Descricao";

            var planoEncontrado = repositorioPlano.SelecionarPorParametro(repositorioPlano.PropriedadeValidar, plano);

            return planoEncontrado != null &&
                   planoEncontrado.Descricao.Equals(plano.Descricao) &&
                   planoEncontrado.Grupo.Nome.Equals(plano.Grupo.Nome) &&
                   planoEncontrado.ValorPorKm.Equals(plano.ValorPorKm) &&
                   planoEncontrado.LimiteQuilometragem.Equals(plano.LimiteQuilometragem) &&
                   planoEncontrado.ValorDiario.Equals(plano.ValorDiario) &&
                  !planoEncontrado.Id.Equals(plano.Id);
        }

        #endregion
    }
}
