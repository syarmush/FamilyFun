namespace FamilyFun.Web.Models.ViewModels
{
    public class MitzvahAdminViewModel
    {
        public MitzvahAdminViewModel(int familyMemberId)
        {
            FamilyMemberId = familyMemberId;
        }

        public int FamilyMemberId { get; }
    }
}