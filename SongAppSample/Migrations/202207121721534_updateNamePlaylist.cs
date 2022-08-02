namespace SongAppSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNamePlaylist : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Playlsits", newName: "PlayLists");
            RenameColumn(table: "dbo.PlayListDetails", name: "Playlsit_Id", newName: "playList_Id");
            RenameIndex(table: "dbo.PlayListDetails", name: "IX_Playlsit_Id", newName: "IX_playList_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PlayListDetails", name: "IX_playList_Id", newName: "IX_Playlsit_Id");
            RenameColumn(table: "dbo.PlayListDetails", name: "playList_Id", newName: "Playlsit_Id");
            RenameTable(name: "dbo.PlayLists", newName: "Playlsits");
        }
    }
}
