

namespace LocadoraVeiculos.Dominio.Modulo_Taxa
{
    public class Taxa : EntidadeBase<Taxa>
    {
       public string Descricao { get; set; }
       public string Valor { get; set; }
       public string Tipo { get; set; }
    }
}
