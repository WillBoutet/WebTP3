using System;

namespace TP3.Models
{
    public class ModelPlaylist
    {
        int id;
        string idUser;
        public int Id { get => id; set => id = value; }
        public string IdUser { get => idUser; set => idUser = value; }

        public ModelPlaylist()
        {
        }

        public ModelPlaylist(int idPlaylist, string idUser)
        {
            this.Id = idPlaylist;
            this.IdUser = idUser;
        }

        public ModelPlaylist(string idUser) {
            this.IdUser = idUser;
        }


        public override bool Equals(object obj)
        {
            return obj is ModelPlaylist playlist &&
                   this.Id == playlist.Id;
        }
    }
        

}