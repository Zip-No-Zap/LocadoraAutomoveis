using FluentValidation;
using FluentValidation.Validators;
using LocadoraVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloCondutor
{
    public class ValidadorCondutor : ValidadorBase<Condutor>
    {
        public ValidadorCondutor()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("Campo 'Nome' é obrigatório.")
                .NotEmpty().WithMessage("Campo 'Nome' é obrigatótio.");

            RuleFor(x => x.Cpf)
             .Cpf();

            RuleFor(x => x.Endereco)
              .NotNull().WithMessage("Campo 'Endereço' é obrigatório.")
              .NotEmpty().WithMessage("Campo 'Endereço' é obrigatório.");

            RuleFor(x => x.Email)
             .EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("'Email' com formato incorreto")
             .NotNull().NotEmpty().WithMessage("'Email' com formato incorreto");

            RuleFor(x => x.Telefone)
               .Telefone()
               .NotEqual("(  )      -");

            RuleFor(x => x.Cnh)
                .NotNull().NotEmpty()
                .MaximumLength(12)
                .WithMessage("'CNH' inválido.");

            RuleFor(x => x.VencimentoCnh)
                .NotEqual(DateTime.MinValue)
                .WithMessage("O campo 'Vencimento CNH' é obrigatório");
        }
    }
}
