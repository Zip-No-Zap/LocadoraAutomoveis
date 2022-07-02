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

        public void Excluir(Plano plano)
        {
            repositorioPlano.Excluir(plano);
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

            if (PlanoDiarioDuplicado(plano))
                resultadoValidacao.Errors.Add(new ValidationFailure("ValorDiario_Diario", "''Valor Diário' do Plano Diário' duplicado"));

            if (PlanoLivreDuplicado(plano))
                resultadoValidacao.Errors.Add(new ValidationFailure("ValorDiario_Livre", "''Valor Diário' do Plano Livre' duplicado"));

            if (PlanoControladoDuplicado(plano))
                resultadoValidacao.Errors.Add(new ValidationFailure("ValorDiario_Controlado", "''Valor Diário' do Plano Controaldo' duplicado"));

            return resultadoValidacao;
        }

        #region privates
        private bool PlanoDiarioDuplicado(Plano plano)
        {
            repositorioPlano.Sql_selecao_por_parametro = @"SELECT * FROM TBPLANO WHERE VALORDIARIO_DIARIO = @VALORDIARIODIARIO";
            repositorioPlano.PropriedadeDominioAValidar = "VALORDIARIODIARIO";

            var planoEncontrado = repositorioPlano.SelecionarPorParametro(repositorioPlano.PropriedadeDominioAValidar, plano);

            return planoEncontrado != null &&
                   planoEncontrado.ValorDiario_Diario.Equals(plano.ValorDiario_Diario) &&
                   planoEncontrado.Grupo.Nome.Equals(plano.Grupo.Nome) &&
                   planoEncontrado.ValorPorKm_Diario.Equals(plano.ValorPorKm_Diario) &&
                  !planoEncontrado.Id.Equals(plano.Id);
        }

        private bool PlanoLivreDuplicado(Plano plano)
        {
            repositorioPlano.Sql_selecao_por_parametro = @"SELECT * FROM TBPLANO WHERE VALORDIARIO_LIVRE = @VALORDIARIOLIVRE";
            repositorioPlano.PropriedadeDominioAValidar = "VALORDIARIOLIVRE";

            var planoEncontrado = repositorioPlano.SelecionarPorParametro(repositorioPlano.PropriedadeDominioAValidar, plano);

            return planoEncontrado != null &&
                   planoEncontrado.ValorDiario_Livre.Equals(plano.ValorDiario_Livre) &&
                   planoEncontrado.Grupo.Nome.Equals(plano.Grupo.Nome) &&
                  !planoEncontrado.Id.Equals(plano.Id);
        }

        private bool PlanoControladoDuplicado(Plano plano)
        {
            repositorioPlano.Sql_selecao_por_parametro = @"SELECT * FROM TBPLANO WHERE VALORDIARIO_CONTROLADO = @VALORDIARIOCONTROLADO";
            repositorioPlano.PropriedadeDominioAValidar = "VALORDIARIOCONTROLADO";

            var planoEncontrado = repositorioPlano.SelecionarPorParametro(repositorioPlano.PropriedadeDominioAValidar, plano);

            return planoEncontrado != null &&
                   planoEncontrado.ValorDiario_Controlado.Equals(plano.ValorDiario_Controlado) &&
                   planoEncontrado.Grupo.Nome.Equals(plano.Grupo.Nome) &&
                  !planoEncontrado.Id.Equals(plano.Id);
        }

        #endregion
    }
}
