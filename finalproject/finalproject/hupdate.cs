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
    public partial class hupdate : Form
    {
        public hupdate()
        {
            InitializeComponent();
        }

       /* private void button1_Click(object sender, EventArgs e)
        {
            hchoosing f10 = new hchoosing();
            f10.Show();
            this.Close();
        }*/

        static string mystr = @"Data Source=.;Initial Catalog=workrent;Integrated Security=True";
        SqlConnection myconn = new SqlConnection(mystr);
        BindingSource mybind = new BindingSource();
        DataSet myset = new DataSet();

        private void Form12_Load(object sender, EventArgs e)
        {
            string s1 = "select * from house,owned where owned.LID='" + A.username.Trim() + "' and house.index1=owned.index1";
            SqlDataAdapter myadapter = new SqlDataAdapter(s1, myconn);
            myadapter.Fill(myset, "house");
            mybind.DataSource = myset;
            mybind.DataMember = "house";
            textBox2.DataBindings.Add(new Binding("Text", mybind, "name", true));
            textBox3.DataBindings.Add(new Binding("Text", mybind, "prise", true));
            textBox4.DataBindings.Add(new Binding("Text", mybind, "户型", true));
            textBox5.DataBindings.Add(new Binding("Text", mybind, "面积", true));
            textBox6.DataBindings.Add(new Binding("Text", mybind, "有无精装修", true));
            textBox7.DataBindings.Add(new Binding("Text", mybind, "有无电梯", true));
            textBox8.DataBindings.Add(new Binding("Text", mybind, "有无车位", true));
            textBox9.DataBindings.Add(new Binding("Text", mybind, "有无燃气", true));
            textBox10.DataBindings.Add(new Binding("Text", mybind, "index1", true));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mybind.MoveFirst();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mybind.MovePrevious();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mybind.MoveNext();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mybind.MoveLast();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string s1 = "update house set name='" + textBox2.Text.Trim() + "',prise = " + textBox3.Text.Trim() + ",户型='" + textBox4.Text.Trim() + "',面积='" + textBox5.Text.Trim() + "',有无精装修='" + textBox6.Text.Trim() + "',有无电梯='" + textBox7.Text + "',有无车位='" + textBox8.Text + "',有无燃气='" + textBox9.Text.Trim() + "' where index1 ='" + textBox10.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(s1, myconn);
            // MessageBox.Show(s1);
            myconn.Open();
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
            myconn.Close();
            MessageBox.Show("成功更新");
            //MessageBox.Show("1");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string s1 = "delete from house where index1 ='" + textBox10.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(s1, myconn);
            //MessageBox.Show(s1);
            myconn.Open();
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
            myconn.Close();
            MessageBox.Show("成功删除");
            mybind.RemoveCurrent();
        }

        private void Form12_FormClosed(object sender, FormClosedEventArgs e)
        {
            //System.Environment.Exit(0);
        }

    }
}
