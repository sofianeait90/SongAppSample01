namespace SongAppSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlaylistLike : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Playlsits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Songs", "Isliked", c => c.Boolean(nullable: false));
            AddColumn("dbo.Songs", "Playlsit_Id", c => c.Int());
            CreateIndex("dbo.Songs", "Playlsit_Id");
            AddForeignKey("dbo.Songs", "Playlsit_Id", "dbo.Playlsits", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "Playlsit_Id", "dbo.Playlsits");
            DropIndex("dbo.Songs", new[] { "Playlsit_Id" });
            DropColumn("dbo.Songs", "Playlsit_Id");
            DropColumn("dbo.Songs", "Isliked");
            DropTable("dbo.Playlsits");
        }
    }
}
