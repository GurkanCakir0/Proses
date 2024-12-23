using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _243908353_Huseyin_Gurkan_CAKIR_Final_Projesi1
{
    public partial class Form1 : Form
    {
        private Queue_L queue_l;
        private stack_l stack_L;
        private Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            queue_l = new Queue_L();
            stack_L = new stack_l();

        }
        private void RastgeleEkle(ListBox listBox)
        {
            int data = rnd.Next(0, 6);
            queue_l.EnQueue(data);
            listBox.Items.Add(data);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Proses1.Start();
            Proses2.Start();
            Proses3.Start();

        }

        private void Proses1_Tick(object sender, EventArgs e)
        {
            RastgeleEkle(listBox1);
        }
        private void Proses2_Tick(object sender, EventArgs e)
        {
            RastgeleEkle(listBox2);
        }

        private void Proses3_Tick(object sender, EventArgs e)
        {
            RastgeleEkle(listBox3);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            Proses1.Interval = 1100 - (100 * trackBar2.Value); 
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            Proses2.Interval = 1100 - (100 * trackBar3.Value);
        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            Proses3.Interval = 1100 - (100 * trackBar4.Value);
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            Islemci.Interval = 1100 - (100 * trackBar1.Value);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Islemci.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
           Islemci.Stop();
        }

        private void Islemci_Tick(object sender, EventArgs e)
        {
            if (!Islemci.Enabled) return;

            var sayim = new List<(int value, string source)>();

            if (listBox1.Items.Count > 0)
            {
                sayim.Add((Convert.ToInt32(listBox1.Items[0]),"P1-"));
            }
            if (listBox2.Items.Count > 0)
            {
                sayim.Add((Convert.ToInt32(listBox2.Items[0]), "P2-"));
            }
            if (listBox3.Items.Count > 0)
            {
                sayim.Add((Convert.ToInt32(listBox3.Items[0]), "P3-"));
            }

            var listesay = sayim.OrderBy(s1 => s1.value).ThenBy(s1 => s1.source).ToList();

            foreach (var data in listesay)
            {
                textBox1.AppendText($"{data.source}-{data.value}"+ "  " + Environment.NewLine);
                if (data.source == "P1-")
                {
                    listBox1.Items.RemoveAt(0);
                    if (listBox1.Items.Count > 0)
                    {
                        queue_l.deQueue();
                        stack_L.push(data.value);
                    }
                }
                else if (data.source == "P2-")
                {
                    listBox2.Items.RemoveAt(0);
                    if (listBox2.Items.Count > 0)
                    {
                        queue_l.deQueue();
                        stack_L.push(data.value);
                    }
                }
                else if (data.source == "P3-")
                {
                    listBox3.Items.RemoveAt(0);
                    if (listBox3.Items.Count > 0)
                    {
                        queue_l.deQueue();
                        stack_L.push(data.value);
                    }
                }
            }
            TextRenk();
        }

        private void TextRenk()
        {
            int sayCount = listBox1.Items.Count + listBox2.Items.Count + listBox3.Items.Count;
            if (sayCount > 150)
            {
                textBox1.BackColor = Color.Red;
            }
            else if (sayCount > 100)
            {
                textBox1.BackColor = Color.Orange;
            }
            else if (sayCount > 50)
            {
                textBox1.BackColor = Color.Green;
            }
            else
            {
                textBox1.BackColor = Color.White;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Clear();

            int stack = Math.Max(listBox1.Items.Count, Math.Max(listBox2.Items.Count, listBox3.Items.Count));

            for (int i = 0; i < stack; i++)
            {
                string p1 = i < listBox1.Items.Count ? listBox1.Items[i].ToString() : ""; 
                string p2 = i < listBox2.Items.Count ? listBox2.Items[i].ToString() : ""; 
                string p3 = i < listBox3.Items.Count ? listBox3.Items[i].ToString() : "";

                textBox2.AppendText($"{p1}\t{p2}\t{p3}" + Environment.NewLine);
            }
        }

        private void check()
        {
            textBox2.Clear();

            int stack = Math.Max(listBox1.Items.Count, Math.Max(listBox2.Items.Count, listBox3.Items.Count));

            for (int i = 0; i < stack; i++)
            {
                string p1 = checkBox1.Checked && i < listBox1.Items.Count ? listBox1.Items[i].ToString() : "";
                string p2 = checkBox2.Checked && i < listBox2.Items.Count ? listBox2.Items[i].ToString() : "";
                string p3 = checkBox3.Checked && i < listBox3.Items.Count ? listBox3.Items[i].ToString() : "";

                textBox2.AppendText($"{p1}\t{p2}\t{p3}" + Environment.NewLine);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            check();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            check();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            check();
        }
    }
}
