using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Funcionario;
using System;

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


        #region private
        private bool LoginDuplicado(Funcionario funcionario)
        {
            repositorioFuncionario.sql_selecao_por_parametro = @"SELECT * FROM TBFUNCIONARIO WHERE LOGIN = @LOGIN";
            repositorioFuncionario.PropriedadeValidar = "login";

            var funcionarioEncontrado = repositorioFuncionario.SelecionarPorParametro(repositorioFuncionario.PropriedadeValidar, funcionario);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Login.Equals(funcionario.Login) &&
                  !funcionarioEncontrado.Id.Equals(funcionario.Id);
        }

        private bool NomeDuplicado(Funcionario funcionario)
        {
            repositorioFuncionario.sql_selecao_por_parametro = @"SELECT * FROM TBFUNCIONARIO WHERE NOME = @NOME";
            repositorioFuncionario.PropriedadeValidar = "nome";

            var funcionarioEncontrado = repositorioFuncionario.SelecionarPorParametro(repositorioFuncionario.PropriedadeValidar, funcionario);

            return funcionarioEncontrado != null && 
                   funcionarioEncontrado.Nome.Equals(funcionario.Nome) && 
                  !funcionarioEncontrado.Id.Equals(funcionario.Id);
        }

        #endregion
    }
}
