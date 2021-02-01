using System;

namespace FamilyFun.Web.Models
{
    public class AddMitzvahResult
    {
        internal AddMitzvahResult(int memberId, string memberName, int points)
        {
            MemberName = memberName ?? throw new ArgumentNullException(nameof(memberName));
            MemberId = memberId;
            Points = points;
        }

        public string MemberName { get; }
        public int MemberId { get; }
        public int Points { get; }
    }
}
