using System.Collections.Generic;
using Core.Entities;

namespace Core.Infra
{
    public interface IRepository
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetById(int id);
        void Add(Movie entinty);
        void Update(Movie entity);
        void Delete(int id);
    }
}
