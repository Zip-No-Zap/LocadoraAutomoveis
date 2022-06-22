using FluentValidation;
using LocadoraVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.Modulo_Cliente
{
    public class ValidadorCliente : AbstractValidator<Cliente<Pessoa>>
    {
        public ValidadorCliente()
        {
            //RuleFor(x => x.Nome)
        }
    }
}
