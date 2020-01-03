using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace NorthWindLibrary.Models
{
    public partial class Customer
    {
        /// <summary>
        /// Provides access to properties in CustomerCountryListItem
        /// </summary>
        public static Expression<Func<Customer, CustomerCountryListItem>> Projection
        {
            
            get
            {
                return customer => new CustomerCountryListItem()
                {
                    CustomerIdentifier = customer.CustomerIdentifier,
                    CompanyName = customer.CompanyName,
                    CountryName = customer.Country.Name
                };
            }
        }
    }

    public class CustomerCountryListItem
    {
        public int CustomerIdentifier { get; set; }
        public string CompanyName { get; set; }
        public string CountryName { get; set; } 
    }
}
