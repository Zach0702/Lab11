using System;

namespace BootCampLab11
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie movie = new Movie();
            Console.WriteLine("Welcome to the movie list application!");
            movie.RunApp();
            Console.ReadLine();
        }
    }
}
