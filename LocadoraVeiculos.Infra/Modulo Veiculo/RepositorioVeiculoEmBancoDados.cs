using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;


namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Veiculo
{
    public class RepositorioVeiculoEmBancoDados : RepositorioBase<Veiculo, MapeadorVeiculo, ValidadorVeiculo>
    {
        protected override string Sql_insercao => throw new NotImplementedException();

        protected override string Sql_edicao => throw new NotImplementedException();

        protected override string Sql_exclusao => throw new NotImplementedException();

        protected override string Sql_selecao_por_id => throw new NotImplementedException();

        protected override string Sql_selecao_todos => throw new NotImplementedException();

    }
}
