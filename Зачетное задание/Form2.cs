using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       
        private void btnGetData_Click(object sender, EventArgs e)
        {
            string ConString = @"Data Source=LAPTOP-6G0GA05G\SQLEXPRESS;Initial Catalog=TestCustomer;Integrated Security=True";
            string Query = "SELECT * FROM dbo.CustomerSet";

            SqlDataAdapter adapter = new SqlDataAdapter(Query, ConString);
            DataSet set = new DataSet();
          

            adapter.Fill(set, "dbo.CustomerSet");
            dataGridView1.DataSource = set.Tables["dbo.CustomerSet"];
        }

        // Изменить данные в 0-ой строке
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Fill Dataset
            string ConString = @"Data Source=LAPTOP-6G0GA05G\SQLEXPRESS;Initial Catalog=TestCustomer;Integrated Security=True";
            string Query = "SELECT * FROM dbo.CustomerSet";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, ConString);
            DataSet set = new DataSet();
            adapter.Fill(set, "dbo.CustomerSet");

       
            set.Tables["dbo.CustomerSet"].Rows[0]["FirstName"] = "Алексей";
            set.Tables["dbo.CustomerSet"].Rows[0]["LastName"] = "Миронов";
            set.Tables["dbo.CustomerSet"].Rows[0]["City"] = "Тихвин";
            set.Tables["dbo.CustomerSet"].Rows[0]["Age"] = "55";

            dataGridView1.DataSource = set.Tables["dbo.CustomerSet"];

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(set.Tables["dbo.CustomerSet"]);

            MessageBox.Show("2nd Row is updated successfully. DataSet Saved to Database Successfully");
        }

   // Добавить данные в новой строке

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //Fill Dataset
            string ConString = @"Data Source=LAPTOP-6G0GA05G\SQLEXPRESS;Initial Catalog=TestCustomer;Integrated Security=True";
            string Query = "SELECT * FROM dbo.CustomerSet";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, ConString);
            DataSet set = new DataSet();
            adapter.Fill(set, "dbo.CustomerSet");

            //Adding New Row to DataSet           
            DataRow row = set.Tables["dbo.CustomerSet"].NewRow();
            row["FirstName"] = "Вера";
            row["LastName"] = "Смирнова";
            row["City"] = "Москва";
            row["Age"] = "27";
            set.Tables["dbo.CustomerSet"].Rows.Add(row);

            dataGridView1.DataSource = set.Tables["dbo.CustomerSet"];

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(set.Tables["dbo.CustomerSet"]);

            MessageBox.Show("The new Row is added successfully. DataSet Saved to Database Successfully");
        }

        // Удалить данные в последней строке
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string ConString = @"Data Source=LAPTOP-6G0GA05G\SQLEXPRESS;Initial Catalog=TestCustomer;Integrated Security=True";
            string Query = "SELECT * FROM dbo.CustomerSet";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, ConString);
            DataSet set = new DataSet();
            adapter.Fill(set, "dbo.CustomerSet");

   

            set.Tables["dbo.CustomerSet"].Rows[7].Delete();
           
            dataGridView1.DataSource = set.Tables["dbo.CustomerSet"];

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(set.Tables["dbo.CustomerSet"]);

            MessageBox.Show("The last Row is deleted successfully. DataSet Saved to Database Successfully");
        }

   // Удалить данные в 0-ой строке
        private void button1_Click(object sender, EventArgs e)
        {
            string ConString = @"Data Source=LAPTOP-6G0GA05G\SQLEXPRESS;Initial Catalog=TestCustomer;Integrated Security=True";
            string Query = "SELECT * FROM dbo.CustomerSet";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, ConString);
            DataSet set = new DataSet();
            adapter.Fill(set, "dbo.CustomerSet");

            set.Tables["dbo.CustomerSet"].Rows[0].Delete();

            dataGridView1.DataSource = set.Tables["dbo.CustomerSet"];

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(set.Tables["dbo.CustomerSet"]);

            MessageBox.Show("The first Row is deleted successfully. DataSet Saved to Database Successfully");
        }
    }
}
