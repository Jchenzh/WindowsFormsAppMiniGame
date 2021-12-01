using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// ArrayList 或 List https://www.itread01.com/content/1549468988.html
using System.Collections;

namespace WindowsFormsAppMiniGame
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        // Deck 牌庫 ，玩家
        Deck d = new Deck();
        Player p = new Player();
        Blackjack bj = new Blackjack();
        public void Restart()
        {
            d = new Deck();
            p = new Player();
            bj = new Blackjack();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Restart();
            foreach (Card c in d.deck) Console.WriteLine(c);
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            p.hand.Clear();
            label1.Text = "0";
            label2.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Blackjack.Point(p) >= 0)
            {
                p.hand.Add(d.Draw());
                listBox1.Items.Clear();
                foreach (Card c in p.hand)
                {
                    listBox1.Items.Add(c);
                }
                label1.Text = Blackjack.Point(p).ToString();
            }
            else MessageBox.Show("你爆囉");
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            d.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            bj.Npc(d);
            foreach (Card c in bj.npc.hand) listBox2.Items.Add(c);
            label2.Text = Blackjack.Point(bj.npc).ToString();
            bj.PK(p);
            Restart();
        }

    }
    public class Card
    {
        public int rank;
        public char suit;
        public override string ToString()
        {
            string s = "";
            if (suit == 'C') s += "梅花";
            else if (suit == 'D') s += "方塊";
            else if (suit == 'H') s += "愛心";
            else if (suit == 'S') s += "黑桃";
            if (rank == 11) s += "J";
            else if (rank == 12) s += "Q";
            else if (rank == 13) s += "K";
            else if (rank == 14) s += "A";
            else s += rank.ToString();
            return s;
        }
    }
    public class Deck
    {     
        public List<Card> deck = new List<Card>();
        
        // 創建新牌庫，52張牌
        public Deck()
        {   
            Init();
        }
        public void Show()
        {
            foreach (Card c in deck) Console.WriteLine(c);
        }

        // 洗牌
        public void Init()
        {
            deck.Clear();
            for (int i = 2; i < 15; i++)
                foreach (char suit in "CDHS")
                {
                    // Console.WriteLine(suit.ToString() + i);
                    Card cc = new Card();
                    cc.rank = i;
                    cc.suit = suit;
                    deck.Add(cc);
                   //  Console.WriteLine(cc.ToString());
                }

        }
        // 抽牌
        public Card Draw()
        {
            if (this.deck.Count() <= 0)
            {
                MessageBox.Show("沒牌囉，重新洗牌");
                Init();
                
            }
            Random r = new Random();
            int n = r.Next() % deck.Count();
            Card c = deck[n];
            deck.RemoveAt(n);
            return c;
        }
    }

    public class Player
    {
        public List<Card> hand = new List<Card>();
        public void DrawCard(Deck dd)
        {
            Random r = new Random();
            int n = r.Next() % dd.deck.Count();
            Card c = dd.deck[n];
            dd.deck.RemoveAt(n);
            hand.Add(c);
        }
        public override string ToString()
        {
            string s = "";
            foreach (Card c in this.hand) s+=c+", ";
            return s;
        }
    }  
        
    public class Blackjack
        {
        public Player npc = new Player();

        // 計算BJ點數
        public static int Point(Player p)
        {
            int sum = 0;
            int na = 0;
            foreach (Card c in p.hand)
            {
                if (c.rank == 11 || c.rank == 12 || c.rank == 13) sum += 10;
                else if (c.rank == 14) { sum += 11; na++; }
                else sum += c.rank;
            }
            while (sum > 21 && na > 0) { na--; sum -= 10; }
            if (sum > 21)  return -1;
            return sum;
        }

        public void Show(Player p)
        {
            foreach (Card c in p.hand) Console.WriteLine(c);
        }

        // 莊家牌
        public void Npc(Deck d)
        {
            if (Blackjack.Point(this.npc) < 15 && Blackjack.Point(this.npc) != -1)
            {
                npc.hand.Add(d.Draw());
                Npc(d);
            }
            
        }
        public void PK(Player p)
        {
            if (Blackjack.Point(this.npc)==-1) MessageBox.Show("莊家爆，你贏了");
            else if (Blackjack.Point(p) > Blackjack.Point(this.npc)) MessageBox.Show("你贏了");
            else MessageBox.Show("莊家贏");
        }
    }     
}
     
