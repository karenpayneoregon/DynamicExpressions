namespace CustomersByCountry
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CountryCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.SelectCountriesButton = new System.Windows.Forms.Button();
            this.CountryDataGridView = new System.Windows.Forms.DataGridView();
            this.CompanyNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactFirstNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.SelectCategoriesButton = new System.Windows.Forms.Button();
            this.ProductDataGridView = new System.Windows.Forms.DataGridView();
            this.ProductIdentifierColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.CountryDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CountryCheckedListBox
            // 
            this.CountryCheckedListBox.FormattingEnabled = true;
            this.CountryCheckedListBox.Location = new System.Drawing.Point(12, 12);
            this.CountryCheckedListBox.Name = "CountryCheckedListBox";
            this.CountryCheckedListBox.Size = new System.Drawing.Size(172, 319);
            this.CountryCheckedListBox.TabIndex = 0;
            // 
            // SelectCountriesButton
            // 
            this.SelectCountriesButton.Location = new System.Drawing.Point(12, 337);
            this.SelectCountriesButton.Name = "SelectCountriesButton";
            this.SelectCountriesButton.Size = new System.Drawing.Size(172, 23);
            this.SelectCountriesButton.TabIndex = 1;
            this.SelectCountriesButton.Text = "Select";
            this.SelectCountriesButton.UseVisualStyleBackColor = true;
            this.SelectCountriesButton.Click += new System.EventHandler(this.SelectCountriesButton_Click);
            // 
            // CountryDataGridView
            // 
            this.CountryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CountryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyNameColumn,
            this.ContactFirstNameColumn,
            this.LastNameColumn,
            this.CountryColumn});
            this.CountryDataGridView.Location = new System.Drawing.Point(204, 21);
            this.CountryDataGridView.Name = "CountryDataGridView";
            this.CountryDataGridView.Size = new System.Drawing.Size(568, 309);
            this.CountryDataGridView.TabIndex = 2;
            // 
            // CompanyNameColumn
            // 
            this.CompanyNameColumn.DataPropertyName = "CompanyName";
            this.CompanyNameColumn.HeaderText = "Company";
            this.CompanyNameColumn.Name = "CompanyNameColumn";
            // 
            // ContactFirstNameColumn
            // 
            this.ContactFirstNameColumn.DataPropertyName = "FirstName";
            this.ContactFirstNameColumn.HeaderText = "First";
            this.ContactFirstNameColumn.Name = "ContactFirstNameColumn";
            // 
            // LastNameColumn
            // 
            this.LastNameColumn.DataPropertyName = "LastName";
            this.LastNameColumn.HeaderText = "Last";
            this.LastNameColumn.Name = "LastNameColumn";
            // 
            // CountryColumn
            // 
            this.CountryColumn.DataPropertyName = "CountryName";
            this.CountryColumn.HeaderText = "Country";
            this.CountryColumn.Name = "CountryColumn";
            // 
            // CategoryCheckedListBox
            // 
            this.CategoryCheckedListBox.FormattingEnabled = true;
            this.CategoryCheckedListBox.Location = new System.Drawing.Point(14, 383);
            this.CategoryCheckedListBox.Name = "CategoryCheckedListBox";
            this.CategoryCheckedListBox.Size = new System.Drawing.Size(170, 214);
            this.CategoryCheckedListBox.TabIndex = 3;
            // 
            // SelectCategoriesButton
            // 
            this.SelectCategoriesButton.Location = new System.Drawing.Point(14, 603);
            this.SelectCategoriesButton.Name = "SelectCategoriesButton";
            this.SelectCategoriesButton.Size = new System.Drawing.Size(172, 23);
            this.SelectCategoriesButton.TabIndex = 4;
            this.SelectCategoriesButton.Text = "Select";
            this.SelectCategoriesButton.UseVisualStyleBackColor = true;
            this.SelectCategoriesButton.Click += new System.EventHandler(this.SelectCategoriesButton_Click);
            // 
            // ProductDataGridView
            // 
            this.ProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductIdentifierColumn,
            this.ProductName,
            this.CategoryNameColumn});
            this.ProductDataGridView.Location = new System.Drawing.Point(204, 383);
            this.ProductDataGridView.Name = "ProductDataGridView";
            this.ProductDataGridView.Size = new System.Drawing.Size(568, 281);
            this.ProductDataGridView.TabIndex = 5;
            // 
            // ProductIdentifierColumn
            // 
            this.ProductIdentifierColumn.DataPropertyName = "ProductId";
            this.ProductIdentifierColumn.HeaderText = "Id";
            this.ProductIdentifierColumn.Name = "ProductIdentifierColumn";
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Name";
            this.ProductName.Name = "ProductName";
            // 
            // CategoryNameColumn
            // 
            this.CategoryNameColumn.DataPropertyName = "CategoryName";
            this.CategoryNameColumn.HeaderText = "Category";
            this.CategoryNameColumn.Name = "CategoryNameColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 705);
            this.Controls.Add(this.ProductDataGridView);
            this.Controls.Add(this.SelectCategoriesButton);
            this.Controls.Add(this.CategoryCheckedListBox);
            this.Controls.Add(this.CountryDataGridView);
            this.Controls.Add(this.SelectCountriesButton);
            this.Controls.Add(this.CountryCheckedListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customers by one or more countries";
            ((System.ComponentModel.ISupportInitialize)(this.CountryDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox CountryCheckedListBox;
        private System.Windows.Forms.Button SelectCountriesButton;
        private System.Windows.Forms.DataGridView CountryDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactFirstNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryColumn;
        private System.Windows.Forms.CheckedListBox CategoryCheckedListBox;
        private System.Windows.Forms.Button SelectCategoriesButton;
        private System.Windows.Forms.DataGridView ProductDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductIdentifierColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryNameColumn;
    }
}

