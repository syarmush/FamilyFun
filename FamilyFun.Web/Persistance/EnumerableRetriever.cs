using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyFun.Web.Persistance
{
    public class EnumerableRetriever<TElement>
    {
        IEnumerable<TElement> _items;

        public EnumerableRetriever(IEnumerable<TElement> items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        public IEnumerable<TElement> Retrieve(Func<TElement, bool>? predicate = null)
        {
            return predicate is null ? _items : _items.Where(predicate);
        }
    }
}
