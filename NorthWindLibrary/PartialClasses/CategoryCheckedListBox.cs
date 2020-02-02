using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindLibrary.PartialClasses
{
    public class CategoryCheckedListBox
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public override string ToString()
        {
            return CategoryName;
        }
    }
}
