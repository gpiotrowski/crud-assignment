namespace CrudAssignment.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductIdentity : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Products", "Id");
        }
    }
}
