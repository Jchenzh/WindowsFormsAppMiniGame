using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppMiniGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        int count = 30;
        int point = 0;


        private void timer1_Tick(object sender, EventArgs e)
        {
            Button[] bbb = new Button[] 
            {button1, button2, button3, button4,button5, button6, button7, button8, button9 };
            Console.WriteLine(count);
            Random r = new Random();
            bbb[(int)(r.NextDouble() * 9)].BackColor = Color.DarkRed;
            count -= 1;
            if (count <= 10)
            {
                bbb[(int)(r.NextDouble() * 9)].BackColor = Color.DarkRed;
            }
           
            if (count <= 0)
            {
                timer1.Enabled = false;
            }
            label1.Text = point.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.BackColor == Color.DarkRed)
            {
                point += 10;
                button1.BackColor = Color.DarkGray;
            }
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.DarkRed)
            {
                point += 10;
                button2.BackColor = Color.DarkGray;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.DarkRed)
            {
                point += 10;
                button3.BackColor = Color.DarkGray;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.DarkRed)
            {
                point += 10;
                button4.BackColor = Color.DarkGray;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.DarkRed)
            {
                point += 10;
                button5.BackColor = Color.DarkGray;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.DarkRed)
            {
                point += 10;
                button6.BackColor = Color.DarkGray;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == Color.DarkRed)
            {
                point += 10;
                button7.BackColor = Color.DarkGray;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.BackColor == Color.DarkRed)
            {
                point += 10;
                button8.BackColor = Color.DarkGray;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.BackColor == Color.DarkRed)
            {
                point += 10;
                button9.BackColor = Color.DarkGray;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            count = 30;
            point = 0;
            timer1.Enabled = true;
        }
    }
}
