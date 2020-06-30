using FamilyFun.Persistence.Models;
using System;
using System.Collections.Generic;

namespace FamilyFun.Web.Persistance
{
    public interface IMitzvosRetriever
    {
        IEnumerable<Mitzvah> RetrieveMitzvos(Func<Mitzvah, bool>? predicate = null);
    }

    internal class MitzvosRetriever : EnumerableRetriever<Mitzvah>, IMitzvosRetriever
    {
        public MitzvosRetriever(IEnumerable<Mitzvah> items) : base(items)
        {
        }

        public IEnumerable<Mitzvah> RetrieveMitzvos(Func<Mitzvah, bool>? predicate = null)
        {
            return Retrieve(predicate);
        }
    }
}