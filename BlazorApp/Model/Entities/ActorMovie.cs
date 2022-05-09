using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class ActorMovie
    {
        public int ActorsId { get; set; }
        public int MoviesId { get; set; }

        public ActorMovie()
        {

        }

        public ActorMovie(int idA, int idM)
        {
            ActorsId = idA;
            MoviesId = idM;
        }
    }
}
