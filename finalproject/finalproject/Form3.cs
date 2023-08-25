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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection myconn = new SqlConnection("Data Source=.;Initial Catalog=workrent;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            if ((A.denglu==false)&&(A.dengluhr==false)&&(A.denglull==false))
            {
                string mysql1 = "select * from users where username='" + textBox1.Text + "' and usermm='" + textBox2.Text + "'";
                SqlCommand mycmd = new SqlCommand(mysql1, myconn);
                SqlDataReader myrd;
                myconn.Open();
                {
                    myrd = mycmd.ExecuteReader();
                    if (myrd.HasRows)
                    {
                        MessageBox.Show("登录成功");
                        A.denglu = true;
                        A.username = textBox1.Text;
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    myconn.Close();
                }
            }
            if ((A.denglu == false) && (A.dengluhr == false) && (A.denglull == false))
              {
                    string mysql2 = "select LID,LPASS from landlord where LID='" + textBox1.Text + "' and LPASS='" + textBox2.Text + "'";
                    SqlCommand mycmd2 = new SqlCommand(mysql2, myconn);
                    SqlDataReader myrd2;
                    myconn.Open();
                    {
                        myrd2 = mycmd2.ExecuteReader();
                        if (myrd2.HasRows)
                        {
                            MessageBox.Show("登录成功");
                            A.denglull = true;
                            A.username = textBox1.Text;
                            DialogResult = DialogResult.OK;
                            this.Close();
                            hchoosing f10 = new hchoosing();
                            f10.Show();
                        }
                    }
                    myconn.Close(); 
              }

            if ((A.denglu == false) && (A.dengluhr == false) && (A.denglull == false))
              {
                            string mysql3 = "select cname,cpass from hr where cname='" + textBox1.Text.Trim() + "' and cpass='" + textBox2.Text.Trim() + "'";
                            SqlCommand mycmd3 = new SqlCommand(mysql3, myconn);
                            SqlDataReader myrd3;
                            myconn.Open();
                            {
                                myrd3 = mycmd3.ExecuteReader();
                                if (myrd3.HasRows)
                                {
                                    MessageBox.Show("登录成功");
                                    A.dengluhr = true;
                                    A.username = textBox1.Text;
                                    DialogResult = DialogResult.OK;
                                    this.Close();
                                    rchoosing f14 = new rchoosing();
                                    f14.Show();
                                }
                                else
                                    MessageBox.Show("登录失败，请检查输入或注册账号");
                            }
                  myconn.Close();
                        }
                    
                
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 f9=new Form9();
            f9.ShowDialog();
        }


    }
}
