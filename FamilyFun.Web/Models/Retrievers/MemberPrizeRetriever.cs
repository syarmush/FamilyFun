using FamilyFun.Web.Models;
using FamilyFun.Web.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyFun.Web
{
    public interface IMemberPrizeRetriever 
    {
        IEnumerable<Prize> RetrieveByFamilyMemberId(int familyMemberId);
    }

    internal class MemberPrizeRetriever : IMemberPrizeRetriever
    {
        protected readonly IPrizeRetriever _prizeRetriever;
        private readonly IDictionary<int, int[]> _memberIdToMitzvos;

        internal MemberPrizeRetriever(IPrizeRetriever prizeRetriever, IDictionary<int, int[]> memberIdToMenuItems)
        {
            _memberIdToMitzvos = memberIdToMenuItems ?? throw new ArgumentNullException(nameof(memberIdToMenuItems));
            _prizeRetriever = prizeRetriever ?? throw new ArgumentNullException(nameof(prizeRetriever));
        }

        public IEnumerable<Prize> RetrieveByFamilyMemberId(int familyMemberId)
        {
            return _prizeRetriever.RetrivePrizes(mi => _memberIdToMitzvos[familyMemberId].Contains(mi.Id));
        }
    }
}