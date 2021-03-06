namespace CricketerStats.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.OneDayStats");
            DropColumn("dbo.OneDayStats", "OneDayInt");
            AddColumn("dbo.OneDayStats", "OneDayIntId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.OneDayStats", "OneDayIntId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OneDayStats", "OneDayInt", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.OneDayStats");
            DropColumn("dbo.OneDayStats", "OneDayIntId");
            AddPrimaryKey("dbo.OneDayStats", "OneDayInt");
        }
    }
}
