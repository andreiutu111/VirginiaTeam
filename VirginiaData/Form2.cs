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
using System.Net;

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

        public static void DownloadString(string address)
        {
            WebClient client = new WebClient();
            string reply = client.DownloadString(address);

            string aca = reply[3]; 
            MessageBox.Show(aca);
        }

        String[] usu = new String[10001];

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < richTextBox1.Lines.Count(); i++)
            {
                usu[i] = richTextBox1.Lines[i];
                MessageBox.Show(usu[i]);
            }

            DownloadString("https://docs.google.com/document/d/1cHn62cveAi8pzurMRApM-tzX57Zh5Bulj19k0ZGA8nA/edit"); 

        }


        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = ""; 
        }
    }
}
