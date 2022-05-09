using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class GenderMovie
    {
        public int GendersId { get; set; }
        public int MoviesId { get; set; }

        public GenderMovie()
        {

        }

        public GenderMovie(int gId, int mId)
        {
            GendersId = gId;
            MoviesId = mId;
        }
    }
}
