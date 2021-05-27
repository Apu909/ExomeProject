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
    public partial class UCclientiPlataFacturi : UserControl
    {
        string connString;
        Clienti client;
        public UCclientiPlataFacturi()
        {
            InitializeComponent();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Clienti.accdb";
            incarcaDate();
            if(listView1.FocusedItem != null)
            {
                listView1.FocusedItem.Focused = false;
            }
        }

        public UCclientiPlataFacturi(Clienti client) : base()
        {
            this.client = client.Clone();
            incarcaDate();
        }

        private void incarcaDate()
        {
            listView1.Items.Clear();

            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "SELECT Nume_Client, Numar_de_Telefon, Email, Adresa, Nume_Abonament, Pret_Abonament FROM Facturi";

                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem itm = new ListViewItem(reader["Nume_Client"].ToString());
                    itm.SubItems.Add(reader["Numar_de_Telefon"].ToString());
                    itm.SubItems.Add(reader["Email"].ToString());
                    itm.SubItems.Add(reader["Adresa"].ToString());
                    itm.SubItems.Add(reader["Nume_Abonament"].ToString());
                    itm.SubItems.Add(reader["Pret_Abonament"].ToString());
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

        private void achitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                var item = listView1.SelectedItems[0];
                MessageBox.Show(item.ToString());
            }
            MessageBox.Show("Factura achitata. :D");
        }


        private void btnPlata_Click(object sender, EventArgs e)
        {


            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                foreach (ListViewItem itm in listView1.SelectedItems)
                {
                    listView1.Items.Remove(itm);
                    comanda.CommandText = "UPDATE Facturi SET Achitata='Da' WHERE Nume_Client='" + itm.SubItems[0].Text + "'";
                    comanda.ExecuteNonQuery();
                }
                MessageBox.Show("Factura achitata. :D");
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var firstSelectedItem = listView1.SelectedItems[0];
            MessageBox.Show(firstSelectedItem.ToString());
        }
    }
}
