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
using System.IO;

namespace finalproject
{
    public partial class rresume : Form
    {
        public rresume()
        {
            InitializeComponent();
        }
        static string mystr = @"Data Source=.;Initial Catalog=workrent;Integrated Security=True";
        SqlConnection con = new SqlConnection(mystr);
        DataSet set = new DataSet();
        static int i = 1;
        static int j = 0;

        private void Form17_Load(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("create view res as select convert(int,(ROW_NUMBER() OVER (ORDER BY convert(binary,resfile) ASC))) AS xuhao,resfile from resume where company ='" +A.username.Trim() + "'", con);
            con.Open();
            {
                try
                {
                    com.ExecuteNonQuery(); //MessageBox.Show("1");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            con.Close();
            SqlDataAdapter myada = new SqlDataAdapter("select count(*) as sum from res", con);
            myada.Fill(set, "s");
            j = (int)set.Tables[0].Rows[0][0];
            byte[] imagebytes = null;
            //打开数据库
            con.Open();
            com.CommandText = "select resfile from res where xuhao =" + i.ToString().Trim();
            //SqlCommand com = new SqlCommand("select resfile from resume where company ='"+hloading.an.Trim()+"'", con);//选到image格式的单元格
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                imagebytes = (byte[])dr.GetValue(0);

            }

            dr.Close();
            com.Clone();
            con.Close();
            MemoryStream ms = new MemoryStream(imagebytes);
            Bitmap bmpt = new Bitmap(ms);
            pictureBox1.Image = bmpt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                MessageBox.Show("已到第一个");
                return;
            }
            i = 1;
            SqlCommand com = new SqlCommand("select resfile from res where xuhao =1", con);
            byte[] imagebytes = null;
            con.Open();
            /*{
                try
                {
                    com.ExecuteNonQuery(); //MessageBox.Show("1");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            con.Close();*/
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                imagebytes = (byte[])dr.GetValue(0);

            }

            dr.Close();
            com.Clone();
            con.Close();
            MemoryStream ms = new MemoryStream(imagebytes);
            Bitmap bmpt = new Bitmap(ms);
            pictureBox1.Image = bmpt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                MessageBox.Show("已经到第一个");
            }
            else
            {
                i = i - 1;
                SqlCommand com = new SqlCommand("select resfile from res where xuhao =" + i.ToString().Trim(), con);
                con.Open();
                /* {
                     try
                     {
                         com.ExecuteNonQuery(); //MessageBox.Show("1");
                     }
                     catch (Exception ex)
                     {
                         MessageBox.Show(ex.ToString());
                     }
                 }
                 con.Close();*/
                byte[] imagebytes = null;
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    imagebytes = (byte[])dr.GetValue(0);

                }
                dr.Close();
                com.Clone();
                con.Close();
                MemoryStream ms = new MemoryStream(imagebytes);
                Bitmap bmpt = new Bitmap(ms);
                pictureBox1.Image = bmpt;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (i == j)
            {
                MessageBox.Show("已经到最后一个");
            }
            else
            {
                i = i + 1;
                SqlCommand com = new SqlCommand("select resfile from res where xuhao =" + i.ToString().Trim(), con);
                con.Open();
                /* {
                     try
                     {
                         com.ExecuteNonQuery(); //MessageBox.Show("1");
                     }
                     catch (Exception ex)
                     {
                         MessageBox.Show(ex.ToString());
                     }
                 }
                 con.Close();*/
                byte[] imagebytes = null;
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    imagebytes = (byte[])dr.GetValue(0);

                }
                dr.Close();
                com.Clone();
                con.Close();
                MemoryStream ms = new MemoryStream(imagebytes);
                Bitmap bmpt = new Bitmap(ms);
                pictureBox1.Image = bmpt;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (i == j)
            {
                MessageBox.Show("已经到最后一个");
                return;
            }
            i = j;
            SqlCommand com = new SqlCommand("select resfile from res where xuhao ="+i.ToString().Trim(), con);
            byte[] imagebytes = null;
            con.Open();
            /*{
                try
                {
                    com.ExecuteNonQuery(); //MessageBox.Show("1");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            con.Close();*/
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                imagebytes = (byte[])dr.GetValue(0);

            }

            dr.Close();
            com.Clone();
            con.Close();
            MemoryStream ms = new MemoryStream(imagebytes);
            Bitmap bmpt = new Bitmap(ms);
            pictureBox1.Image = bmpt;
        }
        

        private void Form17_FormClosed(object sender, FormClosedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("drop view res", con);
            //MessageBox.Show(s1);
            con.Open();
            {
                try
                {
                    cmd.ExecuteNonQuery(); //MessageBox.Show("1");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            con.Close();
           // System.Environment.Exit(0);

        }
    }
}
