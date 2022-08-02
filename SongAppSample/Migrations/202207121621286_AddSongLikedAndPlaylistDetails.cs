namespace SongAppSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSongLikedAndPlaylistDetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Songs", "Playlsit_Id", "dbo.Playlsits");
            DropIndex("dbo.Songs", new[] { "Playlsit_Id" });
            CreateTable(
                "dbo.PlayListDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateAddedToPlaylist = c.DateTime(nullable: false),
                        Playlsit_Id = c.Int(),
                        Song_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Playlsits", t => t.Playlsit_Id)
                .ForeignKey("dbo.Songs", t => t.Song_Id)
                .Index(t => t.Playlsit_Id)
                .Index(t => t.Song_Id);
            
            CreateTable(
                "dbo.SongLikeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsLiked = c.Boolean(nullable: false),
                        Song_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Songs", t => t.Song_Id)
                .Index(t => t.Song_Id);
            
            DropColumn("dbo.Songs", "Isliked");
            DropColumn("dbo.Songs", "Playlsit_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "Playlsit_Id", c => c.Int());
            AddColumn("dbo.Songs", "Isliked", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.SongLikeds", "Song_Id", "dbo.Songs");
            DropForeignKey("dbo.PlayListDetails", "Song_Id", "dbo.Songs");
            DropForeignKey("dbo.PlayListDetails", "Playlsit_Id", "dbo.Playlsits");
            DropIndex("dbo.SongLikeds", new[] { "Song_Id" });
            DropIndex("dbo.PlayListDetails", new[] { "Song_Id" });
            DropIndex("dbo.PlayListDetails", new[] { "Playlsit_Id" });
            DropTable("dbo.SongLikeds");
            DropTable("dbo.PlayListDetails");
            CreateIndex("dbo.Songs", "Playlsit_Id");
            AddForeignKey("dbo.Songs", "Playlsit_Id", "dbo.Playlsits", "Id");
        }
    }
}
