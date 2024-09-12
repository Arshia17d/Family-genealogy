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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            marid_person ADD = new marid_person();
            ADD.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            add_person ADD = new add_person();
            ADD.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            born_child ADD = new born_child();
            ADD.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ubdate_info ADD = new ubdate_info();
            ADD.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            find_Relation ADD = new find_Relation();
            ADD.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            family_tree_main.data_add();
            MessageBox.Show("ADD shod...");
        }
    }
}