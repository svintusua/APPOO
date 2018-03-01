using System;
using Core;
using Core.Infra;

namespace Lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IRepository fileRepo = new MovieFileRepository();

            Console.WriteLine("***From File***");
            fileRepo.GetAllMovies()?.PrintToConsole();

            Console.WriteLine();

            IRepository listRepo = new MovieListRepository();
            Console.WriteLine("***From List***");
            listRepo.GetAllMovies()?.PrintToConsole();
        }
    }
}
