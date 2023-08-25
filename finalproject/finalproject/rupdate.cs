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
    public partial class rupdate : Form
    {
        public rupdate()
        {
            InitializeComponent();
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            hchoosing f10 = new hchoosing();
            f10.Show();
            this.Close();
        }*/
        static string mystr = @"Data Source=.;Initial Catalog=workrent;Integrated Security=True";
        SqlConnection mycon = new SqlConnection(mystr);
        BindingSource mybind = new BindingSource();
        DataSet myset = new DataSet();

        private void Form16_Load(object sender, EventArgs e)
        {
            string s1 = "select * from work where company='" + A.username.Trim() + "'";
            SqlDataAdapter myadapter = new SqlDataAdapter(s1, mycon);
            myadapter.Fill(myset, "hr");
            mybind.DataSource = myset;
            mybind.DataMember = "hr";
            textBox2.DataBindings.Add(new Binding("Text", mybind, "job", true));
            textBox3.DataBindings.Add(new Binding("Text", mybind, "salary", true));
            textBox4.DataBindings.Add(new Binding("Text", mybind, "region", true));
            textBox5.DataBindings.Add(new Binding("Text", mybind, "workexp", true));
            textBox6.DataBindings.Add(new Binding("Text", mybind, "edu", true));
            textBox7.DataBindings.Add(new Binding("Text", mybind, "major", true));
            textBox8.DataBindings.Add(new Binding("Text", mybind, "welfare", true));
            textBox9.DataBindings.Add(new Binding("Text", mybind, "detail", true));
            textBox10.DataBindings.Add(new Binding("Text", mybind, "place", true));
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
            string s1 = "update work set job='" + textBox2.Text.Trim() + "',salary ='" + textBox3.Text.Trim() + "',region='" + textBox4.Text.Trim() + "',workexp='" + textBox5.Text.Trim() + "',edu='" + textBox6.Text.Trim() + "',major='" + textBox7.Text.Trim() + "',welfare='" + textBox8.Text.Trim() + "',detail='" + textBox9.Text.Trim() + "',place='" + textBox10.Text.Trim() + "'where company ='" + A.username.Trim() + "' and job ='" + textBox2.Text.Trim() + "' and place='" + textBox10.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(s1, mycon);
           // MessageBox.Show(s1);
            mycon.Open();
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
            mycon.Close();
            MessageBox.Show("成功更新");
            //MessageBox.Show("1");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string s1 = "delete from work where company='" + A.username + "' and job ='" + textBox2.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(s1, mycon);
            //MessageBox.Show(s1);
            mycon.Open();
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
            mycon.Close();
            MessageBox.Show("成功删除");
            mybind.RemoveCurrent();
        }
    }
}
