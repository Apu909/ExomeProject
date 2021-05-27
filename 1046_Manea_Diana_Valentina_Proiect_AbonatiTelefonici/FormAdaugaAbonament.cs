using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici
{
    public partial class FormAdaugaAbonament : Form
    {
        string connString;
        public FormAdaugaAbonament()
        {
            InitializeComponent();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Abonamente.accdb";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAbMeu_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;

                comanda.CommandText = "SELECT MAX(pret) FROM Abonamente";

                comanda.CommandText = "INSERT INTO Abonamente VALUES(?,?,?,?,?,?,?)";
                comanda.Parameters.Add("NumeAbonament", OleDbType.Char, 20).Value = tbNumeAb.Text;
                comanda.Parameters.Add("PretAbonament", OleDbType.Integer).Value = Convert.ToInt32(tbPretAb.Text);
                comanda.Parameters.Add("InternetAbonament", OleDbType.Integer).Value = Convert.ToInt32(tbNetAb.Text);
                comanda.Parameters.Add("MinuteNationale", OleDbType.Integer).Value = Convert.ToInt32(tbMinNatAb.Text);
                comanda.Parameters.Add("SMS", OleDbType.Integer).Value = Convert.ToInt32(tbSMSab.Text);
                comanda.Parameters.Add("MinuteInternationale", OleDbType.Integer).Value = Convert.ToInt32(tbMinIntAb.Text);
                comanda.Parameters.Add("AreNetNelimitat", OleDbType.Integer).Value = Convert.ToInt32(tbAreNetNelim.Text);

                comanda.ExecuteNonQuery();

                MessageBox.Show("Abonamentul a fost adaugat.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
                tbNumeAb.Clear();
                tbPretAb.Clear();
                tbNetAb.Clear();
                tbMinNatAb.Clear();
                tbSMSab.Clear();
                tbMinIntAb.Clear();
                tbAreNetNelim.Clear();
            }
        }
    }
}
