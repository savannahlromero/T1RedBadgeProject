namespace EventApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingToFixGUID : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Transaction", new[] { "User_Id" });
            CreateIndex("dbo.Transaction", "user_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Transaction", new[] { "user_Id" });
            CreateIndex("dbo.Transaction", "User_Id");
        }
    }
}
