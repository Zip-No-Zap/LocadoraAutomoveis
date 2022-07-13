using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Funcionario;
using Serilog;
using System;
using System.Collections.Generic;

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

        public ValidationResult Inserir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando inserir Funcionário... {@funcionario}", funcionario);

            var resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
            {
                repositorioFuncionario.Inserir(funcionario);
                Log.Logger.Information("Funcionário inserido com sucesso. {@funcionario}", funcionario);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    Log.Logger.Warning("Falha ao tentar inserir Funcionário. {FuncionarioNome} -> Motivo: {erro}", funcionario.Nome, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando editar Funcionário... {@funcionario}", funcionario);

            var resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
            {
                repositorioFuncionario.Editar(funcionario);
                Log.Logger.Information("Funcionário editado com sucesso. {@funcionario}", funcionario);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    Log.Logger.Warning("Falha ao tentar editar Funcionário. {FuncionarioNome} -> Motivo: {erro}", funcionario.Nome, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando excluir Funcionário... {@funcionario}", funcionario);

            var resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
            {
                repositorioFuncionario.Excluir(funcionario);
                Log.Logger.Information("Funcionário excluído com sucesso. {@funcionario}", funcionario);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    Log.Logger.Warning("Falha ao tentar excluir Funcionário. {FuncionarioNome} -> Motivo: {erro}", funcionario.Nome, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public List<Funcionario> SelecionarTodos()
        {
            Log.Logger.Debug("Tentando obter todos os funcionários...");

            var funcionarios = repositorioFuncionario.SelecionarTodos();

            if (funcionarios.Count > 0)
            {
                Log.Logger.Information("Todos os funcionários foram obtidos com sucesso. {FuncionarioCount}", funcionarios.Count);
                return funcionarios;
            }
            else
            {
                Log.Logger.Warning("Falha ao tentar obter todos os funcionários. {FuncionariosCount} -> ", funcionarios.Count);
                return funcionarios;
            }
        }

        public Funcionario SelecionarPorId(Guid id)
        {
            Log.Logger.Debug("Tentando obter um funcionário...");

            var funcionario = repositorioFuncionario.SelecionarPorId(id);

            if (funcionario != null)
            {
                Log.Logger.Information("Funcionário foi obtido com sucesso.");
                return funcionario;
            }
            else
            {
                Log.Logger.Warning("Falha ao tentar obter um funcionário. {Funcionario}");
                return funcionario;
            }
        }

        public ValidationResult Validar(Funcionario funcionario)
        {
            validadorFuncionario = new ValidadorFuncionario();

            var resultadoValidacao = validadorFuncionario.Validate(funcionario);

            if (NomeDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "'Nome' duplicado"));

            if (LoginDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("Login", "'Login' duplicado"));

            return resultadoValidacao;
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
