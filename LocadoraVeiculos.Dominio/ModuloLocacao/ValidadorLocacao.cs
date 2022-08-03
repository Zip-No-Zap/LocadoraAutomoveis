
using LocadoraVeiculos.Dominio.Compartilhado;
using FluentValidation;
using System;

namespace LocadoraVeiculos.Dominio.ModuloLocacao
{
    public class ValidadorLocacao : ValidadorBase<Locacao>
    {
         public ValidadorLocacao()
        {
            RuleFor(x => x.ClienteLocacao)
                .NotNull().WithMessage("Campo 'Cliente', é obrigatório")
                .NotEmpty().WithMessage("Campo 'Cliente', é obrigatório");

            RuleFor(x => x.CondutorLocacao)
                .NotNull().WithMessage("Campo 'Condutor', é obrigatório")
                .NotEmpty().WithMessage("Campo 'Condutor', é obrigatório");

            RuleFor(x => x.Grupo)
                .NotNull().WithMessage("Campo 'Grupo', é obrigatório")
                .NotEmpty().WithMessage("Campo 'Grupo', é obrigatório");

            RuleFor(x => x.VeiculoLocacao)
                .NotNull().WithMessage("Campo 'Veículo', é obrigatório")
                .NotEmpty().WithMessage("Campo 'Veículo', é obrigatório");
          
            RuleFor(x => x.PlanoLocacao)
                .NotNull().WithMessage("Campo 'Plano', é obrigatório")
                .NotEmpty().WithMessage("Campo 'Plano', é obrigatório");

            RuleFor(x => x.PlanoLocacao_Descricao)
                .NotNull().WithMessage("Campo 'Plano', é obrigatório")
                .NotEmpty().WithMessage("Campo 'Plano', é obrigatório");

            RuleFor(x => x.DataLocacao)
                .NotNull().WithMessage("Campo 'Data Locação', é obrigatório")
                .NotEmpty().WithMessage("Campo 'Data Locação', é obrigatório");
                //.GreaterThan(DateTime.Today.Subtract(TimeSpan.FromDays(1))).WithMessage("'Data de locação' deve ser hoje ou futura");

            RuleFor(x => x.DataDevolucao)
                .NotNull().WithMessage("Campo 'Data Devolução', é obrigatório")
                .NotEmpty().WithMessage("Campo 'Data Devolução', é obrigatório")
                .GreaterThan(DateTime.Today).WithMessage("'Data de devolução' deve ser maior que hoje");
        }
    }
}
