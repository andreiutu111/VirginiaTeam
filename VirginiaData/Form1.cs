using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirginiaData
{
    public partial class Form1 : Form
    {
        Thread th; 
        public Form1()
        {
            InitializeComponent();
        }

        //PASTE
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(usu2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }

        private void usu2(object obj)
        {
            Application.Run(new Form2());
        }


        //PDF
        private void button2_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog() { Filter="PDF files|*.pdf", ValidateNames = true, Multiselect = false})
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(ofd.FileName);
                        StringBuilder sb = new StringBuilder(); 
                        for(int i = 1; i <= reader.NumberOfPages; ++i)
                        {
                            sb.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                        }
                        MessageBox.Show(sb.ToString()); 
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    }
                }
            }
        }

        private void usu3(object obj)
        {
            Application.Run(new Form3()); 
        }

        //Google Docs
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(usu3);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
    }
}
