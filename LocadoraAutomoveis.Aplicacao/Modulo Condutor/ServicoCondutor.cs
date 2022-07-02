using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Condutor;
using System.Collections.Generic;

namespace LocadoraAutomoveis.Aplicacao.Modulo_Condutor
{
    public class ServicoCondutor
    {
        readonly RepositorioCondutorEmBancoDados repositorioCondutor;
        ValidadorCondutor validadorCondutor;

        public ServicoCondutor(RepositorioCondutorEmBancoDados repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor; 
        }

        public ValidationResult Inserir(Condutor condutor)
        {
            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
                repositorioCondutor.Inserir(condutor);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Condutor condutor)
        {
            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
                repositorioCondutor.Editar(condutor);

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Condutor condutor)
        {
            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
                repositorioCondutor.Excluir(condutor);

            return resultadoValidacao;
        }

        public List<Condutor> SelecionarTodos()
        {
            return repositorioCondutor.SelecionarTodos();
        }
        public Condutor SelecionarPorId(int id)
        {
            return repositorioCondutor.SelecionarPorId(id);
        }


        public ValidationResult Validar(Condutor funcionario)
        {
            validadorCondutor = new ValidadorCondutor();

            var resultadoValidacao = validadorCondutor.Validate(funcionario);

            return resultadoValidacao;
        }
    }
}
