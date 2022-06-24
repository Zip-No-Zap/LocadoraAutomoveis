using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo
{
    public class ValidadorGrupoVeiculo : AbstractValidator<GrupoVeiculo>
    {
        public ValidadorGrupoVeiculo()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("'Nome' não pode ser vazio");
        }
    }
}
