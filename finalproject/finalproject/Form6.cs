using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Data.SqlClient;




namespace finalproject
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection myconn = new SqlConnection("Data Source=.;Initial Catalog=workrent;Integrated Security=True");

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            string st = listBox1.SelectedItem.ToString();
            string[] starray = st.Split('：');
            string index = starray.Last();
            MessageBox.Show(index);
            SqlDataAdapter zhufangadp = new SqlDataAdapter("select house.index1,house.name,x,y,house.prise,户型,面积,有无精装修,有无电梯,有无车位,有无燃气,landlord.name,landlord.tel from house,owned,landlord where house.index1='" + index.Trim() + "' and house.index1=owned.index1 and owned.LID=landlord.LID", myconn);
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
            string lat = zhufangi.Tables["房源详情"].Rows[0][3].ToString();
            string lon = zhufangi.Tables["房源详情"].Rows[0][2].ToString();
            f5.webBrowser1.Navigate("http://api.map.baidu.com/marker?location=" + lat + "," + lon + "&title=该房源位置&content=&output=html&src=webapp.baidu.openAPIdemo");
            f5.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string st = listBox1.SelectedItem.ToString();
            string[] starray = st.Split('：');
            string index = starray.Last();
            MessageBox.Show(index);
            SqlDataAdapter zhufangadp = new SqlDataAdapter("select house.index1,house.name,x,y,house.prise,户型,面积,有无精装修,有无电梯,有无车位,有无燃气,landlord.name,landlord.tel from house,owned,landlord where house.index1='" + index.Trim() + "' and house.index1=owned.index1 and owned.LID=landlord.LID", myconn);
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
            string lat = zhufangi.Tables["房源详情"].Rows[0][3].ToString();
            string lon = zhufangi.Tables["房源详情"].Rows[0][2].ToString();
            f5.webBrowser1.Navigate("http://api.map.baidu.com/marker?location=" + lat + "," + lon + "&title=该房源位置&content=&output=html&src=webapp.baidu.openAPIdemo");
            f5.Show();
        }
 

        private void button3_Click(object sender, EventArgs e)
        {

            if (A.denglu == true)
            {
                openFileDialog1.Filter = "*jpg|*.JPG|*.GIF|*.GIF|*.BMP|*.BMP";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fullpath = openFileDialog1.FileName;//文件路径

                    FileStream fs = new FileStream(fullpath, FileMode.Open);

                    byte[] imagebytes = new byte[fs.Length];

                    BinaryReader br = new BinaryReader(fs);

                    imagebytes = br.ReadBytes(Convert.ToInt32(fs.Length));

                    //打开数据库


                    myconn.Open();
                    {                        
                        MessageBox.Show(label3.Text.Substring(3, label3.Text.Length - 3));
                        MessageBox.Show(label2.Text.Substring(3, label2.Text.Length - 3));
                        MessageBox.Show(label4.Text.Substring(3, label4.Text.Length - 3));
                        MessageBox.Show("insert into resume values('" + A.username + "','" + label3.Text.Substring(3, label3.Text.Length - 3) + "','" + label2.Text.Substring(3, label2.Text.Length - 3) + "','" + label4.Text.Substring(3, label4.Text.Length - 3) + "', @ImageList)");

                        SqlCommand com = new SqlCommand("insert into resume values('" + A.username + "','" + label3.Text.Substring(3, label3.Text.Length - 3) + "','" + label2.Text.Substring(3, label2.Text.Length - 3) + "','" + label4.Text.Substring(3, label4.Text.Length - 3) + "', @ImageList)", myconn);


                        com.Parameters.Add("ImageList", SqlDbType.Image);

                        com.Parameters["ImageList"].Value = imagebytes;

                        com.ExecuteNonQuery();

                        MessageBox.Show("投递成功！");
                    }
                    myconn.Close();
                }
                
            }
            else
            {
                MessageBox.Show("投递简历请先登录");
            }
            
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
