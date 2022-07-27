using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Infra.Orm.ModuloGrupoVeiculo
{
    public interface IRepositorioOrmGrupoVeiculo : IRepositorioOrmBase<GrupoVeiculo>
    {
        public GrupoVeiculo SelecionarPorNome(string grupoVeiculo);
    }
}
