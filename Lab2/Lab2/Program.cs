using System;
using Core;
using Core.Infra;

namespace Lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var repo = new MovieRepository();

            repo.InitializeData();

            Console.WriteLine("***From List***");
            repo.GetMoviesFromList()?.PrintToConsole();

            Console.WriteLine();

            Console.WriteLine("***From File***");
            repo.GetMoviesFromFile()?.PrintToConsole();
        }
    }
}
