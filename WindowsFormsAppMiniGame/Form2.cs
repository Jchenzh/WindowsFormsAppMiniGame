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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int len = 0;
        int[] ans = new int[4];
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 產生0~9不重複的N位數
            
            ans = new int[Convert.ToInt32(comboBox1.SelectedItem)];
            len = ans.Length;
            Random r = new Random();
            ans[0] = (int)(r.NextDouble() * 9);
            for(int i=1; i<ans.Length; i++)
            {
                int a = (int)(r.NextDouble() * 9);
                for (int j=0; j<i;j++)
                {
                    if (a == ans[j])
                    {
                        i--;
                        break;
                    }
                    else ans[i] = a;
                }
            }

            for(int i = 0; i<ans.Length;i++) Console.Write(ans[i]);
            Console.WriteLine();
            label1.Text = "猜" + len + "位數";
            MessageBox.Show("猜" + len + "位數");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int countA = 0;
            int countB = 0;
            
            try
            {
                string aaa = textBox1.Text;
                if (aaa.Length != len) throw new Exception("長度不一樣");
                for (int i = 0; i<len; i++)
                {
                    // char 轉 int
                    if (Convert.ToInt32(aaa[i].ToString()) == ans[i]) countA++;
                    else for (int j = 0; j < len; j++)
                    {
                        // char 轉 int 方法2
                        if (char.GetNumericValue(aaa[i]) == ans[j]) countB++;                            
                    }                      
                }
                listBox1.Items.Add(aaa + "\t" + countA + "A" + countB + "B");
            }
            catch
            {
                MessageBox.Show("輸入錯物");
            }
            textBox1.Text = "";
            if (countA == len) MessageBox.Show("獲勝");

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
