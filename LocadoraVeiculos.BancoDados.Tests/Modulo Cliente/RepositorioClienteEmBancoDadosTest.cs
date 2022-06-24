using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.BancoDados.Tests.Modulo_Cliente
{
    [TestClass]
    public class RepositorioClienteEmBancoDadosTest
    {
        RepositorioClienteEmBancoDados repositorio ;

        public RepositorioClienteEmBancoDadosTest()
        {
            repositorio = new RepositorioClienteEmBancoDados();
        }
        [TestMethod]
        public void Deve_inserir_cliete()
        {
            // arrange
            var cliente = InstanciarCliente();

            //action
            var resultado = repositorio.Inserir(cliente);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }
        [TestMethod]
        public void Deve_editar_cliete()
        {
            // arrange
            var cliente = InstanciarCliente();
            repositorio.Inserir(cliente);

            cliente.Nome = "Ana Beatriz";

            //action
            var resultado = repositorio.Editar(cliente);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }
        [TestMethod]
        public void Deve_excluir_cliente()
        {
            //arrange
            Cliente cliente = repositorio.SelecionarPorId(5);

            //action
            var resultado = repositorio.Excluir(cliente);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }
        [TestMethod]
        public void Deve_selecionar_todos()
        {

        }

        private Cliente InstanciarCliente()
        {
            
            return new Cliente()
            {
                Nome = "Ana",
                Cpf = "12345678978",
                Cnpj = " ",
                Cnh = "123123123123",
                Email = "anabeatriz@gmail.com",
                Endereco = "Lages - SC",
                Telefone = "11923121231",
            };
        }

    }
}
