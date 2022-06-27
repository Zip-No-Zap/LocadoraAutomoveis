using LocadoraVeiculos.Dominio.Modulo_Taxa;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Taxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LocadoraVeiculos.BancoDados.Tests.Modulo_Taxa
{
    [TestClass]
    public class RepositorioTaxaBancoDadosTests
    {
        RepositorioTaxaEmBancoDados repoTaxa;
       string sql_insercao => @"INSERT INTO TBTAXA
                                                   (
                                                        [DESCRICAO],    
                                                        [TIPO],
                                                        [VALOR]
                                                   )
                                                   VALUES
                                                   (
                                                        @DESCRICAO,
                                                        @TIPO,
                                                        @VALOR

                                                   );SELECT SCOPE_IDENTITY();";
       string sql_edicao => @"UPDATE [TBTAXA] SET 

                                                    [DESCRICAO] = @DESCRICAO, 
                                                    [TIPO] = @TIPO,
                                                    [VALOR] = @VALOR

                                                WHERE
		                                             ID = @ID";
       string sql_exclusao => @"DELETE FROM TBTAXA WHERE ID = @ID;";
       string sql_selecao_por_id => @"SELECT * FROM TBTAXA WHERE ID = @ID";
       string sql_selecao_todos => @"SELECT * FROM TBTAXA";

        public RepositorioTaxaBancoDadosTests()
        {
            repoTaxa = new();
        }

        [TestMethod]
        public void Deve_inserir_taxa()
        {
            //arrange
            var taxa = InstanciarTaxa();
            taxa.Descricao = "teste05";

            //action
            var resultado = repoTaxa.Inserir(taxa, sql_insercao);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }

        [TestMethod]
        public void Deve_editar_taxa()
        {
            //arrange
            var taxa = InstanciarTaxa();

            repoTaxa.Inserir(taxa, sql_insercao);

            taxa.Descricao = "alterado no teste";

            //action
            var resultado = repoTaxa.Editar(taxa, sql_edicao);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }

        [TestMethod]
        public void Deve_excluir_taxa()
        {
            //arrange
            var taxa = InstanciarTaxa();

            repoTaxa.Inserir(taxa, sql_insercao);

            //action
            var resultado = repoTaxa.Excluir(taxa, sql_exclusao);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }

        [TestMethod]
        public void Deve_selecionar_todos_taxa()
        {
            //arrange
            

            //action
            var resultado = repoTaxa.SelecionarTodos(sql_selecao_todos);

            //assert
            Assert.AreNotEqual(0, resultado.Count);
        }


        #region privados
        Taxa InstanciarTaxa()
        {
            return new Taxa()
            {
                Descricao = "descrição teste",
                Tipo = "Fixo",
                Valor = 120
            };
        }

#endregion
    }
}
