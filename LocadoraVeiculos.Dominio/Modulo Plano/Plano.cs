using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;

namespace LocadoraVeiculos.Dominio.Modulo_Plano
{
    public class Plano: EntidadeBase<Plano>
    {
       public GrupoVeiculo Grupo { get; set; } 
       public string Descricao { get; set; }
       public float ValorDiario { get; set; }
       public float ValorPorKm { get; set; }
       public int LimiteQuilometragem { get; set; }
    }
}
