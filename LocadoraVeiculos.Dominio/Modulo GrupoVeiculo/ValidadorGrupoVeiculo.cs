using FluentValidation;
using LocadoraVeiculos.Dominio.Compartilhado;


namespace LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo
{
    public class ValidadorGrupoVeiculo : ValidadorBase<GrupoVeiculo>
    {
        public ValidadorGrupoVeiculo()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("'Nome' não pode ser vazio");
        }
    }
}
