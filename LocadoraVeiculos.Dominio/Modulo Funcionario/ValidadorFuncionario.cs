using FluentValidation;
using System;

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
            RuleFor(x => x.DataAdmissao).GreaterThan(Convert.ToDateTime("1/1/1753")).WithMessage("'Data de Admissão' deve ser maior que 1/1/1753");
            RuleFor(x => x.DataAdmissao).LessThan(DateTime.Today).WithMessage("'Data de Admissão' deve ser menor que hoje");
        }

    }
}
