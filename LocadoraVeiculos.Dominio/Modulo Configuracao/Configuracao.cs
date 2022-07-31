using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.Modulo_Configuracao
{
    public class Configuracao
    {
        public string valorGasolina { get; set; }

        public string valorDiesel { get; set; }

        public Configuracao(string gasolina, string diesel)
        {
            valorGasolina = gasolina;
            valorDiesel = diesel;
        }

        public override bool Equals(object obj)
        {
            return obj is Configuracao configuracao &&
                valorGasolina == configuracao.valorGasolina &&
                valorDiesel == configuracao.valorDiesel;

        }
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(valorGasolina);
            hash.Add(valorDiesel);
            return hash.ToHashCode();
        }

    }
}
