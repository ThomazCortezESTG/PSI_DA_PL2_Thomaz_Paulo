namespace iShopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFechadaToCompra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Compras", "Fechada", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Compras", "Fechada");
        }
    }
}
