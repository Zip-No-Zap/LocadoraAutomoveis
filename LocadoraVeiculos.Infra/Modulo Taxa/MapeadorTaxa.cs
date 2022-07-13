using LocadoraVeiculos.Dominio.Modulo_Taxa;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Taxa
{
    public class MapeadorTaxa : MapeadorBase<Taxa>
    {
        public override void ConfigurarParametros(Taxa entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("ID", entidade.Id);
            cmd.Parameters.AddWithValue("DESCRICAO", entidade.Descricao);
            cmd.Parameters.AddWithValue("TIPO", entidade.Tipo);
            cmd.Parameters.AddWithValue("VALOR", entidade.Valor);
        }

        public override void DefinirParametroValidacao(string campoBd, Taxa entidade, SqlCommand cmd, string propiedade)
        {
            cmd.Parameters.AddWithValue(campoBd.ToUpper(), entidade.Descricao);
        }

        public override List<Taxa> LerTodos(SqlDataReader leitor)
        {
            List<Taxa> taxas = new();

            while (leitor.Read())
            {
                var id = Guid.Parse(leitor["ID"].ToString());
                string descricao = leitor["DESCRICAO"].ToString();
                string tipo = leitor["TIPO"].ToString();
                float valor = (float)leitor["VALOR"];

                var taxa = new Taxa()
                {
                    Id = id,
                    Descricao = descricao,
                    Tipo = tipo,
                    Valor = valor
                };

                taxas.Add(taxa);
            }

            return taxas;
        }

        public override Taxa ConverterRegistro(SqlDataReader leitor)
        {
            Taxa taxa = null;

            if (leitor.Read())
            {
                var id = Guid.Parse(leitor["ID"].ToString());
                string descricao = leitor["DESCRICAO"].ToString();
                string tipo = leitor["TIPO"].ToString();
                float valor = (float)leitor["VALOR"];

                taxa = new Taxa()
                {
                    Id = id,
                    Descricao = descricao,
                    Tipo = tipo,
                    Valor = valor
                };
            }

            return taxa;
        }
    }
}
