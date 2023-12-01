using Speridian.MMS.DAL;
using Speridian.MMS.Entities;

namespace Speridian.MMS.BL
{
    public class MoviesBL
    {
        public static List<Movies> GetMovieList()
        {
            var list = MoviesDAL.GetActorsList();
            return list;
        }
    }
}