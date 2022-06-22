using LocadoraVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.Modulo_Cliente
{
    public class Cliente<T> where T : EntidadeBase<Pessoa>
    {
        //public Cliente()
        //{
        //    var cliente01 = new Cliente<PessoaFisica>();
        //}
    }
}
