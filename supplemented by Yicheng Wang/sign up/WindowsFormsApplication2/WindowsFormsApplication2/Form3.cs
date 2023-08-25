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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public static string str;

        static string mystr = @"Data Source=DESKTOP-FIJ7UEB\WYC;Initial Catalog=大作业;Integrated Security=True";
        SqlConnection myconn = new SqlConnection(mystr);

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String mysql = "select lnum,lpassword from landlord where lnum='" + textBox1.Text.ToString() + "'";
            SqlDataAdapter myadapter = new SqlDataAdapter(mysql, myconn);
            DataSet mydataset = new DataSet();
            myadapter.Fill(mydataset);
            try
            {
                if (textBox2.Text.ToString() == mydataset.Tables[0].Rows[0].ItemArray[1].ToString())
                {
                    Form5 f5 = new Form5();
                    str = textBox1.Text;
                    f5.Show();
                }
                else
                    MessageBox.Show("密码错误，请重新输入！");
            }
            catch
            { MessageBox.Show("不存在该用户，请重新输入用户名！"); }
        }

        int i = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            if (i % 2 != 0)
                textBox2.PasswordChar = '\0';
            else
                textBox2.PasswordChar = '*';
            i += 1;
        }
    }
}
