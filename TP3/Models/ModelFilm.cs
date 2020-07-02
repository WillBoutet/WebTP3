using System;

namespace TP3.Models
{
    public class ModelFilm
    {

        string titre, image, producteur, description, acteur, url;
        int id;



        public ModelFilm()
        {
            this.id = 0;
            this.titre = null;
            this.description = null;
            this.image = null;
            this.producteur = null;
            this.acteur = null;
            this.url = null;

        }

        public ModelFilm(int id , string titre, string image, string producteur, string description, string acteur, string url)
        {
            this.id = id;
            this.titre = titre;
            this.image = image;
            this.producteur = producteur;
            this.description = description;
            this.acteur = acteur;
            this.url = url;
        }

        public string Titre { get => titre; set => titre = value; }
        public string Image { get => image; set => image = value; }
        public string Producteur { get => producteur; set => producteur = value; }
        public string Description { get => description; set => description = value; }
        public string Acteur { get => acteur; set => acteur = value; }
        public string Url { get => url; set => url = value; }
        public int Id { get => id; set => id = value; }

        public override bool Equals(object obj)
        {
            return obj is ModelFilm film &&
                   this.id == film.id;
        }
    }
        

}