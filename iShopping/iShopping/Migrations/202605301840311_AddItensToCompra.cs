namespace iShopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItensToCompra : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Compra_Id", "dbo.Compras");
            AddColumn("dbo.Items", "Compra_Id1", c => c.Int());
            CreateIndex("dbo.Items", "Compra_Id1");
            AddForeignKey("dbo.Items", "Compra_Id", "dbo.Compras", "Id");
            AddForeignKey("dbo.Items", "Compra_Id1", "dbo.Compras", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Compra_Id1", "dbo.Compras");
            DropForeignKey("dbo.Items", "Compra_Id", "dbo.Compras");
            DropIndex("dbo.Items", new[] { "Compra_Id1" });
            DropColumn("dbo.Items", "Compra_Id1");
            AddForeignKey("dbo.Items", "Compra_Id", "dbo.Compras", "Id");
        }
    }
}
