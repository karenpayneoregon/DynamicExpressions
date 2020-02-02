namespace NorthWindFrontEnd
{
    partial class CrawlerForm
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
            this.TableListBox = new System.Windows.Forms.ListBox();
            this.ColumnsListBox = new System.Windows.Forms.ListBox();
            this.TypeNameLabel = new System.Windows.Forms.Label();
            this.PrimaryKeyLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TableListBox
            // 
            this.TableListBox.FormattingEnabled = true;
            this.TableListBox.Location = new System.Drawing.Point(12, 12);
            this.TableListBox.Name = "TableListBox";
            this.TableListBox.Size = new System.Drawing.Size(218, 251);
            this.TableListBox.TabIndex = 0;
            // 
            // ColumnsListBox
            // 
            this.ColumnsListBox.FormattingEnabled = true;
            this.ColumnsListBox.Location = new System.Drawing.Point(257, 12);
            this.ColumnsListBox.Name = "ColumnsListBox";
            this.ColumnsListBox.Size = new System.Drawing.Size(218, 251);
            this.ColumnsListBox.TabIndex = 1;
            // 
            // TypeNameLabel
            // 
            this.TypeNameLabel.AutoSize = true;
            this.TypeNameLabel.Location = new System.Drawing.Point(566, 19);
            this.TypeNameLabel.Name = "TypeNameLabel";
            this.TypeNameLabel.Size = new System.Drawing.Size(27, 13);
            this.TypeNameLabel.TabIndex = 2;
            this.TypeNameLabel.Text = "type";
            // 
            // PrimaryKeyLabel
            // 
            this.PrimaryKeyLabel.AutoSize = true;
            this.PrimaryKeyLabel.Location = new System.Drawing.Point(569, 43);
            this.PrimaryKeyLabel.Name = "PrimaryKeyLabel";
            this.PrimaryKeyLabel.Size = new System.Drawing.Size(24, 13);
            this.PrimaryKeyLabel.TabIndex = 3;
            this.PrimaryKeyLabel.Text = "key";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(495, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Column type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(489, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Is primary key";
            // 
            // CrawlerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 297);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PrimaryKeyLabel);
            this.Controls.Add(this.TypeNameLabel);
            this.Controls.Add(this.ColumnsListBox);
            this.Controls.Add(this.TableListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CrawlerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crawler demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox TableListBox;
        private System.Windows.Forms.ListBox ColumnsListBox;
        private System.Windows.Forms.Label TypeNameLabel;
        private System.Windows.Forms.Label PrimaryKeyLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}