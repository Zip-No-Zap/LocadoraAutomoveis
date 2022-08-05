using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloPlano;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using LocadoraAutomoveis.Infra.Orm.ModuloLocacao;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using System;
using LocadoraVeiculos.Infra.BancoDados;

namespace LocadoraAutomoveis.Aplicacao.Modulo_Plano
{
    public class ServicoPlano
    {
        readonly IRepositorioPlanoOrm repositorioPlano;
        readonly IRepositorioLocacaoOrm repositorioLocacao;
        readonly IContextoPersistencia contextoPersistOrm;
        ValidadorPlano validadorPlano;

        public ServicoPlano(IRepositorioPlanoOrm repositorioPlano, IContextoPersistencia contextoPersistOrm, IRepositorioLocacaoOrm repositorioLocacao)
        {
            this.repositorioPlano = repositorioPlano;
            this.contextoPersistOrm = contextoPersistOrm;
            this.repositorioLocacao = repositorioLocacao;
        }

        public Result<Plano> Inserir(Plano plano)
        {
            Log.Logger.Debug("Tentando inserir Plano... {@plano}", plano);

            var resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors) {

                    Log.Logger.Warning("Falha ao tentar inserir Plano. {plano} -> Motivo: {erro}", plano.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioPlano.Inserir(plano);  // RepositorioPlanoOrm

                contextoPersistOrm.GravarDados(); // LocadoraAutomoviesDbContext / SaveChanges()

                Log.Logger.Information("Plano inserido com sucesso. {@plano}", plano);

                return Result.Ok(plano);
            }
            catch (Exception ex)
            {
                contextoPersistOrm.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar inserir Plano";

                Log.Logger.Error(ex, msgErro + "{PlanoId}", plano.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Plano> Editar(Plano plano)
        {
            Log.Logger.Debug("Tentando editar Plano... {@grupo}", plano);
            
            Result resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors) {

                    Log.Logger.Warning("Falha ao tentar editar Plano. {planoId} -> Motivo: {erro}", plano.Id, erro.Message);

                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioPlano.Editar(plano);

                contextoPersistOrm.GravarDados();

                Log.Logger.Information("Plano. {planoId} editado com sucesso", plano.Id);
                
                return Result.Ok(plano);
            }
            catch(Exception ex)
            {
                contextoPersistOrm.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar editar Plano";

                Log.Logger.Error(ex, msgErro + "{planoId}", plano.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Plano plano)
        {
            Log.Logger.Debug("Tentando excluir Plano... {@grupo}", plano);

            if (VerificarRelacionamento(plano) == true)
            {
                try
                {
                    repositorioPlano.Excluir(plano);

                    contextoPersistOrm.GravarDados();

                    Log.Logger.Information("plano {planoId} excluído com sucesso", plano.Id);

                    return Result.Ok();
                }
                catch (Exception ex)
                {
                    contextoPersistOrm.DesfazerAlteracoes();

                    string msgErro = "Falha no sistema ao tentar excluir o Plano";

                    Log.Logger.Error(ex, msgErro + "{planoId}", plano.Id);

                    return Result.Fail(msgErro);
                }
            }
            else
            {
                string msgErro = "O plano está relacionado à outra tabela e não pode ser excluído";

                Log.Logger.Error(msgErro + "{Plano}", plano.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Plano>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioPlano.SelecionarTodos(true));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os planos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Plano> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioPlano.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o plano";

                Log.Logger.Error(ex, msgErro + "{PlanoId}", id);

                return Result.Fail(msgErro);
            }
        }

        public Result Validar(Plano plano)
        {
            validadorPlano = new ValidadorPlano();

            var resultadoValidacao = validadorPlano.Validate(plano);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (PlanoDiarioDuplicado(plano))
                erros.Add(new Error("Plano de Cobrança duplicado"));

            if (PlanoGrupoDuplicado(plano))
                erros.Add(new Error("Grupoo do plano duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        #region privates

        private bool PlanoDiarioDuplicado(Plano plano)
        {
            var planoEncontrado = repositorioPlano.SelecionarPorValor(plano.ValorDiario_Diario);

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

        private bool PlanoGrupoDuplicado(Plano plano)
        {
            var planoEncontrado = repositorioPlano.SelecionarPorGrupo(plano.Grupo.Nome);

            return planoEncontrado != null &&
                   planoEncontrado.Grupo.Nome.Equals(plano.Grupo.Nome) &&
                  !planoEncontrado.Id.Equals(plano.Id);
        }

        private bool VerificarRelacionamento(Plano plano)
        {
            bool resultado = false;

            var locacoes = repositorioLocacao.SelecionarTodos(true);

            resultado = locacoes.Any(x => x.PlanoLocacao.Id == (plano.Id));

            return resultado;
        }

        #endregion
    }
}
