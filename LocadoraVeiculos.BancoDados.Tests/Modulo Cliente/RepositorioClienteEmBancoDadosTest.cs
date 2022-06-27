using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.BancoDados.Tests.Modulo_Cliente
{
    [TestClass]
    public class RepositorioClienteEmBancoDadosTest
    {
        RepositorioClienteEmBancoDados repositorioCliente;
       string sql_insercao => @"INSERT INTO TBCLIENTE 
                                                   (
                                                        [NOME],    
                                                        [CPF],
                                                        [CNPJ],   
                                                        [ENDERECO],
                                                        [TIPOCLIENTE],
                                                        [CNH],
                                                        [EMAIL],
                                                        [TELEFONE]  
                                                   )
                                                   VALUES
                                                   (
                                                        @NOME,    
                                                        @CPF,
                                                        @CNPJ,   
                                                        @ENDERECO,
                                                        @TIPOCLIENTE,
                                                        @CNH,
                                                        @EMAIL,
                                                        @TELEFONE

                                                   );SELECT SCOPE_IDENTITY();";
       string sql_edicao => @"UPDATE [TBCLIENTE] SET 

                                                        [NOME] = @NOME,
                                                        [CPF] = @CPF,
                                                        [CNPJ] = @CNPJ,
                                                        [ENDERECO] = @ENDERECO,
                                                        [TIPOCLIENTE] = @TIPOCLIENTE,
                                                        [CNH] = @CNH,
                                                        [EMAIL] = @EMAIL,
                                                        [TELEFONE] = @TELEFONE

                                                WHERE
		                                                ID = @ID";
       string sql_exclusao => @"DELETE FROM TBCLIENTE WHERE ID = @ID;";
       string sql_selecao_por_id => @"SELECT * FROM TBCLIENTE WHERE ID = @ID";
       string sql_selecao_todos => @"SELECT * FROM TBCLIENTE";

        public RepositorioClienteEmBancoDadosTest()
        {
            repositorioCliente = new RepositorioClienteEmBancoDados();
        }
        [TestMethod]
        public void Deve_inserir_cliente()
        {
            // arrange
            var cliente = InstanciarCliente();

            //action
            var resultado = repositorioCliente.Inserir(cliente, sql_insercao);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }
        [TestMethod]
        public void Deve_editar_cliente()
        {
            // arrange
            var cliente = InstanciarCliente();
            repositorioCliente.Inserir(cliente, sql_insercao);

            cliente.Nome = "Ana Beatriz";

            //action
            var resultado = repositorioCliente.Editar(cliente, sql_edicao);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }
        [TestMethod]
        public void Deve_excluir_cliente()
        {
            //arrange
            var cliente = InstanciarCliente();
            Cliente clienteSelecionado = repositorioCliente.SelecionarPorId(cliente, sql_selecao_por_id);

            //action
            var resultado = repositorioCliente.Excluir(clienteSelecionado, sql_exclusao);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }

        [TestMethod]
        public void Deve_selecionar_todos()
        {
            //arrange


            //action
            var resultado = repositorioCliente.SelecionarTodos(sql_selecao_todos);

            //assert
            Assert.AreNotEqual(0, resultado.Count);
        }

        [TestMethod]
        public void Deve_selecionar_unico()
        {
            //arrange
            var cliente = InstanciarCliente();

            //action
            var resultado = repositorioCliente.SelecionarPorId(cliente, sql_selecao_por_id);

            //assert
            Assert.AreNotEqual(null, resultado);
        }

        private Cliente InstanciarCliente()
        {
            
            return new Cliente()
            {
                Nome = "Ana",
                Cpf = "12345678978",
                Cnpj = "-",
                Cnh = "123123123123",
                Email = "anabeatriz@gmail.com",
                Endereco = "Lages - SC",
                Telefone = "11923121231",
            };
        }

    }
}
