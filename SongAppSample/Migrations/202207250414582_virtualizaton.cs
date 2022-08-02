namespace SongAppSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Virtualizaton : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Songs", "GenreId_Id", "dbo.Genres");
            DropForeignKey("dbo.Songs", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Songs", new[] { "Genre_Id" });
            DropIndex("dbo.Songs", new[] { "GenreId_Id" });
            RenameColumn(table: "dbo.Songs", name: "Genre_Id", newName: "GenreId");
            AlterColumn("dbo.Songs", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Songs", "GenreId");
            AddForeignKey("dbo.Songs", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Songs", "GenreId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "GenreId_Id", c => c.Int());
            DropForeignKey("dbo.Songs", "GenreId", "dbo.Genres");
            DropIndex("dbo.Songs", new[] { "GenreId" });
            AlterColumn("dbo.Songs", "GenreId", c => c.Int());
            RenameColumn(table: "dbo.Songs", name: "GenreId", newName: "Genre_Id");
            CreateIndex("dbo.Songs", "GenreId_Id");
            CreateIndex("dbo.Songs", "Genre_Id");
            AddForeignKey("dbo.Songs", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Songs", "GenreId_Id", "dbo.Genres", "Id");
        }
    }
}
