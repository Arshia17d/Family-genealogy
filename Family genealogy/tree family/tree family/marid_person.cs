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
    public partial class marid_person : Form
    {

        public marid_person()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string temp = family_tree_main.marid_person(textBox1.Text, textBox2.Text, textBox3.Text);
            MessageBox.Show(temp);
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
    
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ADD = new Form1();
            ADD.ShowDialog();
            this.Close();
        }
    }
}
