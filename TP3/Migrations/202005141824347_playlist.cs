namespace TP3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playlist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModelPlaylistFilms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Playlist = c.Int(nullable: false),
                        Film = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModelPlaylists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ModelPlaylists");
            DropTable("dbo.ModelPlaylistFilms");
            DropTable("dbo.ModelFilms");
        }
    }
}
