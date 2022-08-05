using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloCondutor;
using LocadoraAutomoveis.Infra.Orm.ModuloLocacao;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraAutomoveis.Aplicacao.Modulo_Condutor
{
    public class ServicoCondutor
    {
        readonly IRepositorioCondutorOrm repositorioCondutor;
        readonly IRepositorioLocacaoOrm repositorioLocacao;
        readonly IContextoPersistencia contextoPersistOrm;


        public ServicoCondutor(IRepositorioCondutorOrm repositorioCondutor, IContextoPersistencia contextoPersistOrm, IRepositorioLocacaoOrm repositorioLocacao)
        {
            this.contextoPersistOrm = contextoPersistOrm;
            this.repositorioCondutor = repositorioCondutor;
            this.repositorioLocacao = repositorioLocacao;
        }

        public Result<Condutor> Inserir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando inserir Condutor... {@condutor}", condutor);

            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Condutor. {CondutorId} -> Motivo: {erro}", condutor.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Inserir(condutor); // RepositorioCondutorOrm

                contextoPersistOrm.GravarDados();

                Log.Logger.Information("Condutor inserido com sucesso. {@condutor}", condutor);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                contextoPersistOrm.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar inserir Condutor.";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }

            return resultadoValidacao;
        }

        public Result<Condutor> Editar(Condutor condutor)
        {
            Log.Logger.Debug("Tentando editar Condutor... {@condutor}", condutor);

            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Condutor. {CondutorId} -> Motivo: {erro}", condutor.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Editar(condutor);

                contextoPersistOrm.GravarDados();

                Log.Logger.Information("Condutor editado com sucesso. {@condutor}", condutor);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                contextoPersistOrm.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar editar Condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando excluir Condutor... {@condutor}", condutor);

            if (VerificarRelacionamento(condutor) == false)
            {

                try
                {
                    repositorioCondutor.Excluir(condutor);

                    contextoPersistOrm.GravarDados();

                    Log.Logger.Information("Condutor excluído com sucesso. {@condutor}", condutor);

                    return Result.Ok();
                }
                catch (Exception ex)
                {
                    contextoPersistOrm.DesfazerAlteracoes();

                    string msgErro = "Falha ao tentar excluir Condutor.";

                    Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                    return Result.Fail(msgErro);
                }
            }
            else
            {
                string msgErro = "O condutor está relacionada à outra tabela e não pode ser excluída";

                Log.Logger.Error(msgErro + "{Condutor}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Condutor>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarTodos(true));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os condutores";
                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Condutor> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar condutor";

                Log.Logger.Error(ex, msgErro + "{condutorId}", id);

                return Result.Fail(msgErro);
            }
        }

        public Result Validar(Condutor condutor)
        {

            var validadorCondutor = new ValidadorCondutor();

            var resultadoValidacao = validadorCondutor.Validate(condutor);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation 
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "'Nome' duplicado"));

            if (CpfDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("Cpf", "'CPF' duplicado"));

            if (CnhDuplicada(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("Cnh", "'CNH' duplicada"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        #region Métodos privados


        private bool CnhDuplicada(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarPorCnh(condutor.Cnh);

            return condutorEncontrado != null &&
                   condutorEncontrado.Cnh.Equals(condutor.Cnh) &&
                  !condutorEncontrado.Id.Equals(condutor.Id);
        }

        private bool CpfDuplicado(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarPorCpf(condutor.Cpf);

            return condutorEncontrado != null &&
                   condutorEncontrado.Cpf.Equals(condutor.Cpf) &&
                  !condutorEncontrado.Id.Equals(condutor.Id);
        }

        private bool NomeDuplicado(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarPorNome(condutor.Nome);

            return condutorEncontrado != null &&
                   condutorEncontrado.Nome.Equals(condutor.Nome) &&
                  !condutorEncontrado.Id.Equals(condutor.Id);
        }

        private bool VerificarRelacionamento(Condutor condutor)
        {
            bool resultado = false;

            var condutores = repositorioLocacao.SelecionarTodos(true);

            resultado = condutores.Any(x => x.ItensTaxa.Equals(condutor));

            return resultado;
        }

        #endregion
    }
}
