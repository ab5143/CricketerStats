namespace CricketerStats.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGuid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OneDayStats", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.TestStats", "UserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestStats", "UserId");
            DropColumn("dbo.OneDayStats", "UserId");
        }
    }
}
