using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Infra.Orm.ModuloVeiculo
{
    public interface IRepositorioVeiculoOrm : IRepositorioBaseOrm<Veiculo>
    {
        public Veiculo SelecionarPorPlaca(string placa);
    }
}
