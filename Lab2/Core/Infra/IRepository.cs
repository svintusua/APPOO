using System.Collections.Generic;
using Core.Entities;

namespace Core.Infra
{
    public interface IRepository
    {
        void InitializeData();

        IEnumerable<Movie> GetMoviesFromFile();
        IEnumerable<Movie> GetMoviesFromList();

        Movie GetMovieByIdFromFile(int id);
        Movie GetMovieByIdFromList(int id);

        void Log(string message);
        
        void UpdateInFile(Movie movie);
        void UpdateInList(Movie movie);

        void DeleteFromFile(int id);
        void DeleteFromList(int id);
    }
}
