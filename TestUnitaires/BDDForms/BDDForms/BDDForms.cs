using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BDDForms
{
    public partial class BDDForms : Form
    {
        MySqlConnection Connect = new MySqlConnection("datasource=Localhost;port=3306;username=root;password=;database=personne"); 
        MySqlCommand Command = new MySqlCommand();
        public BDDForms()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Command.Connection = Connect;
                if (textBox1.Text != "")
                {

                    Connect.Open(); // open
                    Command.CommandText = "insert into personne values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                    Command.ExecuteNonQuery(); // execute
                    MessageBox.Show("Good Morning !!!");
                    Connect.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = ""; // Empty the field
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Connect.Close();
            }

        }

    }

}

