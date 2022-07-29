using System;



namespace LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo
{
    public class GrupoVeiculo : EntidadeBase<GrupoVeiculo>
    {
        public string Nome { get; set; }
        
        public GrupoVeiculo(string nome): base()
        {
            Nome = nome;
        }

        public GrupoVeiculo()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is GrupoVeiculo grupo 
                && Id == grupo.Id
                && Nome == grupo.Nome;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Nome);
           
            return hash.ToHashCode();
        }
    }
}
