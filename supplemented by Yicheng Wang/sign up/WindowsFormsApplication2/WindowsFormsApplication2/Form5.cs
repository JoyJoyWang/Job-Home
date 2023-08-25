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

namespace WindowsFormsApplication2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public static string str = Form3.str;      //登录用户名

        static string mystr = @"Data Source=DESKTOP-FIJ7UEB\WYC;Initial Catalog=大作业;Integrated Security=True";
        SqlConnection myconn = new SqlConnection(mystr);

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Text = "aaa";
            String mysql = "select distinct(landlord) from message1 where users= '" + str + "'";
            SqlDataAdapter myadapter = new SqlDataAdapter(mysql, myconn);
            DataSet mydataset = new DataSet();
            myadapter.Fill(mydataset);
            listBox1.DataSource = mydataset.Tables[0];
            listBox1.DisplayMember = "landlord";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            string mysql2 = "select * from message1 where (landlord='" + str + "' and users='" + listBox1.Text.ToString() + "') or(landlord='" + listBox1.Text.ToString() + "' and users='" + str + "')";
            SqlCommand mycmd = new SqlCommand(mysql2, myconn);
            SqlDataReader mydatareader;
            myconn.Open();
            {
                mydatareader = mycmd.ExecuteReader();
                while (mydatareader.Read())
                {
                    textBox1.Text += mydatareader.GetValue(0).ToString() + mydatareader.GetValue(3).ToString() + "\r\n" + mydatareader.GetValue(2).ToString() + "\r\n";
                }
                mydatareader.Close();
            }
            myconn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String mysql = "insert into message1 values( '" + str + "','" + listBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + DateTime.Now.ToString() + "')";
            SqlDataAdapter myadapter = new SqlDataAdapter(mysql, myconn);
            DataSet mydataset = new DataSet();
            myadapter.Fill(mydataset);
            textBox1.Text += str + "   " + DateTime.Now.ToString() + "\r\n" + textBox2.Text + "\r\n";
            textBox2.Clear();
        }
    }
}

