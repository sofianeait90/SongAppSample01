namespace SongAppSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VirtualizationForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.Songs", "Album_Id", "dbo.Albums");
            //DropForeignKey("dbo.Songs", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.SongLikeds", "Song_Id", "dbo.Songs");
            //DropIndex("dbo.Albums", new[] { "Artist_Id" });
            DropIndex("dbo.Songs", new[] { "Album_Id" });
            //DropIndex("dbo.Songs", new[] { "Artist_Id" });
            DropIndex("dbo.SongLikeds", new[] { "Song_Id" });
            RenameColumn(table: "dbo.Albums", name: "Artist_Id", newName: "ArtistId");
            RenameColumn(table: "dbo.Songs", name: "Album_Id", newName: "AlbumId");
            //RenameColumn(table: "dbo.Songs", name: "Artist_Id", newName: "ArtistId");
            RenameColumn(table: "dbo.SongLikeds", name: "Song_Id", newName: "SongId");
            AddColumn("dbo.Songs", "GenreId_Id", c => c.Int());
            //AlterColumn("dbo.Albums", "ArtistId", c => c.Int(nullable: false));
            //AlterColumn("dbo.Songs", "AlbumId", c => c.Int(nullable: false));
            //AlterColumn("dbo.Songs", "ArtistId", c => c.Int(nullable: false));
            AlterColumn("dbo.SongLikeds", "SongId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Albums", "ArtistId");
            //CreateIndex("dbo.Songs", "ArtistId");
            CreateIndex("dbo.Songs", "AlbumId");
            CreateIndex("dbo.Songs", "GenreId_Id");
            CreateIndex("dbo.SongLikeds", "SongId");
            AddForeignKey("dbo.Songs", "GenreId_Id", "dbo.Genres", "Id");
            //AddForeignKey("dbo.Albums", "ArtistId", "dbo.Artists", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Songs", "AlbumId", "dbo.Albums", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Songs", "ArtistId", "dbo.Artists", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SongLikeds", "SongId", "dbo.Songs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SongLikeds", "SongId", "dbo.Songs");
            //DropForeignKey("dbo.Songs", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Songs", "AlbumId", "dbo.Albums");
            //DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Songs", "GenreId_Id", "dbo.Genres");
            DropIndex("dbo.SongLikeds", new[] { "SongId" });
            DropIndex("dbo.Songs", new[] { "GenreId_Id" });
            DropIndex("dbo.Songs", new[] { "AlbumId" });
            //DropIndex("dbo.Songs", new[] { "ArtistId" });
            //DropIndex("dbo.Albums", new[] { "ArtistId" });
            AlterColumn("dbo.SongLikeds", "SongId", c => c.Int());
            //AlterColumn("dbo.Songs", "ArtistId", c => c.Int());
            AlterColumn("dbo.Songs", "AlbumId", c => c.Int());
            //AlterColumn("dbo.Albums", "ArtistId", c => c.Int());
            DropColumn("dbo.Songs", "GenreId_Id");
            RenameColumn(table: "dbo.SongLikeds", name: "SongId", newName: "Song_Id");
            //RenameColumn(table: "dbo.Songs", name: "ArtistId", newName: "Artist_Id");
            //RenameColumn(table: "dbo.Songs", name: "AlbumId", newName: "Album_Id");
            //RenameColumn(table: "dbo.Albums", name: "ArtistId", newName: "Artist_Id");
            CreateIndex("dbo.SongLikeds", "Song_Id");
            //CreateIndex("dbo.Songs", "Artist_Id");
            CreateIndex("dbo.Songs", "Album_Id");
            //CreateIndex("dbo.Albums", "Artist_Id");
            AddForeignKey("dbo.SongLikeds", "Song_Id", "dbo.Songs", "Id");
            //AddForeignKey("dbo.Songs", "Artist_Id", "dbo.Artists", "Id");
            AddForeignKey("dbo.Songs", "Album_Id", "dbo.Albums", "Id");
            //AddForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists", "Id");
        }
    }
}
