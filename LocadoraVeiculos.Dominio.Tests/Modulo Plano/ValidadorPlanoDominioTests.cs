using LocadoraVeiculos.Dominio.Modulo_Plano;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LocadoraVeiculos.Dominio.Tests.Modulo_Plano
{
    [TestClass]
    public class ValidadorPlanoDominioTests
    {
        public ValidadorPlanoDominioTests()
        {

        }

        [TestMethod]
        public void Nao_deve_permitir_nome_grupo_vazio()
        {
            //arrange
            var plano = InstanciarPlano();
            plano.Grupo.Nome = "";

            plano.ValorDiario_Diario = 0;

            ValidadorPlano valida = new();

            //action
            var resultado = valida.Validate(plano);

            //assert
            Assert.AreEqual("'Grupo Veículo' é obrigatório", resultado.Errors[0].ErrorMessage);
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
            Assert.AreEqual("'Valor Diário' categoria: Diário, inválido", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nao_deve_permitir_valor_diario_vazio()
        {
            //arrange
            var plano = InstanciarPlano();

            plano.ValorDiario_Diario = 0;

            ValidadorPlano valida = new();

            //action
            var resultado = valida.Validate(plano);

            //assert
            Assert.AreEqual("'Valor Diário' categoria: Diário, inválido", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nao_deve_permitir_valor_por_km_rodado_diario_vazio()
        {
            //arrange
            var plano = InstanciarPlano();

            plano.ValorPorKm_Diario = 0;

            ValidadorPlano valida = new();

            //action
            var resultado = valida.Validate(plano);

            //assert
            Assert.AreEqual("'Valor por Km Rodado' categoria: Diário, inválido", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nao_deve_permitir_valor_diario_categoria_livre_vazio()
        {
            //arrange
            var plano = InstanciarPlano();

            plano.ValorDiario_Livre = 0;

            ValidadorPlano valida = new();

            //action
            var resultado = valida.Validate(plano);

            //assert
            Assert.AreEqual("'Valor Diário' categoria: Livre, inválido", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nao_deve_permitir_valor_por_km_contorlado_menor_um()
        {
            //arrange
            var plano = InstanciarPlano();

            plano.ValorPorKm_Diario = 0;

            ValidadorPlano valida = new();

            //action
            var resultado = valida.Validate(plano);

            //assert
            Assert.AreEqual("'Valor por Km Rodado' categoria: Diário, inválido", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nao_deve_permitir_valor_por_km_contorlado_vazio()
        {
            //arrange
            var plano = InstanciarPlano();

            plano.ValorPorKm_Controlado = 0;

            ValidadorPlano valida = new();

            //action
            var resultado = valida.Validate(plano);

            //assert
            Assert.AreEqual("'Valor por Km Rodado' categoria: Controlado, inválido", resultado.Errors[0].ErrorMessage);
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
            Assert.AreEqual("'Limite de Quilometragem' categoria: Controlado, inválido", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nao_deve_permitir_limite_quilometragem_vazio()
        {
            //arrange
            var plano = InstanciarPlano();

            plano.LimiteQuilometragem_Controlado = 0;

            ValidadorPlano valida = new();

            //action
            var resultado = valida.Validate(plano);

            //assert
            Assert.AreEqual("'Limite de Quilometragem' categoria: Controlado, inválido", resultado.Errors[0].ErrorMessage);
        }

        #region privates

        Plano InstanciarPlano()
        {
            return new Plano()
            {
                Grupo = new("Uber"),
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
