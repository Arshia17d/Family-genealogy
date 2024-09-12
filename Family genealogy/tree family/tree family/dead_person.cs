using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tree_family
{
    public partial class dead_person : Form
    {
        public dead_person()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ubdate_info ADD = new ubdate_info();
            ADD.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string temp;
           temp = family_tree_main.Death(textBox1.Text, textBox2.Text);
            MessageBox.Show(temp);
        }
    }
}
