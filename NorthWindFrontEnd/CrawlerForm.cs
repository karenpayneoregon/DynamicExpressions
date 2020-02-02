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
using NorthWindLibrary.Helpers;

namespace NorthWindFrontEnd
{
    public partial class CrawlerForm : Form
    {
        private readonly NorthOperations _northOperations = new NorthOperations();
        public CrawlerForm()
        {
            InitializeComponent();

            TableListBox.SelectedIndexChanged += TableListBox_SelectedIndexChanged;
            ColumnsListBox.SelectedIndexChanged += ColumnsListBox_SelectedIndexChanged;
            Shown += CrawlerForm_Shown;
        }

        private void ColumnsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var test = (EntityColumn) ColumnsListBox.SelectedItem;
            TypeNameLabel.Text = test.TypeName;
            PrimaryKeyLabel.Text = $"{test.Key}";

        }

        private void TableListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var test = (TableInformation) TableListBox.SelectedItem;
            ColumnsListBox.DataSource = test.EntityColumnList;

        }

        private async void CrawlerForm_Shown(object sender, EventArgs e)
        {
            var information = await _northOperations.DatabaseTableInformation();
            TableListBox.DataSource = information.OrderBy(info => info.TableName).ToList();
        }
    }
}
