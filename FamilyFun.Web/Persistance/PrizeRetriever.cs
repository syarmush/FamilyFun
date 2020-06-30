using FamilyFun.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyFun.Web.Persistance
{
    public interface IPrizeRetriever
    {
        IEnumerable<Prize> RetrivePrizes(Func<Prize, bool>? predicate = null);
    }

    internal class PrizeRetriever : EnumerableRetriever<Prize>, IPrizeRetriever
    {
        public PrizeRetriever(IEnumerable<Prize> items) : base(items)
        {
        }

        public IEnumerable<Prize> RetrivePrizes(Func<Prize, bool>? predicate = null)
        {
            return Retrieve(predicate);
        }
    }
}
