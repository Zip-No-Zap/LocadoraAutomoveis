using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.Modulo_Funcionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public Funcionario()
        {

        }
        public Funcionario(string nome, string login, string senha, double salario, DateTime dataAdmissao)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Salario = salario;
            DataAdmissao = dataAdmissao;
        }

        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public double Salario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Funcionario funcionario &&
                   Id == funcionario.Id &&
                   Nome == funcionario.Nome &&
                   Login == funcionario.Login &&
                   Senha == funcionario.Senha &&
                   DataAdmissao == funcionario.DataAdmissao;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Login, Senha, Salario, DataAdmissao);
        }
    }
}
