namespace EventApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedTransactionsSection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "DaysRenting", c => c.Int(nullable: false));
            AddColumn("dbo.Transaction", "TransactionCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Transaction", "UserID");
            DropColumn("dbo.Transaction", "VenueCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "VenueCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.Transaction", "TransactionCost");
            DropColumn("dbo.Transaction", "DaysRenting");
        }
    }
}
