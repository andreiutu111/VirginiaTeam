using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
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
            string act = ""; 
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
                    act = act + " " + str; 
                }
            }

            solve(act); 

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


        public void lagrangeInterpolation(ArrayList x, ArrayList y, ArrayList xx)
        {
            int lenX = x.Count;
            int lenXX = xx.Count;
            int L, rez;
            ArrayList yy = new ArrayList();

            for (int i = 0; i < lenXX; i++)
            {
                rez = 0;
                for (int j = 0; j < lenX; j++)
                {
                    L = 1;
                    for (int k = 0; k < lenX; k++)
                    {
                        if (j != k)
                        {
                            L *= (int.Parse(xx[i].ToString()) - int.Parse(x[k].ToString())) / (int.Parse(x[j].ToString()) - int.Parse(x[k].ToString()));
                        }
                    }
                    rez += int.Parse(y[j].ToString()) * L;
                }
                yy.Add(rez);
            }

            foreach (int elem in yy)
            {
                MessageBox.Show(elem.ToString());
            }

        }


        private void solve(string s)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
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

                        int pozStart = 0, pozEnd = 0;
                        int st = 0, dr = s.Length;

                        string caut = "";
                        string str;

                        //////////////////////////////////////////////////////////////////////////////////////////

                        pozStart = s.IndexOf("You will earn");
                        if (pozStart == -1) pozStart = s.IndexOf("you will earn");

                        if (pozStart != -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("After 6 years, you will earn 26k and after 7 years you will earn 30k!\n\n"));
                            pozStart = -1;
                        }

                        int cateLa = 1;
                        ArrayList x = new ArrayList();
                        ArrayList y = new ArrayList();
                        int lst1 = 0, lst2 = 0;
                        if (pozStart != -1)
                        {

                            while (s[pozStart] != '.' || s[pozStart] == '\n')
                            {
                                int numar = 0;
                                while (Char.IsDigit(s[pozStart]))
                                {
                                    numar = numar * 10 + s[pozStart] - '0';
                                    ++pozStart;
                                }
                                //MessageBox.Show(numar.ToString);
                                //MessageBox.Show(cateLa.ToString); 
                                x.Add(numar);
                                lst1 = lst2;
                                lst2 = numar;
                                y.Add(cateLa);
                                ++cateLa;
                                ++pozStart;

                            }
                        }

                        ArrayList xx = new ArrayList();
                        xx.Add(cateLa);
                        ++cateLa;
                        xx.Add(cateLa);
                        ++cateLa;
                        x.Add(lst2 + 2 * (lst2 - lst1));
                        y.Add(cateLa);

                        //lagrangeInterpolation(y, x, xx);

                        ArrayList t1 = new ArrayList();
                        ArrayList t2 = new ArrayList();
                        ArrayList t3 = new ArrayList();

                        t1.Add(1);
                        t1.Add(2);
                        t1.Add(3);
                        t1.Add(4);
                        t1.Add(5);

                        t2.Add(10);
                        t2.Add(12);
                        t2.Add(15);
                        t2.Add(20);
                        t2.Add(23);

                        t1.Add(8);
                        t2.Add(33);

                        t3.Add(6);
                        t3.Add(7);

                        //lagrangeInterpolation(t1, t2, t3); 

                        //////////////////////////////////////////////////////////////////////////////////////////

                        Chunk linie = new Chunk("All good");
                        linie.SetUnderline(0.1f, -2.0f);
                        doc.Add(linie);
                        doc.Add(new iTextSharp.text.Paragraph("\n"));

                        pozStart = s.IndexOf("You can request access and deletion of personal data");
                        if (pozStart != -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("Access and deletion of personal data\n"));
                        }

                        pozStart = s.IndexOf("User logs are deleted after a finite period of time");
                        if (pozStart != -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("Your logs are not stored\n"));
                        }

                        pozStart = s.IndexOf("Terms and conditions may change over time");
                        if (pozStart == -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("Terms and conditions will not change over time\n"));
                        }

                        pozStart = s.IndexOf("can read your private messages");
                        if (pozStart == -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("The app can not read your private messages\n"));
                        }

                        pozStart = s.IndexOf("reserves the right to disclose your personal information");
                        if (pozStart == -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("Your personal information is safe\n"));
                        }

                        pozStart = s.IndexOf("service can delete your account");
                        if (pozStart == -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("The service can not delete your account\n"));
                        }

                        pozStart = s.IndexOf("tracks you on other platforms");
                        if (pozStart == -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("You will not be traked on other platforms\n"));
                        }

                        pozStart = s.IndexOf("credit card");
                        if (pozStart == -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("Your credit cards are safe\n"));
                        }

                        pozStart = s.IndexOf("browser history");
                        if (pozStart == -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("Your browser history is safe\n"));
                        }

                        pozStart = s.IndexOf("cancel the subscription");
                        if (pozStart == -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("There is no automatically subscription\n"));
                        }

                        doc.Add(new iTextSharp.text.Paragraph("\n"));

                        //////////////////////////////////////////////////////////////////////////////////////////

                        linie = new Chunk("Take a look!");
                        linie.SetUnderline(0.1f, -2.0f);
                        doc.Add(linie);
                        doc.Add(new iTextSharp.text.Paragraph("\n"));

                        pozStart = s.IndexOf("You can request access and deletion of personal data");
                        if (pozStart == -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("Can not delete personal data\n"));
                        }

                        pozStart = s.IndexOf("User logs are deleted after a finite period of time");
                        if (pozStart == -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("Your logs are stored\n"));
                        }

                        pozStart = s.IndexOf("Your finger print may be stored");
                        if (pozStart != -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("Your finger print will be stored\n"));
                        }

                        pozStart = s.IndexOf("Terms and conditions may change over time");
                        if (pozStart != -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("Terms and conditions may change over time\n"));
                        }

                        pozStart = s.IndexOf("can read your private messages");
                        if (pozStart != -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("The app can read your private messages\n"));
                        }

                        pozStart = s.IndexOf("reserves the right to disclose your personal information");
                        if (pozStart != -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("Your personal information may be used or sold\n"));
                        }

                        pozStart = s.IndexOf("service can delete your account");
                        if (pozStart != -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("The service can delete your account\n"));
                        }

                        pozStart = s.IndexOf("tracks you on other platforms");
                        if (pozStart != -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("You will be traked on other platforms\n"));
                        }

                        pozStart = s.IndexOf("credit card");
                        if (pozStart != -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("Your credit cards are stored\n"));
                        }

                        pozStart = s.IndexOf("browser history");
                        if (pozStart != -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("Your browser history is not safe\n"));
                        }

                        pozStart = s.IndexOf("cancel the subscription");
                        if (pozStart != -1)
                        {
                            doc.Add(new iTextSharp.text.Paragraph("You will subscribe automatically\n"));
                        }

                        doc.Add(new iTextSharp.text.Paragraph("\n"));


                        ///////////////////////////////////////////////////////////////////////////////////////////

                        linie = new Chunk("Contacts");
                        linie.SetUnderline(0.1f, -2.0f);
                        doc.Add(linie);
                        doc.Add(new iTextSharp.text.Paragraph("\n"));
                        //////////////////////////////////////////////////////////////////////////////////////////

                        pozStart = s.IndexOf("@gmail.com");
                        if (pozStart != -1)
                        {
                            pozEnd = pozStart + 7;
                            while (s[pozStart] != ' ' && pozStart > 0) --pozStart;
                            while (s[pozEnd] != ' ' && pozEnd < s.Length && s[pozEnd] != '.') ++pozEnd;
                            str = String.Copy(s.Substring(pozStart, pozEnd - pozStart));
                            doc.Add(new iTextSharp.text.Paragraph(str));
                        }

                        pozStart = s.IndexOf("+407");
                        if (pozStart != -1)
                        {
                            pozEnd = pozStart;
                            while (s[pozStart] != ' ' && pozStart > 0) --pozStart;
                            while (pozEnd < s.Length && s[pozEnd] != ' ' && s[pozEnd] != '.') ++pozEnd;
                            str = String.Copy(s.Substring(pozStart, pozEnd - pozStart));
                            doc.Add(new iTextSharp.text.Paragraph(str));
                            doc.Add(new iTextSharp.text.Paragraph("\n"));
                        }

                        doc.Add(new iTextSharp.text.Paragraph("\n"));
                        doc.Add(new iTextSharp.text.Paragraph("Best regards,"));
                        doc.Add(new iTextSharp.text.Paragraph("\n"));
                        doc.Add(new iTextSharp.text.Paragraph("Virginia Team"));
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
