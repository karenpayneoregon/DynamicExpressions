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
        public static List<T> Sort<T>(this List<T> list, string sortBySortDirection)
        {
            string[] sortProperties = sortBySortDirection.Split(' ');

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
        /// <summary>
        /// Sort by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="propertyName">Property name to sort by</param>
        /// <param name="ascending">true for ascending, false descending</param>
        /// <returns></returns>
        public static List<T> Sort<T>(this List<T> list,string propertyName, bool @ascending)
        {

            var param = Expression.Parameter(typeof(T), "item");

            var sortExpression = Expression.Lambda<Func<T, object>>
                (Expression.Convert(Expression.Property(param, propertyName), typeof(object)), param);

            list = @ascending ? 
                list.AsQueryable<T>().OrderBy<T, object>(sortExpression).ToList() : 
                list.AsQueryable<T>().OrderByDescending<T, object>(sortExpression).ToList();

            return list;
        }
    }
}
