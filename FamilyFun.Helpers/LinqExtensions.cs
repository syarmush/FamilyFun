using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FamilyFun.Helpers
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> RandomSubset<T>(this IEnumerable<T> source, int k, Random random)
        {
            T[] set = new T[k];
            
            for(int i = 0; i < k; i++)
            {
                set[i] = source.Except(set).ElementAt(random.Next(0, source.Except(set).Count()));
            }

            return set;
        }
    }
}
