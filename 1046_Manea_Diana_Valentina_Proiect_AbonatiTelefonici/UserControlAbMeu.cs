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
    public partial class UserControlAbMeu : UserControl
    {
        string connString;
        List<TipAbonament> listaAb = new List<TipAbonament>();
        Clienti client = new Clienti();
        public UserControlAbMeu()
        {
            InitializeComponent();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Clienti.accdb";
            incarca_date();
        }

        public UserControlAbMeu(Clienti cl)
        {
            InitializeComponent();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Clienti.accdb";
            client = (Clienti)cl.Clone();
            incarca_date();
        }

        private void UserControlAbMeu_Load(object sender, EventArgs e)
        {
        }

        private void incarca_date()
        {
            String numePrenume = client.Nume + " " + client.Prenume;
            listView1.Items.Clear();
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "SELECT f.Nume_Client, f.Nume_Abonament, a.NumeAbonament, a.PretAbonament, a.InternetAbonament, a.MinuteInternationale, a.SMS, a.MinuteNationale," +
                    " a.AreNetNelimitat FROM Abonamente a, Facturi f WHERE f.Nume_Client = '" + numePrenume + "' AND f.Nume_Abonament = a.NumeAbonament; ";


                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem itm = new ListViewItem(reader["NumeAbonament"].ToString());
                    itm.SubItems.Add(reader["PretAbonament"].ToString());
                    itm.SubItems.Add(reader["InternetAbonament"].ToString());
                    itm.SubItems.Add(reader["MinuteInternationale"].ToString());
                    itm.SubItems.Add(reader["SMS"].ToString());
                    itm.SubItems.Add(reader["MinuteNationale"].ToString());
                    itm.SubItems.Add(reader["AreNetNelimitat"].ToString());

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

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(var i in client.ListaAb)
            {
                MessageBox.Show(i.ToString());
            }
        }
    }
}
