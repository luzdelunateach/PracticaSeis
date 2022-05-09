using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
        public string TitleFit
        {
            get
            {
                if (string.IsNullOrEmpty(Name))
                {
                    return null;
                }
                if (Name.Length > 60)
                {
                    return Name.Substring(0, 57) + "..";
                }
                else
                {
                    return Name;
                }
            }
        }

        public Gender(string name)
        {
            Name = name;
        }
    }
}
