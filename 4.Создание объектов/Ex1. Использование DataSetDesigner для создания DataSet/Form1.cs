using DataSetDesigner.NorthwindDataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSetDesigner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet1);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "northwindDataSet1.Orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.northwindDataSet1.Orders);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "northwindDataSet1.Customers". При необходимости она может быть перемещена или удалена.
            this.customersTableAdapter.Fill(this.northwindDataSet1.Customers);

        }

        private void GetCustomersButton_Click(object sender, EventArgs e)
        {
            
NorthwindDataSet1 NorthwindDataset1 = new NorthwindDataSet1();
         
NorthwindDataSet1TableAdapters.CustomersTableAdapter
CustomersTableAdapter1 =
                new NorthwindDataSet1TableAdapters.CustomersTableAdapter();
           
CustomersTableAdapter1.Fill(NorthwindDataset1.Customers);
           
foreach (NorthwindDataSet1.CustomersRow NWCustomer in
                             NorthwindDataset1.Customers.Rows)
            {
                CustomersListBox.Items.Add(NWCustomer.CompanyName);
            }

        }
    }
}
