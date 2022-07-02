using LocadoraVeiculos.Dominio.Modulo_Plano;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LocadoraVeiculos.Dominio.Tests.Modulo_Plano
{
    [TestClass]
    public class MyTestClass
    {
        public MyTestClass()
        {

        }

        [TestMethod]
        public void Nao_deve_permitir_valor_diario_menor_um()
        {
            //arrange
            var plano = InstanciarPlano();

            plano.ValorDiario_Diario = 0;

            ValidadorPlano valida = new();

            //action
            var resultado = valida.Validate(plano);

            //assert
            Assert.AreEqual("'Valor Diário' inválido", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nao_deve_permitir_valor_por_km_menor_um()
        {
            //arrange
            var plano = InstanciarPlano();

            plano.ValorPorKm_Diario = 0;

            ValidadorPlano valida = new();

            //action
            var resultado = valida.Validate(plano);

            //assert
            Assert.AreEqual("'Valor por Quilômetro' inválido", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nao_deve_permitir_limite_quilometragem_menor_um()
        {
            //arrange
            var plano = InstanciarPlano();

            plano.LimiteQuilometragem_Controlado = 0;

            ValidadorPlano valida = new();

            //action
            var resultado = valida.Validate(plano);

            //assert
            Assert.AreEqual("'Limite de Quilometragem' inválido", resultado.Errors[0].ErrorMessage);
        }

        #region privates

        Plano InstanciarPlano()
        {
            return new Plano()
            {
                Grupo = new(),
                ValorDiario_Diario = 50,
                ValorPorKm_Diario = 35,

                ValorDiario_Livre = 30,

                ValorDiario_Controlado = 20,
                ValorPorKm_Controlado = 130,
                LimiteQuilometragem_Controlado = 200
            };
        }

        #endregion
    }
}
