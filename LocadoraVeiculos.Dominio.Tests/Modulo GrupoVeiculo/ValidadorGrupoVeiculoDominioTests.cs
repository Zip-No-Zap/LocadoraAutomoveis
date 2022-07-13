using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LocadoraVeiculos.Dominio.Tests.Modulo_GrupoVeiculo
{
    [TestClass]
    public class ValidadorGrupoVeiculoDominioTests
    {
        [TestMethod]
        public void NaoDeve_servazio_nome_grupo_veiculo()
        {

            var grupo = InstanciarGrupoVeiculo();

            grupo.Nome = "";

            ValidadorGrupoVeiculo validaGrupo = new();

            ValidationResult resultado = validaGrupo.Validate(grupo);

            Assert.AreEqual("'Nome' não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        #region instancia de grupo

        GrupoVeiculo InstanciarGrupoVeiculo()
        {
            return new GrupoVeiculo("Uber")
            {
            };
        }

        #endregion
    }
}
