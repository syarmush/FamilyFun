using FamilyFun.Persistence.Models;
using System;
using System.Collections.Generic;

namespace FamilyFun.Web.Persistance
{
    public interface IFamilyMembersRetriever
    {
        IEnumerable<FamilyMember> RetrieveFamilyMembers(Func<FamilyMember, bool>? predicate = null);
    }

    internal class FamilyMembersRetriever : EnumerableRetriever<FamilyMember>, IFamilyMembersRetriever
    {
        public FamilyMembersRetriever(IEnumerable<FamilyMember> items) : base(items)
        {
        }

        public IEnumerable<FamilyMember> RetrieveFamilyMembers(Func<FamilyMember, bool>? predicate = null)
        {
            return Retrieve(predicate);
        }
    }
}