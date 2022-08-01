using System;


namespace LocadoraVeiculos.Dominio.Modulo_Configuracao
{
    public class Configuracao
    {
        public string valorGasolina { get; set; }

        public string valorDiesel { get; set; }
        public string valorAlcool { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Configuracao configuracao &&
                valorGasolina == configuracao.valorGasolina &&
                valorDiesel == configuracao.valorDiesel &&
                valorAlcool == configuracao.valorAlcool;
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
