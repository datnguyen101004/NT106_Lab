using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        Bai1 bai1 = new Bai1();
        private void button1_Click(object sender, EventArgs e)
        {
            bai1.Hide();
            bai1.ShowDialog();
        }

        Bai3 bai3 = new Bai3();
        private void button2_Click(object sender, EventArgs e)
        {
            bai3.Hide(); 
            bai3.ShowDialog();
        }
        Bai2 bai2 = new Bai2();
        private void button3_Click(object sender, EventArgs e)
        {
            bai2.Hide();
            bai2.ShowDialog();
        }

        Bai4 bai4 = new Bai4();
        private void button4_Click(object sender, EventArgs e)
        {
            bai4.Hide();
            bai4.ShowDialog();
        }
    }
}
