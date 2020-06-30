using FamilyFun.Persistence.Models;
using FamilyFun.Web.Models;
using FamilyFun.Web.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyFun.Web
{
    public interface IFamilyMembersSelectorElementRetriever 
    {
        IEnumerable<SelectorElement> RetriveSelectorElements();
    }

    internal class FamilyMembersSelectorElementRetriever : IFamilyMembersSelectorElementRetriever
    {
        protected readonly IPageColorDeterminer _pageColorDeterminer;
        protected readonly IEnumerable<FamilyMember> _items;

        public FamilyMembersSelectorElementRetriever(IFamilyMembersRetriever items, IPageColorDeterminer pageColorDeterminer)
        {;
            _items = items?.RetrieveFamilyMembers() ?? throw new ArgumentNullException(nameof(items));
            _pageColorDeterminer = pageColorDeterminer ?? throw new ArgumentNullException(nameof(pageColorDeterminer));
        }

        public IEnumerable<SelectorElement> RetriveSelectorElements()
        {
            return _items.Select(m => new SelectorElement(ElementType.Get, m.Name, "Home", "Index", m.Id.ToString(), _pageColorDeterminer));
        }
    }
}