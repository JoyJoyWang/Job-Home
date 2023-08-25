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
using System.Net;
using System.Data.SqlClient;

  

namespace finalproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        //定义地理编码的类
        SqlConnection myconn=new SqlConnection("Data Source=.;Initial Catalog=workrent;Integrated Security=True");
        public static string mysql1 = "select * from information order by good DESC";
        public static string sqlchazhufang;
        public static string sqlchagongzuo;
        public static string landl;



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

        }


        private void 找工作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            A.huodong = "gongzuo";
            找工作ToolStripMenuItem.ForeColor =Color.Black;
            找工作ToolStripMenuItem.Font = new Font("微软雅黑", 12, FontStyle.Bold);
            推荐ToolStripMenuItem.ForeColor = Color.Gray;
            找住房ToolStripMenuItem.ForeColor = Color.Gray;

            listBox1.Visible = false;
            //找住房
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            hScrollBar1.Visible = false;
            hScrollBar2.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            checkBox5.Visible = false;
            checkBox6.Visible = false;
            checkBox7.Visible = false;
            checkBox15.Visible = false;
            checkBox16.Visible = false;
            button5.Visible = false;
            //找工作

            label12.Visible = true;
            label13.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            checkBox8.Visible = true;
            checkBox9.Visible = true;
            checkBox10.Visible = true;
            checkBox17.Visible = true;
            checkBox18.Visible = true;
            checkBox19.Visible = true;
            checkBox20.Visible = true;
            checkBox21.Visible = true;
            checkBox22.Visible = true;
            button6.Visible = true;



        }

        private void 找住房ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            A.huodong = "zhufang";
            找工作ToolStripMenuItem.ForeColor = Color.Gray;
            推荐ToolStripMenuItem.ForeColor = Color.Gray;
            找住房ToolStripMenuItem.ForeColor = Color.Black;
            找住房ToolStripMenuItem.Font = new Font("微软雅黑", 12, FontStyle.Bold);
            listBox1.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            hScrollBar1.Visible = true;
            hScrollBar2.Visible = true;
            checkBox1.Visible = true;
            checkBox2.Visible = true;
            checkBox3.Visible = true;
            checkBox4.Visible = true;
            checkBox5.Visible = true;
            checkBox6.Visible = true;
            checkBox7.Visible = true;
            checkBox8.Visible = true;
            checkBox9.Visible = true;
            checkBox10.Visible = true;
            checkBox15.Visible = true;
            checkBox16.Visible = true;
            button5.Visible = true;

            //找工作
            label12.Visible = false;
            label13.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            checkBox8.Visible = false;
            checkBox9.Visible = false;
            checkBox10.Visible = false;
            checkBox17.Visible = false;
            checkBox18.Visible = false;
            checkBox19.Visible = false;
            checkBox20.Visible = false;
            checkBox21.Visible = false;
            checkBox22.Visible = false;
            button6.Visible = false;


            hScrollBar1.Value = 0;
            hScrollBar2.Value = 10000;

        }

        private void 推荐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            A.huodong = "xinxi";
            找工作ToolStripMenuItem.ForeColor = Color.Gray;
            推荐ToolStripMenuItem.ForeColor = Color.Black;
            推荐ToolStripMenuItem.Font = new Font("微软雅黑", 12, FontStyle.Bold);
            找住房ToolStripMenuItem.ForeColor = Color.Gray;
            
            SqlDataAdapter myadapter = new SqlDataAdapter(mysql1, myconn);
            DataSet mydataset = new DataSet();
            myadapter.Fill(mydataset, "information");
            listBox1.Items.Clear();
            for (int i = 1; i <= mydataset.Tables["information"].Rows.Count; i++)
            {
                string ke = i.ToString() + "  " + mydataset.Tables["information"].Rows[i - 1].ItemArray[0].ToString() + "\n" + "       " + mydataset.Tables["information"].Rows[i - 1].ItemArray[1].ToString().Substring(0, 30).Replace("\n", "") + "……" + "\n" + "\n 赞：" + mydataset.Tables["information"].Rows[i - 1].ItemArray[3].ToString();
                listBox1.Items.Add(ke);
            }
            listBox1.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            hScrollBar1.Visible = false;
            hScrollBar2.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            checkBox5.Visible = false;
            checkBox6.Visible = false;
            checkBox7.Visible = false;
            checkBox15.Visible = false;
            checkBox16.Visible = false;
            button5.Visible = false;

            //找工作
            label12.Visible = false;
            label13.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            checkBox8.Visible = false;
            checkBox9.Visible = false;
            checkBox10.Visible = false;
            checkBox17.Visible = false;
            checkBox18.Visible = false;
            checkBox19.Visible = false;
            checkBox20.Visible = false;
            checkBox21.Visible = false;
            checkBox22.Visible = false;
            button6.Visible = false;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(e.BackColor), e.Bounds);
            if (e.Index % 2 == 0)
            {
                StringFormat sStringFormat = new StringFormat();
                sStringFormat.LineAlignment = StringAlignment.Center;
                e.Graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), e.Bounds);
                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, sStringFormat);

            }
            else
            {
                StringFormat sStringFormat = new StringFormat();
                sStringFormat.LineAlignment = StringAlignment.Center;
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, sStringFormat);

            }
　　e.DrawFocusRectangle();

        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = e.ItemHeight + 100;
        }

        void f2_OnSave()
        {
            if (A.denglu == true)
            {
                string mysql2 = "select * from users where username ='" + A.username + "'";
                SqlDataAdapter myadapter = new SqlDataAdapter(mysql2, myconn);
                DataSet mydataset = new DataSet();
                myadapter.Fill(mydataset, "users");
                string mypath = mydataset.Tables["users"].Rows[0].ItemArray[2].ToString();
                pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + mypath);
                //头像更新

                SqlDataAdapter myadapter2 = new SqlDataAdapter("select * from information order by good DESC", myconn);
                DataSet mydataset2 = new DataSet();
                myadapter2.Fill(mydataset2, "information");
                listBox1.Items.Clear();
                for (int i = 1; i <= mydataset2.Tables["information"].Rows.Count; i++)
                {
                    string ke = i.ToString() + "  " + mydataset2.Tables["information"].Rows[i - 1].ItemArray[0].ToString() + "\n" + "       " + mydataset2.Tables["information"].Rows[i - 1].ItemArray[1].ToString().Substring(0, 30).Replace("\n", "") + "……" + "\n" + "\n 赞：" + mydataset2.Tables["information"].Rows[i - 1].ItemArray[3].ToString();
                    listBox1.Items.Add(ke);
                }
                //赞数更新，高赞在前
            }
            else
            {
                pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\people.png");
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;

            //找住房
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            hScrollBar1.Visible = false;
            hScrollBar2.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            checkBox5.Visible = false;
            checkBox6.Visible = false;
            checkBox7.Visible = false;
            checkBox15.Visible = false;
            checkBox16.Visible = false;
            button5.Visible = false;

            //找工作
            label12.Visible = false;
            label13.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            checkBox8.Visible = false;
            checkBox9.Visible = false;
            checkBox10.Visible = false;
            checkBox17.Visible = false;
            checkBox18.Visible = false;
            checkBox19.Visible = false;
            checkBox20.Visible = false;
            checkBox21.Visible = false;
            checkBox22.Visible = false;
            button6.Visible = false;

            
       //     Geo position = new Geo("同济大学");
       //     MessageBox.Show("经度：" + position.Longtitude + "；纬度：" + position.Latitude);
            SqlDataAdapter myadapter = new SqlDataAdapter(mysql1, myconn);
            DataSet mydataset = new DataSet();
            myadapter.Fill(mydataset, "information");

            for (int i = 1; i <= mydataset.Tables["information"].Rows.Count; i++) 
            {
                string ke = i.ToString() + "  " + mydataset.Tables["information"].Rows[i - 1].ItemArray[0].ToString() + "\n" + "       " + mydataset.Tables["information"].Rows[i - 1].ItemArray[1].ToString().Substring(0, 30).Replace("\n", "") + "……" + "\n" + "\n 赞：" + mydataset.Tables["information"].Rows[i - 1].ItemArray[3].ToString();
            listBox1.Items.Add(ke);
            }

        }

        //列表
        //private void listBox1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (A.huodong == "xinxi")
        //    {
        //        SqlDataAdapter myadapter = new SqlDataAdapter(mysql1, myconn);
        //        DataSet mydataset = new DataSet();
        //        myadapter.Fill(mydataset, "information");
        //        for (int i = 0; i < mydataset.Tables["information"].Rows.Count; i++)
        //        {
        //            if (listBox1.SelectedIndex == i)
        //            {
        //                Form2 f2 = new Form2();
        //                f2.OnSave += new Form2.Save(f2_OnSave);//定阅这个事件
        //                //DialogResult=f2.ShowDialog();

        //                //f2.richTextBox1.Clear();
        //                string st = "\n" + "    " + mydataset.Tables["information"].Rows[i].ItemArray[0].ToString();
        //                f2.richTextBox1.Text = st;
        //                f2.Text = st;
        //                f2.richTextBox1.Text += "\n\n" + mydataset.Tables["information"].Rows[i].ItemArray[1].ToString();
        //                f2.作者ToolStripMenuItem.Text = "作者：" + mydataset.Tables["information"].Rows[i].ItemArray[2].ToString();
        //                f2.赞ToolStripMenuItem.Text = "赞：" + mydataset.Tables["information"].Rows[i].ItemArray[3].ToString();
        //                f2.richTextBox1.Select(0, st.Length);
        //                f2.richTextBox1.SelectionFont = new Font("微软雅黑", 16, FontStyle.Bold);
        //                f2.richTextBox1.Select(0, 0);
        //                f2.Show();

        //            }
        //        }
        //    }

        //    if (A.huodong == "zhufang")
        //    {
        //        string st=listBox1.SelectedItem.ToString();
        //        string[] starray =st.Split('：');
        //        string index=starray.Last();
        //        MessageBox.Show(index);
        //        SqlDataAdapter zhufangadp = new SqlDataAdapter("select house.index1,house.name,x,y,house.prise,户型,面积,有无精装修,有无电梯,有无车位,有无燃气,landlord.name,landlord.tel from house,owned,landlord where house.index1='" + index.Trim() + "' and house.index1=owned.index1 and owned.LID=landlord.LID",myconn);
        //        DataSet zhufangi = new DataSet();
        //        zhufangadp.Fill(zhufangi,"房源详情");
        //        Form5 f5 = new Form5();
        //        f5.label3.Text += zhufangi.Tables["房源详情"].Rows[0][1].ToString();
        //        f5.label2.Text += zhufangi.Tables["房源详情"].Rows[0][4].ToString();
        //        f5.label4.Text += zhufangi.Tables["房源详情"].Rows[0][5].ToString();
        //        f5.label5.Text += zhufangi.Tables["房源详情"].Rows[0][6].ToString();
        //        f5.label6.Text += zhufangi.Tables["房源详情"].Rows[0][7].ToString();
        //        f5.label7.Text += zhufangi.Tables["房源详情"].Rows[0][8].ToString();
        //        f5.label8.Text += zhufangi.Tables["房源详情"].Rows[0][10].ToString();
        //        f5.label9.Text += zhufangi.Tables["房源详情"].Rows[0][9].ToString();
        //        f5.label10.Text += zhufangi.Tables["房源详情"].Rows[0][11].ToString();
        //        f5.label12.Text = zhufangi.Tables["房源详情"].Rows[0][12].ToString();
        //        string lat = zhufangi.Tables["房源详情"].Rows[0][3].ToString();
        //        string lon = zhufangi.Tables["房源详情"].Rows[0][2].ToString();
        //        f5.webBrowser1.Navigate("http://api.map.baidu.com/marker?location="+lat+","+lon+"&title=该房源位置&content=&output=html&src=webapp.baidu.openAPIdemo");
        //        f5.Show();

        //    }

        //    if (A.huodong == "gongzuo")
        //    {
        //        string st = listBox1.SelectedItem.ToString();
        //        string[] starray = st.Split('\n',' ');
        //        string gongsi = starray.Last();
        //        string job = starray.First();
        //        MessageBox.Show(gongsi+job);
        //        SqlDataAdapter gongzuoadp = new SqlDataAdapter("select job,salary,region,workexp,edu,welfare,detail,place,company from work where job='" + job.Trim() + "' and company='"+gongsi.Trim()+"'", myconn);
        //        DataSet gongzuoi = new DataSet();
        //        gongzuoadp.Fill(gongzuoi, "工作详情");
        //        Form6 f6 = new Form6();
        //        if(gongzuoi.Tables["工作详情"].Rows[0][0].ToString()!="")
        //        {
        //        f6.label3.Text += gongzuoi.Tables["工作详情"].Rows[0][0].ToString();
        //        }
        //        if (gongzuoi.Tables["工作详情"].Rows[0][8].ToString()!= "")
        //        {
        //            f6.label2.Text += gongzuoi.Tables["工作详情"].Rows[0][8].ToString();
        //        }
        //        if (gongzuoi.Tables["工作详情"].Rows[0][2].ToString()!= "")
        //        {
        //            f6.label10.Text += gongzuoi.Tables["工作详情"].Rows[0][2].ToString();
        //        }
        //        if (gongzuoi.Tables["工作详情"].Rows[0][7].ToString()!= "")
        //        {
        //            f6.label4.Text += gongzuoi.Tables["工作详情"].Rows[0][7].ToString();
        //        }
        //        if (gongzuoi.Tables["工作详情"].Rows[0][3].ToString()!= "")
        //        {
        //            f6.label6.Text += gongzuoi.Tables["工作详情"].Rows[0][3].ToString();
        //        }
        //        if (gongzuoi.Tables["工作详情"].Rows[0][4].ToString()!="")
        //        f6.label7.Text += gongzuoi.Tables["工作详情"].Rows[0][4].ToString();
        //        if (gongzuoi.Tables["工作详情"].Rows[0][1].ToString()!= "")
        //        f6.label5.Text += gongzuoi.Tables["工作详情"].Rows[0][1].ToString();
        //        if (gongzuoi.Tables["工作详情"].Rows[0][5].ToString()!= "")
        //        f6.label9.Text += gongzuoi.Tables["工作详情"].Rows[0][5].ToString();
        //        if (gongzuoi.Tables["工作详情"].Rows[0][6].ToString()!= "")
        //        f6.textBox1.Text = gongzuoi.Tables["工作详情"].Rows[0][6].ToString();

        //        string place = gongzuoi.Tables["工作详情"].Rows[0][7].ToString();
        //        Geo position = new Geo(place);
        //        if ((position.Longtitude.ToString() != "")&&(position.Latitude.ToString()!=""))
        //        {
        //            MessageBox.Show(position.Longtitude + "下一个" + position.Latitude);
        //            MessageBox.Show(position.Longtitude.ToString() + "   " + position.Latitude.ToString());
        //            string lon = position.Longtitude.ToString().Substring(0, 6);
        //            string lat = position.Latitude.ToString().Substring(0, 5);
        //            float ilon = float.Parse(lon);
        //            float ilat = float.Parse(lat);


        //            string job_house = "select * from house where (x-0.01)<" + ilon + " and (x+0.01)>" + ilon + " and (y-0.01)<" + ilat + " and (y+0.01)>" + ilat;
        //            SqlDataAdapter adapter1 = new SqlDataAdapter(job_house, myconn);
        //            DataSet dataset1 = new DataSet();
        //            adapter1.Fill(dataset1, "工作to住房");
        //            f6.listBox1.Items.Clear();
        //            for (int i = 1; i <= dataset1.Tables["工作to住房"].Rows.Count; i++)
        //            {

        //                string ke = i.ToString() + "  " + dataset1.Tables["工作to住房"].Rows[i - 1].ItemArray[1].ToString() + "\n" + "       " + dataset1.Tables["工作to住房"].Rows[i - 1].ItemArray[5].ToString() + "       编号：" + dataset1.Tables["工作to住房"].Rows[i - 1].ItemArray[0].ToString();
        //                f6.listBox1.Items.Add(ke);
        //                f6.listBox1.ForeColor = new Color();
        //            }
        //        }
                
        //        f6.Show();



        //    }

        //}
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(A.denglu == false)
            {
            Form3 f3 = new Form3();
            DialogResult dr=f3.ShowDialog();
            if ((dr == DialogResult.OK)&&(A.denglu == true))
            {
                string mysql2 = "select * from users where username ='" + A.username + "'";
                SqlDataAdapter myadapter = new SqlDataAdapter(mysql2, myconn);
                DataSet mydataset = new DataSet();
                myadapter.Fill(mydataset, "users");
                string mypath = mydataset.Tables["users"].Rows[0].ItemArray[2].ToString();
                pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + mypath);
                A.denglu = true;

            }
            }
            else
            {
                //string mysql2 = "select * from users where username ='" + A.username + "'";
                //SqlDataAdapter myadapter = new SqlDataAdapter(mysql2, myconn);
                //DataSet mydataset = new DataSet();
                //myadapter.Fill(mydataset, "users");
                //string mypath = mydataset.Tables["users"].Rows[0].ItemArray[2].ToString();
                //pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + mypath);
                if (button1.Visible == false)
                {
                    button1.Visible = true;
                    button2.Visible = true;
                    button4.Visible = true;
                }
                else
                {
                    button1.Visible = false;
                    button2.Visible = false;
                    button4.Visible = false;
                }
            }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            Form4 f4 =new Form4();
            f4.Show();

        }

        //搜索
        private void button3_Click(object sender, EventArgs e)
        {
            if (A.huodong=="xinxi" || A.huodong== "")
            {
            string str = textBox1.Text;
            SqlDataAdapter myadapter2 = new SqlDataAdapter("select * from information where title like '%"+str+"%' order by good DESC", myconn);
            DataSet mydataset2 = new DataSet();
            myadapter2.Fill(mydataset2, "information");
            listBox1.Items.Clear();
            for (int i = 1; i <= mydataset2.Tables["information"].Rows.Count; i++)
            {
                string ke = i.ToString() + "  " + mydataset2.Tables["information"].Rows[i - 1].ItemArray[0].ToString() + "\n" + "       " + mydataset2.Tables["information"].Rows[i - 1].ItemArray[1].ToString().Substring(0, 30).Replace("\n", "") + "……" + "\n" + "\n 赞：" + mydataset2.Tables["information"].Rows[i - 1].ItemArray[3].ToString();
                listBox1.Items.Add(ke);
            }
            textBox1.Text = "";
            }
            if (A.huodong == "zhufang")
            {
                string str = textBox1.Text;
                SqlDataAdapter myadapter2 = new SqlDataAdapter("select * from ViewA2 where name like '%" + str + "%'", myconn);
                DataSet mydataset2 = new DataSet();
                myadapter2.Fill(mydataset2, "zhufang");
                listBox1.Items.Clear();
                for (int i = 1; i <= mydataset2.Tables["zhufang"].Rows.Count; i++)
                {
                    string ke = i.ToString() + "  " + mydataset2.Tables["zhufang"].Rows[i - 1].ItemArray[1].ToString() + "\n" + "       " + mydataset2.Tables["zhufang"].Rows[i - 1].ItemArray[5].ToString() + "       编号：" + mydataset2.Tables["zhufang"].Rows[i - 1].ItemArray[0].ToString();
                    listBox1.Items.Add(ke);
                }
                textBox1.Text = "";
            }
            if (A.huodong == "gongzuo")
            {
                string str = textBox1.Text;
                SqlDataAdapter myadapter2 = new SqlDataAdapter("select * from B where job like '%" + str + "%' or company like  '%" + str + "%' ", myconn);
                DataSet mydataset2 = new DataSet();
                myadapter2.Fill(mydataset2, "gongzuo");
                listBox1.Items.Clear();
                for (int i = 1; i <= mydataset2.Tables["gongzuo"].Rows.Count; i++)
                {
                    string ke = i.ToString() + "  " + mydataset2.Tables["gongzuo"].Rows[i - 1].ItemArray[0].ToString() + "\n" + "       " + mydataset2.Tables["gongzuo"].Rows[i - 1].ItemArray[9].ToString();
                    listBox1.Items.Add(ke);
                }
                textBox1.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            A.denglu = false;
            A.username = "";
            f2_OnSave();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("该功能尚未开发，敬请等待");
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            hScrollBar1.Maximum = hScrollBar2.Value;
            label5.Text = hScrollBar1.Value.ToString() + "元";
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            hScrollBar2.Minimum = hScrollBar1.Value;
            label7.Text = hScrollBar2.Value.ToString() + "元";
        }


        //点确定查询住房
        private void button5_Click(object sender, EventArgs e)
        { 
            if ((checkBox1.Checked == false) && (checkBox2.Checked == false) && (checkBox15.Checked == false) && (checkBox16.Checked == false))
            {
                MessageBox.Show("每题请至少勾选一项");
            }

            else
            {
                string sqldel = "IF EXISTS (select table_name from INFORMATION_SCHEMA.VIEWS where table_name = 'ViewA' ) drop view ViewA IF EXISTS (select table_name from INFORMATION_SCHEMA.VIEWS where table_name = 'ViewA2' ) drop view ViewA2 ";
                SqlCommand mycmddel = new SqlCommand(sqldel, myconn);
                myconn.Open();
                {
                    mycmddel.ExecuteNonQuery();
                }
                myconn.Close();
                listBox1.Visible = true;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                hScrollBar1.Visible = false;
                hScrollBar2.Visible = false;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
                checkBox7.Visible = false;
                checkBox15.Visible = false;
                checkBox16.Visible = false;
                button5.Visible = false;

                string sql2 = "CREATE VIEW ViewA AS select * from house ";
                if (checkBox15.Checked == true)
                {
                    sql2 += "where house.户型 ='1室0厅1卫' ";
                    if (checkBox1.Checked == true)
                    {
                        sql2 += "or house.户型='1室1厅1卫' ";
                    }
                    if (checkBox2.Checked == true)
                    {
                        sql2 += " or house.户型='2室1厅1卫' ";
                    }
                    if (checkBox16.Checked == true)
                    {
                        sql2 += "union select * from house where house.户型 not in ('1室1厅1卫','2室1厅1位','1室0厅1卫')  ";
                    }
                }
                else
                {
                    if (checkBox1.Checked == true)
                    {
                        sql2 += "where house.户型='1室1厅1卫' ";
                        if (checkBox2.Checked == true)
                        {
                            sql2 += " or house.户型='2室1厅1卫' ";
                        }
                        if (checkBox16.Checked == true)
                        {
                            sql2 += "union select * from house where house.户型 not in ('1室1厅1卫','2室1厅1位','1室0厅1卫')  ";
                        }
                    }
                    else
                    {
                        if (checkBox2.Checked == true)
                        {
                            sql2 += "where house.户型='2室1厅1卫' ";
                            if (checkBox16.Checked == true)
                            {
                                sql2 += "union select * from house where house.户型 not in ('1室1厅1卫','2室1厅1位','1室0厅1卫')  ";
                            }
                        }
                        else
                        {
                            if (checkBox16.Checked == true)
                            {
                                sql2 += "where house.户型 not in ('1室1厅1卫','2室1厅1位','1室0厅1卫')  ";
                            }
                        }
                    }
                }
                if ((checkBox4.Checked == true) && (checkBox3.Checked == false))
                {
                    sql2 += "and house.有无精装修='精装修' ";
                }
                if ((checkBox4.Checked == false) && (checkBox3.Checked == true))
                {
                    sql2 += "and house.有无精装修 is null ";
                }
                if (checkBox5.Checked == true)
                {
                    sql2 += "and house.有无电梯 ='有' ";
                }
                if (checkBox6.Checked == true)
                {
                    sql2 += " and house.有无燃气 ='有' ";
                }
                if (checkBox7.Checked == true)
                {
                    sql2 += "and house.有无车位 like '%用%' ";
                }
                SqlCommand tempcmd = new SqlCommand(sql2, myconn);
                myconn.Open();
                {
                    tempcmd.ExecuteNonQuery();
                }
                myconn.Close();


                int pricemin = hScrollBar1.Value;
                int pricemax = hScrollBar2.Value;

                string sql3 = "CREATE VIEW ViewA2 AS select * from ViewA where ViewA.prise<" + pricemax + " and prise>" + pricemin + " ";
                SqlCommand sqltemp = new SqlCommand(sql3, myconn);
                myconn.Open();
                {
                    sqltemp.ExecuteNonQuery();
                }
                myconn.Close();


                sqlchazhufang = "select * from ViewA2";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sqlchazhufang, myconn);
                DataSet dataset1 = new DataSet();
                adapter1.Fill(dataset1, "查住房");
                listBox1.Items.Clear();
                for (int i = 1; i <= dataset1.Tables["查住房"].Rows.Count; i++)
                {
                    string ke = i.ToString() + "  " + dataset1.Tables["查住房"].Rows[i - 1].ItemArray[1].ToString() + "\n" + "       " + dataset1.Tables["查住房"].Rows[i - 1].ItemArray[5].ToString() + "       编号：" + dataset1.Tables["查住房"].Rows[i - 1].ItemArray[0].ToString();
                    listBox1.Items.Add(ke);
                }
                listBox1.Visible = true;

            }
        }


        //点确定查询工作
        private void button6_Click(object sender, EventArgs e)
        {
            if (((checkBox8.Checked == false) && (checkBox9.Checked == false) && (checkBox10.Checked == false))||((checkBox17.Checked == false) && (checkBox18.Checked == false) && (checkBox19.Checked == false))||((checkBox20.Checked == false) && (checkBox21.Checked == false) && (checkBox22.Checked == false)))
            {
                MessageBox.Show("每题请至少勾选一项");
            }
            else
            {
                string sqldel = "IF EXISTS (select table_name from INFORMATION_SCHEMA.VIEWS where table_name = 'B' ) drop view B";
                SqlCommand mycmddel = new SqlCommand(sqldel, myconn);
                myconn.Open();
                {
                    mycmddel.ExecuteNonQuery();
                }
                myconn.Close();

                label12.Visible = false;
                label13.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                checkBox8.Visible = false;
                checkBox9.Visible = false;
                checkBox10.Visible = false;
                checkBox17.Visible = false;
                checkBox18.Visible = false;
                checkBox19.Visible = false;
                checkBox20.Visible = false;
                checkBox21.Visible = false;
                checkBox22.Visible = false;
                button6.Visible = false;
                string sql1 = "CREATE VIEW B AS select * from work ";
                if (checkBox8.Checked == true)
                {
                    sql1 += "where work.edu='中专' ";
                    if (checkBox9.Checked == true)
                    {
                        sql1 += "or work.edu ='大专' ";
                    }
                    if (checkBox10.Checked == true)
                    {
                        sql1 += "or work.edu ='本科' ";
                    }
                }
                else
                {
                    if (checkBox9.Checked == true)
                    {
                        sql1 += "where work.edu ='大专' ";
                        if (checkBox10.Checked == true)
                        {
                            sql1 += "or work.edu ='本科' ";
                        }
                    }
                    else
                    {
                        if (checkBox10.Checked == true)
                        {
                            sql1 += "where work.edu ='本科' ";
                        }
                    }
                }


                if (checkBox17.Checked == true)
                {
                    sql1 += " and work.workexp='无需经验' ";
                    if (checkBox18.Checked == true)
                    {
                        sql1 += "or work.workexp='1年经验' ";
                    }
                    if (checkBox19.Checked == true)
                    {
                        sql1 += "or work.workexp='2年经验' or '3-4年经验' or  '5-7年经验' ";
                    }
                }
                else
                {
                    if (checkBox18.Checked == true)
                    {
                        sql1 += "and work.workexp='1年经验' ";
                        if (checkBox19.Checked == true)
                        {
                            sql1 += "or work.workexp='2年经验' or '3-4年经验' or  '5-7年经验' ";
                        }
                    }
                    else
                    {
                        if (checkBox19.Checked == true)
                        {
                            sql1 += "and work.workexp='2年经验' or '3-4年经验' or  '5-7年经验' ";
                        }
                    }
                }

                if (checkBox20.Checked == true)
                {
                    sql1 += "and work.welfare like '%五险一金%' ";
                    if (checkBox21.Checked == true)
                    {
                        sql1 += "or work.welfare like '%做五休二%' ";
                    }
                    if (checkBox22.Checked == true)
                    {
                        sql1 += "or work.welfare like '%带薪年假%' ";
                    }
                }
                else
                {
                    if (checkBox21.Checked == true)
                    {
                        sql1 += "and work.welfare like '%做五休二%' ";
                        if (checkBox22.Checked == true)
                        {
                            sql1 += "or work.welfare like '%带薪年假%' ";
                        }
                    }
                    else
                    {
                        if (checkBox22.Checked == true)
                        {
                            sql1 += "and work.welfare like '%带薪年假%' ";
                        }
                    }

                }
                //MessageBox.Show(sql1);
                SqlCommand tempcmd = new SqlCommand(sql1, myconn);
                myconn.Open();
                {
                    tempcmd.ExecuteNonQuery();
                }
                myconn.Close();

                sqlchagongzuo = "select * from B";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sqlchagongzuo, myconn);
                DataSet dataset1 = new DataSet();
                adapter1.Fill(dataset1, "查工作");
                listBox1.Items.Clear();
                for (int i = 1; i <= dataset1.Tables["查工作"].Rows.Count; i++)
                {
                    string ke = dataset1.Tables["查工作"].Rows[i - 1].ItemArray[0].ToString() + "\n" + "       " + dataset1.Tables["查工作"].Rows[i - 1].ItemArray[9].ToString();
                    listBox1.Items.Add(ke);
                }
                listBox1.Visible = true;
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (A.huodong == "xinxi")
            {
                SqlDataAdapter myadapter = new SqlDataAdapter(mysql1, myconn);
                DataSet mydataset = new DataSet();
                myadapter.Fill(mydataset, "information");
                for (int i = 0; i < mydataset.Tables["information"].Rows.Count; i++)
                {
                    if (listBox1.SelectedIndex == i)
                    {
                        Form2 f2 = new Form2();
                        f2.OnSave += new Form2.Save(f2_OnSave);//定阅这个事件
                        //DialogResult=f2.ShowDialog();

                        //f2.richTextBox1.Clear();
                        string st = "\n" + "    " + mydataset.Tables["information"].Rows[i].ItemArray[0].ToString();
                        f2.richTextBox1.Text = st;
                        f2.Text = st;
                        f2.richTextBox1.Text += "\n\n" + mydataset.Tables["information"].Rows[i].ItemArray[1].ToString();
                        f2.作者ToolStripMenuItem.Text = "作者：" + mydataset.Tables["information"].Rows[i].ItemArray[2].ToString();
                        f2.赞ToolStripMenuItem.Text = "赞：" + mydataset.Tables["information"].Rows[i].ItemArray[3].ToString();
                        f2.richTextBox1.Select(0, st.Length);
                        f2.richTextBox1.SelectionFont = new Font("微软雅黑", 16, FontStyle.Bold);
                        f2.richTextBox1.Select(0, 0);
                        f2.Show();

                    }
                }
            }

            if (A.huodong == "zhufang")
            {
                string st = listBox1.SelectedItem.ToString();
                string[] starray = st.Split('：');
                A.index = starray.Last();
                SqlDataAdapter zhufangadp = new SqlDataAdapter("select house.index1,house.name,x,y,house.prise,户型,面积,有无精装修,有无电梯,有无车位,有无燃气,landlord.name,landlord.tel from house,owned,landlord where house.index1='" + A.index.Trim() + "' and house.index1=owned.index1 and owned.LID=landlord.LID", myconn);
                DataSet zhufangi = new DataSet();
                zhufangadp.Fill(zhufangi, "房源详情");
                Form5 f5 = new Form5();
                f5.label3.Text += zhufangi.Tables["房源详情"].Rows[0][1].ToString();
                f5.label2.Text += zhufangi.Tables["房源详情"].Rows[0][4].ToString();
                f5.label4.Text += zhufangi.Tables["房源详情"].Rows[0][5].ToString();
                f5.label5.Text += zhufangi.Tables["房源详情"].Rows[0][6].ToString();
                f5.label6.Text += zhufangi.Tables["房源详情"].Rows[0][7].ToString();
                f5.label7.Text += zhufangi.Tables["房源详情"].Rows[0][8].ToString();
                f5.label8.Text += zhufangi.Tables["房源详情"].Rows[0][10].ToString();
                f5.label9.Text += zhufangi.Tables["房源详情"].Rows[0][9].ToString();
                f5.label10.Text += zhufangi.Tables["房源详情"].Rows[0][11].ToString();
                f5.label12.Text = zhufangi.Tables["房源详情"].Rows[0][12].ToString();
                string landl = zhufangi.Tables["房源详情"].Rows[0][11].ToString();
                string lat = zhufangi.Tables["房源详情"].Rows[0][3].ToString();
                string lon = zhufangi.Tables["房源详情"].Rows[0][2].ToString();
                f5.webBrowser1.Navigate("http://api.map.baidu.com/marker?location=" + lat + "," + lon + "&title=该房源位置&content=&output=html&src=webapp.baidu.openAPIdemo");
                f5.Show();

            }

            if (A.huodong == "gongzuo")
            {
                string st = listBox1.SelectedItem.ToString();
                string[] starray = st.Split('\n', ' ');
                string gongsi = starray.Last();
                string job = starray.First();
                SqlDataAdapter gongzuoadp = new SqlDataAdapter("select job,salary,region,workexp,edu,welfare,detail,place,company from work where job='" + job.Trim() + "' and company='" + gongsi.Trim() + "'", myconn);
                DataSet gongzuoi = new DataSet();
                gongzuoadp.Fill(gongzuoi, "工作详情");
                Form6 f6 = new Form6();
                if (gongzuoi.Tables["工作详情"].Rows[0][0].ToString() != "")
                {
                    f6.label3.Text += gongzuoi.Tables["工作详情"].Rows[0][0].ToString();
                }
                if (gongzuoi.Tables["工作详情"].Rows[0][8].ToString() != "")
                {
                    f6.label2.Text += gongzuoi.Tables["工作详情"].Rows[0][8].ToString();
                }
                if (gongzuoi.Tables["工作详情"].Rows[0][2].ToString() != "")
                {
                    f6.label10.Text += gongzuoi.Tables["工作详情"].Rows[0][2].ToString();
                }
                if (gongzuoi.Tables["工作详情"].Rows[0][7].ToString() != "")
                {
                    f6.label4.Text += gongzuoi.Tables["工作详情"].Rows[0][7].ToString();
                }
                if (gongzuoi.Tables["工作详情"].Rows[0][3].ToString() != "")
                {
                    f6.label6.Text += gongzuoi.Tables["工作详情"].Rows[0][3].ToString();
                }
                if (gongzuoi.Tables["工作详情"].Rows[0][4].ToString() != "")
                    f6.label7.Text += gongzuoi.Tables["工作详情"].Rows[0][4].ToString();
                if (gongzuoi.Tables["工作详情"].Rows[0][1].ToString() != "")
                    f6.label5.Text += gongzuoi.Tables["工作详情"].Rows[0][1].ToString();
                if (gongzuoi.Tables["工作详情"].Rows[0][5].ToString() != "")
                    f6.label9.Text += gongzuoi.Tables["工作详情"].Rows[0][5].ToString();
                if (gongzuoi.Tables["工作详情"].Rows[0][6].ToString() != "")
                    f6.textBox1.Text = gongzuoi.Tables["工作详情"].Rows[0][6].ToString();

                string place = gongzuoi.Tables["工作详情"].Rows[0][7].ToString();
                Geo position = new Geo(place);
                if ((position.Longtitude.ToString() != "") && (position.Latitude.ToString() != ""))
                {
                    string lon = position.Longtitude.ToString().Substring(0, 6);
                    string lat = position.Latitude.ToString().Substring(0, 5);
                    float ilon = float.Parse(lon);
                    float ilat = float.Parse(lat);


                    string job_house = "select * from house where (x-0.01)<" + ilon + " and (x+0.01)>" + ilon + " and (y-0.01)<" + ilat + " and (y+0.01)>" + ilat;
                    SqlDataAdapter adapter1 = new SqlDataAdapter(job_house, myconn);
                    DataSet dataset1 = new DataSet();
                    adapter1.Fill(dataset1, "工作to住房");
                    f6.listBox1.Items.Clear();
                    for (int i = 1; i <= dataset1.Tables["工作to住房"].Rows.Count; i++)
                    {

                        string ke = i.ToString() + "  " + dataset1.Tables["工作to住房"].Rows[i - 1].ItemArray[1].ToString() + "\n" + "       " + dataset1.Tables["工作to住房"].Rows[i - 1].ItemArray[5].ToString() + "       编号：" + dataset1.Tables["工作to住房"].Rows[i - 1].ItemArray[0].ToString();
                        f6.listBox1.Items.Add(ke);
                        f6.listBox1.ForeColor = new Color();
                    }
                }

                f6.Show();



            }
        }

        }

    }
