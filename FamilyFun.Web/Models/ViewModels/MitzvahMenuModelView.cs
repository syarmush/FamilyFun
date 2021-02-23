using System;
using System.Collections.Generic;

namespace FamilyFun.Web.Models.ViewModels
{
    public class MitzvahMenuModelView
    {
        public MitzvahMenuModelView(int familyMemberId, IEnumerable<SelectorElement> mitzvahSelectors)
        {
            FamilyMemberId = familyMemberId;
            MitzvahSelectors = mitzvahSelectors ?? throw new ArgumentNullException(nameof(mitzvahSelectors));
        }

        public int FamilyMemberId { get; }
        public IEnumerable<SelectorElement> MitzvahSelectors { get; }
    }
}