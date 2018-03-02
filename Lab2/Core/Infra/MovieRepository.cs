using System.Collections.Generic;
using System.Linq;
using Core.Entities;

namespace Core.Infra
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly IDataProvider<Movie> _dataProvider;
        private List<Movie> _cash;

        public MovieRepository(IDataProvider<Movie> provider)
        {
            _dataProvider = provider;
            _cash = new List<Movie>(provider.GetData());
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _cash;
        }

        public Movie GetById(int id)
        {
            return _cash.First(x => x.Id == id);
        }

        public void Add(Movie entinty)
        {
            _cash.Add(entinty);
            _dataProvider.SaveChanges(_cash);
        }

        public void Update(Movie entity)
        {
            var m = GetById(entity.Id);
            m.Category = entity.Category;
            m.Name = entity.Name;
            _dataProvider.SaveChanges(_cash);
        }

        public void Delete(int id)
        {
            var m = GetById(id);
            _cash.Remove(m);
            _dataProvider.SaveChanges(_cash);
        }
    }
}
