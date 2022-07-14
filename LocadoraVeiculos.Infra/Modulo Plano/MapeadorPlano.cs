using LocadoraVeiculos.Dominio.Modulo_Plano;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Plano
{
    public class MapeadorPlano : MapeadorBase<Plano>
    {
        public override void ConfigurarParametros(Plano entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("ID", entidade.Id);
            cmd.Parameters.AddWithValue("VALORDIARIO_DIARIO", entidade.ValorDiario_Diario);
            cmd.Parameters.AddWithValue("VALORPORKM_DIARIO", entidade.ValorPorKm_Diario);

            cmd.Parameters.AddWithValue("VALORDIARIO_LIVRE", entidade.ValorDiario_Livre);

            cmd.Parameters.AddWithValue("VALORDIARIO_CONTROLADO", entidade.ValorDiario_Controlado);
            cmd.Parameters.AddWithValue("VALORPORKM_CONTROLADO", entidade.ValorPorKm_Controlado);
            cmd.Parameters.AddWithValue("LIMITEQUILOMETRAGEM_CONTROLADO", entidade.LimiteQuilometragem_Controlado);

            cmd.Parameters.AddWithValue("GRUPO_ID", entidade.Grupo.Id);
            cmd.Parameters.AddWithValue("GRUPO_NOME", entidade.Grupo.Nome);
        }

        public override void DefinirParametroValidacao(string campoBancoDados, Plano entidade, SqlCommand cmd, string propiedade)
        {
            cmd.Parameters.AddWithValue(campoBancoDados.ToUpper(), entidade.ValorDiario_Diario);
        }

        public override List<Plano> LerTodos(SqlDataReader leitor)
        {
            List<Plano> planos = new();

            while (leitor.Read())
            {
                var id = Guid.Parse(leitor["ID"].ToString());
                float valorDiario_Diario = float.Parse(leitor["VALORDIARIO_DIARIO"].ToString());
                float valorPorKm_Diario = float.Parse(leitor["VALORPORKM_DIARIO"].ToString());

                float valorDiario_Livre = float.Parse(leitor["VALORDIARIO_LIVRE"].ToString());

                float valorDiario_Controlado = float.Parse(leitor["VALORDIARIO_CONTROLADO"].ToString());
                float valorPorKm_Controlado = float.Parse(leitor["VALORPORKM_CONTROLADO"].ToString());
                int limiteQuilometragem_Controlado = Convert.ToInt32(leitor["LIMITEQUILOMETRAGEM_CONTROLADO"]);

                var grupo_id = Guid.Parse(leitor["GRUPO_ID"].ToString());
                string grupo_nome = leitor["GRUPO_NOME"].ToString();

                Plano plano = new()
                {
                    Id = id,
                    ValorDiario_Diario = valorDiario_Diario,
                    ValorPorKm_Diario = valorPorKm_Diario,

                    ValorDiario_Livre = valorDiario_Livre,

                    ValorDiario_Controlado = valorDiario_Controlado,
                    ValorPorKm_Controlado = valorPorKm_Controlado,
                    LimiteQuilometragem_Controlado = limiteQuilometragem_Controlado,

                    Grupo = new(grupo_nome)
                    {
                        Id = grupo_id,
                    }
                   
               };

                planos.Add(plano);
            }

            return planos;
        }

        public override Plano ConverterRegistro(SqlDataReader leitor)
        {
            Plano plano = null;

            if (leitor.Read())
            {
                var id = Guid.Parse(leitor["ID"].ToString());
                float valorDiario_Diario = float.Parse(leitor["VALORDIARIO_DIARIO"].ToString());
                float valorPorKm_Diario = float.Parse(leitor["VALORPORKM_DIARIO"].ToString());

                float valorDiario_Livre = float.Parse(leitor["VALORDIARIO_LIVRE"].ToString());

                float valorDiario_Controlado = float.Parse(leitor["VALORDIARIO_CONTROLADO"].ToString());
                float valorPorKm_Controlado = float.Parse(leitor["VALORPORKM_CONTROLADO"].ToString());
                int limiteQuilometragem_Controlado = Convert.ToInt32(leitor["LIMITEQUILOMETRAGEM_CONTROLADO"]);

                var grupo_id = Guid.Parse(leitor["GRUPO_ID"].ToString());
                string grupo_nome = leitor["GRUPO_NOME"].ToString();

                plano = new()
                {
                    Id = id,
                    ValorDiario_Diario = valorDiario_Diario,
                    ValorPorKm_Diario = valorPorKm_Diario,

                    ValorDiario_Livre = valorDiario_Livre,

                    ValorDiario_Controlado = valorDiario_Controlado,
                    ValorPorKm_Controlado = valorPorKm_Controlado,
                    LimiteQuilometragem_Controlado = limiteQuilometragem_Controlado,

                    Grupo = new(grupo_nome)
                    {
                        Id = grupo_id,
                    }

                };
            }

            return plano;
        }
    }
}
