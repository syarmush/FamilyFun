using FamilyFun.Persistence.Models;
using FamilyFun.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly string? _imageDirectoryPath;

        public MitzvosSelectorElementRetriever(IEnumerable<Mitzvah> items, IPageColorDeterminer pageColorDeterminer, IDictionary<int, int[]> memberIdToMenuItems,
            IMitzvahImageDirectoryPathRetriever? imageDirectoryPathRetriver = null)
        {
            _memberIdToMitzvos = memberIdToMenuItems ?? throw new ArgumentNullException(nameof(memberIdToMenuItems));
            _items = items ?? throw new ArgumentNullException(nameof(items));
            _pageColorDeterminer = pageColorDeterminer ?? throw new ArgumentNullException(nameof(pageColorDeterminer));
            _imageDirectoryPath = imageDirectoryPathRetriver?.RetrieveImageDirectoryPath();
        }

        public IEnumerable<SelectorElement> RetrieveByFamilyMemberId(int familyMemberId)
        {
            IEnumerable<Mitzvah> filteredItems = _items.Where(mi => _memberIdToMitzvos[familyMemberId].Contains(mi.Id));
            return filteredItems.Select(i =>
            {
                IDictionary<string, string> mitzvahOccuranceFields = new Dictionary<string, string>
                {
                    ["FamilyMemberId"] = familyMemberId.ToString(),
                    ["MitzvahId"] = i.Id.ToString(),
                    ["MitzvahDate"] = DateTime.Today.ToString("MM/dd/yy")
                };

                if (i.HasImageFile())
                {
                    if (!(_imageDirectoryPath is null))
                    {
                        string imagePath = Path.Combine(_imageDirectoryPath, i.ImageFileName!);
                        return new SelectorElement(ElementType.Post, i.Name, "Mitzvos", "Index", "", mitzvahOccuranceFields, imagePath);
                    }

                    throw new InvalidOperationException("No image directory path was provided");
                }
                else
                {
                    return new SelectorElement(ElementType.Post, i.Name, "Mitzvos", "Index", "", mitzvahOccuranceFields, _pageColorDeterminer);
                }
            });
        }
    }
}