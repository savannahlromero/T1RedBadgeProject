namespace EventApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weBrokeTheCodeAndNowWeMaybeFixedIt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Review", "VenueID", c => c.Int(nullable: false));
            AddColumn("dbo.Review", "ApplicationUserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Review", "VenueRating", c => c.Int(nullable: false));
            AddColumn("dbo.Review", "Comments", c => c.String());
            AddColumn("dbo.Review", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Transaction", "ApplicationUserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Transaction", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Transaction", "VenueID", c => c.Int(nullable: false));
            AddColumn("dbo.Transaction", "VenueCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Review", "VenueID");
            CreateIndex("dbo.Review", "User_Id");
            CreateIndex("dbo.Transaction", "VenueID");
            CreateIndex("dbo.Transaction", "User_Id");
            AddForeignKey("dbo.Review", "User_Id", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.Review", "VenueID", "dbo.Venue", "VenueID", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "User_Id", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.Transaction", "VenueID", "dbo.Venue", "VenueID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "VenueID", "dbo.Venue");
            DropForeignKey("dbo.Transaction", "User_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Review", "VenueID", "dbo.Venue");
            DropForeignKey("dbo.Review", "User_Id", "dbo.ApplicationUser");
            DropIndex("dbo.Transaction", new[] { "User_Id" });
            DropIndex("dbo.Transaction", new[] { "VenueID" });
            DropIndex("dbo.Review", new[] { "User_Id" });
            DropIndex("dbo.Review", new[] { "VenueID" });
            DropColumn("dbo.Transaction", "User_Id");
            DropColumn("dbo.Transaction", "VenueCost");
            DropColumn("dbo.Transaction", "VenueID");
            DropColumn("dbo.Transaction", "UserID");
            DropColumn("dbo.Transaction", "ApplicationUserId");
            DropColumn("dbo.Review", "User_Id");
            DropColumn("dbo.Review", "Comments");
            DropColumn("dbo.Review", "VenueRating");
            DropColumn("dbo.Review", "ApplicationUserId");
            DropColumn("dbo.Review", "VenueID");
        }
    }
}
