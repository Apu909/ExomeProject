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
    public partial class LoginForm : Form
    {
        string connString;
        Clienti client;

        public LoginForm()
        {
            InitializeComponent();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Clienti.accdb";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String nume;
            String prenume;
            String parola;
            String tip;
            bool isValid = false;

            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.CommandText = "SELECT * FROM Clienti";
                comanda.Connection = conexiune;

                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    nume = reader["Nume"].ToString();
                    prenume = reader["Prenume"].ToString();
                    parola = reader["Parola"].ToString();
                    tip = reader["Tip"].ToString();
                    client = new Clienti(nume, prenume, parola, tip);

                    string numePrenume = nume + prenume;
                    if (tbUsername.Text == numePrenume)
                    {
                        if (tbUsername.Text == numePrenume && tbPassword.Text == parola)
                        {
                            isValid = true;
                            if (tip == "Companie")
                            {
                                new FormCompanie(client).Show();
                                this.Hide();
                            }
                            else if (tip == "Client")
                            {
                                new Form1(client).Show();
                                this.Hide();
                            }
                        }
                    }
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


            if (isValid == false)
            {
                MessageBox.Show("Username sau parola invalida.");
                tbUsername.Clear();
                tbPassword.Clear();
                tbUsername.Focus();
            }
        }

        private void lbCurata_Click(object sender, EventArgs e)
        {
            tbUsername.Clear();
            tbPassword.Clear();
            tbUsername.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCreareCont_Click(object sender, EventArgs e)
        {
            new SignUpForm().Show();
            this.Hide();
        }

        private void tbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbPassword.Focus();
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }
    }
}
