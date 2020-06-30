using FamilyFun.Persistence.Models;
using FamilyFun.Web.Models;
using System;
using System.Collections.Generic;

namespace FamilyFun.Web
{
    public class PrizeResult
    {
        public FamilyMember Member { get; }
        public int Points { get; }
        public IEnumerable<Prize> Prizes { get; }

        internal PrizeResult(FamilyMember member, int points, IEnumerable<Prize> prizes)
        {
            Member = member ?? throw new ArgumentNullException(nameof(member));
            Prizes = prizes ?? throw new ArgumentNullException(nameof(prizes));
            Points = points;

        }
    }
}