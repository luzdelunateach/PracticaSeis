using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int YearsActive { get; set; }
        public string? Photo { get; set; }
        public string? Biography { get; set; }
        public ICollection<Movie> Movies { get; set; }

        public Actor()
        {

        }
        public Actor(string name, string lastName, DateTime? birth, int year, string photo, string biography)
        {
            FirstName = name;
            LastName = lastName;
            DateOfBirth = birth;
            YearsActive = year;
            Photo = photo;
            Biography = biography;
        }
        public string TitleFit
        {
            get
            {
                if (string.IsNullOrEmpty(FirstName))
                {
                    return null;
                }
                if (FirstName.Length > 60)
                {
                    return FirstName.Substring(0, 57) + "..";
                }
                else
                {
                    return FirstName;
                }
            }
        }
    }
}
