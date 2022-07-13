using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace LocadoraVeiculos.Infra.BancoDados.Modulo_GrupoVeiculo
{
    public class MapeadorGrupoVeiculo : MapeadorBase<GrupoVeiculo>
    {
        public override void ConfigurarParametros(GrupoVeiculo entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("ID", entidade.Id);
            cmd.Parameters.AddWithValue("NOMEGRUPO", entidade.Nome);
        }

        public override void DefinirParametroValidacao(string campoBd, GrupoVeiculo entidade, SqlCommand cmd, string propiedade)
        {
            cmd.Parameters.AddWithValue(campoBd.ToUpper(), entidade.Nome);
        }

        public override List<GrupoVeiculo> LerTodos(SqlDataReader leitor)
        {
            List<GrupoVeiculo> gruposVeiculos = new();

            while (leitor.Read())
            {
                var id = Guid.Parse(leitor["GRUPO_ID"].ToString());
                string nome = leitor["GRUPO_NOME"].ToString();

                GrupoVeiculo grupoVeiculo = new (nome)
                {
                    Id = id
                };

                gruposVeiculos.Add(grupoVeiculo);
            }

            return gruposVeiculos;
        }

        public override GrupoVeiculo ConverterRegistro(SqlDataReader leitor)
        {
            GrupoVeiculo grupo = null;

            if (leitor.Read())
            {
                var id = Guid.Parse(leitor["GRUPO_ID"].ToString());
                string nome = leitor["GRUPO_NOME"].ToString();


                grupo = new GrupoVeiculo(nome)
                {
                    Id = id
                };
            }

            return grupo;
        }
    }
}
