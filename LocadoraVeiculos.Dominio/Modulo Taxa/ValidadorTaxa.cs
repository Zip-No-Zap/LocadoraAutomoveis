using FluentValidation;


namespace LocadoraVeiculos.Dominio.Modulo_Taxa
{
    public class ValidadorTaxa : AbstractValidator<Taxa>
    {
        public ValidadorTaxa()
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("'Descrição' não pode ser vazio");
            RuleFor(x => x.Valor).NotNull().WithMessage("'Valor' não pode ser nulo");
            RuleFor(x => x.Valor).GreaterThan(0).WithMessage("'Valor' não pode ser zero ou menos");
            RuleFor(x => x.Tipo).NotEmpty().WithMessage("'Tipo' não pode ser vazio");
        }
    }
}
