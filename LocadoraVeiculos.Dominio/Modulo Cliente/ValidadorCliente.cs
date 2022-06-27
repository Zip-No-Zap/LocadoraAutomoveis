using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;


namespace LocadoraVeiculos.Dominio.Modulo_Cliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("Campo 'Nome' é obrigatório.")
                .NotEmpty().WithMessage("Campo 'Nome' é obrigatótio.");

            RuleFor(x => x.Cpf)
              .MaximumLength(11)
              .WithMessage("'CPF' inválido.");

            RuleFor(x => x.Cnpj)
              .MaximumLength(14)
              .WithMessage("'CNPJ' inválido.");

            RuleFor(x => x.Endereco)
              .NotNull().WithMessage("Campo 'Endereço' é obrigatório.")
              .NotEmpty().WithMessage("Campo 'Endereço' é obrigatório.");

            RuleFor(x => x.Email)
             .EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("'Email' formato incorreto")
             .NotNull().NotEmpty().WithMessage("'Email' formato incorreto");

            RuleFor(x => x.Telefone)
               //.Matches(@"((?\d{2})?\s)?(\d{4,5}-\d{4})").WithMessage("'Telefone' com formato incorreto.")
               .MaximumLength(16).WithMessage("'Telefone' formato incorreto")
               .NotEmpty().WithMessage("'Telefone' formato incorreto")
               .NotNull().WithMessage("'Telefone' formato incorreto")
               .NotEqual("(  )      -");

            RuleFor(x => x.Cnh)
                .NotNull().NotEmpty()
                .MaximumLength(12)
                .WithMessage("'CNH' inválido.");

        }
    }
}
