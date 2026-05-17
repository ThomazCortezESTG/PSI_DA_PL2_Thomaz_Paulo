namespace iShopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artigoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Tipo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tipo_de_artigo", t => t.Tipo_Id)
                .Index(t => t.Tipo_Id);
            
            CreateTable(
                "dbo.Tipo_de_artigo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Utilizadors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Preco_total = c.Single(nullable: false),
                        Data_criacao = c.DateTime(nullable: false),
                        Data_alteracao = c.DateTime(nullable: false),
                        Data_fecho = c.DateTime(nullable: false),
                        AlteradoPor_Id = c.Int(),
                        FechadoPor_Id = c.Int(),
                        Utilizador_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilizadors", t => t.AlteradoPor_Id)
                .ForeignKey("dbo.Utilizadors", t => t.FechadoPor_Id)
                .ForeignKey("dbo.Utilizadors", t => t.Utilizador_Id)
                .Index(t => t.AlteradoPor_Id)
                .Index(t => t.FechadoPor_Id)
                .Index(t => t.Utilizador_Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Preco_unitario = c.Single(nullable: false),
                        Observacoes = c.String(),
                        Quantidade_prevista = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Artigo_Id = c.Int(),
                        Compra_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artigoes", t => t.Artigo_Id)
                .ForeignKey("dbo.Compras", t => t.Compra_Id)
                .Index(t => t.Artigo_Id)
                .Index(t => t.Compra_Id);
            
            CreateTable(
                "dbo.Orcamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Montante = c.Single(nullable: false),
                        Mes = c.Int(nullable: false),
                        Ano = c.Int(nullable: false),
                        Data_criacao = c.DateTime(nullable: false),
                        Ultima_alteracao = c.DateTime(nullable: false),
                        AlteradoPor_Id = c.Int(),
                        CriadoPor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilizadors", t => t.AlteradoPor_Id)
                .ForeignKey("dbo.Utilizadors", t => t.CriadoPor_Id)
                .Index(t => t.AlteradoPor_Id)
                .Index(t => t.CriadoPor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orcamentoes", "CriadoPor_Id", "dbo.Utilizadors");
            DropForeignKey("dbo.Orcamentoes", "AlteradoPor_Id", "dbo.Utilizadors");
            DropForeignKey("dbo.Compras", "Utilizador_Id", "dbo.Utilizadors");
            DropForeignKey("dbo.Items", "Compra_Id", "dbo.Compras");
            DropForeignKey("dbo.Items", "Artigo_Id", "dbo.Artigoes");
            DropForeignKey("dbo.Compras", "FechadoPor_Id", "dbo.Utilizadors");
            DropForeignKey("dbo.Compras", "AlteradoPor_Id", "dbo.Utilizadors");
            DropForeignKey("dbo.Artigoes", "Tipo_Id", "dbo.Tipo_de_artigo");
            DropIndex("dbo.Orcamentoes", new[] { "CriadoPor_Id" });
            DropIndex("dbo.Orcamentoes", new[] { "AlteradoPor_Id" });
            DropIndex("dbo.Items", new[] { "Compra_Id" });
            DropIndex("dbo.Items", new[] { "Artigo_Id" });
            DropIndex("dbo.Compras", new[] { "Utilizador_Id" });
            DropIndex("dbo.Compras", new[] { "FechadoPor_Id" });
            DropIndex("dbo.Compras", new[] { "AlteradoPor_Id" });
            DropIndex("dbo.Artigoes", new[] { "Tipo_Id" });
            DropTable("dbo.Orcamentoes");
            DropTable("dbo.Items");
            DropTable("dbo.Compras");
            DropTable("dbo.Utilizadors");
            DropTable("dbo.Tipo_de_artigo");
            DropTable("dbo.Artigoes");
        }
    }
}
