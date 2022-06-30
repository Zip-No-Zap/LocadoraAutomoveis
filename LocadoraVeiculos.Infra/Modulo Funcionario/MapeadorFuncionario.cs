using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Funcionario
{
    public class MapeadorFuncionario : MapeadorBase<Funcionario>
    {
        public override void DefinirParametros(Funcionario entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("ID", entidade.Id);
            cmd.Parameters.AddWithValue("NOME", entidade.Nome);
            cmd.Parameters.AddWithValue("LOGIN", entidade.Login);
            cmd.Parameters.AddWithValue("SENHA", entidade.Senha);
            cmd.Parameters.AddWithValue("SALARIO", entidade.Salario);
            cmd.Parameters.AddWithValue("DATAADMISSAO", entidade.DataAdmissao);
            cmd.Parameters.AddWithValue("CIDADE", entidade.Cidade);
            cmd.Parameters.AddWithValue("ESTADO", entidade.Estado);
            cmd.Parameters.AddWithValue("PERFIL", entidade.Perfil);
        }

        public override void DefinirParametroValidacao(string campoBancoDados, Funcionario entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue(campoBancoDados.ToUpper(), entidade.Nome);
        }

        public override List<Funcionario> LerTodos(SqlDataReader leitor)
        {
            List<Funcionario> funcionarios = new();

            while (leitor.Read())
            {
                int id = Convert.ToInt32(leitor["ID"]);
                string nome = leitor["NOME"].ToString();
                string login = leitor["LOGIN"].ToString();
                string senha = leitor["SENHA"].ToString();
                double salario = Convert.ToDouble(leitor["SALARIO"]);
                DateTime dataAdmissao = Convert.ToDateTime(leitor["DATAADMISSAO"]);
                string perfil = leitor["PERFIL"].ToString();
                string cidade = leitor["CIDADE"].ToString();
                string estado = leitor["ESTADO"].ToString();

                Funcionario funcionario = new Funcionario(nome, login, senha, salario, dataAdmissao)
                {
                    Id = id,
                    Cidade = cidade,
                    Estado = estado,
                    Perfil = perfil

                };

                funcionarios.Add(funcionario);
            }

            return funcionarios;
        }

        public override Funcionario LerUnico(SqlDataReader leitor)
        {
            Funcionario funcionario = null;

            if (leitor.Read())
            {
                int id = Convert.ToInt32(leitor["ID"]);
                string nome = leitor["NOME"].ToString();
                string login = leitor["LOGIN"].ToString();
                string senha = leitor["SENHA"].ToString();
                double salario = Convert.ToDouble(leitor["SALARIO"]);
                DateTime dataAdmissao = Convert.ToDateTime(leitor["DATAADMISSAO"]);
                string perfil = leitor["PERFIL"].ToString();
                string cidade = leitor["CIDADE"].ToString();
                string estado = leitor["ESTADO"].ToString();

                funcionario = new Funcionario(nome, login, senha, salario, dataAdmissao)
                {
                    Id = id,
                    Cidade = cidade,
                    Estado = estado,
                    Perfil = perfil
                };
            }

            return funcionario;
        }

    }
}
