using System;


namespace LocadoraVeiculos.Dominio.Modulo_Taxa
{
    public class Taxa : EntidadeBase<Taxa>
    {
       public string Descricao { get; set; }
       public float Valor { get; set; }
       public string Tipo { get; set; }

        public Taxa()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is Taxa taxa &&
                   Descricao == taxa.Descricao &&
                   Valor == taxa.Valor &&
                   Tipo == taxa.Tipo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Descricao, Valor, Tipo);
        }
        public override string ToString()
        {
            return string.Format($"{Descricao} - Valor: R$ {Valor}");
        }
    }
}
