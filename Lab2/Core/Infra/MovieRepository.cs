using System;
using System.Collections.Generic;
using Core.Entities;
using static Core.Common;

namespace Core.Infra
{
    public class MovieRepository : IRepository
    {
        private List<Movie> _fileData;
        private List<Movie> _listData;
        private bool Initialized { get; set; }

        public void InitializeData()
        {
            if (Initialized)
                return;

            var m1 = new Movie { Id = 25, Category = Category.Action, Name = "Star Wars IV: New Hope" };
            var m2 = new Movie { Id = 11, Category = Category.Drama, Name = "Up" };
            var m3 = new Movie { Id = 12, Category = Category.Fantasy, Name = "Lord of the Rings III: Return of the King" };
            var m4 = new Movie { Id = 41, Category = Category.Adventure, Name = "Jumanji" };

            _fileData = new List<Movie> { m1, m3, m2, m4 };
            _listData = new List<Movie> { m2, m4, m3, m1 };
            Initialized = true;
        }

        public IEnumerable<Movie> GetMoviesFromFile()
        {
            if (!Initialized) return null;

            Log("File read");
            return _fileData;
        }

        public IEnumerable<Movie> GetMoviesFromList()
        {
            if (!Initialized) return null;

            Log("List initialized");
            return _listData;
        }

        public Movie GetMovieByIdFromFile(int id)
        {
            if (!Initialized) return null;

            Log("File read. Get list");
            return _fileData.Find(x => x.Id == id);
        }

        public Movie GetMovieByIdFromList(int id)
        {
            if (!Initialized) return null;

            Log("File Initialized. Get list");
            return _fileData.Find(x => x.Id == id);
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void UpdateInFile(Movie movie)
        {
            if (!Initialized) return;

            var m = _fileData.Find(x => x.Id == movie.Id);
            m.Category = movie.Category;
            m.Name = movie.Name;
        }

        public void UpdateInList(Movie movie)
        {
            if (!Initialized) return;

            var m = _listData.Find(x => x.Id == movie.Id);
            m.Category = movie.Category;
            m.Name = movie.Name;
        }

        public void DeleteFromFile(int id)
        {
            if (!Initialized) return;

            var m = _fileData.Find(x => x.Id == id);
            _fileData.Remove(m);
        }

        public void DeleteFromList(int id)
        {
            if (!Initialized) return;

            var m = _listData.Find(x => x.Id == id);
            _listData.Remove(m);
        }
    }
}
