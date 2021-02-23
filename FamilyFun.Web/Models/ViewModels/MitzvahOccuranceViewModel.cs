using System;

namespace FamilyFun.Web.Models.ViewModels
{
    public class MitzvahOccuranceViewModel
    {
        public DateTime? MitzvahDate { get; set; }
        public int MitzvahId { get; set; }
        public int FamilyMemberId { get; set; }
    }
}
