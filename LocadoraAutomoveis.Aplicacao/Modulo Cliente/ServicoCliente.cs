using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente;
using System.Collections.Generic;

namespace LocadoraAutomoveis.Aplicacao.Modulo_Cliente
{
    public class ServicoCliente
    {
        readonly RepositorioClienteEmBancoDados repositorioCliente;
        ValidadorCliente validadorCliente;

        public ServicoCliente(RepositorioClienteEmBancoDados reopositorioCliente)
        {
            this.repositorioCliente = reopositorioCliente;

        }

        public ValidationResult Inserir(Cliente cliente)
        {
            var resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Inserir(cliente);

            return resultadoValidacao;
        }

        private ValidationResult Validar(Cliente cliente)
        {
            validadorCliente = new ValidadorCliente();

            var resultadoValidacao = validadorCliente.Validate(cliente);

            //if (NomeDuplicado(funcionario))
            //    resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "'Nome' duplicado"));

            //if (LoginDuplicado(funcionario))
            //    resultadoValidacao.Errors.Add(new ValidationFailure("Login", "'Login' duplicado"));

            return resultadoValidacao;
        }
        public ValidationResult Editar(Cliente cliente)
        {
            var resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Editar(cliente);

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Cliente cliente)
        {
            var resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Excluir(cliente);

            return resultadoValidacao;
        }

        public List<Cliente> SelecionarTodos()
        {
            return repositorioCliente.SelecionarTodos();
        }

        public Cliente SelecionarPorId(int id)
        {
            return repositorioCliente.SelecionarPorId(id);
        }


    }
}
