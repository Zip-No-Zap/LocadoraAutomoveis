using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo
{
    public class GrupoVeiculo : EntidadeBase<GrupoVeiculo>
    {
        public string Nome { get; set; }

             
        public GrupoVeiculo(string nome)
        {
            Nome = nome;
        }

        public override bool Equals(object obj)
        {
            return obj is GrupoVeiculo grupoVeiculo &&
                   Id == grupoVeiculo.Id &&
                   Nome == grupoVeiculo.Nome;

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome);
        }
    }
}
