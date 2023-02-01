using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ADO1_WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string testConnect = @"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;User ID=LAPTOP-6G0GA05G\vadim;Initial Catalog=Northwind;Data Source=LAPTOP-6G0GA05G\SQLEXPRESS";

        private void button1_Click(object sender, EventArgs e)
        {

            // создание подключения
            OleDbConnection connection = new OleDbConnection(testConnect);

            // открываем подключение
            connection.Open();

            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT ProductName FROM Products";
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listView1.Items.Add(reader["ProductName"].ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            OleDbConnection connection = new OleDbConnection(testConnect);
            connection.Open();
            OleDbTransaction OleTran = connection.BeginTransaction();
            OleDbCommand command = connection.CreateCommand();
            command.Transaction = OleTran;
        
            try
            {
                command.CommandText =
                "INSERT INTO Products (ProductName) VALUES('Wrong size')";
                //"DELETE FROM Products (ProductName) VALUES('Wrong size')";
                command.ExecuteNonQuery();
                command.CommandText =
               "INSERT INTO Products (ProductName) VALUES('Wrong color')";
               // "DELETE FROM Products (ProductName) VALUES('Wrong color')";
                command.ExecuteNonQuery();

                OleTran.Commit();
                MessageBox.Show("Both records were written to database");
            }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                try
                {
                    OleTran.Rollback();
                }
                catch (Exception exRollback)
                {
                    MessageBox.Show(exRollback.Message);
                }
            }
          
              connection.Close();




        }
    }
}
