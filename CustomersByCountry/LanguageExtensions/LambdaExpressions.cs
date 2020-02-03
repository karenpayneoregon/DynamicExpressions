using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace LambdaEntityFrameWorkInCondition.LanguageExtensions
{
    public static class LambdaExpressions
    {
        public static IQueryable<T> WithIdentifiers<T>(this IQueryable<T> entities, Expression<Func<T, int?>> propertySelector, ICollection<int?> ids)
        {
            var property = (PropertyInfo)((MemberExpression)propertySelector.Body).Member;

            ParameterExpression parameter = Expression.Parameter(typeof(T));

            var expression = Expression.Lambda<Func<T, bool>>(
                Expression.Call(
                    Expression.Constant(ids),
                    typeof(ICollection<int?>).GetMethod("Contains"),
                    Expression.Property(parameter, property)),
                parameter);

            return entities.Where(expression);
        }
    }
}
