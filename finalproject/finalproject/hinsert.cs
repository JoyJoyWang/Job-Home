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
using System.Net;

namespace finalproject
{
    public partial class hinsert : Form
    {
        public hinsert()
        {
            InitializeComponent();
        }
        public class Geo
        {
            private string _latitude = "";
            private string _longtitude = "";
            public Geo()
            {
            }
            public Geo(string latitude, string longtitude)
            {
                _latitude = latitude;
                _longtitude = longtitude;
            }
            public Geo(string location)
            {
                string ak = "LXHneKH38eybWgCfzFEFiafsyQGW92mX";//百度开发者平台免费申请的密钥
                string url = string.Format("http://api.map.baidu.com/geocoding/v3/?address={0}&output=json&ak={1}&callback=showLocation", location, ak);
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                        {
                            string[] tmpArray = sr.ReadToEnd().Split(new char[2] { ',', ':' });
                            _latitude = tmpArray[7];//纬度
                            _longtitude = tmpArray[5];//经度
                        }
                    }
                }
                catch (System.Net.Sockets.SocketException ex)
                {
                    Console.WriteLine("网络中断");
                }
                catch (Exception ex)
                {
                    //throw ex;
                    Console.WriteLine("异常类型：{0}", ex.GetType());
                    Console.WriteLine("异常信息：{0}", ex.Message);
                    Console.WriteLine("异常来源：{0}", ex.Source);
                    Console.WriteLine("异常堆栈：{0}", ex.StackTrace);
                    Console.WriteLine("内部异常：{0}", ex.InnerException);
                }
            }
            public string Latitude
            {
                get { return _latitude; }
                set { _latitude = value; }
            }

            public string Longtitude
            {
                get { return _longtitude; }
                set { _longtitude = value; }
            }

            ///Geo position = new Geo("同济大学");
            ///MessageBox.Show("经度：" + position.Longtitude + "；纬度：" + position.Latitude);
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            hchoosing f10 = new hchoosing();
            f10.Show();
            
        }*/

        static string mystr = @"Data Source=.;Initial Catalog=workrent;Integrated Security=True";
        SqlConnection myconn = new SqlConnection(mystr);

        private void button8_Click(object sender, EventArgs e)
        {
            Geo position = new Geo(textBox1.Text);

            //MessageBox.Show("经度：" + position.Longtitude + "；纬度：" + position.Latitude.Substring(0, 17));
            string s2 = A.username.Trim() + DateTime.Now.Year.ToString().Trim() + DateTime.Now.Month.ToString().Trim() + DateTime.Now.Day.ToString().Trim() + DateTime.Now.Minute.ToString().Trim();
            string s1 = "insert into house values('" + A.username.Trim() + DateTime.Now.Year.ToString().Trim() + DateTime.Now.Month.ToString().Trim() + DateTime.Now.Day.ToString().Trim() + DateTime.Now.Minute.ToString().Trim() + "','" + textBox1.Text.Trim() + "'," + position.Longtitude + "," + position.Latitude.Substring(0, 17) + "," + textBox2.Text.Trim() + ",'" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "㎡','" + comboBox4.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "')";
            SqlCommand cmd = new SqlCommand(s1, myconn);
            //MessageBox.Show(s1);
            myconn.Open();
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("成功更新");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            myconn.Close();
            s1 = "insert into owned values('" + s2.Trim() + "','" + A.username.Trim() + "')";
            cmd.CommandText = s1;
            myconn.Open();
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void Form11_FormClosed(object sender, FormClosedEventArgs e)
        {
            //System.Environment.Exit(0);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "无")
                textBox3.Text = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "无")
                textBox4.Text = "";
        }
    }
}
