using FamilyFun.Persistence.Models;
using FamilyFun.Web.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace FamilyFun.Web
{


    public interface IMenuItemSelectorElementRetriever
    {
        IEnumerable<SelectorElement> RetrieveByFamilyMemberId(int familyMemberId);
    }

    internal class MenuItemSelectorElementRetriever : IMenuItemSelectorElementRetriever
    {
        protected readonly IPageColorDeterminer _pageColorDeterminer;
        protected readonly IEnumerable<MenuItem> _items;
        private readonly IDictionary<int, int[]> _memberIdToMenuItems;

        public MenuItemSelectorElementRetriever(IEnumerable<MenuItem> items, IPageColorDeterminer pageColorDeterminer, IDictionary<int, int[]> memberIdToMenuItems)
        {
            _memberIdToMenuItems = memberIdToMenuItems ?? throw new ArgumentNullException(nameof(memberIdToMenuItems));
            _items = items ?? throw new ArgumentNullException(nameof(items));
            _pageColorDeterminer = pageColorDeterminer ?? throw new ArgumentNullException(nameof(pageColorDeterminer));
        }


        public IEnumerable<SelectorElement> RetrieveByFamilyMemberId(int familyMemberId)
        {
            IEnumerable<MenuItem> filteredItems = _items.Where(mi => _memberIdToMenuItems[familyMemberId].Contains(mi.Id));
            return filteredItems.Select(mi => mi.ImagePath is null
                ? new SelectorElement(ElementType.Get, mi.Name, mi.Controller, mi.Action, familyMemberId.ToString(), _pageColorDeterminer)
                : new SelectorElement(ElementType.Get, mi.Name, mi.Controller, mi.Action, familyMemberId.ToString(), mi.ImagePath));
        }
    }
}