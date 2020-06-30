using System;
using System.Collections.Generic;

namespace FamilyFun.Domain
{
    public class Family : Entity
    {
        public Family()
        {
            FamilyMemberIds = new HashSet<string>();
        }

        public string FamilyName { get; set; }
        public ISet<string> FamilyMemberIds { get; set; }

    }

    public class FamilyMember : Entity
    {
        public FamilyMember()
        {
            Dispensations = new HashSet<Dispensation>();
            Activities = new HashSet<Activity>();
        }

        public string Name { get; set; }

        public ISet<Activity> Activities { get; set; }
        public ISet<Dispensation> Dispensations { get; set; }
    }
}
