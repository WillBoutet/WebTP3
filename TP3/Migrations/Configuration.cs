namespace TP3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TP3.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ExempleAjaxProduit.Models.FilmDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExempleAjaxProduit.Models.FilmDbContext context)
        {

            context.Database.ExecuteSqlCommand("delete from dbo.ModelFilms");
            context.Database.ExecuteSqlCommand("delete from dbo.ModelPlaylists");
            context.Database.ExecuteSqlCommand("delete from dbo.ModelPlaylistFilms");
            
            TP3.Models.ModelPlaylist pl = new TP3.Models.ModelPlaylist();
            pl.Id = 1;
            pl.IdUser = "1";
            context.Playlists.Add(pl);

            ModelFilm film1 = new ModelFilm();
            film1.Id = 1;
            film1.Titre = "The SpongeBob SquarePants Movie";
            film1.Image = "https://upload.wikimedia.org/wikipedia/en/thumb/3/31/The_SpongeBob_SquarePants_Movie_poster.jpg/220px-The_SpongeBob_SquarePants_Movie_poster.jpg";
            film1.Producteur = "Stephen Hillenburg";
            film1.Acteur = "Tom Kenny";
            film1.Description = "A yellow sea sponge named SpongeBob SquarePants lives in the city of Bikini Bottom deep in the Pacific Ocean. He works at the Krusty Krab restaurant and is friends with a starfish named Patrick.";
            film1.Url = "https://www.youtube.com/embed/Nm7W0bElZ4s";
            context.Films.Add(film1);


            ModelPlaylistFilm plf1 = new ModelPlaylistFilm();
            plf1.Id = 1;
            plf1.Playlist = pl.Id;
            plf1.Film = film1.Id;
            context.PlaylistFilms.Add(plf1);

            film1 = new ModelFilm();
            film1.Id = 2;
            film1.Titre = "The SpongeBob Movie : Out of Water";
            film1.Image = "https://i.pinimg.com/originals/62/59/75/625975388a352bd8163810f2dc19730f.jpg";
            film1.Producteur = "Paul Tibbitt";
            film1.Acteur = "Tom Kenny";
            film1.Description = "SpongeBob SquarePants comes ashore and embarks on an adventurous quest to recover the Krabby Patty's secret formula stolen by a pirate known as Burger Beard.";
            film1.Url = "https://www.youtube.com/embed/W3x0ZxDSF38";
            context.Films.Add(film1);

            film1 = new ModelFilm();
            film1.Id = 3;
            film1.Titre = "The SpongeBob Movie : Sponge on the Run";
            film1.Image = "https://images.penguinrandomhouse.com/cover/9780593127513";
            film1.Producteur = "Ryan Harris";
            film1.Acteur = "Tom Kenny";
            film1.Description = "SpongeBob and Patrick travel to the lost city of Atlantic City to solve the mysterious kidnapping of Gary the snail. They soon prove that there's nothing stronger than the power of friendship as they encounter danger and delight at every turn.";
            film1.Url = "https://www.youtube.com/embed/HfiH_526qhY";
            context.Films.Add(film1);

            ModelPlaylistFilm plf2 = new ModelPlaylistFilm();
            plf2.Id = 2;
            plf2.Playlist = pl.Id;
            plf2.Film = film1.Id;
            context.PlaylistFilms.Add(plf2);

            film1 = new ModelFilm();
            film1.Id = 4;
            film1.Titre = "SpongeBob SquarePants : Christmas";
            film1.Image = "https://images-na.ssl-images-amazon.com/images/I/51kLRqFASAL._SY445_.jpg";
            film1.Producteur = "Stephen Hillenburg";
            film1.Acteur = "Tom Kenny";
            film1.Description = "A yellow sea sponge named SpongeBob SquarePants lives in the city of Bikini Bottom deep in the Pacific Ocean. He works at the Krusty Krab restaurant and is friends with a starfish named Patrick.";
            film1.Url = "https://www.youtube.com/embed/BQc6xZErY-0";
            context.Films.Add(film1);

            film1 = new ModelFilm();
            film1.Id = 5;
            film1.Titre = "SpongeBob SquarePants : SeaSide Story";
            film1.Image = "https://static.raru.co.za/cover/2017/02/14/5488643-l.jpg?v=1487060148";
            film1.Producteur = "Stephen Hillenburg";
            film1.Acteur = "Tom Kenny";
            film1.Description = "Bikini Bottom's baddest gang, the Sharks, just got a new member!...But can SpongeBob prove that he isn't as square as he looks when they face their rivals, the Pods? Soak up the action and 7 more tales of nautical nonsense, including prophetic fortune cookies, Sandy's newest food craze, countless SpongeBob clones and more.";
            film1.Url = "https://www.youtube.com/embed/ZTmewoYT5s8";
            context.Films.Add(film1);


            ModelPlaylistFilm plf3 = new ModelPlaylistFilm();
            plf3.Id = 3;
            plf3.Playlist = pl.Id;
            plf3.Film = film1.Id;
            context.PlaylistFilms.Add(plf3);

            
        }
    }
}
