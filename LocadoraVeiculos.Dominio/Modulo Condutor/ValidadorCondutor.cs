using FluentValidation;
using FluentValidation.Validators;
using LocadoraVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.Modulo_Condutor
{
    public class ValidadorCondutor : ValidadorBase<Condutor>
    {
        public ValidadorCondutor()
        {
            RuleFor(x => x.Cliente.Nome)
                .NotEmpty().WithMessage("Campo 'Cliente', é obrigatório")
                .NotNull().WithMessage("Campo 'Cliente', é obrigatório");

            RuleFor(x => x.Nome)
                .NotNull().WithMessage("Campo 'Nome' é obrigatório.")
                .NotEmpty().WithMessage("Campo 'Nome' é obrigatótio.")
                .MinimumLength(2).WithMessage("Campo 'Nome' inválido.");

            RuleFor(x => x.Cpf)
                .Custom((cpf, context) =>
                {
                    if (string.IsNullOrEmpty(cpf) == false)
                    {
                        if (Regex.IsMatch(cpf, @"^[0-9]{3}[.][0-9]{3}[.][0-9]{3}[-][0-9]{2}", RegexOptions.IgnoreCase) == false)
                            context.AddFailure("'CPF' inválido.");
                    }
                });

            RuleFor(x => x.Telefone)
               .Telefone()
               .NotEqual("(  )      -");

            RuleFor(x => x.Email)
            .EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("'Email' com formato incorreto")
            .NotNull().NotEmpty().WithMessage("'Email' com formato incorreto");

            RuleFor(x => x.Endereco)
              .NotNull().WithMessage("Campo 'Endereço' é obrigatório.")
              .NotEmpty().WithMessage("Campo 'Endereço' é obrigatório.");
         
            RuleFor(x => x.Cnh)
                .NotNull().NotEmpty()
                .MaximumLength(12)
                .WithMessage("'CNH' inválido.");

            RuleFor(x => x.VencimentoCnh)
                .NotEqual(DateTime.MinValue)
                .WithMessage("O campo 'Vencimento CNH' é obrigatório")
                .GreaterThan(DateTime.Now)
                .WithMessage("O campo 'Vencimento CNH' inválido");

        }
    }
}
