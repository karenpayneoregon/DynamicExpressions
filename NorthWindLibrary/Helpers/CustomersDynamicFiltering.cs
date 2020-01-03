using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NorthWindLibrary.Models;

namespace NorthWindLibrary.Helpers
{
    /// <summary>
    /// Responsible for creating a predicate for a lambda query
    /// </summary>
    public class CustomersDynamicFiltering
    {
        /// <summary>
        /// Provides a method to perform dynamic where conditions using
        /// string property name and string value. If a value can not be
        /// converted to the type of the property a runtime exception
        /// is thrown.
        /// </summary>
        /// <param name="propertyName">Name of property to work against</param>
        /// <param name="value">Value to find</param>
        /// <returns></returns>
        public static Func<Customer, bool> DynamicQueryWithExpressionTrees(string propertyName, string value)
        {
            var parameterExpression = Expression.Parameter(typeof(Customer), "z");

            #region Convert to specific data type
            MemberExpression member = Expression.Property(parameterExpression, propertyName);
            UnaryExpression valueExpression = ValueExpression(propertyName, value, parameterExpression);
            #endregion

            Expression body = Expression.Equal(member, valueExpression);

            return Expression.Lambda<Func<Customer, bool>>(body: body, parameters: parameterExpression).Compile();
        }

        private static UnaryExpression ValueExpression(string propertyName, string value, Expression expression)
        {
            var memberExpression = Expression.Property(expression, propertyName);
            var propertyType = ((PropertyInfo)memberExpression.Member).PropertyType;
            var converter = TypeDescriptor.GetConverter(propertyType);

            if (!converter.CanConvertFrom(typeof(string)))
            {
                throw new NotSupportedException();
            }

            var propertyValue = converter.ConvertFromInvariantString(value);
            var constant = Expression.Constant(propertyValue);

            return Expression.Convert(constant, propertyType);
        }
    }
}
