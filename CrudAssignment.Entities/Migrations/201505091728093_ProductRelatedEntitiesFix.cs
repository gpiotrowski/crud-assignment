namespace CrudAssignment.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductRelatedEntitiesFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Products", "Supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Products", new[] { "Supplier_Id" });
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Products", name: "Supplier_Id", newName: "SupplierId");
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "SupplierId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Products", "SupplierId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            AlterColumn("dbo.Products", "SupplierId", c => c.Int());
            AlterColumn("dbo.Products", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "SupplierId", newName: "Supplier_Id");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Products", "Supplier_Id");
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Products", "Supplier_Id", "dbo.Suppliers", "Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
