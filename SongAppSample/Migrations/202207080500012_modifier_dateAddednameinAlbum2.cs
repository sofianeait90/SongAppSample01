namespace SongAppSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifier_dateAddednameinAlbum2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Songs", "Title", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Songs", "Title", c => c.Int(nullable: false));
        }
    }
}
