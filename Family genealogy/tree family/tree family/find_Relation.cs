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
    public partial class find_Relation : Form
    {
        public find_Relation()
        {
            InitializeComponent();
        }

        private void find_Relation_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ADD = new Form1();
            ADD.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string temp = default(string);
            if (comboBox1.Text == "")
            {
                temp = "null";
            }
            else
            {
       
                switch (comboBox1.Text)
                {
                    case "husbent":
                        temp = family_tree_main.R_husband_name(textBox1.Text);
                        break;
                    case "wife":
                        temp = family_tree_main.R_wife_name(textBox1.Text);
                        break;
                    case "Dad":
                        temp = family_tree_main.R_Dad_name(textBox1.Text);
                        break;
                    case "Mom":
                        temp = family_tree_main.R_mom_name(textBox1.Text);
                        break;
                    case "Brother":
                        temp = family_tree_main.R_just_Broter(textBox1.Text);
                        break;
                    case "sister":
                        temp = family_tree_main.R_just_Sister(textBox1.Text);
                        break;
                    case "sister and brother":
                        temp = family_tree_main.R_sister_Brother(textBox1.Text);
                        break;
                    case "grand father":
                        temp = family_tree_main.grand_father(textBox1.Text);
                        break;
                    case "grand mother":
                        temp = family_tree_main.grand_mom(textBox1.Text);
                        break;
                    case "children":
                        temp = family_tree_main.Children(textBox1.Text);
                        break;
                    case "grand children":
                        temp = family_tree_main.grandchild(textBox1.Text);
                        break;
                    case "ammu":
                        temp = family_tree_main.ammu(textBox1.Text);
                        break;
                    case "daei":
                        temp = family_tree_main.Daei(textBox1.Text);
                        break;
                    case "khale":
                        temp = family_tree_main.khalle(textBox1.Text);
                        break;
                    case "amme":
                        temp = family_tree_main.amme(textBox1.Text);
                        break;
                    case "dokhtar_khale":
                        temp = family_tree_main.R_dokhtar_khale(textBox1.Text);
                        break;
                    case "pesar_khale":
                        temp = family_tree_main.Ru_pesar_khale(textBox1.Text);
                        break;

                }
            }
         
            MessageBox.Show(temp);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
 }  

