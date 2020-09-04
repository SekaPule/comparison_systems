using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace системы_сравнений
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        int[] c = new int[100];//= { 15, 24, 10 };
        int[] m = new int[100];// = { 11, 23, 8 };
        int n;
        TextBox[] artext1 = new TextBox[100];
        TextBox[] artext2 = new TextBox[100];
        Label[] arlabel1 = new Label[100];
        Label[] arlabel2 = new Label[100];
        int k = 0;
        void input()
        {
            n = int.Parse(textBox1.Text);
        }
        void beg(int i)
        {

                arlabel1[i] = new Label();
                arlabel1[i].Text = "x = ";
                arlabel1[i].Name = string.Format("newLabel1-{0}", i);
                arlabel1[i].Top = 20 + k;
                arlabel1[i].Left = 20;
                panel1.Controls.Add(arlabel1[i]);


                artext1[i] = new TextBox();
                artext1[i].Name = string.Format("newTextBox1-{0}", i);
                artext1[i].Top = 20 + k;
                artext1[i].Left = 120;
                panel1.Controls.Add(artext1[i]);

                arlabel2[i] = new Label();
                arlabel2[i].Text = "mod";
                arlabel2[i].Name = string.Format("newLabel2-{0}", i);
                arlabel2[i].Top = 20 + k;
                arlabel2[i].Left = 240;
                panel1.Controls.Add(arlabel2[i]);

                artext2[i] = new TextBox();
                artext2[i].Name = string.Format("newTextBox2-{0}", i);
                artext2[i].Top = 20 + k;
                artext2[i].Left = 370;
                panel1.Controls.Add(artext2[i]);

                k += 30;
            
        }
        void delete()
        {
            panel1.Controls.Clear();
            k = 0;
        }
        int NOD(int a, int b)
        {
            while (a > 0 && b > 0)

                if (a > b)
                    a %= b;
                else
                    b %= a;

            return a + b;
        }
        void IN()
        {
            for (int i = 0; i < n; i++)
            {
                c[i] = int.Parse(artext1[i].Text);
                m[i] = int.Parse(artext2[i].Text);
                
            }
        }
        void result()
        {
            //x = c[] (mod m[])
            bool flag = false;
            int M = 1, x0 = 0, x;
            int[] Mi = new int[n];
            int[] y = new int[n];
            input();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        if (NOD(m[i], m[j]) != 1)
                        {
                            flag = true;
                        }
                    }
                }
            }
             if (flag)
             {
                MessageBox.Show("Нет решения , числа после mod не взаимно-простые!");
            }

            //.. textBox2.Text = "Решение " + (n == 1 ? "сравнения" : "системы сравнений") + " по модулю:\n\n";
            for (int i = 0; i < n; i++)
            {
                M *= m[i];//M = (m1 * m2 *...* mn)
                //textBox2.Text += "x = " + c[i] + " (mod " + m[i] + ")\n";
            }

            for (int i = 0; i < n; i++)
            {
                Mi[i] = M / m[i];//Mi = M/m[i]
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m[i]; j++)
                {
                    if ((Mi[i] * (j + 1) - 1) % m[i] == 0)
                    {
                        y[i] = (j + 1) % m[i];//M1y1 = 1(mod m1) 
                    }
                }

            }

            for (int i = 0; i < n; i++)
            {
                x0 += Mi[i] * y[i] * c[i];//x0 = (M1*y1*c1+M2*y2*c2+...+Mn*yn*cn)
            }

            x = x0 % M;//x = x0(mod M)

            // x = x0 % M;//x = x0(mod M)
            /* textBox3.Text = "\n\nx = " + x0 + " (mod " + M + ")\n";
             if (M < x0)
             {
                 textBox4.Text = "x = " + (x0 - M * (int)(Math.Floor((double)x0 / M))) + " (mod " + M + ")\n";
             }
             textBox5.Text = "Ответ: " + x;*/
            listBox1.Items.Add("x = " + x0 + " (mod " + M + ")\n");
            if (M < x0)
            {
                listBox1.Items.Add("x = " + (x0 - M * (int)(Math.Floor((double)x0 / M))) + " (mod " + M + ")");
            }
            listBox1.Items.Add("Ответ: " + x);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            delete();
            n = int.Parse(textBox1.Text);
            for (int i = 0; i < n; i++)
            {
                beg(i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            IN();
            result();
        }
    }
}
