using System;

namespace FamilyFun.Persistence.Models
{
    public class Mitzvah
    {
        public Mitzvah(int id, string name, int points, string? imageFileName = null, bool autoApprove = false)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ImageFileName = imageFileName;
            Points = points;
            AutoApprove = autoApprove;

        }

        public int Id { get; }
        public string Name { get; }
        public int Points { get; }
        public bool AutoApprove { get; }
        public string? ImageFileName { get; }

        public bool HasImageFile()
        {
            return !(ImageFileName is null);
        }
    }
}