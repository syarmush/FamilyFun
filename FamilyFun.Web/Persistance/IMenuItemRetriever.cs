using FamilyFun.Persistence.Models;
using FamilyFun.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyFun.Web.Persistance
{
    public interface IMenuItemRetriever
    {
        IEnumerable<MenuItem> RetriveMenuItems(Func<MenuItem, bool>? predicate = null);
    }

    internal class MenuItemRetriever : EnumerableRetriever<MenuItem>, IMenuItemRetriever
    {
        public MenuItemRetriever(IEnumerable<MenuItem> items) : base(items)
        {
        }

        public IEnumerable<MenuItem> RetriveMenuItems(Func<MenuItem, bool>? predicate = null)
        {
            return Retrieve(predicate);
        }
    }
}