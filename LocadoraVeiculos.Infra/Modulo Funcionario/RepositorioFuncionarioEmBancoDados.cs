using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Funcionario
{
    public class RepositorioFuncionarioEmBancoDados : ConexaoBancoDados<Funcionario>, IRepositorio<Funcionario>
    {
        public ValidationResult Editar(Funcionario entidade)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(Funcionario entidade)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Inserir(Funcionario entidade)
        {
            throw new NotImplementedException();
        }

        public Funcionario SelecionarPorId(int numero)
        {
            throw new NotImplementedException();
        }

        public List<Funcionario> SelecionarTodos()
        {
            throw new NotImplementedException();
        }

        protected override void DefinirParametros(Funcionario entidade, SqlCommand cmd_Insercao)
        {
            throw new NotImplementedException();
        }

        protected override void EditarRegistroBancoDados(Funcionario entidade)
        {
            throw new NotImplementedException();
        }

        protected override void ExcluirRegistroBancoDados(Funcionario entidade)
        {
            throw new NotImplementedException();
        }

        protected override void InserirRegistroBancoDados(Funcionario entidade)
        {
            throw new NotImplementedException();
        }

        protected override List<Funcionario> LerTodos(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }

        protected override Funcionario LerUnico(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }

        protected override ValidationResult Validar(Funcionario entidade)
        {
            throw new NotImplementedException();
        }
    }
}
