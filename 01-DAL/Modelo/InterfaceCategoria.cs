using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelo
{
    public interface InterfaceCategoria : IDisposable
    {
        DbSet<Categoria> Categorias { get; }
        int SaveChanges();
        void MarkAsModified(Categoria item);

    }
}
