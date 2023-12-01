using Speridian.MMS.Entities;
using Speridian.MMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speridian.MMS.DAL
{
    public class ActorsDAL
    {
        static List<Actors> list = new List<Actors>
        {
            new Actors{ActorId=1,ActorName="Tom Cruise",Gender=Gender.Male},
            new Actors{ActorId=2,ActorName="Nidhin",Gender=Gender.Male},
            new Actors{ActorId=3,ActorName="Adarsh",Gender=Gender.Male},
        };
        static int counter = 3;
        public static List<Actors> GetActorsList()
        {
            return list;
        }
        public static bool Add(Actors newActor)
        {
            bool isExists = list.Exists(d => d.ActorName == newActor.ActorName);
            if (isExists)
            {
                throw new MMSExceptions("Actor already Exists");
            }
            newActor.ActorId = ++counter;
            list.Add(newActor);
            return true;
        }

        public static Actors GetById(int id)
        {
            var actor = list.Find(d => d.ActorId == id);
            return actor;
        }
        public static bool Update(Actors actor)
        {

            list.Append(actor);
            return true;
        }


    }
}