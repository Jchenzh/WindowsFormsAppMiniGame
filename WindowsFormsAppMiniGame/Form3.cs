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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Lottery lo = new Lottery();
            if (checkedListBox1.CheckedItems.Count > 6) MessageBox.Show("最多選六個");
            else foreach (string j in checkedListBox1.CheckedItems)
            {
                Console.WriteLine(j, "加入清單");
                lo.Add(Convert.ToInt32(j));
            }
            lo.Pick();
            lo.Sort();
            listBox1.Items.Add(lo.ToString());
        }

        // 一組號碼
        public class Lottery
        {
            private int[] lot = new int[6];

            // 電腦選號
            public int[] Pick()
            {
                Random r = new Random();
                for (int i=0; i<6; i++)
                    {
                    if (lot[i] == 0)
                    {
                        
                        int n = (int)(r.NextDouble() * 49) + 1;
                        if (i == 0) { lot[i] = n; continue; }
                        // 檢查重複
                        else for (int j = 0; j < i; j++)
                            {
                                if (n == lot[j])
                                {
                                    Console.WriteLine("ddddd");
                                    i--;
                                    break;
                                }
                                else lot[i] = n;
                            }
                    }
                    else continue;             
                    }
                    return lot;
            }

            // 加入號碼
            public void Add(int n)
            {
                for (int i=0; i<lot.Length;i++)
                {
                    if (lot[i] == 0)
                    {
                        lot[i] = n;
                        break;
                    }
                }
            }
            public void Sort()
            {
                Array.Sort(lot);
            }

            public override string ToString()
            {
                string s = "";
                foreach (int j in lot)
                {
                    s += j;
                    s += "\t";
                }
                return s;
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
