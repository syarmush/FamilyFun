using FamilyFun.Persistence.Models;
using System;

namespace FamilyFun.Web.Models.ViewModels
{
    public class LoggedMitzvahViewModel
    {
        public LoggedMitzvahViewModel(string id, FamilyMember familyMember, Mitzvah mitzvah, int points, DateTime occuredOn, DateTime? approveOn, string? approvedBy)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            FamilyMember = familyMember ?? throw new ArgumentNullException(nameof(familyMember));
            Mitzvah = mitzvah ?? throw new ArgumentNullException(nameof(mitzvah));
            Points = points;
            OccuredOn = occuredOn;
            ApproveOn = approveOn;
            ApprovedBy = approvedBy;
        }

        public string Id { get; }
        public FamilyMember FamilyMember { get; }
        public Mitzvah Mitzvah { get; }
        public int Points { get; }
        public DateTime OccuredOn { get; }
        public DateTime? ApproveOn { get; }
        public string? ApprovedBy { get; }
    }
}