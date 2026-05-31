namespace iShopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDateTimeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Compras", "Data_alteracao", c => c.DateTime());
            AlterColumn("dbo.Compras", "Data_fecho", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Compras", "Data_fecho", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Compras", "Data_alteracao", c => c.DateTime(nullable: false));
        }
    }
}
