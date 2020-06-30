using FamilyFun.Persistence.Models;
using FamilyFun.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyFun.Web
{


    public interface IMitzvosSelectorElementRetriever 
    {
        IEnumerable<SelectorElement> RetrieveByFamilyMemberId(int familyMemberId);
    }

    internal class MitzvosSelectorElementRetriever : IMitzvosSelectorElementRetriever
    {
        protected readonly IPageColorDeterminer _pageColorDeterminer;
        protected readonly IEnumerable<Mitzvah> _items;
        private readonly IDictionary<int, int[]> _memberIdToMitzvos;

        public MitzvosSelectorElementRetriever(IEnumerable<Mitzvah> items, IPageColorDeterminer pageColorDeterminer, IDictionary<int, int[]> memberIdToMenuItems)
        {
            _memberIdToMitzvos = memberIdToMenuItems ?? throw new ArgumentNullException(nameof(memberIdToMenuItems));
            _items = items ?? throw new ArgumentNullException(nameof(items));
            _pageColorDeterminer = pageColorDeterminer ?? throw new ArgumentNullException(nameof(pageColorDeterminer));
        }

        public IEnumerable<SelectorElement> RetrieveByFamilyMemberId(int familyMemberId)
        {
            IEnumerable<Mitzvah> filteredItems = _items.Where(mi => _memberIdToMitzvos[familyMemberId].Contains(mi.Id));
            return filteredItems.Select(i =>
            {
                IDictionary<string, string> attributes = new Dictionary<string, string>
                {
                    ["familyMemberId"] = familyMemberId.ToString(),
                    ["mitzvahId"] = i.Id.ToString()
                };

                return new SelectorElement(ElementType.Post, i.Name, "Mitzvos", "Index", "", attributes, _pageColorDeterminer);
            });
        }
    }
}