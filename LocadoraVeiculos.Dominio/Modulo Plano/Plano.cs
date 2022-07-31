using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using System;

namespace LocadoraVeiculos.Dominio.Modulo_Plano
{
    public class Plano: EntidadeBase<Plano>
    {
        public GrupoVeiculo Grupo { get; set; }
        public Guid GrupoVeiculoId { get; set; } // tem que ter isso com o Orm

        public double ValorDiario_Diario { get; set; }
        public double ValorPorKm_Diario { get; set; }

        public double ValorDiario_Livre { get; set; }

        public double ValorDiario_Controlado { get; set; }
        public double ValorPorKm_Controlado { get; set; }
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
