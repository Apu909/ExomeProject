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
    public partial class UCFacturiCompanie : UserControl
    {
        string connString;
        public UCFacturiCompanie()
        {
            InitializeComponent();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Clienti.accdb";
            incarca_date();
        }

        private void incarca_date()
        {
            listView1.Items.Clear();
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "SELECT Nume_Client, Numar_de_Telefon, Email, Adresa, Nume_Abonament, Pret_Abonament, Achitata FROM Facturi";

                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem itm = new ListViewItem(reader["Nume_Client"].ToString());
                    itm.SubItems.Add(reader["Numar_de_Telefon"].ToString());
                    itm.SubItems.Add(reader["Email"].ToString());
                    itm.SubItems.Add(reader["Adresa"].ToString());
                    itm.SubItems.Add(reader["Nume_Abonament"].ToString());
                    itm.SubItems.Add(reader["Pret_Abonament"].ToString());
                    itm.SubItems.Add(reader["Achitata"].ToString());
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
