namespace ExempleAjaxProduit.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Data.Entity;
    using TP3_Web_Identity;

    public class FilmDbContext : DbContext
    {
        public FilmDbContext()
            : base("Film")
        {
        }

        public virtual DbSet<TP3.Models.ModelFilm> Films { get; set; }
        public virtual DbSet<TP3.Models.ModelPlaylist> Playlists { get; set; }
        public virtual DbSet<TP3.Models.ModelPlaylistFilm> PlaylistFilms { get; set; }
    }

}