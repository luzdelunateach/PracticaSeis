using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Actor> Actors { get; set; } = new List<Actor>();
        public ICollection<Gender> Genders { get; set; } = new List<Gender>();

        public Movie()
        {

        }

        public Movie(string title, string poster, DateTime date)
        {
            Title = title;
            Poster = poster;
            ReleaseDate = date;
        }

        public string TitleFit
        {
            get
            {
                if (string.IsNullOrEmpty(Title))
                {
                    return null;
                }
                if (Title.Length > 60)
                {
                    return Title.Substring(0, 57) + "..";
                }
                else
                {
                    return Title;
                }
            }
        }
    }
}
