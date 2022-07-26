using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloFuncionario;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraAutomoveis.Aplicacao.Modulo_Funcionario
{
    public class ServicoFuncionario
    {
        readonly RepositorioFuncionarioOrm repositorioFuncionario;
        readonly IContextoPersistencia contextoPersistOrm;
        ValidadorFuncionario validadorFuncionario;

        public ServicoFuncionario(RepositorioFuncionarioOrm repositorioFuncionario, IContextoPersistencia contextoPersistOrm)
        {
            this.repositorioFuncionario = repositorioFuncionario;
            this.contextoPersistOrm = contextoPersistOrm;
        }

        public Result<Funcionario> Inserir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando inserir Funcionário... {@funcionario}", funcionario);

            var resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Funcionário. {FuncionarioId} -> Motivo: {erro}", funcionario.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioFuncionario.Inserir(funcionario);

                contextoPersistOrm.GravarDados();

                Log.Logger.Information("Funcionário inserido com sucesso. {@funcionario}", funcionario);

                return Result.Ok(funcionario);

            }
            catch (Exception ex)
            {
                string msgErro = "Falha ao tentar inserir Funcionário.";
                Log.Logger.Error(ex, msgErro + "{FuncionarioId}",  funcionario.Id);
                return Result.Fail(msgErro);
            }

            return resultadoValidacao;
        }

        public Result<Funcionario> Editar(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando editar Funcionário... {@funcionario}", funcionario);

            var resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Funcionário. {FuncionarioId} -> Motivo: {erro}", funcionario.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioFuncionario.Editar(funcionario);

                contextoPersistOrm.GravarDados();

                Log.Logger.Information("Funcionário editado com sucesso. {@funcionario}", funcionario);

                return Result.Ok(funcionario);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha ao tentar editar Funcionário";

                Log.Logger.Error(ex, msgErro + "{FuncionarioId}", funcionario.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando excluir Funcionário... {@funcionario}", funcionario);

            try
            {
                repositorioFuncionario.Excluir(funcionario);

                contextoPersistOrm.GravarDados();

                Log.Logger.Information("Funcionário excluído com sucesso. {@funcionario}", funcionario);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha ao tentar excluir Funcionário.";

                Log.Logger.Error(ex, msgErro + "{FuncionarioId}", funcionario.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result< List<Funcionario> > SelecionarTodos()
        {
            try
            {
                return Result.Ok( repositorioFuncionario.SelecionarTodos(false) );
            }
            catch(Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os funcionários";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Funcionario> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioFuncionario.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar funcionário";

                Log.Logger.Error(ex, msgErro + "{FuncionarioId}", id);

                return Result.Fail(msgErro);
            }
        }

        public Result Validar(Funcionario funcionario)
        {
            validadorFuncionario = new ValidadorFuncionario();

            var resultadoValidacao = validadorFuncionario.Validate(funcionario);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation 
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "'Nome' duplicado"));

            if (LoginDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("Login", "'Login' duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }


        #region privates
        private bool LoginDuplicado(Funcionario funcionario)
        {
            var funcionarioEncontrado = repositorioFuncionario.SelecionarPorParametroLogin(funcionario.Login);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Login.Equals(funcionario.Login) &&
                  !funcionarioEncontrado.Id.Equals(funcionario.Id);
        }

        private bool NomeDuplicado(Funcionario funcionario)
        {
            var funcionarioEncontrado = repositorioFuncionario.SelecionarPorParametro(funcionario.Nome);

            return funcionarioEncontrado != null && 
                   funcionarioEncontrado.Nome.Equals(funcionario.Nome) && 
                  !funcionarioEncontrado.Id.Equals(funcionario.Id);
        }

        #endregion
    }
}
