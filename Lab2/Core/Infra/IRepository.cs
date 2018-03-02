using System.Collections.Generic;

namespace Core.Infra
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAllMovies();
        T GetById(int id);
        void Add(T entinty);
        void Update(T entity);
        void Delete(int id);
    }
}
