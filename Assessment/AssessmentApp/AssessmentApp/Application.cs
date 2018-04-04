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
        private List<Order> _orders;
        private int _selectedCustomerIndex;
        private int _previousCustomerIndex;
        private string _exportPath = ConfigurationManager.AppSettings["ExportPath"].ToString();

        public Application()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ToString();
            _customers = new List<Customer>();
            _products = new List<Product>();
            _orders = new List<Order>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetProducts();
            GetCustomers();
            GetOrders();
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
                    command.CommandText = "SELECT Id, ContactName FROM Customer";
                    dataReader = command.ExecuteReader();
                    Customer customer;

                    while (dataReader.Read())
                    {
                        customer = new Customer();
                        customer.Products = new List<Product>();
                        customer.Id = Convert.ToString(dataReader["Id"]);
                        customer.Name = Convert.ToString(dataReader["ContactName"]);
                        _customers.Add(customer);
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

        private void GetOrders()
        {
            SQLiteDataReader dataReader = null;

            using (SQLiteConnection sqlConnection = new SQLiteConnection(_connectionString))
            {
                sqlConnection.Open();
                SQLiteCommand command = sqlConnection.CreateCommand();

                command.Connection = sqlConnection;

                try
                {
                    command.CommandText = "SELECT c.Id, e.LastName, e.FirstName FROM Customer c INNER JOIN [Order] o ON c.Id = o.CustomerId INNER JOIN Employee e ON o.EmployeeId = e.Id WHERE o.OrderDate >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND o.OrderDate < '" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "'";
                    dataReader = command.ExecuteReader();
                    Order order;

                    while (dataReader.Read())
                    {
                        order = new Order();
                        order.Employee = Convert.ToString(dataReader["FirstName"]) + " " + Convert.ToString(dataReader["LastName"]);

                        if(_customers.Any(x => x.Id == Convert.ToString(dataReader["Id"])))
                        {
                            order.Customer = _customers.First(x => x.Id == Convert.ToString(dataReader["Id"]));
                        }
                        
                        _orders.Add(order);
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
            decimal customerAveragePrice = 0;
            decimal customerTotalPrice = 0;

            foreach (Customer customer in _customers)
            {
                customerDropdown.Items.Add(customer);
            }

            foreach (Product product in _products)
            {
                productListBox.Items.Add(product);
            }

            customerDropdown.SelectedIndex = 0;
            _selectedCustomerIndex = customerDropdown.SelectedIndex;

            averagePriceTextBox.Text = "$" + customerAveragePrice.ToString("0.00");
            totalPriceTextBox.Text = "$" + customerTotalPrice.ToString("0.00");
        }

        private void productListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(_selectedCustomerIndex == _previousCustomerIndex)
            {
                string productName = productListBox.Items[e.Index].ToString();

                if (e.NewValue.ToString() == "Checked" && _customers[_selectedCustomerIndex].Products.FindIndex(x => x.Name == productName) == -1)
                {
                    _customers[_selectedCustomerIndex].Products.Add(new Product { Name = productName, Price = _products.Find(x => x.Name == productName).Price });
                }
                else if (e.NewValue.ToString() == "Unchecked" && _customers[_selectedCustomerIndex].Products.FindIndex(x => x.Name == productName) != -1)
                {
                    _customers[_selectedCustomerIndex].Products.RemoveAt(_customers[_selectedCustomerIndex].Products.FindIndex(x => x.Name == productName));
                }

                _customers[_selectedCustomerIndex].ProductsConcat = String.Join(", ", _customers[_selectedCustomerIndex].Products);

                UpdateDisplay();
            }                  
        }

        private void aliasButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(aliasListTextBox.Text))
            {
                _customers[_selectedCustomerIndex].Aliases = aliasTextBox.Text;
                aliasListTextBox.Text = _customers[_selectedCustomerIndex].Aliases;
            }
            else
            {
                _customers[_selectedCustomerIndex].Aliases = aliasListTextBox.Text + "," + aliasTextBox.Text;
                aliasListTextBox.Text = _customers[_selectedCustomerIndex].Aliases;
            }

            aliasTextBox.Text = "";
        }

        private void exportCsvButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(_exportPath))
            {
                Directory.CreateDirectory(_exportPath);
            }
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(_exportPath + "Customers.csv", false, Encoding.UTF8))
                {
                    var csv = new CsvWriter(streamWriter);
                    csv.Configuration.RegisterClassMap<CustomerMap>();
                    csv.WriteRecords(_customers);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("COULD NOT WRITE TO FILE: {0}", ex);
            }
                                  
        }

        private void exportHtmlButton_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = new DataGridView();
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Nicknames", typeof(string));
            table.Columns.Add("Products", typeof(string));
            table.Columns.Add("Total Price", typeof(string));
            table.Columns.Add("Average Price", typeof(string));
            table.Columns.Add("Employee", typeof(string));

            foreach (Order order in _orders)
            {
                table.Rows.Add(order.Customer.Name, order.Customer.Aliases, order.Customer.ProductsConcat, "$" + order.Customer.PriceTotal.ToString("0.00"), "$" + order.Customer.AveragePrice.ToString("0.00"), order.Employee);
            }

            dataGridView.DataSource = table;

            string HtmlBody = ExportDatableToHtml(table);

            if (!Directory.Exists(_exportPath))
            {
                Directory.CreateDirectory(_exportPath);
            }

            try
            {
                File.WriteAllText(_exportPath + "Customers.html", HtmlBody, Encoding.UTF8);
            }
            catch(Exception ex)
            {
                Console.WriteLine("COULD NOT WRITE TO FILE: {0}", ex);
            }          
        }

        private void customerDropdown_SelectCustomer(object sender, EventArgs e)
        {
            _previousCustomerIndex = _selectedCustomerIndex;
            _selectedCustomerIndex = customerDropdown.SelectedIndex;
            SetCustomerState();
            UpdateDisplay();
            _previousCustomerIndex = _selectedCustomerIndex;
        }

        private void UpdateDisplay(decimal customerTotal, decimal grandTotal)
        {
            averagePriceTextBox.Text = "$" + customerTotal.ToString("0.00");
            totalPriceTextBox.Text = "$" + grandTotal.ToString("0.00");
        }


        private void SetCustomerState()
        {
            foreach(int i in productListBox.CheckedIndices)
            {
                productListBox.SetItemChecked(i, false);
            }

            foreach (Product product in _customers[_selectedCustomerIndex].Products)
            {
                productListBox.SetItemChecked(productListBox.FindString(product.Name), true);
            }

            aliasTextBox.Text = "";
            aliasListTextBox.Text = _customers[_selectedCustomerIndex].Aliases;
        }

        private void UpdateDisplay()
        {
            decimal customerAveragePrice = 0;
            decimal customerTotalPrice = 0;

            foreach (Product product in _customers[_selectedCustomerIndex].Products)
            {
                customerTotalPrice += product.Price;
            }

            if(_customers[_selectedCustomerIndex].Products.Count != 0)
            {
                customerAveragePrice = Math.Round(customerTotalPrice / _customers[_selectedCustomerIndex].Products.Count, 2);
            }
            
            _customers[_selectedCustomerIndex].AveragePrice = customerAveragePrice;
            _customers[_selectedCustomerIndex].PriceTotal = customerTotalPrice;
            averagePriceTextBox.Text = "$" + customerAveragePrice.ToString("0.00");
            totalPriceTextBox.Text = "$" + customerTotalPrice.ToString("0.00");
        }

        private string ExportDatableToHtml(DataTable table)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<html>");
            stringBuilder.Append("<head>");
            stringBuilder.Append("</head>");
            stringBuilder.Append("<body>");
            stringBuilder.Append(@"<input type=""text"" id=""input"" onkeyup=""myFunction()"" placeholder=""Search for employee.."">");
            stringBuilder.Append("<label>");
            stringBuilder.Append("Current Date: " + DateTime.Now.ToString("yyyy-MM-dd"));
            stringBuilder.Append("</label>");
            stringBuilder.Append("<table id=\"customers\" border='1px' cellpadding='1' cellspacing='1' bgcolor='lightyellow' style='font-family:Garamond; font-size:smaller'>");
            stringBuilder.Append("<tr class=\"header\">");
            foreach(DataColumn column in table.Columns)
            {
                stringBuilder.Append("<td>");
                stringBuilder.Append(column.ColumnName);
                stringBuilder.Append("</td>");
            }
            stringBuilder.Append("</tr>");

            foreach (DataRow myRow in table.Rows)
            {

                stringBuilder.Append("<tr class=\"tableBody\">");
                foreach (DataColumn myColumn in table.Columns)
                {
                    if (myColumn.ColumnName == "Employee")
                    {
                        stringBuilder.Append("<td class=\"employeeName\">");
                        stringBuilder.Append(myRow[myColumn.ColumnName].ToString());
                        stringBuilder.Append("</td>");
                    }
                    else
                    {
                        stringBuilder.Append("<td >");
                        stringBuilder.Append(myRow[myColumn.ColumnName].ToString());
                        stringBuilder.Append("</td>");
                    }
                }
                stringBuilder.Append("</tr>");
            }

            //Close tags.  
            stringBuilder.Append("</table>");

            stringBuilder.Append(@"<script>
                function myFunction() {

                var input, filter, table, tr, td, i;
                input = document.getElementById(""input"");
                filter = input.value.toUpperCase();
                table = document.getElementById(""customers"");
                tr = table.getElementsByClassName(""tableBody"");

                for (i = 0; i < tr.length; i++)
                {
                    td = tr[i].getElementsByClassName(""employeeName"")[0];
                    if (td) {
                        if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                            tr[i].style.display = """";
                        } else {
                            tr[i].style.display = ""none"";
                        }
                    }
                }
            }
            </script>");
            stringBuilder.Append("</body>");
            stringBuilder.Append("</html>");

            string Htmltext = stringBuilder.ToString();

            return Htmltext;
        }
    }
}
