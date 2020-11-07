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

namespace VirginiaData
{
    public partial class Form2 : Form
    {
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
            for (int i = 0; i < richTextBox1.Lines.Count(); i++)
            {
                usu[i] = richTextBox1.Lines[i];
                MessageBox.Show(usu[i]);
            }


        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = ""; 
        }
    }
}
