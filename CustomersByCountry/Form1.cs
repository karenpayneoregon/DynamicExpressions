using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LambdaEntityFrameWorkInCondition.Classes;
using LambdaEntityFrameWorkInCondition.LanguageExtensions;
using NorthWindLibrary;

namespace LambdaEntityFrameWorkInCondition
{
    public partial class Form1 : Form
    {
        private readonly NorthOperations _northOperations = new NorthOperations();

        public Form1()
        {
            InitializeComponent();

            Shown += Form1_Shown;
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            CountryDataGridView.AutoGenerateColumns = false;
            ProductDataGridView.AutoGenerateColumns = false;

            var countries = await _northOperations.GetAllCountries();
            CountryCheckedListBox.DataSource = countries;

            var categories = await _northOperations.GetAllCategories();
            CategoryCheckedListBox.DataSource = categories;

            SelectCountriesButton.Enabled = true;
            SelectCategoriesButton.Enabled = true;

        }

        private void SelectCountriesButton_Click(object sender, EventArgs e)
        {
            var countries = CountryCheckedListBox.CheckedCountryList().Select(country => (int?)country.CountryIdentifier);

            var ops = new DataOperations();
            var data = ops.CustomersByCountries(countries.ToList());
            CountryDataGridView.DataSource = data;
            CountryDataGridView.ExpandColumns();

        }

        private void SelectCategoriesButton_Click(object sender, EventArgs e)
        {
            var categories = CategoryCheckedListBox.CheckedCategoriesList().Select(category => (int?)category.CategoryID);
            var ops = new DataOperations();
            var data = ops.ProductsByCategories(categories.ToList()).ToList();
            ProductDataGridView.DataSource = data;
            ProductDataGridView.ExpandColumns();
        }
    }
    
}
