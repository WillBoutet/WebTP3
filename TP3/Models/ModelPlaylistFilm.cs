using System;

namespace TP3.Models
{
    public class ModelPlaylistFilm
    {
        int id;
        int playlist;
        int film;
        public int Playlist{ get => playlist; set => playlist = value; }
        
        public int Film { get => film; set => film = value; }
        public int Id { get => id; set => id = value; }

        public ModelPlaylistFilm()
        {
            this.Id = 0;
            this.Playlist = 0;
            this.Film = 0;
        }

        public ModelPlaylistFilm(int idPlaylistFilm , int Playlist, int Film)
        {
            this.Id = idPlaylistFilm;
            this.Playlist = Playlist;
            this.Film = Film;
        }

        public ModelPlaylistFilm(int idPlaylist, int film) {
            this.Playlist = idPlaylist;
            this.Film = film;
        }

        public override bool Equals(object obj)
        {
            return obj is ModelPlaylistFilm playlistFilm &&
                   this.Id == playlistFilm.Id;
        }
    }
        

}