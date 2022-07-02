using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Funcionario;
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
            var resultadoValidacao = Validar(funcionario);

            if(resultadoValidacao.IsValid)
                repositorioFuncionario.Inserir(funcionario);

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
            repositorioFuncionario.Sql_selecao_por_parametro = @"SELECT * FROM TBFUNCIONARIO WHERE LOGIN = @LOGIN";
            repositorioFuncionario.PropriedadeDominioAValidar = "login";

            var funcionarioEncontrado = repositorioFuncionario.SelecionarPorParametro(repositorioFuncionario.PropriedadeDominioAValidar, funcionario);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Login.Equals(funcionario.Login) &&
                  !funcionarioEncontrado.Id.Equals(funcionario.Id);
        }

        private bool NomeDuplicado(Funcionario funcionario)
        {
            repositorioFuncionario.Sql_selecao_por_parametro = @"SELECT * FROM TBFUNCIONARIO WHERE NOME = @NOME";
            repositorioFuncionario.PropriedadeDominioAValidar = "nome";

            var funcionarioEncontrado = repositorioFuncionario.SelecionarPorParametro(repositorioFuncionario.PropriedadeDominioAValidar, funcionario);

            return funcionarioEncontrado != null && 
                   funcionarioEncontrado.Nome.Equals(funcionario.Nome) && 
                  !funcionarioEncontrado.Id.Equals(funcionario.Id);
        }

        #endregion
    }
}
