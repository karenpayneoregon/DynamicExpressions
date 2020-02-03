using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindLibrary.Helpers
{
    public enum SortDirection
    {
        /// <summary>
        /// Sort ascending.
        /// </summary>
        Ascending,
        /// <summary>
        /// Sort descending.
        /// </summary>
        Descending
    }
    public enum SortOrderEnum
    {
        /// <summary>
        /// The returned list will be ordered in ascending order
        /// </summary>
        ASC,
        /// <summary>
        /// The returned list wil lbe orderded in descending order
        /// </summary>
        DESC
    }

    public static class GenericSorterExtension
    {
        public static List<T> Sort<T>(this List<T> list, string propertyName, SortDirection sortDirection)
        {
            var param = Expression.Parameter(typeof(T), "item");
            var sortExpression = Expression.Lambda<Func<T, object>>(Expression.Convert(Expression.Property(param, propertyName), typeof(object)), param);

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    list = list.AsQueryable().OrderBy(sortExpression).ToList();
                    break;
                default:
                    list = list.AsQueryable().OrderByDescending(sortExpression).ToList();
                    break;
            }

            return list;

        }
        public static IOrderedQueryable<T> Order<T>(this IQueryable<T> source, string[] propertyNames, SortOrderEnum sortOrder)
        {

            if (propertyNames.Length == 0)
            {
                throw new InvalidOperationException();
            }

            var param = Expression.Parameter(typeof(T), string.Empty);
            var property = Expression.PropertyOrField(param, propertyNames[0]);

            var sort = Expression.Lambda(property, param);

            MethodCallExpression orderByCall = Expression.Call(typeof(Queryable), "OrderBy" + (((sortOrder == SortOrderEnum.DESC) ? "Descending" : string.Empty)), new[] { typeof(T), property.Type }, source.Expression, Expression.Quote(sort));

            if (propertyNames.Length > 1)
            {
                for (int index = 1; index < propertyNames.Length; index++)
                {
                    var item = propertyNames[index];
                    param = Expression.Parameter(typeof(T), string.Empty);
                    property = Expression.PropertyOrField(param, item);

                    sort = Expression.Lambda(property, param);

                    orderByCall = Expression.Call(typeof(Queryable), "ThenBy" + (((sortOrder == SortOrderEnum.DESC) ? "Descending" : string.Empty)), new[] { typeof(T), property.Type }, orderByCall, Expression.Quote(sort));
                }
            }


            return (IOrderedQueryable<T>)(source.Provider.CreateQuery<T>(orderByCall));

        }


        public static List<T> Sort1<T>(this List<T> list, string sortBySortDirection)
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
        public static List<T> Sort1<T>(this List<T> list,string propertyName, bool @ascending)
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
