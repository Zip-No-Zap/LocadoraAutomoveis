

namespace LocadoraAutomoveis.Infra.Orm.Compartilhado
{
    public interface IContextoPersistencia
    {
        void GravarDados();

        void DesfazerAlteracoes();
    }
}
