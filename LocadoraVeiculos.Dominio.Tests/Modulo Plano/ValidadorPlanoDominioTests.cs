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
        public void Nao_deve_permitir_descricao_menos_dois_char()
        {
            //arrange
            var plano = InstanciarPlano();

            plano.Descricao = "l";

            ValidadorPlano valida = new();

            //action
            var resultado = valida.Validate(plano);

            //assert
            Assert.AreEqual("'Descrição' não permite menos de 2 caracteres", resultado.Errors[0].ErrorMessage);
        }
        
        [TestMethod]
        public void Nao_deve_permitir_valor_diario_menor_um()
        {
            //arrange
            var plano = InstanciarPlano();

            plano.ValorDiario = 0;

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

            plano.ValorPorKm = 0;

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

            plano.LimiteQuilometragem = 0;

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
                Descricao = "Livre",
                ValorDiario = 50,
                LimiteQuilometragem = 200,
                ValorPorKm = 30
            };
        }

        #endregion
    }
}
