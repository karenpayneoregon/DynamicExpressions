namespace NorthWindFrontEnd
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
            this.CustomerByNameOrIdButton = new System.Windows.Forms.Button();
            this.CustomerNameIdentifierComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CompanyNameIdentifier1RadioButton = new System.Windows.Forms.RadioButton();
            this.CompanyName1RadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CountryComboBox = new System.Windows.Forms.ComboBox();
            this.CustomerByCountryButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CustomerByNameOrIdButton
            // 
            this.CustomerByNameOrIdButton.Enabled = false;
            this.CustomerByNameOrIdButton.Location = new System.Drawing.Point(259, 22);
            this.CustomerByNameOrIdButton.Name = "CustomerByNameOrIdButton";
            this.CustomerByNameOrIdButton.Size = new System.Drawing.Size(75, 23);
            this.CustomerByNameOrIdButton.TabIndex = 0;
            this.CustomerByNameOrIdButton.Text = "Run";
            this.CustomerByNameOrIdButton.UseVisualStyleBackColor = true;
            this.CustomerByNameOrIdButton.Click += new System.EventHandler(this.CustomerByNameOrIdButton_Click);
            // 
            // CustomerNameIdentifierComboBox
            // 
            this.CustomerNameIdentifierComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CustomerNameIdentifierComboBox.FormattingEnabled = true;
            this.CustomerNameIdentifierComboBox.Location = new System.Drawing.Point(23, 24);
            this.CustomerNameIdentifierComboBox.Name = "CustomerNameIdentifierComboBox";
            this.CustomerNameIdentifierComboBox.Size = new System.Drawing.Size(210, 21);
            this.CustomerNameIdentifierComboBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CompanyNameIdentifier1RadioButton);
            this.groupBox1.Controls.Add(this.CompanyName1RadioButton);
            this.groupBox1.Controls.Add(this.CustomerNameIdentifierComboBox);
            this.groupBox1.Controls.Add(this.CustomerByNameOrIdButton);
            this.groupBox1.Location = new System.Drawing.Point(7, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 70);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "By name or identifier";
            // 
            // CompanyNameIdentifier1RadioButton
            // 
            this.CompanyNameIdentifier1RadioButton.AutoSize = true;
            this.CompanyNameIdentifier1RadioButton.Location = new System.Drawing.Point(408, 28);
            this.CompanyNameIdentifier1RadioButton.Name = "CompanyNameIdentifier1RadioButton";
            this.CompanyNameIdentifier1RadioButton.Size = new System.Drawing.Size(34, 17);
            this.CompanyNameIdentifier1RadioButton.TabIndex = 3;
            this.CompanyNameIdentifier1RadioButton.Tag = "CustomerIdentifier";
            this.CompanyNameIdentifier1RadioButton.Text = "Id";
            this.CompanyNameIdentifier1RadioButton.UseVisualStyleBackColor = true;
            // 
            // CompanyName1RadioButton
            // 
            this.CompanyName1RadioButton.AutoSize = true;
            this.CompanyName1RadioButton.Checked = true;
            this.CompanyName1RadioButton.Location = new System.Drawing.Point(349, 28);
            this.CompanyName1RadioButton.Name = "CompanyName1RadioButton";
            this.CompanyName1RadioButton.Size = new System.Drawing.Size(53, 17);
            this.CompanyName1RadioButton.TabIndex = 2;
            this.CompanyName1RadioButton.TabStop = true;
            this.CompanyName1RadioButton.Tag = "CompanyName";
            this.CompanyName1RadioButton.Text = "Name";
            this.CompanyName1RadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CountryComboBox);
            this.groupBox2.Controls.Add(this.CustomerByCountryButton);
            this.groupBox2.Location = new System.Drawing.Point(7, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 70);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer by country";
            // 
            // CountryComboBox
            // 
            this.CountryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CountryComboBox.FormattingEnabled = true;
            this.CountryComboBox.Location = new System.Drawing.Point(23, 24);
            this.CountryComboBox.Name = "CountryComboBox";
            this.CountryComboBox.Size = new System.Drawing.Size(210, 21);
            this.CountryComboBox.TabIndex = 1;
            // 
            // CustomerByCountryButton
            // 
            this.CustomerByCountryButton.Enabled = false;
            this.CustomerByCountryButton.Location = new System.Drawing.Point(259, 22);
            this.CustomerByCountryButton.Name = "CustomerByCountryButton";
            this.CustomerByCountryButton.Size = new System.Drawing.Size(75, 23);
            this.CustomerByCountryButton.TabIndex = 0;
            this.CustomerByCountryButton.Text = "Run";
            this.CustomerByCountryButton.UseVisualStyleBackColor = true;
            this.CustomerByCountryButton.Click += new System.EventHandler(this.CustomerByCountryButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 254);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code samples";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CustomerByNameOrIdButton;
        private System.Windows.Forms.ComboBox CustomerNameIdentifierComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton CompanyNameIdentifier1RadioButton;
        private System.Windows.Forms.RadioButton CompanyName1RadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CountryComboBox;
        private System.Windows.Forms.Button CustomerByCountryButton;
    }
}

