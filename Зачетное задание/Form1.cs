using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuname.Text == "")
            {
                MessageBox.Show("Enter Username !!");
            }
            else if (txtpass.Text == "")
            {
                MessageBox.Show("Enter Password !!");
            }
            else if (txtuname.Text == "Vadim" && txtpass.Text == "123")
            {
               
                Form frm2 = new Form2();
                frm2.ShowDialog();
             //   this.Close();

            }
            else
            {
                MessageBox.Show("Invalid Credential");
            }
        }
    }
}
