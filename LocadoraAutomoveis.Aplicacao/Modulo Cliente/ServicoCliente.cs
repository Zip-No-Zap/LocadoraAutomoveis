using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloCliente;
using LocadoraAutomoveis.Infra.Orm.ModuloCondutor;
using LocadoraAutomoveis.Infra.Orm.ModuloLocacao;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using System.Collections.Generic;
using Serilog;
using System;
using System.Linq;

namespace LocadoraAutomoveis.Aplicacao.Modulo_Cliente
{
    public class ServicoCliente
    {
        readonly RepositorioClienteOrm repositorioCliente;
        readonly RepositorioCondutorOrm repositorioCondutor;
        readonly RepositorioLocacaoOrm repositorioLocacao;
        readonly IContextoPersistencia contextoPersistOrm;

        public ServicoCliente(RepositorioClienteOrm repositorioCliente, IContextoPersistencia contextoPersistOrm, RepositorioCondutorOrm repositorioCondutor, RepositorioLocacaoOrm repositorioLocacao)
        {
            this.repositorioCliente = repositorioCliente;
            this.contextoPersistOrm = contextoPersistOrm;
            this.repositorioCondutor = repositorioCondutor;
            this.repositorioLocacao = repositorioLocacao;
        }

        public Result<Cliente> Inserir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando inserir Cliente... {@cliente}", cliente);

            var resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Cliente. {ClienteId} -> Motivo: {erro}", cliente.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCliente.Inserir(cliente);

                contextoPersistOrm.GravarDados();

                Log.Logger.Information("Cliente inserido com sucesso. {@cliente}", cliente);

                return Result.Ok(cliente);
            }
            catch (Exception ex)
            {
                contextoPersistOrm.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar inserir Cliente.";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }

            return resultadoValidacao;
        }

        public Result<Cliente> Editar(Cliente cliente)
        {
            Log.Logger.Debug("Tentando editar Cliente... {@cliente}", cliente);

            var resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Cliente. {ClienteId} -> Motivo: {erro}", cliente.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCliente.Editar(cliente);

                contextoPersistOrm.GravarDados();

                Log.Logger.Information("Cliente editado com sucesso. {@cliente}", cliente);

                return Result.Ok(cliente);
            }
            catch (Exception ex)
            {
                contextoPersistOrm.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar editar Cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando excluir Cliente... {@cliente}", cliente);

            if (VerificarRelacionamento(cliente) == false)
            {

                try
                {
                    repositorioCliente.Excluir(cliente);

                    contextoPersistOrm.GravarDados();

                    Log.Logger.Information("Cliente excluído com sucesso. {@cliente}", cliente);

                    return Result.Ok();
                }
                catch (Exception ex)
                {
                    contextoPersistOrm.DesfazerAlteracoes();

                    string msgErro = "Falha ao tentar excluir Cliente.";

                    Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                    return Result.Fail(msgErro);
                }
            }
            else
            {
                string msgErro = "O cliente está relacionado à outra tabela e não pode ser excluído";

                Log.Logger.Error(msgErro + "{Cliente}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Cliente>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioCliente.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "falha no sistema ao tentar selecioanr todos os clientes";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Cliente> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCliente.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", id);

                return Result.Fail(msgErro);
            }
        }

        #region privates

        private bool NomeDuplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarPorNome(cliente.Nome);

            return clienteEncontrado != null &&
                   clienteEncontrado.Nome.Equals(cliente.Nome) &&
                  !clienteEncontrado.Id.Equals(cliente.Id);
        }

        private bool CnpjDuplicado(Cliente cliente)
        {

            var clienteEncontrado = repositorioCliente.SelecionarPorCnpj(cliente.Cnpj);

            return clienteEncontrado != null &&
                   clienteEncontrado.Cnpj != "-" &&
                   clienteEncontrado.Cnpj.Equals(cliente.Cnpj) &&
                   !clienteEncontrado.Id.Equals(cliente.Id);
        }

        private bool CpfDuplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarPorCpf(cliente.Cpf);

            return clienteEncontrado != null &&
                   clienteEncontrado.Cpf != "-" &&
                   clienteEncontrado.Cpf.Equals(cliente.Cpf) &&
                  !clienteEncontrado.Id.Equals(cliente.Id);
        }

        private Result Validar(Cliente cliente)
        {
            var validadorCliente = new ValidadorCliente();

            var resultadoValidacao = validadorCliente.Validate(cliente);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation 
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "'Nome' duplicado"));

            if (CpfDuplicado(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("Cpf", "'Cpf' duplicado"));

            if (CnpjDuplicado(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("Cnpj", "'Cnpj' duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }
        private bool VerificarRelacionamento(Cliente cliente)
        {
            bool resultadoCondutor;
            bool resultadoLocacao;
            bool resultadofinal = false;
              
            var condutores = repositorioCondutor.SelecionarTodos();
            var locacoes = repositorioLocacao.SelecionarTodos();
              
            resultadoCondutor = condutores.Any(x => x.Cliente.Nome == cliente.Nome);
            resultadoLocacao = locacoes.Any(x => x.ClienteLocacao.Nome == cliente.Nome);
           
            if (resultadoCondutor == true || resultadoLocacao == true)
                resultadofinal = true;
            
            return resultadofinal;
         }

         #endregion
        }
    
}
