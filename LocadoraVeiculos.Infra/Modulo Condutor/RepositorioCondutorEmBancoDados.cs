using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Condutor
{
    public class RepositorioCondutorEmBancoDados : RepositorioBase<Condutor, MapeadorCondutor, ValidadorCondutor>
    {
        protected override string Sql_insercao => throw new NotImplementedException();

        protected override string Sql_edicao => throw new NotImplementedException();

        protected override string Sql_exclusao => throw new NotImplementedException();

        protected override string Sql_selecao_por_id => throw new NotImplementedException();

        protected override string Sql_selecao_todos => throw new NotImplementedException();

        protected override bool VerificarDuplicidade(Condutor entidade)
        {
            throw new NotImplementedException();
        }
    }
}
