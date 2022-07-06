using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Veiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        public override void ConfigurarParametros(Veiculo entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("ID", entidade.Id);
            cmd.Parameters.AddWithValue("MODELO", entidade.Modelo);
            cmd.Parameters.AddWithValue("PLACA", entidade.Placa);
            cmd.Parameters.AddWithValue("COR", entidade.Cor);
            cmd.Parameters.AddWithValue("ANO", entidade.Ano);
            cmd.Parameters.AddWithValue("TIPOCOMBUSTIVEL", entidade.TipoCombustivel);
            cmd.Parameters.AddWithValue("CAPACIDADETANQUE", entidade.CapacidadeTanque);
            cmd.Parameters.AddWithValue("STATUS", entidade.StatusVeiculo);
            cmd.Parameters.AddWithValue("QUILOMETRAGEMATUAL", entidade.QuilometragemAtual);
            cmd.Parameters.AddWithValue("FOTO", entidade.Foto);

            cmd.Parameters.AddWithValue("IDGRUPOVEICULO", entidade.GrupoPertencente.Id);
            cmd.Parameters.AddWithValue("NOMEGRUPO", entidade.GrupoPertencente.Nome);
        }

        public override void DefinirParametroValidacao(string parametro, Veiculo entidade, SqlCommand cmd, string propriedade)
        {
            cmd.Parameters.AddWithValue(parametro.ToUpper(), entidade.Placa);
        }

        public override List<Veiculo> LerTodos(SqlDataReader leitor)
        {
            List<Veiculo> veiculos = new();

            while (leitor.Read())
            {
                int id = Convert.ToInt32(leitor["ID"]);
                string modelo = leitor["MODELO"].ToString();
                string placa = leitor["PLACA"].ToString();
                string cor = leitor["COR"].ToString();
                int ano = Convert.ToInt32(leitor["ANO"]);
                string tipoCombustivel = leitor["TIPOCOMBUSTIVEL"].ToString();
                int capacidade = Convert.ToInt32(leitor["CAPACIDADETANQUE"]);
                string status = leitor["STATUS"].ToString();
                int quilometragem = Convert.ToInt32(leitor["QUILOMETRAGEMATUAL"]);

                int grupoVeiculoID = Convert.ToInt32(leitor["IDGRUPOVEICULO"]);
                string grupoVeiculoNome = (leitor["NOMEGRUPO"]).ToString();

                byte[] foto = (byte[])leitor["FOTO"];

                Veiculo veiculo = new(modelo, placa, cor, ano, tipoCombustivel, capacidade, status, quilometragem, foto)
                {
                    Id = id,
                    GrupoPertencente = new(grupoVeiculoNome)
                    {
                        Id = grupoVeiculoID,
                    },
                };

                veiculos.Add(veiculo);
            }

            return veiculos;
        }

        public override Veiculo ConverterRegistro(SqlDataReader leitor)
        {
            Veiculo veiculo = null;

            if (leitor.Read())
            {
                int id = Convert.ToInt32(leitor["ID"]);
                string modelo = leitor["MODELO"].ToString();
                string placa = leitor["PLACA"].ToString();
                string cor = leitor["COR"].ToString();
                int ano = Convert.ToInt32(leitor["ANO"]);
                string tipoCombustivel = leitor["TIPOCOMBUSTIVEL"].ToString();
                int capacidade = Convert.ToInt32(leitor["CAPACIDADETANQUE"]);
                string status = leitor["STATUS"].ToString();
                int quilometragem = Convert.ToInt32(leitor["QUILOMETRAGEMATUAL"]);

                int grupoVeiculoID = Convert.ToInt32(leitor["IDGRUPOVEICULO"]);
                string grupoVeiculoNome = (leitor["NOMEGRUPO"]).ToString();

                byte[] foto = (byte[])leitor["FOTO"];

                veiculo = new(modelo, placa, cor, ano, tipoCombustivel, capacidade, status, quilometragem, foto)
                {
                    Id = id,
                    GrupoPertencente = new(grupoVeiculoNome)
                    {
                        Id = grupoVeiculoID,
                    },
                };
            }

            return veiculo;
        }
    }
}
