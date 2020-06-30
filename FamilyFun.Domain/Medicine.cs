using System;
using System.Collections.Generic;
using System.Text;

namespace FamilyFun.Domain
{
    public class Medicine : Entity
    {
        public string Name { get; set; }
    }

    public class Dispensation : Entity
    {
        public Medicine Medicine { get; set; }
        public DateTime DispensationDate { get; set; }
    }

    public class NoseSprayDispensation : Dispensation
    {
        public string NoseSide { get; set; }
    }
}
