using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace finalproject
{
    public partial class rinsert : Form
    {
        public rinsert()
        {
            InitializeComponent();
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            rchoosing f14 = new rchoosing();
            f14.ShowDialog();
        }*/
        static string mystr = @"Data Source=.;Initial Catalog=workrent;Integrated Security=True";
        SqlConnection mycon = new SqlConnection(mystr);

        private void button8_Click(object sender, EventArgs e)
        {
            string s1 = "insert into work values('" + textBox14.Text.Trim() + "','" + textBox13.Text.Trim() + "','" + textBox12.Text.Trim() + "','" + textBox11.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + textBox7.Text.Trim() + "','" + textBox8.Text.Trim() + "','" + textBox9.Text.Trim() + "','" + textBox10.Text.Trim() + "','" +A.username.Trim() + "')";
            SqlCommand cmd = new SqlCommand(s1, mycon);
            //MessageBox.Show(s1);
            mycon.Open();
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            mycon.Close();
        }


        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "无")
                textBox7.Text = "";
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text == "无")
                textBox8.Text = "";
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text == "无")
                textBox9.Text = "";
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text == "无")
                textBox11.Text = "";
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (textBox12.Text == "无")
                textBox12.Text = "";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "无")
                textBox5.Text = "";
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (textBox13.Text == "无")
                textBox13.Text = "";
        }
    }
}
