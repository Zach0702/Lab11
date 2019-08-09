using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BootCampLab11
{
    public class Movie
    {
        public Movie()
        {

        }
        //constructor to take in a title and movie category
        public Movie(string userTitle, string userCategory)
        {
            Title = userTitle;
            Category = userCategory;
        }
        //movie title property
        private string Title { get; set; }
        //movie category property
        private string Category { get; set; }

        public void RunApp()
        {
            //creating loopbreaker variable
            char loopBreaker;
            int startMenuOption;

            do
            {
            
              var movieTypeMenu = new List<string>()
              
            {
                "[1]. animated",
                "[2]. drama",
                "[3]. horror",
                "[4]. scifi"
            };
                var MovieList = new List<Movie>();
                Console.WriteLine("Would you like to add a movie to a category, or view the movies already stored in each category(enter 1 to add, enter 2 to view movies): ");
                startMenuOption = IsValidIntEntered(Console.ReadLine());

                if (startMenuOption == 1)
                {

                    //foreach loop to display menu to user 
                    foreach (var movieType in movieTypeMenu)
                    {
                        Console.WriteLine(movieType);
                    }
                    Console.WriteLine("Which movie category would you like to add a movie in? : ");
                    bool isInvalidInput = true;
                    while (isInvalidInput)
                    {
                        if (Enum.TryParse<MovieType>(Console.ReadLine(), out MovieType userMovieType)) //if this is a valid enum
                        {
                            var movieList = new List<Movie>();
                            movieList = AddMovies(userMovieType);
                            isInvalidInput = false;
                        }
                    }
                }
                else {
                    //foreach loop to display menu to user 
                    foreach (var movieType in movieTypeMenu)
                    {
                        Console.WriteLine(movieType);
                    }

                    //Asking user to pick a category
                    Console.WriteLine("Please enter which movie category you're interested in (enter a number b/w 1-4): ");


                    //validating input with an enum try parse
                    bool isInvalidInput = true;
                    //While the input is invalid this loop will continue to run
                    while (isInvalidInput)
                    {
                        if (Enum.TryParse<MovieType>(Console.ReadLine(), out MovieType userMovieType)) //if this is a valid enum
                        {

                            var movieList = new List<Movie/*string*/>(); //creating new movie list to store list of movies in valid category
                            movieList = ShowMoviesInCategory(userMovieType); //finding movies in categore
                            var organizedMovieList = movieList.OrderBy(s => s.Title).ToList(); //organizing movies in aplhabetical order

                            foreach (var movie in organizedMovieList)
                            {

                                Console.WriteLine(movie.Title); //displaying organized movie list
                                isInvalidInput = false; //breaking while loop because we have valid input now

                            }
                        }

                        else //invalid movie category
                        {
                            Console.WriteLine("ERROR: invalid movie category entered.. Please try again");
                            Console.WriteLine("Please enter which movie category you're interested in (enter a number b/w 1-4): ");

                        }
                    }
                }
                //}
                Console.WriteLine("Do you wish to continue(enter y/n): "); //ask user to if they want to continue
                loopBreaker = IsValidLoopBreaker(Console.ReadLine()); //storing answer and if it's valid input 

            } while (loopBreaker == 'y'); //do while break
            }
        
        //method to display movie list depending on which category was picked
        private static List<Movie/*string*/> ShowMoviesInCategory (MovieType movieType)
        {
            var movieList = new List<Movie/*string*/>();

            switch (movieType)
            {
                case MovieType.animated:
                    movieList = new List<Movie/*string*/>()
                    {
                        new Movie ("Toy Story", "animated"),
                        new Movie ("Up", "animated"),
                        new Movie ("Shrek", "animated")
                    };
                    break;
                case MovieType.drama:
                    movieList = new List<Movie/*string*/>()
                    {
                        new Movie ("The Departed", "drama"),
                        new Movie ("Pulp Fiction", "drama"),
                        new Movie ("A Beautiful Mind", "drama")
                    };
                    break;
                case MovieType.horror:
                    movieList = new List<Movie/*string*/>()
                    {
                        //"Get Out",
                        //"Silence Of The Lambs",
                        //"IT" This is how it was when it worked
                        new Movie ("Get Out", "horror"),
                        new Movie ("Silence Of The Lambs", "horror"),
                        new Movie ("IT", "horror")
                    };
                    break;
                case MovieType.scifi:
                    movieList = new List<Movie/*string*/>()
                    {
                        //"Inception",
                        //"The Avengers",
                        //"Minority Report"
                        new Movie ("The Departed", "scifi"),
                        new Movie ("Pulp Fiction", "scifi"),
                        new Movie ("A Beautiful Mind", "scifi")
                    };
                    break;
            }
            return movieList;
        }
        public static char IsValidLoopBreaker(string testChar)
        {
            bool isInvalidChar = true;

            Regex pattern = new Regex(@"^[y|n]$");

            char validChar = ' ';

            while (isInvalidChar)
            {
                if (pattern.IsMatch(testChar))
                {
                    isInvalidChar = false;
                    validChar = char.Parse(testChar);
                }
                else
                {
                    Console.WriteLine($"ERROR invalid input of {testChar}  entered please try again");
                    Console.WriteLine("Do you wish to continue(enter y/n): ");
                    testChar = Console.ReadLine();
                }
            }
            return validChar;
        }

        public static int IsValidIntEntered(string testInt)
        {
            bool isInvalidInput = true;
            Regex pattern = new Regex(@"^[1|2]$");
            int validInt = 0;

            while (isInvalidInput)
            {
                if (pattern.IsMatch(testInt))
                {
                    isInvalidInput = false;
                    validInt = int.Parse(testInt);
                }
                else
                {
                    Console.WriteLine($"ERROR: invalid input of {testInt}  entered please try again");
                    Console.WriteLine("Would you like to add a student, or find information about a student (enter 1 to add, enter 2 to find info): ");
                    testInt = Console.ReadLine();

                }

            }
            return validInt;
        }

        private static List<Movie> AddMovies (MovieType movieType)
        {
            var movieList = new List<Movie>();
            movieList = ShowMoviesInCategory(movieType);

            switch (movieType)
            {
                 
                case MovieType.animated:
                    
                    Console.WriteLine("What is the title of the movie");
                    string userTitle = Console.ReadLine();
                    Movie userMovie = new Movie(userTitle, "animated");
                    movieList.Add(userMovie);
                    break;


            }

            return movieList;
        }

    }
}
