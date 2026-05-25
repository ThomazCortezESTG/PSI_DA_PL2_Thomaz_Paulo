using iShopping.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace iShopping.Migrations
{

    internal sealed class AppDbInitializer : DropCreateDatabaseIfModelChanges<ShoppingContext>
    {

        protected override void Seed(iShopping.Models.ShoppingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
