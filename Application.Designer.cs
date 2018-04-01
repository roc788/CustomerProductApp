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
            this.grandTotalTextBox = new System.Windows.Forms.RichTextBox();
            this.customerTotalTextBox = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            this.aliasTextBox.Location = new System.Drawing.Point(29, 143);
            this.aliasTextBox.Name = "aliasTextBox";
            this.aliasTextBox.Size = new System.Drawing.Size(270, 20);
            this.aliasTextBox.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add Alias";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.aliasButton_Click);
            // 
            // grandTotalTextBox
            // 
            this.grandTotalTextBox.Location = new System.Drawing.Point(29, 467);
            this.grandTotalTextBox.Name = "grandTotalTextBox";
            this.grandTotalTextBox.ReadOnly = true;
            this.grandTotalTextBox.Size = new System.Drawing.Size(100, 47);
            this.grandTotalTextBox.TabIndex = 4;
            this.grandTotalTextBox.Text = "";
            // 
            // customerTotalTextBox
            // 
            this.customerTotalTextBox.Location = new System.Drawing.Point(232, 467);
            this.customerTotalTextBox.Name = "customerTotalTextBox";
            this.customerTotalTextBox.ReadOnly = true;
            this.customerTotalTextBox.Size = new System.Drawing.Size(100, 47);
            this.customerTotalTextBox.TabIndex = 5;
            this.customerTotalTextBox.Text = "";
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
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 548);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.customerTotalTextBox);
            this.Controls.Add(this.grandTotalTextBox);
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
        private System.Windows.Forms.RichTextBox grandTotalTextBox;
        private System.Windows.Forms.RichTextBox customerTotalTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

