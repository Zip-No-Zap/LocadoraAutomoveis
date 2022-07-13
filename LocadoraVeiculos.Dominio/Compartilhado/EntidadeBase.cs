

using System;
using Taikandi;

namespace LocadoraVeiculos.Dominio
{
    public class EntidadeBase<T>
    {
        public Guid Id { get; set; }

        public EntidadeBase()
        {
            Id = SequentialGuid.NewGuid(); 
        }
    }
}
