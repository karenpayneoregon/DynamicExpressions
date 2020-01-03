using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindLibrary.Helpers
{
    public enum Operator
    {
        EQUAL,
        NOT_EQUAL,
        LESS_THAN,
        MORE_THAN,
        ANY
    };
    public class Builder
    {
        public static Expression<Func<T, bool>> Build<T, TProperty>(Expression<Func<T, TProperty>> property, Operator op, TProperty value)
        {
            if (op == Operator.ANY)
            {
                return e => true;
            }

            var left = property.Body;   //you need to check if it's a valid property visit
            var right = Expression.Constant(value);
            BinaryExpression body;

            switch (op)
            {
                case Operator.EQUAL:
                    body = Expression.Equal(left, right);
                    break;
                case Operator.NOT_EQUAL:
                    body = Expression.NotEqual(left, right);
                    break;
                case Operator.LESS_THAN:
                    //you'd better check if < operator is available for the type
                    body = Expression.LessThan(left, right);
                    break;
                case Operator.MORE_THAN:
                    body = Expression.GreaterThan(left, right);
                    break;
                default: throw new NotSupportedException();
            }

            return Expression.Lambda<Func<T, bool>>(body, property.Parameters[0]);
        }
    }
}
