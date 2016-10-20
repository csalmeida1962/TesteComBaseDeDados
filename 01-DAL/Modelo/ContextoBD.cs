using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{

    public class ContextoBD : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }

        public ContextoBD()  : base("name=ContextoBD")
        {
            
            // Database.SetInitializer<ContextoBD>(new DropCreateBD());        // Elimina a BD e cria de novo
           // Database.SetInitializer<ContextoBD>(new CreateBDIfNotExist());    // Cria a BD se não Existe
            //Database.SetInitializer<ContextoBd>( new DropCreateIfChange()); // Drop e Create se houver change
            this.Configuration.ProxyCreationEnabled = false;

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }

}
