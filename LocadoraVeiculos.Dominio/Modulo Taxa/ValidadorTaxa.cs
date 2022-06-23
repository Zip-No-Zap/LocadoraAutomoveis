using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.Modulo_Taxa
{
    public class ValidadorTaxa : AbstractValidator<Taxa>
    {
        public ValidadorTaxa()
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("'Descrição' não pode ser vazio");
            RuleFor(x => x.Valor).NotNull().WithMessage("'Valor' não pode ser nulo");
            RuleFor(x => x.Tipo).NotEmpty().WithMessage("'Tipo' não pode ser vazio");
        }
    }
}
