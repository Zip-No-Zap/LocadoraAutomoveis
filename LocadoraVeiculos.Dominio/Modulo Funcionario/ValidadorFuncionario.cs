using FluentValidation;


namespace LocadoraVeiculos.Dominio.Modulo_Funcionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("'Nome' não pode ser vazio");
            RuleFor(x => x.Salario).NotEmpty().WithMessage("'Nome' não pode ser vazio");
            RuleFor(x => x.Login).NotEmpty().WithMessage("'Nome' não pode ser vazio");
            RuleFor(x => x.Senha).NotEmpty().WithMessage("'Nome' não pode ser vazio");
            RuleFor(x => x.Cidade).NotEmpty().WithMessage("'Nome' não pode ser vazio");
            RuleFor(x => x.Estado).NotEmpty().WithMessage("'Nome' não pode ser vazio");
            RuleFor(x => x.Perfil).NotNull().WithMessage("'Nome' não pode ser nulo");
            RuleFor(x => x.DataAdmissao).NotNull().WithMessage("'Nome' não pode ser nulo");
        }
    }
}
