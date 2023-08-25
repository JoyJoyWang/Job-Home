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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection myconn = new SqlConnection("Data Source=.;Initial Catalog=workrent;Integrated Security=True");
        public static string mysql1 = "select * from information";
        string mysql2 = "select * from users where username ='" + A.username + "'";
        private void Form4_Load(object sender, EventArgs e)
        {
            SqlDataAdapter myadapter = new SqlDataAdapter(mysql2, myconn);
            DataSet mydataset = new DataSet();
            myadapter.Fill(mydataset, "users");
            string mypath = mydataset.Tables["users"].Rows[0].ItemArray[2].ToString();
            pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + mypath);
            textBox1.Text = mydataset.Tables["users"].Rows[0][3].ToString();
            textBox3.Text = mydataset.Tables["users"].Rows[0][7].ToString();
            string tempsex = mydataset.Tables["users"].Rows[0][4].ToString();
            if (tempsex == "男")
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                if (tempsex == "女")
                {
                    comboBox1.SelectedIndex = 1;
                }
                else
                {
                    comboBox1.SelectedIndex = 2;
                }
            }
            comboBox7.SelectedItem = mydataset.Tables["users"].Rows[0][6].ToString();
            textBox3.Text = mydataset.Tables["users"].Rows[0][7].ToString();
            comboBox6.SelectedItem = mydataset.Tables["users"].Rows[0][8].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string realname = textBox1.Text;
            string sex = comboBox1.SelectedItem.ToString();
            string year = comboBox2.SelectedItem.ToString();
            string month = comboBox3.SelectedItem.ToString();
            string date = comboBox4.SelectedItem.ToString();
            string birthday = year + "-" + month + "-" + date;

            SqlCommand mycmd = new SqlCommand("update users set realname='" + realname + "', sex='"+sex+"',birthday='"+birthday+"', university='"+comboBox7.SelectedItem.ToString()+"', gradyear='"+comboBox6.SelectedItem.ToString()+"', major='"+textBox3.Text+"' where username='" + A.username+"'", myconn);
            
            myconn.Open();
            {
                try
                {
                    mycmd.ExecuteNonQuery();
                    MessageBox.Show("修改成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }
            myconn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.ShowDialog();
        }

    }
}
