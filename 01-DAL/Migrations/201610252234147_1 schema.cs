namespace Modelo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1schema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        IdCategoria = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdCategoria);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        IdProduto = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        Imagem = c.Binary(),
                        PrVenda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdSubCategoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProduto)
                .ForeignKey("dbo.SubCategorias", t => t.IdSubCategoria)
                .Index(t => t.IdSubCategoria);
            
            CreateTable(
                "dbo.SubCategorias",
                c => new
                    {
                        IdSubCategoria = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        IdCategoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSubCategoria)
                .ForeignKey("dbo.Categorias", t => t.IdCategoria)
                .Index(t => t.IdCategoria);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "IdSubCategoria", "dbo.SubCategorias");
            DropForeignKey("dbo.SubCategorias", "IdCategoria", "dbo.Categorias");
            DropIndex("dbo.SubCategorias", new[] { "IdCategoria" });
            DropIndex("dbo.Produtos", new[] { "IdSubCategoria" });
            DropTable("dbo.SubCategorias");
            DropTable("dbo.Produtos");
            DropTable("dbo.Categorias");
        }
    }
}
