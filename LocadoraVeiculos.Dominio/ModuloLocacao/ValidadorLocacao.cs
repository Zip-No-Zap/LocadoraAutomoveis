
using LocadoraVeiculos.Dominio.Compartilhado;
using FluentValidation;
using System;

namespace LocadoraVeiculos.Dominio.ModuloLocacao
{
    public class ValidadorLocacao : ValidadorBase<Locacao>
    {
         public ValidadorLocacao()
        {
            RuleFor(x => x.ClienteLocacao).NotEmpty().WithMessage("Campo 'Cliente', é obrigatório");
            RuleFor(x => x.CondutorLocacao).NotEmpty().WithMessage("Campo 'Condutor', é obrigatório");
            RuleFor(x => x.Grupo).NotEmpty().WithMessage("Campo 'Grupo', é obrigatório");
            RuleFor(x => x.VeiculoLocacao).NotEmpty().WithMessage("Campo 'Veículo', é obrigatório");
            RuleFor(x => x.PlanoLocacao).NotEmpty().WithMessage("Campo 'Plano', é obrigatório");

            RuleFor(x => x.DataLocacao)
                .NotEmpty().WithMessage("Campo 'Data Locação', é obrigatório")
                .GreaterThan(DateTime.Today.Subtract(TimeSpan.FromDays(1))).WithMessage("'Data de locação' deve ser hoje ou futura");

            RuleFor(x => x.DataDevolucao)
                .NotEmpty().WithMessage("Campo 'Data Devolução', é obrigatório")
                .GreaterThan(DateTime.Today).WithMessage("'Data de devolução' deve ser maior que hoje");
        }
    }
}
