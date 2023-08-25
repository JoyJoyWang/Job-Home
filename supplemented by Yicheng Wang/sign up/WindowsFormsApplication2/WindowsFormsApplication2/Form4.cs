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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        static string mystr = @"Data Source=DESKTOP-FIJ7UEB\WYC;Initial Catalog=university;Integrated Security=True";
        SqlConnection myconn = new SqlConnection(mystr);

        private void Form4_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
            textBox5.PasswordChar = '*';
            textBox6.PasswordChar = '*';
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "我要租房")
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
            }
            else if(comboBox1.Text=="我是房东")
            {
                groupBox2.Visible = true;
                groupBox1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string year, month, date, nyr;
            year = comboBox2.Text.Trim();
            month = comboBox3.Text.Trim();
            date = comboBox4.Text.Trim();
            nyr = year + '-' + month + '-' + date;
            /*if (textBox2.Text == textBox3.Text)
            {
                try
                {*/
                    String mysql = "insert into student values( 's111','xxx','女','城市规划','"+nyr+"','021-33333333')";
                    SqlDataAdapter myadapter = new SqlDataAdapter(mysql, myconn);
                    DataSet mydataset = new DataSet();
                    myadapter.Fill(mydataset);
                    MessageBox.Show("您已注册成功");
               /* }
                catch
                { MessageBox.Show("用户已存在，请更换用户名"); }
            }
            else
                MessageBox.Show("两次密码不一致，请重新输入！");*/
        }

        int i = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            if (i % 2 != 0)
            {
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }
            i += 1;   
        }


        int j = 1;
        private void button4_Click(object sender, EventArgs e)
        {
            if (j % 2 != 0)
            {
                textBox5.PasswordChar = '\0';
                textBox6.PasswordChar = '\0';
            }
            else
            {
                textBox5.PasswordChar = '*';
                textBox6.PasswordChar = '*';
            }
            j += 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == textBox6.Text)
            {
                try
                {
                    String mysql = "insert into landlord values( '" + textBox4.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox8.Text.ToString() + "')";
                    SqlDataAdapter myadapter = new SqlDataAdapter(mysql, myconn);
                    DataSet mydataset = new DataSet();
                    myadapter.Fill(mydataset);
                    MessageBox.Show("您已注册成功");
                }
                catch
                { MessageBox.Show("用户已存在，请更换用户名"); }
            }
            else
                MessageBox.Show("两次密码不一致，请重新输入！");
        }
    }
}
