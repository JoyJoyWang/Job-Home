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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }
        public static string landl;
        SqlConnection myconn = new SqlConnection("Data Source=.;Initial Catalog=workrent;Integrated Security=True");

        private void Form18_Load(object sender, EventArgs e)
        {
            String mysql = "select distinct(username) from ulmessage where LID= '" + A.username.Trim() + "'";    //选择联系人
            SqlDataAdapter myadapter = new SqlDataAdapter(mysql, myconn);
            DataSet mydataset = new DataSet();
            myadapter.Fill(mydataset);
            listBox1.DataSource = mydataset.Tables[0];
            listBox1.DisplayMember = "username";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            MessageBox.Show(listBox1.SelectedItem.ToString());
            String mysql = "select * from ulmessage where username= '"+listBox1.SelectedItem.ToString().Trim()+"' and LID='" + A.username.Trim()+ "'";
            MessageBox.Show(mysql);
            SqlCommand mycmd = new SqlCommand(mysql, myconn);
            SqlDataReader mydatareader;
            myconn.Open();
            {
                mydatareader = mycmd.ExecuteReader();
                while (mydatareader.Read())
                {
                    if (Convert.ToInt32(mydatareader.GetValue(4)) == 1)
                        textBox1.Text += mydatareader.GetValue(0).ToString() + mydatareader.GetValue(3).ToString() + "\r\n" + mydatareader.GetValue(2).ToString() + "\r\n";
                    else
                        textBox1.Text += mydatareader.GetValue(1).ToString() + mydatareader.GetValue(3).ToString() + "\r\n" + mydatareader.GetValue(2).ToString() + "\r\n";
                }
                mydatareader.Close();
            }
            myconn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String mysql = "insert into ulmessage values( '" + A.username + "','" + listBox1.SelectedItem.ToString() + "','" + textBox2.Text.ToString() + "','" + DateTime.Now.ToString() + "',2)";     //聊天记录入库
            SqlDataAdapter myadapter = new SqlDataAdapter(mysql, myconn);
            DataSet mydataset = new DataSet();
            myadapter.Fill(mydataset);
            textBox1.Text += A.username + "   " + DateTime.Now.ToString() + "\r\n" + textBox2.Text + "\r\n";
            textBox2.Clear();
        }
    }
}
