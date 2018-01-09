using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text12_2
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }
        private Form2 form2;
        private Form3 form3;
        private Form4 form4;
        private void button1_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form3 = new Form3();
            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form4 = new Form4();
            form4.Show();
        }
    }
}
