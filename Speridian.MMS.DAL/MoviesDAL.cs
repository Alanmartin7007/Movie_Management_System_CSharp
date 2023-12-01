using Speridian.MMS.Entities;
using System.Collections.Generic;

namespace Speridian.MMS.DAL
{
    public class MoviesDAL
    {
        static List<Movies> list = new List<Movies>
     {
        new Movies
         {
             Id = 1,
             Name = "BIG B",
             Director = "Amal Neerad",
             ReleaseYear = 2007,
             Duration = TimeSpan.FromHours(2).Add(TimeSpan.FromMinutes(6)), // 02:06:00
             Rating = 8.5,
           Actors = new List<Actors>
             {
                 new Actors { ActorId = 2,ActorName = "Mammootty",Gender= Gender.Male,DateOfBirth=new DateOnly(1951, 9, 7)},
                 new Actors { ActorName = "Manoj K. Jayan",Gender= Gender.Male,DateOfBirth=new DateOnly(1961, 7, 16) }
             },
            MovieGenre = Genre.Horror,
             MovieLanguage = Language.Malayalam
         },
     };
        static int counter = 1;

        public static List<Movies> GetMovies()
        {
            return list;

        }




      
        public static List<Movies> GetActorsList()
        {
            return list;
        }

    }
}