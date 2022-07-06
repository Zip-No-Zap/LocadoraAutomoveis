using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente;
using Serilog;
using System.Collections.Generic;

namespace LocadoraAutomoveis.Aplicacao.Modulo_Cliente
{
    public class ServicoCliente
    {
        readonly RepositorioClienteEmBancoDados repositorioCliente;
        ValidadorCliente validadorCliente;

        public ServicoCliente(RepositorioClienteEmBancoDados repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public ValidationResult Inserir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando inserir Cliente... {@cliente}", cliente);
            var resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
            {
                repositorioCliente.Inserir(cliente);
                Log.Logger.Information("Cliente inserido com sucesso. {@cliente}", cliente);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                Log.Logger.Warning("Falha ao tentar inserir Cliente. {ClienteNome} -> Motivo: {erro}", cliente.Nome, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Cliente cliente)
        {
            Log.Logger.Debug("Tentando editar Cliente... {@cliente}", cliente);
            var resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
            {
                repositorioCliente.Editar(cliente);
                Log.Logger.Information("Cliente editado com sucesso. {@cliente}", cliente);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    Log.Logger.Warning("Falha ao tentar editar Cliente. {ClienteNome} -> Motivo: {erro}", cliente.Nome, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando excluir Cliente... {@cliente}", cliente);
            var resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
            {
                repositorioCliente.Excluir(cliente);
                Log.Logger.Information("Cliente excluir com sucesso. {@cliente}", cliente);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    Log.Logger.Warning("Falha ao tentar excluir Cliente. {ClienteNome} -> Motivo: {erro}", cliente.Nome, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public List<Cliente> SelecionarTodos()
        {
            Log.Logger.Debug("Tentando obter todos os clientes...");
            
            var clientes = repositorioCliente.SelecionarTodos();

            if (clientes.Count > 0)
            {
                Log.Logger.Information("Todos os clientes foram obtidos com sucesso. {ClienteCount}", clientes.Count);
                return clientes;
            }
            else
            {
                Log.Logger.Warning("Falha ao tentar obter todos os clientes. {ClienteCount} -> ", clientes.Count);
                return clientes;
            }
        }

        public Cliente SelecionarPorId(int id)
        {
            Log.Logger.Debug("Tentando obter um cliente...");
            var cliente =  repositorioCliente.SelecionarPorId(id);

            if (cliente != null)
            {
                Log.Logger.Information("Cliente foi obtido com sucesso.", cliente.Nome);
                return cliente;
            }
            else
            {
                Log.Logger.Warning("Falha ao tentar obter um cliente. {Cliente} -> ", cliente.Nome);
                return cliente;
            }
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

        #endregion

    }
}
