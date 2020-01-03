using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindLibrary.Classes
{
    public class CustomerNameIdentifier
    {
        public int CustomerIdentifier { get; set; }
        public string CompanyName { get; set; }
        public int CountryIdentifier { get; set; }
        public override string ToString() => CompanyName;

    }
}
