namespace Modelo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContextoBD>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ContextoBD db)
        {
            db.Categorias.AddOrUpdate(
                p => p.Descricao,
                new Categoria { Descricao = "Categoria 1" },
                new Categoria { Descricao = "Categoria 2"},
                new Categoria { Descricao = "Categoria 3" }
                );

        }
    }
}
