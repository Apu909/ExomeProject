using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace _1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici
{
    public partial class UCClientAbonamente : UserControl
    {
        string connString;
        string connString2;
        UCab ucAbonament = new UCab();
        List<UCab> listaAb = new List<UCab>();
        Clienti client = new Clienti();
        List<UCab> listaAbSelectate = new List<UCab>();
        UCab selectat;
        public UCClientAbonamente()
        {
            InitializeComponent();
            //connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Abonamente.accdb";
            connString2 = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Clienti.accdb";
            incarca_date();
            AutoScrollMinSize = new Size(0, 1);
            AutoScroll = true;
            adaugaInListaAbonamente();
        }

        public UCClientAbonamente(Clienti client) : this()
        {
            this.client = client;
            extrage_date_clienti();
        }

        private void incarca_date()
        {
            String areNetNelim;
            String minInt;
            String minNat;
            String netAb;
            String numeAb;
            String pretAb;
            String smsAb;
            int x = 10;
            int y = 100;
            OleDbConnection conexiune = new OleDbConnection(connString2);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.CommandText = "SELECT * FROM Abonamente";
                comanda.Connection = conexiune;

                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    areNetNelim = reader["AreNetNelimitat"].ToString();
                    minInt = reader["MinuteInternationale"].ToString();
                    minNat = reader["MinuteNationale"].ToString();
                    netAb = reader["InternetAbonament"].ToString();
                    numeAb = reader["NumeAbonament"].ToString();
                    pretAb = reader["PretAbonament"].ToString();
                    smsAb = reader["SMS"].ToString();

                    UCab abonament = new UCab(areNetNelim, minInt, minNat, netAb, numeAb, pretAb, smsAb);
                    listaAb.Add(abonament);
                }

                foreach (var i in listaAb)
                {
                    if (x >= 500)
                    {
                        y += 150;
                        x = 10;
                    }
                    i.Location = new Point(x, y);
                    i.Dock = DockStyle.None;
                    this.Controls.Add(i);
                    x += 150;
                }
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

        private void adaugaInListaAbonamente()
        {
            for (int i = 0; i < listaAb.Count; i++)
            {
                listaAb[i].Click += adaugaAb_ButtonClicked;
            }
        }

        private int counter = 0;
        void adaugaAb_ButtonClicked(object sender, EventArgs e)
        {
            if(counter >= 1)
            {
                ((UCab)sender).BackColor = Color.FromArgb(40, 41, 50);
                foreach (var i in listaAb)
                {
                    if (sender as UCab == i)
                    {
                        selectat = i;
                    }
                }
                counter = 0;
            }
            else
            {
                ((UCab)sender).BackColor = Color.FromArgb(40, 45, 55);
                foreach (var i in listaAb)
                {
                    if (sender as UCab == i)
                    {
                        selectat = i;
                    }
                }
                counter++;
            }
        }

        private void btnAbMeu_Click(object sender, EventArgs e)
        {
            //adauga abonamentul selectat in cosul de cumparaturi
            listaAbSelectate.Add(selectat);
            MessageBox.Show("Adaugat in cos :D");
            foreach (var i in listaAbSelectate)
            {
                client.ListaAb.Add((TipAbonament)i);
            }

            foreach (var i in client.ListaAb)
            {
                incarca_facturi(client, (TipAbonament)selectat);
            }
        }

        private void incarca_facturi(Clienti cln, TipAbonament tip)
        {
            OleDbConnection conexiune = new OleDbConnection(connString2);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;

                comanda.CommandText = "INSERT INTO Facturi VALUES(?,?,?,?,?,?,?,?,?)";

                comanda.Parameters.Add("Nume_Client", OleDbType.Char, 20).Value = cln.Nume + " " + cln.Prenume; ;
                comanda.Parameters.Add("Numar_de_Telefon", OleDbType.Char, 20).Value = cln.NumarTelefon;
                comanda.Parameters.Add("Email", OleDbType.Char, 20).Value = cln.Email;
                comanda.Parameters.Add("Adresa", OleDbType.Char, 20).Value = cln.Adresa;
                comanda.Parameters.Add("Nume_Abonament", OleDbType.Char, 20).Value = tip.Nume;
                comanda.Parameters.Add("Pret_Abonament", OleDbType.Char, 20).Value = tip.Pret.ToString();
                comanda.Parameters.Add("Nume_Extraoptiune", OleDbType.Char, 20).Value = "NumeExtraoptiune";
                comanda.Parameters.Add("Pret_Extraoptiune", OleDbType.Char, 20).Value = "PretExtraoptiune";
                comanda.Parameters.Add("Achitata", OleDbType.Char, 20).Value = "Nu";


                comanda.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
            }
            MessageBox.Show("Abonamentul a fost adaugat in baza de date aferent contului curent.");
        }

        private void extrage_date_clienti()
        {
            String nrTel;
            String email;
            String adresa;
            String numePrenume = client.Nume + client.Prenume;
            OleDbConnection conexiune = new OleDbConnection(connString2);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.CommandText = "SELECT * FROM Clienti WHERE Nume LIKE '" + client.Nume + "'" ;
                comanda.Connection = conexiune;

                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    nrTel = reader["Numar_de_Telefon"].ToString();
                    email = reader["Email"].ToString();
                    adresa = reader["Adresa"].ToString();

                    Clienti c = new Clienti(client.Nume, client.Prenume, nrTel, email, adresa, "NA", "NA", "NA", "NA");
                    client = c.Clone();
                }
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
