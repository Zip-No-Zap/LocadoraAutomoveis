﻿using FluentValidation;
using FluentValidation.Validators;
using LocadoraVeiculos.Dominio.Compartilhado;
using System.Text.RegularExpressions;


namespace LocadoraVeiculos.Dominio.Modulo_Cliente
{
    public class ValidadorCliente : ValidadorBase<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("Campo 'Nome' é obrigatório.")
                .NotEmpty().WithMessage("Campo 'Nome' é obrigatótio.")
                .MinimumLength(2).WithMessage("Campo 'Nome' é inválido.");

            When(x => x.TipoCliente == EnumTipoCliente.PessoaJuridica, () =>
            {
                RuleFor(x => x.Cnpj)
                .Custom((cnpj, context) =>
                {
                    if (string.IsNullOrEmpty(cnpj) == false)
                    {
                        if (Regex.IsMatch(cnpj, @"^[0-9]{2}[.][0-9]{3}[.][0-9]{3}[/][0-9]{4}[-][0-9]{2}", RegexOptions.IgnoreCase) == false)
                            context.AddFailure("'CNPJ' inválido.");
                    }
                });
            });

            When(x => x.TipoCliente == EnumTipoCliente.PessoaFisica, () =>
            {
                RuleFor(x => x.Cpf)
                .Custom((cpf, context) =>
                {
                    if (string.IsNullOrEmpty(cpf) == false)
                    {
                        if (Regex.IsMatch(cpf, @"^[0-9]{3}[.][0-9]{3}[.][0-9]{3}[-][0-9]{2}", RegexOptions.IgnoreCase) == false)
                            context.AddFailure("'CPF' inválido.");
                    }
                });
            });
            
            RuleFor(x => x.Endereco)
              .NotNull().WithMessage("Campo 'Endereço' é obrigatório.")
              .NotEmpty().WithMessage("Campo 'Endereço' é obrigatório.");

            RuleFor(x => x.Email)
             .EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("'Email' formato incorreto")
             .NotNull().NotEmpty().WithMessage("'Email' formato incorreto");

            RuleFor(x => x.Telefone)
               .Telefone()
               .NotEqual("(  )      -");

           
        }
    }
}
