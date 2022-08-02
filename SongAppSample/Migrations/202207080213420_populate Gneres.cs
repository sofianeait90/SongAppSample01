namespace SongAppSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGneres : DbMigration
    {
        public override void Up()
        {
           Sql("Insert Into Genres (Name) VALUES ('Rock')" );
           Sql("Insert Into Genres (Name) VALUES ('Jazz')" );
           Sql("Insert Into Genres (Name) VALUES ('Electronic ')" );
            Sql("Insert Into Genres (Name) VALUES ('Classic')");
        }
        
        public override void Down()
        {
        }
    }
}
