using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NorthWindLibrary.Models;

namespace NorthWindLibrary.Helpers
{
    public static class Extensions
    {

        public static IQueryable<T> WithIdendifier<T>(this IQueryable<T> entities,Expression<Func<T, int>> propertySelector, ICollection<int> ids)
        {
            var property = (PropertyInfo)((MemberExpression)propertySelector.Body).Member;

            ParameterExpression parameter = Expression.Parameter(typeof(T));

            var expression = Expression.Lambda<Func<T, bool>>(
                Expression.Call(
                    Expression.Constant(ids),
                    typeof(ICollection<int>).GetMethod("Contains"),
                    Expression.Property(parameter, property)),
                parameter);

            return entities.Where(expression);
        }
        public static IQueryable<T> WithContactTypes<T>(this IQueryable<T> entities, Expression<Func<T, int?>> propertySelector, ICollection<int?> ids)
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
        /// <summary>
        /// Get customer details without orders
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static IQueryable<Customer> PartialCompleteCustomers(this NorthWindAzureContext context)
        {
            return context.Customers
                .Include(customer => customer.Country)
                .Include(customer => customer.Contact)
                .Include(customer => customer.ContactType);
        }
        /// <summary>
        /// Get single customer by customer identifier and return customer data and order data
        /// excluding complete order details.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public static Customer CustomerById(this NorthWindAzureContext context, int customerIdentifier) 
        {
            return context.Customers
                .Include(customer => customer.Country)
                .Include(customer => customer.Contact)
                .Include(customer => customer.ContactType)
                .Include(customer => customer.Orders)
                .FirstOrDefault(c => c.CustomerIdentifier == customerIdentifier);
        }

        public static Customer CustomerById1(this NorthWindAzureContext context, int customerIdentifier)
        {
            return context.Customers
                .Include(customer => customer.Country)
                .Include(customer => customer.Contact)
                .Include(customer => customer.ContactType)
                .Include(customer => customer.Orders.Select(ord => ord.Order_Details))
                .FirstOrDefault(cust => cust.CustomerIdentifier == customerIdentifier);
        }
    }
}

