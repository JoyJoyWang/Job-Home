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
    public partial class hchoosing : Form
    {
        public hchoosing()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            button3.Visible = false;
            button4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hinsert f11 = new hinsert();
            f11.ShowDialog();
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hupdate f12 = new hupdate();
            f12.ShowDialog();
            //this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            button3.Visible =true;
            button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            A.denglull = false;
            A.username = "";
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.Show();
        }

        private void hchoosing_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            button3.Visible = false;
            A.denglull = false;
            A.username = "";
        }
    }
}
