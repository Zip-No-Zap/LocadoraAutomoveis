using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Plano;
using Serilog;
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
            Log.Logger.Debug("Tentando inserir Plano... {@plano}", plano);
            var resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsValid)
            {
                repositorioPlano.Inserir(plano);
                Log.Logger.Information("Plano inserido com sucesso. {@plano}", plano);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                     Log.Logger.Warning("Falha ao tentar inserir Plano. {Plano} -> Motivo: {erro}", erro.ErrorMessage);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Plano plano)
        {
            Log.Logger.Debug("Tentando editar Plano... {@plano}", plano);
            var resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsValid)
            {
                repositorioPlano.Editar(plano);
                Log.Logger.Information("Plano editado com sucesso. {@plano}", plano);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    Log.Logger.Warning("Falha ao tentar editar Plano. {Plano} -> Motivo: {erro}", erro.ErrorMessage);


            return resultadoValidacao;
        }

        public void Excluir(Plano plano)
        {
            Log.Logger.Debug("Tentando excluir Plano... {@plano}", plano);
            repositorioPlano.Excluir(plano);

            var planoExcluido = SelecionarPorId(plano.Id);

            if (planoExcluido == null)
                Log.Logger.Information("Plano excluído com sucesso. {@plano} -> ", plano);
            else
                Log.Logger.Warning("Falha ao excluir Plano. {Plano} -> Motivo: {erro}", plano);
        }

        public List<Plano> SelecionarTodos()
        {
            Log.Logger.Debug("Tentando obter todos Plano...");

            var planos = repositorioPlano.SelecionarTodos();

            if (planos.Count > 0)
            {
                Log.Logger.Information("Todos os planos foram obtidos com sucesso. {PlanoCount}", planos.Count);
                return planos;
            }
            else
            {
                Log.Logger.Warning("Falha ao tentar obter todos Plano. {PlanosCount} -> ", planos.Count);
                return planos;
            }
        }

        public Plano SelecionarPorId(int id)
        {
            Log.Logger.Debug("Tentando obter um plano...");

            var plano = repositorioPlano.SelecionarPorId(id);

            if (plano != null)
            {
                Log.Logger.Information("Plano foi obtido com sucesso.", plano);
                return plano;
            }
            else
            {
                Log.Logger.Warning("Falha ao tentar obter um plano. {Plano} -> ", plano);
                return plano;
            }
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

                                                            ON PLANO.GRUPO_ID = GRUPO.ID 
                                            
                                                        WHERE VALORDIARIO_DIARIO = @VALORDIARIODIARIO";

            repositorioPlano.PropriedadeParametro = "VALORDIARIODIARIO";

            var planoEncontrado = repositorioPlano.SelecionarPorParametro(repositorioPlano.PropriedadeParametro, plano);

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
