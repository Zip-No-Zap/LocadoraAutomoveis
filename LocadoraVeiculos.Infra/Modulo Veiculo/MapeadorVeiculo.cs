using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            cmd.Parameters.AddWithValue("GRUPOVEICULO_ID", entidade.GrupoPertencente);
            cmd.Parameters.AddWithValue("FOTO", entidade.Foto);
        }

        public override void DefinirParametroValidacao(string campoBd, Veiculo entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue(campoBd.ToUpper(), entidade.Modelo);
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
                int grupoVeiculo = Convert.ToInt32(leitor["GRUPOVEICULO_ID"]);
                byte[] foto = (byte[])leitor["FOTO"];

                Veiculo veiculo = new(modelo, placa, cor, ano, tipoCombustivel, capacidade, status, quilometragem, foto)
                {
                    Id = id
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
                int grupoVeiculo = Convert.ToInt32(leitor["GRUPOVEICULO_ID"]);
                byte[] foto = (byte[])leitor["FOTO"];

                veiculo = new Veiculo(modelo, placa, cor, ano, tipoCombustivel, capacidade, status, quilometragem, foto)
                {
                    Id = id,
                    Placa = placa,
                    Cor = cor,
                    Ano = ano,
                    TipoCombustivel=tipoCombustivel,
                    CapacidadeTanque = capacidade,
                    StatusVeiculo = status,
                    QuilometragemAtual = quilometragem,
                    Foto = foto
                };
            }

            return veiculo;
        }
    }
}
