using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Minesweeper_Reloaded
{
    public partial class Highscore2 : Form
    {
        public Highscore2(string n1, string n2, string n3, string z1, string z2, string z3, int mode)
        {
            InitializeComponent();
            label1.Text = "Platz 1:";
            label2.Text = "Platz 2:";
            label3.Text = "Platz 3:";
            label4.Text = z1;
            label5.Text = z2;
            label6.Text = z3;
            label7.Text = n1;
            label8.Text = n2;
            label9.Text = n3;
            switch (mode)
            {
                case 3:
                    label10.Text = "Rang: SCHWER";
                    break;
                case 2:
                    label10.Text = "Rang: MITTEL";
                    break;
                default:
                    label10.Text = "Rang: LEICHT";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
