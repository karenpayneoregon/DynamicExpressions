using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWindLibrary.Classes;
using NorthWindLibrary.Models;
using static NorthWindLibrary.Helpers.CustomersDynamicFiltering;

namespace NorthWindLibrary
{
    public class NorthOperations
    {
        public async Task<List<Customer>> GetAllCustomers()
        {
            
            using (var context = new NorthWindAzureContext())
            {
                return await Task.Run(() => context.Customers.Select(customer => customer).ToList()); 
            }

        }
        public async Task<Customer> GetCustomers(string propertyName, string value)
        {           

            var dn = DynamicQueryWithExpressionTrees(propertyName, value);
            using (var context = new NorthWindAzureContext())
            {
                return await Task.Run(() => context.Customers
                    .Include(cust => cust.Country).Where(dn).Select(customer => customer).FirstOrDefault());
            }

        }

        public async Task<List<Customer>> GetCustomersList(string propertyName, string value)
        {

            var dn = DynamicQueryWithExpressionTrees(propertyName, value);
            using (var context = new NorthWindAzureContext())
            {
                return await Task.Run(() => context.Customers
                    .Include(cust => cust.Country).Where(dn).Select(customer => customer).ToList());
            }

        }

        public async Task<List<CustomerNameIdentifier>> CustomerNameWithIdentifiers()
        {
            using (var context = new NorthWindAzureContext())
            {
                return await Task.Run(() =>
                    context.Customers.Select(customer => new CustomerNameIdentifier()
                    {
                        CustomerIdentifier = customer.CustomerIdentifier,
                        CompanyName = customer.CompanyName,
                        CountryIdentifier = customer.CountryIdentifier.Value
                    }).ToList());
            }
        }
        public async Task<List<CountryItem>> GetAllCountries()
        {

            using (var context = new NorthWindAzureContext())
            {
                return await Task.Run(() => 
                    context.Countries.Select(country => new CountryItem()
                    {
                        CountryIdentifier = country.CountryIdentifier,
                        Name = country.Name
                    }).ToList());
            }

        }


    }
}
