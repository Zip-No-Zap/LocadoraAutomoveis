using FluentValidation;


namespace LocadoraVeiculos.Dominio.Modulo_Funcionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("'Nome' não pode ser vazio");
            RuleFor(x => x.Salario).NotEmpty().WithMessage("'Salário' não pode ser vazio");
            RuleFor(x => x.Login).NotEmpty().WithMessage("'Login' não pode ser vazio");
            RuleFor(x => x.Senha).NotEmpty().WithMessage("'Senha' não pode ser vazio");
            RuleFor(x => x.Cidade).NotEmpty().WithMessage("'Cidade' não pode ser vazio");
            RuleFor(x => x.Estado).NotEmpty().WithMessage("'Estado' não pode ser vazio");
            RuleFor(x => x.Perfil).NotNull().WithMessage("'Perfil' não pode ser nulo");
            RuleFor(x => x.DataAdmissao).NotNull().WithMessage("'Data de Admissão' não pode ser nulo");
        }
    }
}
