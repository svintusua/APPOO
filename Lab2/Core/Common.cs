using System;
using System.Collections.Generic;
using Core.Entities;

namespace Core
{
    public static class Common
    {
        public enum Category
        {
            Action, Drama, Adventure, Fantasy
        }
    }

    public static class Util
    {
        public static void PrintToConsole(this IEnumerable<Movie> movies)
        {
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }
        }
    }
}
