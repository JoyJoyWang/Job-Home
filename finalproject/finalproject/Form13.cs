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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }
        SqlConnection myconn = new SqlConnection("Data Source=.;Initial Catalog=workrent;Integrated Security=True");
        public static string mysql1 = "select * from information";
        string mysql2 = "select * from landlord where LID ='" + A.username + "'";

        private void Form13_Load(object sender, EventArgs e)
        {
            SqlDataAdapter myadapter = new SqlDataAdapter(mysql2, myconn);
            DataSet mydataset = new DataSet();
            myadapter.Fill(mydataset, "users");
            textBox1.Text = mydataset.Tables["users"].Rows[0][0].ToString();
            textBox2.Text = mydataset.Tables["users"].Rows[0][2].ToString();
            textBox3.Text = mydataset.Tables["users"].Rows[0][3].ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string tel = textBox3.Text;

            SqlCommand mycmd = new SqlCommand("update landlord set name='" + name + "', tel='" +tel + "' where username='" + A.username + "'", myconn);

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

        private void button1_Click(object sender, EventArgs e)
        {
            Form18 f18 = new Form18();
            f18.Show();
        }
    }
}
