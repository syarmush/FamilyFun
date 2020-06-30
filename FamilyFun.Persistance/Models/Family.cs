using System;
using System.Collections.Generic;

namespace FamilyFun.Persistence.Models
{
    public class Family
    {
        public Family(string familyName)
        {
            FamilyName = familyName ?? throw new ArgumentNullException(nameof(familyName));
        }

        public string FamilyName { get; set; }
    }
}
