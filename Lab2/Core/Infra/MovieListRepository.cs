using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using static Core.Common;

namespace Core.Infra
{
    public class MovieListRepository : IRepository
    {
        private List<Movie> _listData;
        private readonly Logger _logger = Logger.Instance;

        public MovieListRepository()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            _logger.Log("Initializing list data");
            var m1 = new Movie { Id = 42, Category = Category.Drama, Name = "Silence" };
            var m2 = new Movie { Id = 9, Category = Category.Action, Name = "War for the Planet of the Apes" };
            var m3 = new Movie { Id = 7, Category = Category.Action, Name = "Kingsman: The Golden Circle" };
            var m4 = new Movie { Id = 53, Category = Category.Adventure, Name = "Star Wars VI: Return of the Jedi" };

            _listData = new List<Movie> {m2, m4, m1, m3};
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            _logger.Log("List loaded");
            return _listData;
        }

        public Movie GetById(int id)
        {
            _logger.Log($"List loaded. Finding ID [{id}]");
            return _listData.Find(x => x.Id == id);
        }

        public void Add(Movie entinty)
        {
            _logger.Log("Adding new movie. List updated");
            _listData.Add(entinty);
        }

        public void Update(Movie entity)
        {
            _logger.Log($"Updating movie [{entity.Id}]. List updated");
            var m = _listData.Find(x => x.Id == entity.Id);
            m.Category = entity.Category;
            m.Name = entity.Name;
        }

        public void Delete(int id)
        {
            _logger.Log($"Deleting movie [{id}]. List updated");
            var m = _listData.Find(x => x.Id == id);
            _listData.Remove(m);
        }
    }
}
