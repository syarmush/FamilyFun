using System;

namespace FamilyFun.Persistence.Models
{
    [Serializable]
    public class MitzvahOccurence
    {
        public MitzvahOccurence(int mitzvahId, int familyMemberId, int points, DateTime occuredOn, string? approvedBy = null, DateTime? approveOn = null)
        {
            MitzvahId = mitzvahId;
            FamilyMemberId = familyMemberId;
            OccuredOn = occuredOn;
            ApprovedBy = approvedBy;
            ApproveOn = approveOn;
            Points = points;
        }

        public int MitzvahId { get; }
        public int FamilyMemberId { get; }
        public DateTime OccuredOn { get; }
        public int Points { get; }
        public string? ApprovedBy { get; }
        public DateTime? ApproveOn { get; }
    }
}
