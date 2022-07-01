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

            RuleFor(x => x.ValorDiario)
                .GreaterThan(0).WithMessage("'Valor Diário' inválido");

            RuleFor(x => x.ValorPorKm)
                .GreaterThan(0).WithMessage("'Valor por Quilômetro' inválido");

            RuleFor(x => x.LimiteQuilometragem)
                .GreaterThan(0).WithMessage("'Limite de Quilometragem' inválido");
        }
    }
}
