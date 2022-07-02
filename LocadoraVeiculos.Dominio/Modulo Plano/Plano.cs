using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;

namespace LocadoraVeiculos.Dominio.Modulo_Plano
{
    public class Plano: EntidadeBase<Plano>
    {
        public GrupoVeiculo Grupo { get; set; }

        public string Descricao { get; set; }

        public float ValorDiario_Diario { get; set; }
        public float ValorPorKm_Diario { get; set; }

        public float ValorDiario_Livre { get; set; }

        public float ValorDiario_Controlado { get; set; }
        public float ValorPorKm_Controlado { get; set; }
        public int LimiteQuilometragem_Controlado { get; set; }


        public string NomeGrupo
        {
            get
            {
                return Grupo.Nome;
            }
        }
    }
}
