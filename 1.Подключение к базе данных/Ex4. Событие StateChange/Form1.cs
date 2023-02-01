using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DBConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }

     

       
        OleDbConnection connection = new OleDbConnection();
      
      



      


        //   string testConnect = @"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;User ID=LAPTOP-6G0GA05G\vadim;Initial Catalog=Northwind;Data Source=LAPTOP-6G0GA05G\SQLEXPRESS";
        string testConnect = @"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;User ID=LAPTOP-6G0GA05G\vadim;Initial Catalog=Northwind;Data Source=LAPTOP-6G0GA05G\SQLEXPRESS";

        private void подключениеКБазеДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {

                if (connection.State != ConnectionState.Open)
                {



                    connection.ConnectionString = testConnect;
                    connection.Open();
                    MessageBox.Show("Соединение с базой данных выполнено успешно");
                    this.connection.StateChange += new System.Data.StateChangeEventHandler(this.connection_StateChange);
                }
                else
                    MessageBox.Show("Соединение с базой данных уже установлено");
            }


            /* 
            catch (OleDbException XcpSQL)
            {
              MessageBox.Show("Ошибка соединения с базой данных");
            }
            */

            /* catch (OleDbException XcpSQL)
            {
              foreach (OleDbError se in XcpSQL.Errors)
              {
                  MessageBox.Show(se.Message,
                  "SQL Error code " + se.NativeError,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
              }
            }
            */
        
            
            catch (Exception Xcp)
            {
                MessageBox.Show(Xcp.Message, "Unexpected Exception",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

    

        private void отключитьСоединениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // OleDbConnection connection = new OleDbConnection();
          
           
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    MessageBox.Show("Соединение с базой данных закрыто");
                }
                else
                    MessageBox.Show("Соединение с базой данных уже закрыто");



        }



          
            private void connection_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            подключениеКБазеДанныхToolStripMenuItem.Enabled =
                (e.CurrentState == ConnectionState.Closed);
            отключитьСоединениеToolStripMenuItem.Enabled =
                (e.CurrentState == ConnectionState.Open);
        }




    }
}
