using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindLibrary.Helpers
{
    public class NorthCrawler
    {
        public EntityCrawler Configuration = new EntityCrawler();

        public NorthCrawler()
        {
            Configuration.AssembleName = "";
            Configuration.EnitityModelName = "NorthWindAzureContext";
            Configuration.TypeName = "NorthWindAzureContext";
        }

    }
}
