namespace CrudAssignment.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMinimumStockToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "MinimumStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "MinimumStock");
        }
    }
}
