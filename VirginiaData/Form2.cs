using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Threading;

namespace VirginiaData
{
    public partial class Form2 : Form
    {

        Thread th; 
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        String[] usu = new String[10001];

        private void button1_Click(object sender, EventArgs e)
        {
            string act = ""; 
            for (int i = 0; i < richTextBox1.Lines.Count(); i++)
            {
                usu[i] = richTextBox1.Lines[i];
                act = act + " " + usu[i];
            }

            solve(act); 

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = ""; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(usu2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void usu2(object obj)
        {
            Application.Run(new Form1());
        }

        private void solve(string s)
        {
            MessageBox.Show(s); 
        }

    }
}
