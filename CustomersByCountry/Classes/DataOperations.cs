using System.Collections.Generic;
using System.Linq;
using NorthWindLibrary;
using System.Data.Entity;
using CustomersByCountry.LanguageExtensions;
using NorthWindLibrary.PartialClasses;

namespace CustomersByCountry.Classes
{
    public class DataOperations
    {
        /// <summary>
        /// Return customers by country using country identifier(s)
        /// </summary>
        /// <param name="identifiers">one or more country identifiers</param>
        /// <returns></returns>
        public List<CustomerCountries> CustomersByCountries(List<int?> identifiers)
        {
            
            using (var context = new NorthWindAzureContext())
            {
                return context.Customers
                    .Include(customer => customer.Contact)
                    .Include(customer => customer.Country)
                    .WithIdentifiers(customer => customer.CountryIdentifier, identifiers)
                    .Select(customer => new CustomerCountries()
                    {
                        CustomerIdentifier = customer.CustomerIdentifier,
                        CompanyName = customer.CompanyName,
                        FirstName = customer.Contact.FirstName,
                        LastName = customer.Contact.LastName,
                        CountryName = customer.Country.Name
                    }).ToList();

            }
        }

        public List<ProductCheckedListBox> ProductsByCategories(List<int?> identifiers) 
        {
            using (var context = new NorthWindAzureContext())
            {
                return context.Products
                    .Include(product => product.Category)
                    .WithIdentifiers(product => product.CategoryID, identifiers)
                    .Select(product => new ProductCheckedListBox()
                    {
                        ProductID = product.ProductID,
                        ProductName = product.ProductName,
                        CategoryName = product.Category.CategoryName
                    })
                    .ToList();
            }
        }

    }
}
