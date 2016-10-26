using Modelo.Modelo;
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
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContextoBD, Migrations.Configuration>("ContextoBD"));

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
        //----------------------------------- Dependency injection --------------------------------//
        public void MarkAsModified(Categoria item) //retira a dependência da tabela categoria
        {
            Entry(item).State = EntityState.Modified;
        }

        public void MarkAsModified(SubCategoria item) //retira a dependência da tabela Subcategoria
        {
            Entry(item).State = EntityState.Modified;
        }

        public void MarkAsModified(Produto item) //retira a dependência da tabela Produto
        {
            Entry(item).State = EntityState.Modified;
        }

        //-----------------------------------Fim de dependency injection --------------------------------//

    }

}
