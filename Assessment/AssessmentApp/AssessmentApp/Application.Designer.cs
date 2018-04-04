namespace AssessmentApp
{
    partial class Application
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
            this.productListBox = new System.Windows.Forms.CheckedListBox();
            this.customerDropdown = new System.Windows.Forms.ComboBox();
            this.aliasTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.totalPriceTextBox = new System.Windows.Forms.RichTextBox();
            this.averagePriceTextBox = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.aliasListTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // productListBox
            // 
            this.productListBox.CheckOnClick = true;
            this.productListBox.FormattingEnabled = true;
            this.productListBox.Location = new System.Drawing.Point(567, 64);
            this.productListBox.Name = "productListBox";
            this.productListBox.Size = new System.Drawing.Size(260, 394);
            this.productListBox.TabIndex = 0;
            this.productListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.productListBox_ItemCheck);
            // 
            // customerDropdown
            // 
            this.customerDropdown.FormattingEnabled = true;
            this.customerDropdown.Location = new System.Drawing.Point(29, 64);
            this.customerDropdown.Name = "customerDropdown";
            this.customerDropdown.Size = new System.Drawing.Size(325, 21);
            this.customerDropdown.TabIndex = 1;
            this.customerDropdown.SelectedIndexChanged += new System.EventHandler(this.customerDropdown_SelectCustomer);
            // 
            // aliasTextBox
            // 
            this.aliasTextBox.Location = new System.Drawing.Point(29, 193);
            this.aliasTextBox.Name = "aliasTextBox";
            this.aliasTextBox.Size = new System.Drawing.Size(207, 20);
            this.aliasTextBox.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add New Nickname";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.aliasButton_Click);
            // 
            // totalPriceTextBox
            // 
            this.totalPriceTextBox.Location = new System.Drawing.Point(29, 467);
            this.totalPriceTextBox.Name = "totalPriceTextBox";
            this.totalPriceTextBox.ReadOnly = true;
            this.totalPriceTextBox.Size = new System.Drawing.Size(100, 47);
            this.totalPriceTextBox.TabIndex = 4;
            this.totalPriceTextBox.Text = "";
            // 
            // averagePriceTextBox
            // 
            this.averagePriceTextBox.Location = new System.Drawing.Point(232, 467);
            this.averagePriceTextBox.Name = "averagePriceTextBox";
            this.averagePriceTextBox.ReadOnly = true;
            this.averagePriceTextBox.Size = new System.Drawing.Size(100, 47);
            this.averagePriceTextBox.TabIndex = 5;
            this.averagePriceTextBox.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(567, 482);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 54);
            this.button2.TabIndex = 6;
            this.button2.Text = "Export CSV";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.exportCsvButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(720, 482);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 54);
            this.button3.TabIndex = 7;
            this.button3.Text = "Export HTML";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.exportHtmlButton_Click);
            // 
            // aliasListTextBox
            // 
            this.aliasListTextBox.Location = new System.Drawing.Point(29, 131);
            this.aliasListTextBox.Name = "aliasListTextBox";
            this.aliasListTextBox.ReadOnly = true;
            this.aliasListTextBox.Size = new System.Drawing.Size(325, 20);
            this.aliasListTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(26, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Customer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(26, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nicknames";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(26, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Total Value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label4.Location = new System.Drawing.Point(228, 438);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Average Per Order";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label5.Location = new System.Drawing.Point(563, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Products";
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 548);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aliasListTextBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.averagePriceTextBox);
            this.Controls.Add(this.totalPriceTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.aliasTextBox);
            this.Controls.Add(this.customerDropdown);
            this.Controls.Add(this.productListBox);
            this.Name = "Application";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox productListBox;
        private System.Windows.Forms.ComboBox customerDropdown;
        private System.Windows.Forms.TextBox aliasTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox totalPriceTextBox;
        private System.Windows.Forms.RichTextBox averagePriceTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox aliasListTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

