using System;

namespace FamilyFun.Web.Models
{
    public class AddMitzvahResult
    {
        internal AddMitzvahResult(string name, int points)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Points = points;
        }

        public string Name { get; }
        public int Points { get; }
    }
}
