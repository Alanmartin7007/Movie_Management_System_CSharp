using Newtonsoft.Json.Linq;
using Speridian.MMS.BL;
using Speridian.MMS.Entities;
using Speridian.MMS.Exceptions;
using System.Text.RegularExpressions;

namespace Speridian.MMS.PresentationLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {

                    Console.WriteLine("#################");
                    Console.WriteLine("1  LIST ACTORS ");
                    Console.WriteLine("2  LIST MOVIES");
                    Console.WriteLine("3  ADD ACTORS ");
                    Console.WriteLine("4  UPDATE ACTORS ");
                    Console.WriteLine("5  ADD MOVIES ");
                    Console.WriteLine("6  UPDATE MOVIE ");
                    Console.WriteLine("7  DELETE ACTOR ");
                    Console.WriteLine("8  DELETE MOVIE ");
                    Console.WriteLine("9 #### EXIT ####");
                    Console.WriteLine(" Enter your choice ");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out int choice))
                    {
                        Console.WriteLine("INVALID INPUT");
                        return;
                    }
                    switch (choice)
                    {
                        case 1:
                             ListActors();
                            break;
                        case 2:
                             ListMovies();
                            break;
                        case 3:
                             AddActors();
                            break;
                        case 4:
                            UpdateActor();
                            break;
                        case 5:
                            //AddMovies();
                            break;
                        case 6:
                            // UpdateActors();
                            break;
                        case 7:
                            //DeleteActor();
                            break;
                        case 8:
                            //DeleteMovies();
                            break;
                        case 9:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;

                    }

                }
                catch (MMSExceptions ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }
        private static void AddActors()

        {
            Actors act = new Actors();
            Console.WriteLine(" Enter Actor Name");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            act.ActorName = input;
           
            Console.WriteLine("Enter Employee Gender:");
            foreach (var g in Enum.GetNames(typeof(Gender)))
            {
                Console.WriteLine(g);
            }
            input = Console.ReadLine();
            if (Enum.TryParse(input, out Gender gender))
            {
                act.Gender = gender;
            }
            else
            {
                Console.WriteLine("Invalid input");
                return;
            }
            Console.WriteLine("Enter Actor Date Of Birth");
            input = Console.ReadLine();
            if (!DateOnly.TryParse(input, out DateOnly dob))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            act.DateOfBirth = dob;

            bool isAdded = ActorsBL.Add(act);
            if (isAdded)
            {
                Console.WriteLine("Actor added successfully");
            }
            else
            {
                Console.WriteLine("Add Actor failed");

            }

        }

        private static bool IsValidActorName(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.Any(char.IsLetter);
        }

        static void ListActors()
        {
            var list = ActorsBL.GetActorsLIst();
            foreach (var actor in list)
            {
                Console.WriteLine(actor);
            }
        }
        static void ListMovies()
        {
            var list = MoviesBL.GetMovieList();
            foreach (var actor in list)
            {
                Console.WriteLine(actor);
            }
        }
        private static void UpdateActor()
        {
            ListActors();
            Console.WriteLine("enter employee id to update");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int actId))
            {
                Console.WriteLine("invalid input");
            }
            var act = ActorsBL.GetById(actId);
            if (act == null)
            {
                Console.WriteLine("Employee not exist");
                return;

            }
            Console.WriteLine(" Enter Actor Name");
             input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            act.ActorName = input;

            Console.WriteLine("Enter Employee Gender:");
            foreach (var g in Enum.GetNames(typeof(Gender)))
            {
                Console.WriteLine(g);
            }
            input = Console.ReadLine();
            if (Enum.TryParse(input, out Gender gender))
            {
                act.Gender = gender;
            }
            else
            {
                Console.WriteLine("Invalid input");
                return;
            }
            Console.WriteLine("Enter Actor Date Of Birth");
            input = Console.ReadLine();
            if (!DateOnly.TryParse(input, out DateOnly dob))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            act.DateOfBirth = dob;

            bool isUpdated = ActorsBL.Update(act);
            if (isUpdated)
            {
                Console.WriteLine("Actor Updated successfully");
            }
            else
            {
                Console.WriteLine("Update Actor failed");

            }



        }
    }
}


