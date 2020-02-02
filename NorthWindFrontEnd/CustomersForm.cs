using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NorthWindLibrary;

namespace NorthWindFrontEnd
{
    public partial class CustomersForm : Form
    {
        private readonly NorthOperations _northOperations = new NorthOperations();
        public CustomersForm()
        {
            InitializeComponent();
            Shown += CustomersForm_Shown;
        }

        private void CustomersForm_Shown(object sender, EventArgs e)
        {
            var test = _northOperations.ProjectionTest();
            Console.WriteLine();
        }
    }
}
