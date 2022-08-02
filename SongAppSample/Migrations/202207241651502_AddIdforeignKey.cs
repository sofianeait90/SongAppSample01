namespace SongAppSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdforeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlayListDetails", "playList_Id", "dbo.PlayLists");
            DropForeignKey("dbo.PlayListDetails", "Song_Id", "dbo.Songs");
            DropIndex("dbo.PlayListDetails", new[] { "playList_Id" });
            DropIndex("dbo.PlayListDetails", new[] { "Song_Id" });
            RenameColumn(table: "dbo.PlayListDetails", name: "playList_Id", newName: "PlayListId");
            RenameColumn(table: "dbo.PlayListDetails", name: "Song_Id", newName: "SongId");
            AlterColumn("dbo.PlayListDetails", "PlayListId", c => c.Int(nullable: false));
            AlterColumn("dbo.PlayListDetails", "SongId", c => c.Int(nullable: false));
            CreateIndex("dbo.PlayListDetails", "PlayListId");
            CreateIndex("dbo.PlayListDetails", "SongId");
            AddForeignKey("dbo.PlayListDetails", "PlayListId", "dbo.PlayLists", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PlayListDetails", "SongId", "dbo.Songs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayListDetails", "SongId", "dbo.Songs");
            DropForeignKey("dbo.PlayListDetails", "PlayListId", "dbo.PlayLists");
            DropIndex("dbo.PlayListDetails", new[] { "SongId" });
            DropIndex("dbo.PlayListDetails", new[] { "PlayListId" });
            AlterColumn("dbo.PlayListDetails", "SongId", c => c.Int());
            AlterColumn("dbo.PlayListDetails", "PlayListId", c => c.Int());
            RenameColumn(table: "dbo.PlayListDetails", name: "SongId", newName: "Song_Id");
            RenameColumn(table: "dbo.PlayListDetails", name: "PlayListId", newName: "playList_Id");
            CreateIndex("dbo.PlayListDetails", "Song_Id");
            CreateIndex("dbo.PlayListDetails", "playList_Id");
            AddForeignKey("dbo.PlayListDetails", "Song_Id", "dbo.Songs", "Id");
            AddForeignKey("dbo.PlayListDetails", "playList_Id", "dbo.PlayLists", "Id");
        }
    }
}
