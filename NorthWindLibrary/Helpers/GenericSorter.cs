using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindLibrary.Helpers
{
    public static class GenericSorterExtension
    {
        public static List<T> Sort<T>(this List<T> list, string sortBy_sortDirection)
        {
            string[] sortProperties = sortBy_sortDirection.Split(' ');

            //if(sortProperties.l > 2)
            var param = Expression.Parameter(typeof(T), "item");

            var sortExpression = Expression.Lambda<Func<T, object>>
                (Expression.Convert(Expression.Property(param, sortProperties[0]), typeof(object)), param);

            switch (sortProperties[1].ToLower())
            {
                case "asc":
                    list = list.AsQueryable<T>().OrderBy<T, object>(sortExpression).ToList();
                    break;
                default:
                    list = list.AsQueryable<T>().OrderByDescending<T, object>(sortExpression).ToList();
                    break;
            }
            return list;
        }
    }
}
