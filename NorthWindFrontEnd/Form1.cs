using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NorthWindFrontEnd.LanguageExtensions;
using NorthWindLibrary;
using NorthWindLibrary.Classes;

namespace NorthWindFrontEnd
{
    public partial class Form1 : Form
    {
        private readonly NorthOperations _northOperations = new NorthOperations();
        public Form1()
        {
            InitializeComponent();
            Shown += Form1_Shown;
        }
        /// <summary>
        /// Load reference data followed by enabling controls on success
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Form1_Shown(object sender, EventArgs e)
        {
            try
            {
                var customerResults = await _northOperations.CustomerNameWithIdentifiers();
                CustomerNameIdentifierComboBox.DataSource = customerResults;

                var countryResults = await _northOperations.GetAllCountries();
                CountryComboBox.DataSource = countryResults;

                CustomerByNameOrIdButton.Enabled = true;
                CustomerByCountryButton.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Each RadioButton tag is set to a property in customer class
        /// Dependent on which RadioButton is selected dictates to use the
        /// CustomerIdentifier or CompanyName property to perform the select.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CustomerByNameOrIdButton_Click(object sender, EventArgs e)
        {

            // get currently selected customer
            var current = (CustomerNameIdentifier) CustomerNameIdentifierComboBox.SelectedItem;

            // property name to query with
            var propertyName = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked).Tag.ToString();

            // value to query against
            var value = propertyName == "CustomerIdentifier" ? current.CustomerIdentifier.ToString() : current.CompanyName;

            try
            {
                // run query
                var customer = await _northOperations.GetCustomers(propertyName, value);
                MessageBox.Show($"{CustomerNameIdentifierComboBox.Text} country is '{customer.Country.Name}'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// Using CountryIdentifier property as a string find all customers by country identifier
        /// where the country identity value is passed as a string.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CustomerByCountryButton_Click(object sender, EventArgs e)
        {
            // get currently selected customer
            var current = (CountryItem)CountryComboBox.SelectedItem;

            // property name to query with
            var propertyName = "CountryIdentifier";

            try
            {
                // run query
                var customerList = await _northOperations.GetCustomersList(propertyName, current.CountryIdentifier.ToString());

                if (customerList.Count == 0)
                {
                    MessageBox.Show($"{CountryComboBox.Text} has no customers");
                }
                else
                {
                    MessageBox.Show($"{CountryComboBox.Text} has {customerList.Count} customers");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _northOperations.SortTest();
        }
    }
}
