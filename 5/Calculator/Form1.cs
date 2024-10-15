using System;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private float a, b;
        private int count;
        private bool znak = true;

        public Form1()
        {
            InitializeComponent();
        }

            private void button10_Click(object sender, EventArgs e)
            {
                richTextBox1.Text = richTextBox1.Text + 0;
            }

            private void button1_Click(object sender, EventArgs e)
            {
                richTextBox1.Text = richTextBox1.Text + 1;
            }

            private void button2_Click(object sender, EventArgs e)
            {
                richTextBox1.Text = richTextBox1.Text + 2;
            }

            private void button3_Click(object sender, EventArgs e)
            {
                richTextBox1.Text = richTextBox1.Text + 3;
            }

            private void button4_Click(object sender, EventArgs e)
            {
                richTextBox1.Text = richTextBox1.Text + 4;
            }

            private void button5_Click(object sender, EventArgs e)
            {
                richTextBox1.Text = richTextBox1.Text + 5;
            }

            private void button6_Click(object sender, EventArgs e)
            {
                richTextBox1.Text = richTextBox1.Text + 6;
            }

            private void button7_Click(object sender, EventArgs e)
            {
                richTextBox1.Text = richTextBox1.Text + 7;
            }

            private void button8_Click(object sender, EventArgs e)
            {
                richTextBox1.Text = richTextBox1.Text + 8;
            }

            private void button9_Click(object sender, EventArgs e)
            {
                richTextBox1.Text = richTextBox1.Text + 9;
            }


            private void button11_Click(object sender, EventArgs e)
            {
                richTextBox1.Text = richTextBox1.Text + ",";
            }
        
    

            private void button_Click(object sender, EventArgs e)
            {
                Button btn = sender as Button;
                richTextBox1.Text += btn.Text;
            }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            a = float.Parse(richTextBox1.Text);
            richTextBox1.Clear();
            count = 1;
            label1.Text = a.ToString() + "+";
            znak = true;
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            a = float.Parse(richTextBox1.Text);
            richTextBox1.Clear();
            count = 2;
            label1.Text = a.ToString() + "-";
            znak = true;
        }

        private void buttonMul_Click(object sender, EventArgs e)
        {
            a = float.Parse(richTextBox1.Text);
            richTextBox1.Clear();
            count = 3;
            label1.Text = a.ToString() + "*";
            znak = true;
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            a = float.Parse(richTextBox1.Text);
            richTextBox1.Clear();
            count = 4;
            label1.Text = a.ToString() + "/";
            znak = true;
        }

        private void buttonEq_Click(object sender, EventArgs e)
        {
            calculate();
        }

        private void calculate()
        {
            switch (count)
            {
                case 1:
                    b = a + float.Parse(richTextBox1.Text);
                    richTextBox1.Text = b.ToString();
                    break;
                case 2:
                    b = a - float.Parse(richTextBox1.Text);
                    richTextBox1.Text = b.ToString();
                    break;
                case 3:
                    b = a * float.Parse(richTextBox1.Text);
                    richTextBox1.Text = b.ToString();
                    break;
                case 4:
                    b = a / float.Parse(richTextBox1.Text);
                    richTextBox1.Text = b.ToString();
                    break;
                default:
                    break;
            }
            label1.Text = "";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length != 0)
                richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.Length - 1);
        }


    }
}
