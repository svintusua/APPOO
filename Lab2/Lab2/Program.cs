using System;
using Core;
using Core.Entities;
using Core.Infra;

namespace Lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IRepository<Movie> fileRepo = new MovieRepository(new FileDataProvider());

            Console.WriteLine("***From File***");
            fileRepo.GetAllMovies()?.PrintToConsole();

            Console.WriteLine();

            IRepository<Movie> listRepo = new MovieRepository(new InMemoryDataProvider());
            Console.WriteLine("***From List***");
            listRepo.GetAllMovies()?.PrintToConsole();
        }
    }
}
