using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NorthWindLibrary.Classes;
using NorthWindLibrary.PartialClasses;

namespace CustomersByCountry.LanguageExtensions
{
    public static class CheckedListBoxExtensions
    {
        public static List<CountryItem> CheckedCountryList(this CheckedListBox sender) 
        {
            var result = from column in sender.Items.OfType<CountryItem>()
                    .Where((item, index) => sender.GetItemChecked(index))
                select column;

            return result.ToList();
        }
        public static List<CategoryCheckedListBox> CheckedCategoriesList(this CheckedListBox sender)
        {
            var result = from column in sender.Items.OfType<CategoryCheckedListBox>()
                    .Where((item, index) => sender.GetItemChecked(index))
                select column;

            return result.ToList();
        }
    }
}