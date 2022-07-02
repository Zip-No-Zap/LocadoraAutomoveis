using LocadoraVeiculos.Dominio.Compartilhado;
using FluentValidation;

namespace LocadoraVeiculos.Dominio.Modulo_Plano
{
    public class ValidadorPlano : ValidadorBase<Plano>
    {
        public ValidadorPlano()
        {
            RuleFor(x => x.ValorDiario_Diario)
                .GreaterThan(0).WithMessage("'Valor Diário' categoria: Diário, inválido")
                .NotEmpty().WithMessage("'Valor Diário' categoria: Diário, inválido");

            RuleFor(x => x.ValorPorKm_Diario)
                .GreaterThan(0).WithMessage("'Valor por Quilômetro' categoria: Diário, inválido")
                .NotEmpty().WithMessage("'Valor por Quilômetro' categoria: Diário, inválido");

            RuleFor(x => x.ValorDiario_Livre)
               .GreaterThan(0).WithMessage("'Valor Diário' categoria: Livre, inválido")
               .NotEmpty().WithMessage("'Valor Diário' categoria: Livre, inválido");

            RuleFor(x => x.ValorDiario_Controlado)
            .GreaterThan(0).WithMessage("'Valor Diário' categoria: Controlado, inválido")
            .NotEmpty().WithMessage("'Valor Diário' categoria: Controlado, inválido");

            RuleFor(x => x.ValorPorKm_Controlado)
                .GreaterThan(0).WithMessage("'Valor por Quilômetro' categoria: Controlado, inválido")
                .NotEmpty().WithMessage("'Valor por Quilômetro' categoria: Controlado, inválido");

            RuleFor(x => x.LimiteQuilometragem_Controlado)
                .GreaterThan(0).WithMessage("'Limite de Quilometragem' categoria: Controlado, inválido")
                .NotEmpty().WithMessage("'Valor por Quilômetro' categoria: Controlado, inválido");
        }
    }
}
