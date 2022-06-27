using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Funcionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculos.BancoDados.Tests
{
    [TestClass]
    public class RepositorioFuncionarioBancoDadosTests
    {
        RepositorioFuncionarioEmBancoDados repoFunc;
        protected string sql_insercao
        {
            get => @"INSERT INTO TBFUNCIONARIO 
                                    (
                                            [NOME],    
                                            [LOGIN],
                                            [SENHA],
                                            [SALARIO],
                                            [DATAADMISSAO],
                                            [CIDADE],
                                            [ESTADO],
                                            [PERFIL]
                                    )
                                    VALUES
                                    (
                                            @NOME,
                                            @LOGIN,
                                            @SENHA,
                                            @SALARIO,
                                            @DATAADMISSAO,
                                            @CIDADE,
                                            @ESTADO,
                                            @PERFIL

                                    );SELECT SCOPE_IDENTITY();";
        }
        protected string sql_edicao
        {
            get =>
                                @"UPDATE [TBFUNCIONARIO] SET 

                                    [NOME] = @NOME,    
	                                [LOGIN] = @LOGIN,
                                    [SENHA] = @SENHA,
                                    [SALARIO] = @SALARIO,
                                    [DATAADMISSAO] = @DATAADMISSAO,
                                    [CIDADE] = @CIDADE,
                                    [ESTADO] = @ESTADO

                               WHERE
		                             ID = @ID";
        }
        protected string sql_exclusao
        {
            get => @"DELETE FROM TBFUNCIONARIO WHERE ID = @ID;";
        }
        protected string sql_selecao_por_id
        {
            get => @"SELECT * FROM TBFUNCIONARIO WHERE ID = @ID";
        }
        protected string sql_selecao_todos
        {
            get => @"SELECT * FROM TBFUNCIONARIO";
        }

        public RepositorioFuncionarioBancoDadosTests()
        {
            repoFunc = new();
        }

        [TestMethod]
        public void Deve_inserir_funcionario()
        {
            //arrange
            Funcionario funcionario = InstanciarFuncionario();

            //action
            var resultado = repoFunc.Inserir(funcionario, sql_insercao);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }

        [TestMethod]
        public void Deve_editar_funcionario()
        {
            //arrange
            var funcionario = InstanciarFuncionario();
            Funcionario selecionado = repoFunc.SelecionarPorId(funcionario, sql_selecao_por_id);

            funcionario.Nome = "Foi alterado no teste";
            funcionario.Salario = 9000;

            //action
            var resultado = repoFunc.Editar(funcionario, sql_edicao);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            //arrange
            var funcionario = InstanciarFuncionario();

            repoFunc.Inserir(funcionario, sql_insercao);

            //action
            var resultado = repoFunc.Excluir(funcionario, sql_exclusao);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }

        [TestMethod]
        public void Deve_selecionarTodos_funcionario()
        {
            //arrange


            //action
            var resultado = repoFunc.SelecionarTodos(sql_selecao_todos);

            //assert
            Assert.AreNotEqual(0, resultado.Count);
        }

        #region privados

        Funcionario InstanciarFuncionario()
        {
            return new Funcionario()
            {
                Nome = "nome teste",
                Cidade = "cidade teste",
                Estado = "UF",
                Salario = 123456,
                DataAdmissao = DateTime.Parse("12/12/2021"),
                Login = "loginteste",
                Senha = "senhateste",
                Perfil = "Administrador"
                
            };
        }
            

        #endregion
    }
}
