using System;

namespace FamilyFun.Persistence.Models
{
    public class Mitzvah
    {
        public Mitzvah(int id, string name, int points)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Points = points;
        }

        public int Id { get; }
        public string Name { get; }
        public int Points { get; }
    }
}