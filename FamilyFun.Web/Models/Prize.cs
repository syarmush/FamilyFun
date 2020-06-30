using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyFun.Web.Models
{
    public class Prize
    {
        public int Id { get; }
        public string Name { get; }
        public int CostInPoints { get; }

        public Prize(int id, string name, int points)
        {
            Id = id;
            Name = name;
            CostInPoints = points;
        }
    }
}
