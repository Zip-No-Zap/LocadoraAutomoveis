using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Compartilhado
{
    public abstract class ControladorBase
    {
       public abstract void Inserir();
       public abstract void Editar();
       public abstract void Excluir();
       public abstract UserControl ObtemListagem();
       public abstract ConfiguracaoToolStripBase ObtemConfiguracaoToolStrip();
    }
}
