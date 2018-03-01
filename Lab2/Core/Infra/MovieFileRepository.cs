using System.Collections.Generic;
using Core.Entities;
using static Core.Common;

namespace Core.Infra
{
    public class MovieFileRepository : IRepository
    {
        private List<Movie> _fileData;
        private readonly Logger _logger = Logger.Instance;

        public MovieFileRepository()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            _logger.Log("Initializing file data");
            var m1 = new Movie { Id = 25, Category = Category.Action, Name = "Star Wars IV: New Hope" };
            var m2 = new Movie { Id = 11, Category = Category.Drama, Name = "Up" };
            var m3 = new Movie { Id = 12, Category = Category.Fantasy, Name = "Lord of the Rings III: Return of the King" };
            var m4 = new Movie { Id = 41, Category = Category.Adventure, Name = "Jumanji" };

            _fileData = new List<Movie> {m1, m3, m2, m4};
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            _logger.Log("File read");
            return _fileData;
        }

        public Movie GetById(int id)
        {
            _logger.Log($"File read. Finding ID [{id}]");
            return _fileData.Find(x => x.Id == id);
        }

        public void Add(Movie entinty)
        {
            _logger.Log("Adding new movie. File write");
            _fileData.Add(entinty);
        }

        public void Update(Movie entity)
        {
            _logger.Log($"Updating movie [{entity.Id}]. File write");
            var m = _fileData.Find(x => x.Id == entity.Id);
            m.Category = entity.Category;
            m.Name = entity.Name;
        }

        public void Delete(int id)
        {
            _logger.Log($"Deleting movie [{id}]. File write");
            var m = _fileData.Find(x => x.Id == id);
            _fileData.Remove(m);
        }
    }
}
