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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        Area a = new Area();

        class Area // 計算面積用函數
        {
            private double _width;
            private double _height;
            public string shape { get; set; }
            // Rec Tri Cir
            
            public double width
            {
                get { return _width; }
                set { _width = value; }
            }
            public double height
            {
                get => _height;
                set => _height = value;
            }
            public double GetArea(string a) {

                return width*height;
            }
            public override string ToString()
            {
                string s = "";
                if (this.shape == "Tri")
                {
                    s += "三角形\n面積:" + this.GetArea("Tri");

                }
                return s;
            }

        }
        
        private void Form4_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            a.width = Convert.ToDouble(textBox2.Text);
            a.height = Convert.ToDouble(textBox1.Text);
            Console.WriteLine(a.width);
            Console.WriteLine(a.height);
            Console.WriteLine(a.GetArea("Tri"));
            Console.WriteLine(a.ToString());
            label4.Text = a.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() == "圓形") a.shape = "Cir";
            if (listBox1.SelectedItem.ToString() == "三角形") a.shape = "Tri";
            if (listBox1.SelectedItem.ToString() == "方形") a.shape = "Rec";
        }
    }
}
