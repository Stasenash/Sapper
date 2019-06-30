using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sapper
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1(9,9,10).Show();
            
        }

        private void btn16_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1(16, 16, 40).Show();
        }

        private void btnRand_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbHeight.Text, out int height) && int.TryParse(tbWidth.Text, out int width))
            {
                this.Hide();
                new Form1(height,width,height*width / 6).Show();
            }
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
