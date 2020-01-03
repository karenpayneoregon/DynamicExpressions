using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWindLibrary.Classes;
using NorthWindLibrary.Helpers;
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
                    context.Customers.Include(cust => cust.Country).Select(customer => new CustomerNameIdentifier()
                    {
                        CustomerIdentifier = customer.CustomerIdentifier,
                        CompanyName = customer.CompanyName,
                        CountryIdentifier = customer.CountryIdentifier.Value
                    }).ToList());
            }
        }

        public void ProjectTest()
        {
            using (var context = new NorthWindAzureContext())
            {
                var results = context.Customers.Select(Customer.Projection).ToList();
                Console.WriteLine();
            }
        }

        public void BuilderTest()
        {
            var test = Builder.Build<Customer, string>(
                customer => customer.ContactType.ContactTitle, Operator.EQUAL,"Owner");

            using (var context = new NorthWindAzureContext())
            {
                var results = context.Customers.Where(test).ToList();
                Console.WriteLine();
            }
        }

        public List<Customer> ExtensionCustomersContainsIdentifiersTest()
        {
            var ids = new List<int> { 1, 2, 3 };
            using (var context = new NorthWindAzureContext())
            {
                return context.Customers.Include(c => c.Contact).WithId(cust => cust.CustomerIdentifier, ids).ToList();
            }
        }

        public List<Customer> CompleteCustomersTest()
        {
            using (var context = new NorthWindAzureContext())
            {
                return context.PartialCompleteCustomers().ToList();
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
