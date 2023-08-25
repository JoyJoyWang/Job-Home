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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        Form5 f5=new Form5();
        public static string landl;
        SqlConnection myconn = new SqlConnection("Data Source=.;Initial Catalog=workrent;Integrated Security=True");

        private void Form7_Load(object sender, EventArgs e)
        {
            landl = f5.label10.Text.Substring(3, f5.label10.Text.Length - 3);
            String mysql = "select * from ulmessage where username= '" + A.username + "' and LID='"+landl.Trim()+"'";
            SqlCommand mycmd = new SqlCommand(mysql, myconn);
            SqlDataReader mydatareader;
            myconn.Open();
            {
                mydatareader = mycmd.ExecuteReader();
                while (mydatareader.Read())
                {
                    if (Convert.ToInt32(mydatareader.GetValue(4))==1)
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
            if (A.denglu == true)
            {

                string sqltem = "select landlord.LID from landlord,owned where landlord.LID=owned.LID and owned.index1='" + A.index + "'";
                SqlDataAdapter adptemp = new SqlDataAdapter(sqltem, myconn);
                DataSet settem = new DataSet();
                adptemp.Fill(settem, "LID表");
                string lid = settem.Tables["LID表"].Rows[0][0].ToString();
                String mysql = "insert into ulmessage values( '" + A.username + "','" + lid + "','" + textBox2.Text.ToString() + "','" + DateTime.Now.ToString() + "',1)";     //聊天记录入库
                SqlDataAdapter myadapter = new SqlDataAdapter(mysql, myconn);
                DataSet mydataset = new DataSet();
                myadapter.Fill(mydataset);
                textBox1.Text += A.username.Trim() + "   " + DateTime.Now.ToString() + "\r\n" + textBox2.Text + "\r\n";
                textBox2.Clear();
            }
            else 
            {
                MessageBox.Show("请登录！");
            }
        }
    }
}
