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
        Clienti client;
        public UserControlAbMeu()
        {
            InitializeComponent();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Abonamente.accdb";
            incarca_date();
        }

        public UserControlAbMeu(Clienti client) : base()
        {
            this.client = client.Clone();
        }

        private void UserControlAbMeu_Load(object sender, EventArgs e)
        {
            //incarca_date();
        }

        private void incarca_date()
        {
            //string numePrenume = client.Nume + " " + client.Prenume;
            listView1.Items.Clear();
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "SELECT NumeAbonament, PretAbonament, InternetAbonament, MinuteInternationale, SMS, MinuteNationale, AreNetNelimitat FROM Abonamente";

                //"SELECT f.Nume_Client, a.AreNetNelimitat, a.MinuteInternationale, a.MinuteNationale, a.InternetAbonament, a.NumeAbonament, " +
                //"a.PretAbonament, a.SMS FROM Abonamente a, Facturi f WHERE a.NumeAbonament = f.Nume_Abonament AND f.Nume_Client LIKE '" + numePrenume + "'";


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
