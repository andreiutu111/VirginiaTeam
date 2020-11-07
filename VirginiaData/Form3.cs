using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirginiaData
{
    public partial class Form3 : Form
    {
        Thread th;
        public Form3()
        {
            InitializeComponent();
        }

        static StreamReader URLStream(String fileurl)
        {
            return new StreamReader(new HttpClient().GetStreamAsync(fileurl).Result);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string line;
            StreamReader s = URLStream(@textBox1.Text);
            String myline = s.ReadLine(); //First Line
            int pozStart, pozEnd;
            string sStart = "DOCS_modelChunk = [", sEnd = "\"},";
            string str;
            bool ok = true;
            while ((line = s.ReadLine()) != null && ok == true) //Subsequent Lines
            {
                pozStart = line.IndexOf(sStart);
                if (pozStart != -1)
                {
                    pozStart += 43;
                    pozEnd = line.IndexOf(sEnd);
                    str = String.Copy(line.Substring(pozStart, pozEnd - pozStart));
                    ok = false;
                    MessageBox.Show(str);
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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
    }
}
