using LocadoraVeiculos.Dominio.Modulo_Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.Modulo_Condutor
{
    public class Condutor : EntidadeBase<Condutor>
    {
        public Cliente Cliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cnh { get; set; }
        public DateTime VencimentoCnh { get { return _dateVemcimentoCnh.Date; } set { _dateVemcimentoCnh = value; } }

        private DateTime _dateVemcimentoCnh;

        public Condutor()
        {
            _dateVemcimentoCnh = DateTime.Now;
        }
        public Condutor(Cliente cliente, string nome, string cpf, string email, 
            string endereco, string telefone, string cnh, DateTime vencimentoCnh)
        {
            Cliente = cliente;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Endereco = endereco;
            Telefone = telefone;
            Cnh = cnh;
            VencimentoCnh = vencimentoCnh;
        }

        
        public override bool Equals(object obj)
        {
            return obj is Condutor condutor &&
                Id == condutor.Id &&
                Nome == condutor.Nome &&
                Cpf == condutor.Cpf &&
                Email == condutor.Email &&
                Endereco == condutor.Endereco &&
                Telefone == condutor.Telefone &&
                Cnh == condutor.Cnh &&
                VencimentoCnh.Date == condutor.VencimentoCnh.Date &&
                Cliente.Equals(condutor.Cliente);               
        }
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Nome);
            hash.Add(Cpf);
            hash.Add(Email);
            hash.Add(Endereco);
            hash.Add(Telefone);
            hash.Add(Cnh);
            hash.Add(VencimentoCnh);
            hash.Add(Cliente);
            return hash.ToHashCode();
        }
    }
}
