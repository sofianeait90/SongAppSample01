namespace SongAppSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class virtualization2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Songs", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Songs", new[] { "Artist_Id" });
            RenameColumn(table: "dbo.Songs", name: "Artist_Id", newName: "ArtistId");
            //AlterColumn("dbo.Songs", "AlbumId", c => c.Int(nullable: false));
            AlterColumn("dbo.Songs", "ArtistId", c => c.Int(nullable: false));
            CreateIndex("dbo.Songs", "ArtistId");
            AddForeignKey("dbo.Songs", "ArtistId", "dbo.Artists", "Id", cascadeDelete: true);

        }

        public override void Down()
        {
            //dropforeignkey("dbo.songs", "artistid", "dbo.artists");
            DropIndex("dbo.Songs", new[] { "ArtistId" });
            RenameColumn(table: "dbo.Songs", name: "ArtistId", newName: "Artist_Id");
            //RenameColumn(table: "dbo.Songs", name: "AlbumId", newName: "Album_Id");
            CreateIndex("dbo.Songs", "Artist_Id");
            AddForeignKey("dbo.Songs", "Artist_Id", "dbo.Artists", "Id");
        }

}
}
