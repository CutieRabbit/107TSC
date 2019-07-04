using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problemA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void printPermutation(int n, string str, string result, int complete)
        {
            if (complete == n)
            {
                listBox1.Items.Add(result);
                return;
            }
            char[] vec = str.ToCharArray();
            char[] rst = result.ToCharArray();
            for(int i = 0; i < vec.Length; i++)
            {
                rst[complete] = str[i];
                string remake = "";
                List<char> list = str.ToList<char>();
                list.RemoveAt(i);
                remake = String.Join("", list);
                result = String.Join("", rst);
                printPermutation(n, remake, result, complete + 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            String str = textBox1.Text;
            printPermutation(str.Length, str, "".PadLeft(str.Length, 'X'), 0);
            textBox2.Text = listBox1.Items.Count + "";
        }
    }
}
