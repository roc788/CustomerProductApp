using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;
using CsvHelper;
using System.IO;

namespace AssessmentApp
{
    public partial class Application : Form
    {
        private string _connectionString;
        private List<Customer> _customers;
        private List<Product> _products;
        private int _selectedCustomerIndex;
        private string _csvPath = ConfigurationManager.AppSettings["CsvPath"].ToString();

        public Application()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ToString();
            _customers = new List<Customer>();
            _products = new List<Product>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetProducts();
            GetCustomers();
            SetDefaultDisplay();
        }

        private void GetCustomers()
        {
            SQLiteDataReader dataReader = null;

            using (SQLiteConnection sqlConnection = new SQLiteConnection(_connectionString))
            {
                sqlConnection.Open();
                SQLiteCommand command = sqlConnection.CreateCommand();

                command.Connection = sqlConnection;

                try
                {
                    command.CommandText = "SELECT ContactName FROM Customer";
                    dataReader = command.ExecuteReader();
                    Customer customer;

                    while (dataReader.Read())
                    {
                        customer = new Customer();
                        customer.Products = new List<Product>();
                        customer.Name = Convert.ToString(dataReader["ContactName"]);
                        _customers.Add(customer);
                    }

                    foreach (Customer c in _customers)
                    {
                        foreach(Product p in _products)
                        {
                            c.Products.Add(new Product { Name = p.Name, Price = p.Price, Selected = p.Selected });
                        }

                        c.ProductsConcat = String.Join(",", c.Products);
                    }
                }
                catch (Exception e)
                {
                }
                finally
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }               
            }
        }

        private void GetProducts()
        {
            SQLiteDataReader dataReader = null;

            using (SQLiteConnection sqlConnection = new SQLiteConnection(_connectionString))
            {
                sqlConnection.Open();
                SQLiteCommand command = sqlConnection.CreateCommand();

                command.Connection = sqlConnection;

                try
                {
                    command.CommandText = "SELECT ProductName, UnitPrice FROM Product";
                    dataReader = command.ExecuteReader();
                    Product product;

                    while (dataReader.Read())
                    {
                        product = new Product();
                        product.Name = Convert.ToString(dataReader["ProductName"]);
                        product.Price = Convert.ToDecimal(dataReader["UnitPrice"]);
                        _products.Add(product);
                    }
                }
                catch (Exception e)
                {
                }
                finally
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        public void SetDefaultDisplay()
        {
            int index;
            decimal customerTotal = 0;
            decimal grandTotal = 0;

            foreach (Customer customer in _customers)
            {
                customerDropdown.Items.Add(customer);

                foreach (Product product in customer.Products)
                {
                    if (product.Selected)
                        grandTotal += product.Price;
                }
            }

            foreach(Product product in _customers.First().Products)
            {
                index = productListBox.Items.Add(product);

                if(product.Selected)
                {
                    customerTotal += product.Price;
                    productListBox.SetItemChecked(index, true);
                }
                    
            }

            customerDropdown.SelectedIndex = 0;
            _selectedCustomerIndex = customerDropdown.SelectedIndex;

            customerTotalTextBox.Text = customerTotal.ToString("0.00");
            grandTotalTextBox.Text = grandTotal.ToString("0.00");
        }

        private void productListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            decimal customerTotal = 0;
            decimal grandTotal = 0;

            if (e.NewValue.ToString() == "Checked")
            {
                _customers[_selectedCustomerIndex].Products[e.Index].Selected = true;                
            }
            else if(e.NewValue.ToString() == "Unchecked")
            {
                _customers[_selectedCustomerIndex].Products[e.Index].Selected = false;
            }            

            foreach (Product product in _customers[_selectedCustomerIndex].Products)
            {
                if (product.Selected)
                {
                    customerTotal += product.Price;
                }
            }

            foreach (Customer customer in _customers)
            {
                foreach (Product product in customer.Products)
                {
                    if (product.Selected)
                        grandTotal += product.Price;
                }
            }

            _customers[_selectedCustomerIndex].ProductsConcat = String.Join(",", _customers[_selectedCustomerIndex].Products);
            _customers[_selectedCustomerIndex].PriceTotal = customerTotal;
            UpdateDisplay(customerTotal, grandTotal);         
        }

        private void aliasButton_Click(object sender, EventArgs e)
        {
            _customers[_selectedCustomerIndex].Alias = aliasTextBox.Text;
        }

        private void exportCsvButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(_csvPath))
            {
                Directory.CreateDirectory(_csvPath);
            }

            using (StreamWriter streamWriter = new StreamWriter(_csvPath + "Customers.csv", false, Encoding.UTF8))
            {
                var csv = new CsvWriter(streamWriter);
                csv.Configuration.RegisterClassMap<CustomerMap>();
                csv.WriteRecords(_customers);
            }                       
        }

        private void exportHtmlButton_Click(object sender, EventArgs e)
        {

        }

        private void customerDropdown_SelectCustomer(object sender, EventArgs e)
        {
            _selectedCustomerIndex = customerDropdown.SelectedIndex;
            UpdateDisplay();         
        }

        private void UpdateDisplay(decimal customerTotal, decimal grandTotal)
        {
            customerTotalTextBox.Text = customerTotal.ToString("0.00");
            grandTotalTextBox.Text = grandTotal.ToString("0.00");
        }

        private void UpdateDisplay()
        {
            aliasTextBox.Text = _customers[_selectedCustomerIndex].Alias;

            foreach (Product product in _customers[_selectedCustomerIndex].Products)
            {
                if (product.Selected)
                {
                    productListBox.SetItemChecked(productListBox.FindString(product.Name), true);
                }
                else
                {
                    productListBox.SetItemChecked(productListBox.FindString(product.Name), false);
                }
            }
        }
    }
}
