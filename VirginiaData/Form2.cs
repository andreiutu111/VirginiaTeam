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
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;

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
            using(SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4);

                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();

                        String[] v1 = new String[10001];
                        String[] v2 = new String[10001];
                        String[] v3 = new String[10001];

                        doc.Add(new iTextSharp.text.Paragraph("Dear friend,"));
                        doc.Add(new iTextSharp.text.Paragraph(""));
                        doc.Add(new iTextSharp.text.Paragraph("We respect the fact that you are seeking for help and you trust our services. We extracted your 'Terms and Conditions' content:"));
                        doc.Add(new iTextSharp.text.Paragraph("\n"));
                        doc.Add(new iTextSharp.text.Paragraph("\n"));

                        Chunk linie = new Chunk("All good");
                        linie.SetUnderline(0.1f, -2.0f);
                        doc.Add(linie);
                        doc.Add(new iTextSharp.text.Paragraph("\n"));
                        doc.Add(new iTextSharp.text.Paragraph("\n"));

                        linie = new Chunk("Take a look!");
                        linie.SetUnderline(0.1f, -2.0f);
                        doc.Add(linie);
                        doc.Add(new iTextSharp.text.Paragraph("\n"));
                        doc.Add(new iTextSharp.text.Paragraph("\n"));

                        linie = new Chunk("Contacts");
                        linie.SetUnderline(0.1f, -2.0f);
                        doc.Add(linie);
                        doc.Add(new iTextSharp.text.Paragraph("\n"));
                        doc.Add(new iTextSharp.text.Paragraph("\n"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        doc.Close();
                    }
                }
            }
        }

    }
}
