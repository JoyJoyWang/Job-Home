using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalproject
{
    public partial class rchoosing : Form
    {
        public rchoosing()
        {
            InitializeComponent();
        }


        private void Form14_Load(object sender, EventArgs e)
        {
            button4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rinsert f15 = new rinsert();
            f15.ShowDialog();
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rupdate f16 = new rupdate();
            f16.ShowDialog();
            //this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            rresume f17 = new rresume();
            f17.ShowDialog();
            //this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form18 f18 = new Form18();
            f18.ShowDialog();
            //this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            A.dengluhr = false;
            A.username = "";
            this.Close();
        }

        private void rchoosing_FormClosed(object sender, FormClosedEventArgs e)
        {
            A.dengluhr = false;
            A.username = "";
        }
    }
}
