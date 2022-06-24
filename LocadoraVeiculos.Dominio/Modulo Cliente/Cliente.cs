using LocadoraVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.Modulo_Cliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        public Cliente()
        {

        }

        private EnumTipoCliente _tipoCliente;
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Cnh { get; set; }
        public string Email { get; set; }   
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public Cliente (string nome, string cpf, string cnpj,
            string cnh, string email, string endereco, string telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Cnpj = cnpj;
            Cnh = cnh;
            Email = email;
            Endereco = endereco;
            Telefone = telefone;
        }

        public EnumTipoCliente TipoCliente
        {
            get { return _tipoCliente; }
            set
            {
                _tipoCliente = value;

                switch (_tipoCliente)
                {
                    case EnumTipoCliente.PessoaFisica: Cpf = null; 
                        break;
                    case EnumTipoCliente.PessoaJuridica: Cnpj = null; 
                        break;
                    default:
                        break;
                }
            }
        }
        public override bool Equals(object obj)
        {
            return obj is Cliente cliente &&
                Id == cliente.Id &&
                Nome == cliente.Nome &&
                Cpf == cliente.Cpf &&
                Cnh == cliente.Cnh &&
                Cnpj == cliente.Cnpj &&
                Email == cliente.Email &&
                Endereco == cliente.Endereco &&
                Telefone == cliente.Telefone &&
                TipoCliente == cliente.TipoCliente;
        }
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Nome);
            hash.Add(Cpf);
            hash.Add(Cnh);
            hash.Add(Cnpj);
            hash.Add(Email);
            hash.Add(Endereco);
            hash.Add(Telefone);
            hash.Add(TipoCliente);
            return hash.ToHashCode();
        }

        public string DocumentoDuplicado { get; set; }
    }
}
