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

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        static string mystr = @"Data Source=DESKTOP-FIJ7UEB\WYC;Initial Catalog=大作业;Integrated Security=True";
        SqlConnection myconn = new SqlConnection(mystr);

        private void button1_Click(object sender, EventArgs e)
        {
            String mysql = "insert into message1 values( 's001','s009','" + textBox2.Text.ToString() + "','" + DateTime.Now.ToString() + "')";     //聊天记录入库
            SqlDataAdapter myadapter = new SqlDataAdapter(mysql, myconn);
            DataSet mydataset = new DataSet();
            myadapter.Fill(mydataset);
            textBox1.Text += "s001" + "   " + DateTime.Now.ToString() + "\r\n" + textBox2.Text + "\r\n";
            textBox2.Clear();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string mysql2 = "select * from message1 where (landlord='s001' and users='s009') or(landlord='s001' and users='s009') order by dat";   //查找历史聊天记录
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
    }
}
