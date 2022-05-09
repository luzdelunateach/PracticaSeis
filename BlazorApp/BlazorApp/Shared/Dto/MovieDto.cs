using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Poster { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public List<int> Actors { get; set; }
        public List<int> Genres { get; set; }

        public ICollection<Actor> Actorss { get; set; } = new List<Actor>();
        public ICollection<Gender> Genderss { get; set; } = new List<Gender>();
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
