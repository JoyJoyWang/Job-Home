using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace finalproject
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        SqlConnection myconn = new SqlConnection("Data Source=.;Initial Catalog=workrent;Integrated Security=True");

        private void Form9_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            button1.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
            textBox8.PasswordChar = '*';
            textBox9.PasswordChar = '*';
            textBox15.PasswordChar = '*';
            textBox16.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "请选择文件夹";
            openFileDialog1.Filter = "所有文件(*.*)|*.*";
            //string file;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            {
                this.pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            button1.Visible = true;
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox5.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            button6.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = true;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            button7.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string year, month, date, nyr;
            year = comboBox2.Text.Trim();
            month = comboBox3.Text.Trim();
            date = comboBox4.Text.Trim();
            nyr = year + '-' + month + '-' + date;


                if (textBox2.Text == textBox3.Text)
                {
                    try
                    {
                        String mysql = "insert users values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + pictureBox1.Image.ToString() + "','" + textBox4.Text.ToString() + "','" + comboBox1.Text.ToString() + "','','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + comboBox5.Text.ToString() + "')";
                        SqlCommand mycmd = new SqlCommand(mysql, myconn);
                        myconn.Open();
                        {
                            mycmd.ExecuteNonQuery();
                        }
                        myconn.Close();

                        MessageBox.Show("您已注册成功");
                        this.Close();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.ToString()); }
                }
                else
                    MessageBox.Show("两次密码不一致，请重新输入！");
            }
           
        
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == textBox9.Text)
            {
               
                    String mysql = "insert into landlord values('" + textBox7.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + textBox10.Text.ToString() + "','" + textBox11.Text.ToString() + "')";
                    SqlDataAdapter myadapter = new SqlDataAdapter(mysql, myconn);
                    DataSet mydataset = new DataSet();
                    myadapter.Fill(mydataset,"nihao");
                    MessageBox.Show("您已注册成功");
                    this.Close();

            }
            else
                MessageBox.Show("两次密码不一致，请重新输入！");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox15.Text == textBox16.Text)
            {
                try
                {
                    String mysql = "insert into hr values('" + textBox14.Text.ToString() + "','" + textBox15.Text.ToString() + "')";
                    SqlDataAdapter myadapter = new SqlDataAdapter(mysql, myconn);
                    DataSet mydataset = new DataSet();
                    myadapter.Fill(mydataset);
                    MessageBox.Show("您已注册成功");
                    this.Close();
                }
                catch
                { MessageBox.Show("用户已存在，请更换用户名"); }
            }
            else
                MessageBox.Show("两次密码不一致，请重新输入！");
        }



    }
}
