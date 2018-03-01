using System;

namespace Core.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Common.Category Category { get; set; }

        public override string ToString()
        {
            return $"{Name}[{Id}] - {Category}";
        }
    }
}
