using System;

namespace FamilyFun.Persistence.Models
{
    public class FamilyMember
    {
        public FamilyMember(int id, string name, DateTime birthDate, string familyName)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            BirthDate = birthDate;
            Family = familyName is null ? throw new ArgumentNullException(nameof(familyName)) : new Family(familyName) ;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Family Family { get; set; }
    }
}