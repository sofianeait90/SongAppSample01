namespace SongAppSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifier_dateAddednameinAlbum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "DateAdded", c => c.DateTime(nullable: false));
            DropColumn("dbo.Albums", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "MyProperty", c => c.DateTime(nullable: false));
            DropColumn("dbo.Albums", "DateAdded");
        }
    }
}
