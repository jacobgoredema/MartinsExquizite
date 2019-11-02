namespace MartinsExquizite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedCategoryid : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Categories", new[] { "ParentCategoryID" });
            CreateIndex("dbo.Categories", "ParentCategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categories", new[] { "ParentCategoryId" });
            CreateIndex("dbo.Categories", "ParentCategoryID");
        }
    }
}
