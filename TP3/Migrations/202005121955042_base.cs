namespace TP3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class _base : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModelFilms",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Titre = c.String(),
                    Image = c.String(),
                    Producteur = c.String(),
                    Description = c.String(),
                    Acteur = c.String(),
                    Url = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.ModelFilms");
            DropTable("dbo.ModelPlaylist");
            DropTable("dbo.ModelPlaylistFilm");
        }
    }
}
