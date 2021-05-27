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
    public partial class UCGraficProfit : UserControl
    {
        string connString;
        Clienti client;
        public UCGraficProfit()
        {
            InitializeComponent();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Clienti.accdb";
        }


        public UCGraficProfit(Clienti client) : base()
        {
            this.client = client.Clone();
        }

        private void btnAbMeu_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "SELECT Nume_Abonament, Pret_Abonament FROM Facturi";

                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    chart1.Series["Pret"].Points.AddXY(reader["Nume_Abonament"].ToString(), reader["Pret_Abonament"].ToString());
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

