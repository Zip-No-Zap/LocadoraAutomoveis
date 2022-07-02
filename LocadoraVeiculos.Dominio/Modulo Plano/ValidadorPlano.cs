using LocadoraVeiculos.Dominio.Compartilhado;
using FluentValidation;

namespace LocadoraVeiculos.Dominio.Modulo_Plano
{
    public class ValidadorPlano : ValidadorBase<Plano>
    {
        public ValidadorPlano()
        {
            RuleFor(x => x.Descricao)
                .MinimumLength(2).WithMessage("'Descrição' não permite menos de 2 caracteres");

            RuleFor(x => x.ValorDiario_Diario)
                .GreaterThan(0).WithMessage("'Valor Diário' inválido");
            RuleFor(x => x.ValorPorKm_Diario)
                .GreaterThan(0).WithMessage("'Valor por Quilômetro' inválido");

            RuleFor(x => x.ValorDiario_Livre)
               .GreaterThan(0).WithMessage("'Valor Diário' inválido");

            RuleFor(x => x.ValorDiario_Controlado)
            .GreaterThan(0).WithMessage("'Valor Diário' inválido");
            RuleFor(x => x.ValorPorKm_Controlado)
                .GreaterThan(0).WithMessage("'Valor por Quilômetro' inválido");
            RuleFor(x => x.LimiteQuilometragem_Controlado)
                .GreaterThan(0).WithMessage("'Limite de Quilometragem' inválido");
        }
    }
}
