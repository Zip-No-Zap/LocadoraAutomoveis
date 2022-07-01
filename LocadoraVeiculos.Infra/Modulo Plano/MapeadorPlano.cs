using LocadoraVeiculos.Dominio.Modulo_Plano;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Plano
{
    public class MapeadorPlano : MapeadorBase<Plano>
    {
        public override void DefinirParametros(Plano entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("ID", entidade.Id);
            cmd.Parameters.AddWithValue("DESCRICAO", entidade.Descricao);
            cmd.Parameters.AddWithValue("VALORDIARIO", entidade.ValorDiario);
            cmd.Parameters.AddWithValue("VALORPORKM", entidade.ValorPorKm);
            cmd.Parameters.AddWithValue("LIMITEQUILOMETRAGEM", entidade.LimiteQuilometragem);
            cmd.Parameters.AddWithValue("GRUPO_ID", entidade.Grupo.Id);
        }

        public override void DefinirParametroValidacao(string campoBd, Plano entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue(campoBd.ToUpper(), entidade.Descricao);
        }

        public override List<Plano> LerTodos(SqlDataReader leitor)
        {
            List<Plano> planos = new();

            while (leitor.Read())
            {
                int id = Convert.ToInt32(leitor["ID"]);
                string descricao = leitor["DESCRICAO"].ToString();
                float valorDiario = float.Parse(leitor["VALORDIARIO"].ToString());
                float valorPorKm = float.Parse(leitor["VALORPORKM"].ToString());
                int limiteQuilometragem = Convert.ToInt32(leitor["LIMITEQUILOMETRAGEM"]);

                int grupo_id = Convert.ToInt32(leitor["GRUPO_ID"]);
                string grupo_nome = leitor["GRUPO_NOME"].ToString();

                Plano plano = new()
                {
                    Id = id,
                    Descricao = descricao,
                    ValorDiario = valorDiario,
                    ValorPorKm = valorPorKm,
                    LimiteQuilometragem = limiteQuilometragem,

                    Grupo = new()
                    {
                        Id = grupo_id,
                        Nome = grupo_nome,
                    }
                   
               };

                planos.Add(plano);
            }

            return planos;
        }

        public override Plano LerUnico(SqlDataReader leitor)
        {
            Plano plano = null;

            if (leitor.Read())
            {
                int id = Convert.ToInt32(leitor["ID"]);
                string descricao = leitor["DESCRICAO"].ToString();
                float valorDiario = float.Parse(leitor["VALORDIARIO"].ToString());
                float valorPorKm = float.Parse(leitor["VALORPORKM"].ToString());
                int limiteQuilometragem = Convert.ToInt32(leitor["LIMITEQUILOMETRAGEM"]);

                int grupo_id = Convert.ToInt32(leitor["GRUPO_ID"]);
                string grupo_nome = leitor["GRUPO_NOME"].ToString();

                plano = new()
                {
                    Id = id,
                    Descricao = descricao,
                    ValorDiario = valorDiario,
                    ValorPorKm = valorPorKm,
                    LimiteQuilometragem = limiteQuilometragem,

                    Grupo = new()
                    {
                        Id = grupo_id,
                        Nome = grupo_nome,
                    }

                };
            }

            return plano;
        }
    }
}
