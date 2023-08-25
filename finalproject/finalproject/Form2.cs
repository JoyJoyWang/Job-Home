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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //定义委托
        public delegate void Save();
        //定义事件
        public event Save OnSave;


        SqlConnection myconn = new SqlConnection("Data Source=.;Initial Catalog=workrent;Integrated Security=True");
        public static string mysql1 = "select * from information";

        private void 赞ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (A.denglu == true)
            {
                string t = this.Text.ToString().Trim();
                string temp = "update information set good=good+1 where title ='"+t+"'";
                SqlCommand mycmd = new SqlCommand(temp, myconn);
                myconn.Open();
                {
                    try
                    {
                        mycmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                myconn.Close();
                赞ToolStripMenuItem.Text = "赞：" + (int.Parse(赞ToolStripMenuItem.Text.Substring(2)) + 1).ToString();
                赞ToolStripMenuItem.Enabled = false;
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (A.denglu == false)
            {
                Form3 f3 = new Form3();
                DialogResult dr = f3.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string mysql2 = "select * from users where username ='" + f3.textBox1.Text + "'";
                    SqlDataAdapter myadapter = new SqlDataAdapter(mysql2, myconn);
                    DataSet mydataset = new DataSet();
                    myadapter.Fill(mydataset, "users");
                    string mypath = mydataset.Tables["users"].Rows[0].ItemArray[2].ToString();
                    pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + mypath);
                    A.denglu = true;
                    A.username = f3.textBox1.Text;
                    
                    pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + mypath);
                    赞ToolStripMenuItem.Enabled = true;
                    赞ToolStripMenuItem.Font=new Font("微软雅黑",12,FontStyle.Bold);

                    string t = this.Text.ToString().Trim();
                    string tempsql = "select count(*) from usermark where username='" + A.username + "' and title='" + t + "'";
                    SqlDataAdapter myadapter2 = new SqlDataAdapter(tempsql, myconn);
                    DataSet markornot = new DataSet();
                    myadapter2.Fill(markornot, "收藏了没");
                    if (markornot.Tables["收藏了没"].Rows[0][0].ToString() == "0")
                    {
                        收藏ToolStripMenuItem.Enabled = true;
                        收藏ToolStripMenuItem.Font = new Font("微软雅黑", 12, FontStyle.Bold);
                    }
                    else
                    {
                        收藏ToolStripMenuItem.Enabled = false;
                        收藏ToolStripMenuItem.Text = "已收藏";
                    }
                    
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (A.denglu == true)
            {
                string mysql2 = "select * from users where username ='" + A.username + "'";
                SqlDataAdapter myadapter = new SqlDataAdapter(mysql2, myconn);
                DataSet mydataset = new DataSet();
                myadapter.Fill(mydataset, "users");
                string mypath = mydataset.Tables["users"].Rows[0].ItemArray[2].ToString();
                pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + mypath);
                赞ToolStripMenuItem.Enabled = true;
                赞ToolStripMenuItem.Font = new Font("微软雅黑", 12, FontStyle.Bold);

                string t = this.Text.ToString().Trim();
                string tempsql = "select count(*) from usermark where username='" + A.username + "' and title='"+t+"'";
                SqlDataAdapter myadapter2 = new SqlDataAdapter(tempsql, myconn);
                DataSet markornot = new DataSet();
                myadapter2.Fill(markornot, "收藏了没");
                if (markornot.Tables["收藏了没"].Rows[0][0].ToString() == "0")
                {
                    收藏ToolStripMenuItem.Enabled = true;
                    收藏ToolStripMenuItem.Font = new Font("微软雅黑", 12, FontStyle.Bold);
                }
                else
                {
                    收藏ToolStripMenuItem.Enabled = false;
                    收藏ToolStripMenuItem.Text = "已收藏";
                }


            }

            }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Close();
            OnSave();//关闭的时候执行事件
        }

        private void 收藏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (A.denglu == true)
            {
                string t = this.Text.ToString().Trim();
                string temp = "insert into usermark values('" + A.username + "','" + t + "') ";
                SqlCommand mycmd = new SqlCommand(temp, myconn);
                myconn.Open();
                {
                    try
                    {
                        mycmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                myconn.Close();
                收藏ToolStripMenuItem.Text = "已收藏";
                赞ToolStripMenuItem.Enabled = false;

            }
        }

        }
    }

