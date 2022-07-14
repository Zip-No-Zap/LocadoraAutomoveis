using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Funcionario;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraAutomoveis.Aplicacao.Modulo_Funcionario
{
    public class ServicoFuncionario
    {
        readonly RepositorioFuncionarioEmBancoDados repositorioFuncionario;
        ValidadorFuncionario validadorFuncionario;

        public ServicoFuncionario(RepositorioFuncionarioEmBancoDados repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
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
               return Result.Ok( repositorioFuncionario.SelecionarTodos() );
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
            repositorioFuncionario.Sql_selecao_por_parametro = @"SELECT * FROM TBFUNCIONARIO WHERE LOGIN = @LOGINFUNCIONARIO";
            repositorioFuncionario.PropriedadeParametro = "LOGINFUNCIONARIO";

            var funcionarioEncontrado = repositorioFuncionario.SelecionarPorParametro(repositorioFuncionario.PropriedadeParametro, funcionario);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Login.Equals(funcionario.Login) &&
                  !funcionarioEncontrado.Id.Equals(funcionario.Id);
        }

        private bool NomeDuplicado(Funcionario funcionario)
        {
            repositorioFuncionario.Sql_selecao_por_parametro = @"SELECT * FROM TBFUNCIONARIO WHERE NOME = @NOMEFUNCIOINARIO";
            repositorioFuncionario.PropriedadeParametro = "NOMEFUNCIOINARIO";

            var funcionarioEncontrado = repositorioFuncionario.SelecionarPorParametro(repositorioFuncionario.PropriedadeParametro, funcionario);

            return funcionarioEncontrado != null && 
                   funcionarioEncontrado.Nome.Equals(funcionario.Nome) && 
                  !funcionarioEncontrado.Id.Equals(funcionario.Id);
        }

        #endregion
    }
}
