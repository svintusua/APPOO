using System;
using System.Collections.Generic;
using Core.Entities;

namespace Core.Infra
{
    public class InMemoryDataProvider : IDataProvider<Movie>
    {
        private readonly List<Movie> _fileData;

        public InMemoryDataProvider()
        {
            Logger.Instance.Log("Initializing list data");
            var m1 = new Movie { Id = 25, Category = Common.Category.Action, Name = "Star Wars IV: New Hope" };
            var m2 = new Movie { Id = 11, Category = Common.Category.Drama, Name = "Up" };
            var m3 = new Movie { Id = 12, Category = Common.Category.Fantasy, Name = "Lord of the Rings III: Return of the King" };
            var m4 = new Movie { Id = 41, Category = Common.Category.Adventure, Name = "Jumanji" };

            _fileData = new List<Movie> { m2, m4, m1, m3 };
        }

        public IEnumerable<Movie> GetData()
        {
            return _fileData;
        }

        public void SaveChanges(IEnumerable<Movie> dataToSave)
        {
            Console.WriteLine("Save in memory");   
        }
    }
}
