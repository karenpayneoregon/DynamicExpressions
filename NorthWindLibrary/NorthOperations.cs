using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NorthWindLibrary.Classes;
using NorthWindLibrary.Helpers;
using NorthWindLibrary.Models;
using NorthWindLibrary.PartialClasses;
using static NorthWindLibrary.Helpers.CustomersDynamicFiltering;

namespace NorthWindLibrary
{
    public class NorthOperations
    {
        /// <summary>
        /// Get tables, columns, column types and primary keys
        /// </summary>
        /// <returns></returns>
        public async Task<List<TableInformation>> DatabaseTableInformation()
        {

            var entityCrawler = new EntityCrawler()
            {
                AssembleName = Assembly.GetExecutingAssembly().GetName().Name,
                TypeName = "NorthWindAzureContext"
            };

            await Task.Run(() => entityCrawler.GetInformation());
            

            return entityCrawler.TableInformation;

        }
        /// <summary>
        /// Get all customers without children
        /// </summary>
        /// <returns></returns>
        public async Task<List<Customer>> GetAllCustomers()
        {

            using (var context = new NorthWindAzureContext())
            {
                return await Task.Run(() => context.Customers.Select(customer => customer).ToList()); 
            }

        }
        /// <summary>
        /// Get customer by dynamic property and value, include country
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<Customer> GetCustomers(string propertyName, string value)
        {           

            Func<Customer, bool> query = DynamicQueryWithExpressionTrees(propertyName, value);

            using (var context = new NorthWindAzureContext())
            {
                return await Task.Run(() => context.Customers
                    .Include(customer => customer.Country)
                    .Where(query).Select(customer => customer)
                    .FirstOrDefault());
            }

        }
        /// <summary>
        /// Get customers by dynamic property and value
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<List<Customer>> GetCustomersList(string propertyName, string value)
        {

            Func<Customer, bool> query = DynamicQueryWithExpressionTrees(propertyName, value);
            using (var context = new NorthWindAzureContext())
            {
                return await Task.Run(() => context.Customers
                    .Include(customer => customer.Country)
                    .Where(query).Select(customer => customer)
                    .ToList());
            }

        }
        /// <summary>
        /// Get subset of customers focusing on primary keys
        /// </summary>
        /// <returns></returns>
        public async Task<List<CustomerNameIdentifier>> CustomerNameWithIdentifiers()
        {
            using (var context = new NorthWindAzureContext())
            {
                
                return await Task.Run(() =>
                    context.Customers
                        .Include(customer => customer.Country)
                        .Select(customer => new CustomerNameIdentifier()
                    {
                        CustomerIdentifier = customer.CustomerIdentifier,
                        CompanyName = customer.CompanyName,
                        CountryIdentifier = customer.CountryIdentifier.Value
                    }).ToList());
            }
        }
        /// <summary>
        /// Dynamic sort by property name and order ascending or descending 
        /// </summary>
        public void SortTest()
        {
            using (var context = new NorthWindAzureContext())
            {
                var results = context.Customers.ToList().Sort1("CompanyName DESC");
                Console.WriteLine();
            }

        }
        /// <summary>
        /// Example for projection of a specific model
        /// </summary>
        /// <returns></returns>
        public List<CustomerCountryListItem> ProjectionTest()
        {
            using (var context = new NorthWindAzureContext())
            {
                List<CustomerCountryListItem> results = context.Customers.Select(Customer.Projection).ToList();
                return results;
            }
        }
        /// <summary>
        /// Example for building a where predicate with an expression
        /// </summary>
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
        /// <summary>
        /// Using expressions to build a predicate for obtaining data
        /// by multiple key values
        /// </summary>
        /// <returns></returns>
        public List<Customer> ExtensionCustomersContainsIdentifiersTest()
        {
            var ids = new List<int> { 1, 2, 3 };

            using (var context = new NorthWindAzureContext())
            {
                return context.Customers
                    .Include(customer => customer.Contact)
                    .WithIdendifier(cust => cust.CustomerIdentifier, ids)
                    .ToList();
            }

        }
        /// <summary>
        /// Using expressions to build a predicate for obtaining data
        /// by multiple key values
        /// </summary>
        /// <returns></returns>
        public void CustomerContactsTypes()
        {
            var ids = new List<int?> { 1, 2, 3 };
            using (var context = new NorthWindAzureContext())
            {
                var results = context.Customers
                    .Include(c => c.ContactType)
                    .WithContactTypes(item => item.ContactTypeIdentifier, ids)
                    .ToList();

                Console.WriteLine();
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

        public async Task<List<CategoryCheckedListBox>> GetAllCategories()
        {
            using (var context = new NorthWindAzureContext())
            {
                return await Task.Run(() => context.Categories.Select(category => new CategoryCheckedListBox()
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName
                }).ToList());
            }

        }
        /// <summary>
        /// How a developer might try to perform a IN condition yet this
        /// is hard coded, not suited to work with dynamic values.
        /// </summary>
        private void ArticleSample1()
        {
            using (var context = new NorthWindAzureContext())
            {
                var results = context.Customers.
                    Where(customer => customer.CountryIdentifier == 8 || 
                                      customer.CountryIdentifier == 7)
                    .ToList();
            }
        }
        /// <summary>
        /// Next attempt, pass in a Nullable Int array of country identifiers
        /// </summary>
        /// <param name="countryIdentifiers"></param>
        private void ArticleSample2(int?[] countryIdentifiers)
        {
            using (var context = new NorthWindAzureContext())
            {
                var results = context.Customers
                    .Where(customer => countryIdentifiers.Contains(customer.CountryIdentifier))
                    .ToList();
            }
        }

    }
}
