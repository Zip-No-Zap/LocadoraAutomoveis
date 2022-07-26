using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using LocadoraVeiculos.Infra.BancoDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Infra.Orm.ModuloTaxa
{
    public class RepositorioTaxaOrm : RepositorioBaseOrm, IRepositorioOrmPlano
    {
        public void Editar(Plano registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Plano registro)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Plano registro)
        {
            throw new NotImplementedException();
        }

        public Plano SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Plano SelecionarPorParametro(string valor)
        {
            throw new NotImplementedException();
        }

        public List<Plano> SelecionarTodos(bool verificador)
        {
            throw new NotImplementedException();
        }
    }
}
