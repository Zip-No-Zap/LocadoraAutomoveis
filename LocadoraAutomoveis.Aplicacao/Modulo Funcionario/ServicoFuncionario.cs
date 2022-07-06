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
            Log.Logger.Information("Tentando inserir Funcionário... {@funcionario}", funcionario);

            var resultadoValidacao = Validar(funcionario);

            if(resultadoValidacao.IsValid)
                repositorioFuncionario.Inserir(funcionario);
            else
                foreach (var erro in resultadoValidacao.Errors)
                      Log.Logger.Warning("Falha ao tentar inserir Funcionário! {FuncionarioNome} -> Motivo: {erro}", funcionario.Nome, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Funcionario funcionario)
        {
            var resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
                repositorioFuncionario.Editar(funcionario);

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Funcionario funcionario)
        {
            var resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
                repositorioFuncionario.Excluir(funcionario);

            return resultadoValidacao;
        }

        public List<Funcionario> SelecionarTodos()
        {
            return repositorioFuncionario.SelecionarTodos();
        }

        public Funcionario SelecionarPorId(int id)
        {
            return repositorioFuncionario.SelecionarPorId(id);
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
