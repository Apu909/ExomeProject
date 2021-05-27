using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Data.OleDb;

namespace _1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici
{
    public partial class UCCompanieBtnClienti : UserControl
    {
        List<Clienti> listaClienti = new List<Clienti>();
        int id = 5;
        string connString;

        public UCCompanieBtnClienti()
        {   
            InitializeComponent();
            incarcaDate();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Clienti.accdb";
        }


        private void incarcaDate()
        {
            List<string> paths = Directory.EnumerateFiles(@"C:\Users\gronk the conqueror\source\repos\1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici\1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici\bin\Debug\Clienti_Companii\", "*.txt").ToList();

            foreach (string filePath in paths)
            {
                StreamReader sr = new StreamReader(filePath);
                string linie = null;
                String nume = null;
                String prenume = null;
                String nrTelefon = null;
                String email = null;
                String adresa = null;
                String parola = null;
                String dataNastere = null;
                String sex = null;
                // ListViewItem itm = new ListViewItem();
                string[] lines = File.ReadAllLines(filePath);
                while ((linie = sr.ReadLine()) != null)
                {
                    try
                    {
                        if (linie.Contains("Nume: "))
                        {
                            nume = linie.Replace("Nume: ", string.Empty).Trim();
                        }

                        if (linie.Contains("Prenume: "))
                        {
                            prenume = linie.Replace("Prenume: ", string.Empty).Trim();
                        }

                        if (linie.Contains("Numar de telefon: "))
                        {
                            nrTelefon = linie.Replace("Numar de telefon: ", string.Empty).Trim();
                            //itm.SubItems.Add(nrTelefon);
                        }

                        if (linie.Contains("Email: "))
                        {
                            email = linie.Replace("Email: ", string.Empty).Trim();
                            //itm.SubItems.Add(email);
                        }

                        if (linie.Contains("Adresa: "))
                        {
                            adresa = linie.Replace("Adresa: ", string.Empty).Trim();
                            //itm.SubItems.Add(adresa);
                        }

                        if (linie.Contains("Parola: "))
                        {
                            parola = linie.Replace("Parola: ", string.Empty).Trim();
                        }

                        if (linie.Contains("Data de nastere: "))
                        {
                            dataNastere = linie.Replace("Data de nastere: ", string.Empty).Trim();
                        }

                        if (linie.Contains("Sex: "))
                        {
                            sex = linie.Replace("Sex: ", string.Empty).Trim();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                sr.Close();
                Clienti client = new Clienti( nume, prenume, nrTelefon, email, adresa, parola, "Client", dataNastere, "NA");
                id++;
                listaClienti.Add(client);
            }

            listaClienti.Add(new Clienti());

            foreach (Clienti c in listaClienti)
            {
                ListViewItem itm = new ListViewItem(c.Nume);
                itm.SubItems.Add(c.NumarTelefon.ToString());
                itm.SubItems.Add(c.Email);
                itm.SubItems.Add(c.Adresa);
                itm.SubItems.Add(c.Sex.ToString());
                itm.SubItems.Add(c.DataNastere.ToString());

                listView1.Items.Add(itm);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            pdPrint();
        }

        private void pdPrint()
        {
            PrintDocument PrintDocument = new PrintDocument();
            PrintDocument.PrintPage += (object sender, PrintPageEventArgs e) =>
            {
                Font font = new Font("Arial", 12);
                float offset = e.MarginBounds.Top;
                foreach (ListViewItem Item in listView1.Items)
                {
                    // The 5.0f is to add a small space between lines
                    offset += (font.GetHeight() + 5.0f);
                    PointF location = new System.Drawing.PointF(e.MarginBounds.Left, offset);
                    //e.Graphics.DrawString(Item.Text, font, Brushes.Black, location);
                    if (Item.SubItems[2].Text != "NA")
                        e.Graphics.DrawString(Item.Text, font, Brushes.Black, location);
                }
            };
            PrintDocument.Print();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PrintDocument pd = new PrintDocument();
            //pd.PrintPage += new PrintPageEventHandler(pdPrint);
            //PrintPreviewDialog dlg = new PrintPreviewDialog();
            //dlg.Document = pd;
            //dlg.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "SELECT Nume, Numar_de_Telefon, Email, Adresa, Sex, Data_de_Nastere FROM Clienti";

                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem itm = new ListViewItem(reader["Nume"].ToString());
                    itm.SubItems.Add(reader["Numar_de_Telefon"].ToString());
                    itm.SubItems.Add(reader["Email"].ToString());
                    itm.SubItems.Add(reader["Adresa"].ToString());
                    itm.SubItems.Add(reader["Sex"].ToString());
                    itm.SubItems.Add(reader["Data_de_Nastere"].ToString());
                    listView1.Items.Add(itm);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
            }
        }

    }
}

