using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente;
using System;
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

            if (NomeDuplicado(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "'Nome' duplicado"));

            if (CpfDuplicado(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("Cpf", "'Cpf' duplicado"));

            if (CnpjDuplicado(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("Cnpj", "'Cnpj' duplicado"));

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

        #region privates

        private bool NomeDuplicado(Cliente cliente)
        {
            repositorioCliente.Sql_selecao_por_parametro = @"SELECT * FROM TBCLIENTE WHERE NOME = @NOMECLIENTE";
            repositorioCliente.PropriedadeParametro = "NOMECLIENTE";

            var clienteEncontrado = repositorioCliente.SelecionarPorParametro(repositorioCliente.PropriedadeParametro, cliente);

            return clienteEncontrado != null &&
                   clienteEncontrado.Nome.Equals(cliente.Nome) &&
                  !clienteEncontrado.Id.Equals(cliente.Id);
        }

        private bool CnpjDuplicado(Cliente cliente)
        {
            repositorioCliente.Sql_selecao_por_parametro = @"SELECT * FROM TBCLIENTE WHERE CNPJ = @CNPJCLIENTE";
            repositorioCliente.PropriedadeParametro = "CNPJCLIENTE";

            var clienteEncontrado = repositorioCliente.SelecionarPorParametro(repositorioCliente.PropriedadeParametro, cliente);

            return clienteEncontrado != null &&
                   clienteEncontrado.Cnpj != "-" &&
                   clienteEncontrado.Cnpj.Equals(cliente.Cnpj) &&
                  !clienteEncontrado.Id.Equals(cliente.Id);
        }

        private bool CpfDuplicado(Cliente cliente)
        {
            repositorioCliente.Sql_selecao_por_parametro = @"SELECT * FROM TBCLIENTE WHERE CPF = @CPFCLIENTE";
            repositorioCliente.PropriedadeParametro = "CPFCLIENTE";

            var clienteEncontrado = repositorioCliente.SelecionarPorParametro(repositorioCliente.PropriedadeParametro, cliente);

            return clienteEncontrado != null &&
                   clienteEncontrado.Cpf != "-" &&
                   clienteEncontrado.Cpf.Equals(cliente.Cpf) &&
                  !clienteEncontrado.Id.Equals(cliente.Id);
        }

        #endregion

    }
}
