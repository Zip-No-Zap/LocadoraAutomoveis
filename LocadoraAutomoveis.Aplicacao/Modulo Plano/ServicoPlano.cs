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
                resultadoValidacao.Errors.Add(new ValidationFailure("ValorDiario_Diario", "Plano de Cobrança duplicado"));

            return resultadoValidacao;
        }

        #region privates
        private bool PlanoDiarioDuplicado(Plano plano)
        {
            repositorioPlano.Sql_selecao_por_parametro = @"SELECT 
            
                                                            PLANO.[ID],
                                                            PLANO.[GRUPO_ID],
                                                            PLANO.[VALORDIARIO_DIARIO],
                                                            PLANO.[VALORPORKM_DIARIO],
                                                 
                                                            PLANO.[VALORDIARIO_LIVRE],
                                               
                                                            PLANO.[VALORDIARIO_CONTROLADO],
                                                            PLANO.[VALORPORKM_CONTROLADO],
                                                            PLANO.[LIMITEQUILOMETRAGEM_CONTROLADO],
                                                            
                                                            GRUPO.[NOMEGRUPO] AS GRUPO_NOME
                         
                                                        FROM TBPLANO AS PLANO

                                                            INNER JOIN TBGRUPOVEICULO AS GRUPO 

                                                            ON PLANO.GRUPO_ID = GRUPO.ID WHERE VALORDIARIO_DIARIO = @VALORDIARIODIARIO";

            repositorioPlano.PropriedadeDominioAValidarParametro = "VALORDIARIODIARIO";

            var planoEncontrado = repositorioPlano.SelecionarPorParametro(repositorioPlano.PropriedadeDominioAValidarParametro, plano);

            return planoEncontrado != null &&
                   planoEncontrado.Grupo.Nome.Equals(plano.Grupo.Nome) &&
                   planoEncontrado.ValorDiario_Diario.Equals(plano.ValorDiario_Diario) &&
                   planoEncontrado.ValorPorKm_Diario.Equals(plano.ValorPorKm_Diario) &&

                   planoEncontrado.ValorDiario_Livre.Equals(plano.ValorDiario_Livre) &&

                   planoEncontrado.ValorDiario_Controlado.Equals(plano.ValorDiario_Controlado) &&
                   planoEncontrado.ValorPorKm_Controlado.Equals(plano.ValorPorKm_Controlado) &&
                   planoEncontrado.LimiteQuilometragem_Controlado.Equals(plano.LimiteQuilometragem_Controlado) &&

                  !planoEncontrado.Id.Equals(plano.Id);
        }

        #endregion
    }
}
