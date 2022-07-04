using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Condutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.BancoDados.Tests.Modulo_Condutor
{
    [TestClass]
    public class RepositorioCondutorEmBancoDadosTests
    {
        RepositorioCondutorEmBancoDados repositorioCondutor;
        public RepositorioCondutorEmBancoDadosTests()
        {
            repositorioCondutor = new();
        }

        [TestMethod]
        public void Deve_inserir_condutor()
        {
            //arrange
            Condutor condutor = InstanciarCondutor();

            //action
            repositorioCondutor.Inserir(condutor);

            //assert
            var resultado = repositorioCondutor.SelecionarPorId(condutor.Id);

            Assert.IsNotNull(resultado);
        }

    }
}
