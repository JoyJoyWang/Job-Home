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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        SqlConnection myconn = new SqlConnection("Data Source=.;Initial Catalog=workrent;Integrated Security=True");
        DataSet myset = new DataSet();
        BindingSource mybind = new BindingSource();


        private void Form8_Load(object sender, EventArgs e)
        {
             SqlDataAdapter myadp = new SqlDataAdapter("select usermark.title,textall,author from usermark,information where usermark.username='" + A.username + "' and usermark.title=information.title", myconn);

            myadp.Fill(myset,"收藏表");
            mybind.DataSource = myset;
            mybind.DataMember = "收藏表";
            richTextBox1.DataBindings.Add(new Binding("Text", mybind, "textall", true));
            label1.DataBindings.Add(new Binding("Text", mybind, "title",true));
            label2.DataBindings.Add(new Binding("Text", mybind, "author", true));

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mybind.MoveFirst();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            mybind.MoveLast();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mybind.MovePrevious();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            mybind.MoveNext();
        }


        private void Form8_FormClosed(object sender, FormClosedEventArgs e)
        {

        }



        private void button6_Click()
        {

        }
    }
}
