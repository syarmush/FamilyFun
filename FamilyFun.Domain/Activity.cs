using System;
using System.Collections.Generic;
using System.Text;

namespace FamilyFun.Domain
{
    public class Activity : Entity
    {
        public string Name { get; set; }
        public int Points { get; set; }
    }
}
