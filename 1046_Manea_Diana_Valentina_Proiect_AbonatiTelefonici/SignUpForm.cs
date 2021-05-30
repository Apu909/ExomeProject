using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;
using System.Data.OleDb;

namespace _1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici
{
    public partial class SignUpForm : Form
    {
        string connString;

        public SignUpForm()
        {
            InitializeComponent();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Clienti.accdb";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var selectat = gbUtilizator.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Name;
            if(selectat == "Client")
            {
                String nume = tbNume.Text;
                String prenume = tbPrenume.Text;
                String nrTel = tbNrTel.Text;
                String email = tbEmail.Text;
                String adresa = tbAdresa.Text;
                String parola = tbParola.Text;
                String dataNastere = dateTimePicker1.Text;
                String tipUt = selectat;
                var sex = gbSex.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Name;
                Clienti nou = new Clienti(nume, prenume, nrTel, email, adresa, parola, dataNastere, tipUt, sex);
                MessageBox.Show(nou.ToString());
            }
            else if(selectat == "Companie")
            {

            }
        }

        private void btnCreeaza_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                bool isValid = true;
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;

                comanda.CommandText = "SELECT MAX(Id) FROM Clienti";
                int cod = Convert.ToInt32(comanda.ExecuteScalar());
                cod++;

                comanda.CommandText = "INSERT INTO Clienti VALUES(?,?,?,?,?,?,?,?,?,?)";

                comanda.Parameters.Add("Id", OleDbType.Integer).Value = Convert.ToInt32(cod);

                if (!(string.IsNullOrWhiteSpace(tbNume.Text)))
                    comanda.Parameters.Add("Nume", OleDbType.Char, 20).Value = tbNume.Text;
                else
                {
                    isValid = false;
                    MessageBox.Show("Introduceti numele!");
                }

                if (!string.IsNullOrWhiteSpace(tbPrenume.Text))
                    comanda.Parameters.Add("Prenume", OleDbType.Char, 20).Value = tbPrenume.Text;
                else
                {
                    MessageBox.Show("Introduceti prenumele!");
                    isValid = false;
                }

                if (string.IsNullOrWhiteSpace(tbNrTel.Text))
                {
                    MessageBox.Show("Introduceti numarul de telefon!");
                    isValid = false;
                }
                else if (tbNrTel.Text.Length != 10)
                {
                    MessageBox.Show("Numarul de telefon trebuie sa fie compus din 10 cifre!");
                    isValid = false;
                }
                else if (!areDoarNumere(tbNrTel.Text))
                {
                    MessageBox.Show("Numarul de telefon trebuie sa fie compus doar din cifre!");
                    isValid = false;
                }
                else
                {
                    comanda.Parameters.Add("Numar_de_Telefon", OleDbType.Char, 20).Value = tbNrTel.Text;
                }

                if (!(string.IsNullOrWhiteSpace(tbEmail.Text)))
                    comanda.Parameters.Add("Email", OleDbType.Char, 20).Value = tbEmail.Text;
                else
                {
                    MessageBox.Show("Introduceti emailul!");
                    isValid = false;
                }

                if (!(string.IsNullOrWhiteSpace(tbAdresa.Text)))
                    comanda.Parameters.Add("Adresa", OleDbType.Char, 20).Value = tbAdresa.Text;
                else
                {
                    MessageBox.Show("Introduceti adresa!");
                    isValid = false;
                }

                var selectat = gbUtilizator.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Name;
                comanda.Parameters.Add("Tip", OleDbType.Char, 20).Value = selectat.ToString();
                comanda.Parameters.Add("Data_de_Nastere", OleDbType.Char, 50).Value = dateTimePicker1.Text;
                var sex = gbSex.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Name;
                comanda.Parameters.Add("Sex", OleDbType.Char, 20).Value = sex.ToString();

                if (!(string.IsNullOrWhiteSpace(tbParola.Text)))
                    comanda.Parameters.Add("Parola", OleDbType.Char, 20).Value = tbParola.Text;
                else
                {
                    MessageBox.Show("Introduceti parola");
                    isValid = false;
                }

                if (tbParola.Text != tbConfParola.Text)
                {
                    MessageBox.Show("Parolele nu se potrivesc!");
                    isValid = false;
                }

                if (isValid)
                {
                    comanda.ExecuteNonQuery();
                    MessageBox.Show("Date salvate cu succes! Clietul a fost adaugat.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
                tbNume.Clear();
                tbPrenume.Clear();
                tbNrTel.Clear();
                tbEmail.Clear();
                tbAdresa.Clear();
                tbParola.Clear();
                tbConfParola.Clear();
            }
        }

        public bool esteValid(string mail)
        {
            try
            {
                MailAddress ma = new MailAddress(mail);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool areDoarNumere(string s)
        {
            foreach(char c in s)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            StreamWriter sw;
            sw = new StreamWriter(Application.StartupPath + "\\Clienti_Companii\\" + tbNume.Text + " " + tbPrenume.Text + ".txt");

            try
            {
                bool isValid = true;

                if (!(string.IsNullOrWhiteSpace(tbNume.Text)))
                    sw.WriteLine("Nume: " + tbNume.Text);
                else
                {
                    isValid = false;
                    MessageBox.Show("Introduceti numele!");
                }


                if (!string.IsNullOrWhiteSpace(tbPrenume.Text))
                    sw.WriteLine("Prenume: " + tbPrenume.Text);
                else
                {
                    MessageBox.Show("Introduceti prenumele!");
                    isValid = false;
                }


                if (string.IsNullOrWhiteSpace(tbNrTel.Text))
                {
                    MessageBox.Show("Introduceti numarul de telefon!");
                    isValid = false;
                }
                else if(tbNrTel.Text.Length != 10)
                {
                    MessageBox.Show("Numarul de telefon trebuie sa fie compus din 10 cifre!");
                    isValid = false;
                }
                else if (!areDoarNumere(tbNrTel.Text))
                {
                    MessageBox.Show("Numarul de telefon trebuie sa fie compus doar din cifre!");
                    isValid = false;
                }
                else
                {
                    sw.WriteLine("Numar de telefon: " + tbNrTel.Text);
                }
                    

                if (!(string.IsNullOrWhiteSpace(tbEmail.Text)))
                    sw.WriteLine("Email: " + tbEmail.Text);
                else
                {
                    MessageBox.Show("Introduceti emailul!");
                    isValid = false;
                }


                if (!(string.IsNullOrWhiteSpace(tbAdresa.Text)))
                    sw.WriteLine("Adresa: " + tbAdresa.Text);
                else
                {
                    MessageBox.Show("Introduceti adresa!");
                    isValid = false;
                }

                if (!(string.IsNullOrWhiteSpace(tbParola.Text)))
                    sw.WriteLine("Parola: " + tbParola.Text);
                else
                {
                    MessageBox.Show("Introduceti parola");
                    isValid = false;
                }

                if (tbParola.Text != tbConfParola.Text)
                {
                    MessageBox.Show("Parolele nu se potrivesc!");
                    isValid = false;
                }


                sw.WriteLine("Data de nastere: " + dateTimePicker1.Text);
                var selectat = gbUtilizator.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Name;
                sw.WriteLine("Tip Utilizator: " + selectat);

                var selectat2 = gbSex.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Name;
                sw.WriteLine("Sex: " + selectat2);
                sw.Close();

                if (isValid)
                {
                    MessageBox.Show("Date salvate cu succes!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void label2_Click(object sender, EventArgs e)
        {
            string fileName = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
            }

            if(fileName != "")
            {
                StreamReader sr = new StreamReader(fileName);
                string linie = null;

                while((linie = sr.ReadLine()) != null)
                {
                    try
                    {


                        if(linie.Contains("Nume: "))
                        {
                            tbNume.Text = linie.Replace("Nume: ", string.Empty).Trim();
                        }


                        if (linie.Contains("Prenume: "))
                        {
                            tbPrenume.Text = linie.Replace("Prenume: ", string.Empty).Trim();
                            Console.WriteLine(tbPrenume.Text);
                        }

                        if (linie.Contains("Numar de telefon: "))
                        {
                            tbNrTel.Text = linie.Replace("Numar de telefon: ", string.Empty).Trim();
                        }

                        if (linie.Contains("Email: "))
                        {
                            tbEmail.Text = linie.Replace("Email: ", string.Empty).Trim();
                        }

                        if (linie.Contains("Adresa: "))
                        {
                            tbAdresa.Text = linie.Replace("Adresa: ", string.Empty).Trim();
                        }

                        if (linie.Contains("Parola: "))
                        {
                            tbParola.Text = linie.Replace("Parola: ", string.Empty).Trim();
                        }
                    }
                catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                sr.Close();
                MessageBox.Show("Date incarcate!");

            }
        }

        private void tbPrenume_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPrenume.Text))
            {
                MessageBox.Show("Introduceti prenumele!");
            }
        }

        private void lblCurata_Click(object sender, EventArgs e)
        {
            tbNume.Clear();
            tbPrenume.Clear();
            tbNrTel.Clear();
            tbEmail.Clear();
            tbAdresa.Clear();
            tbParola.Clear();
            tbConfParola.Clear();
        }

        private void SignUpForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "S")
            {
                label3_Click(sender, new EventArgs());
            }

        else if(e.Control && e.KeyCode.ToString() == "I")
            {
                label2_Click(sender, new EventArgs());
            }
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            if (!(label4.Visible))
            {
                label4.Show();
            }
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            if (label4.Visible)
            {
                label4.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }

        private void tbNume_Enter(object sender, EventArgs e)
        {
            if(tbNume.Text == "Nume")
            {
                tbNume.Text = "";
            }
        }

        private void tbNume_Leave(object sender, EventArgs e)
        {
            if (tbNume.Text == "")
            {
                tbNume.Text = "Nume";
            }
        }

        private void tbPrenume_Enter(object sender, EventArgs e)
        {
            if (tbPrenume.Text == "Prenume")
            {
                tbPrenume.Text = "";
            }
        }

        private void tbPrenume_Leave(object sender, EventArgs e)
        {
            if (tbPrenume.Text == "")
            {
                tbPrenume.Text = "Prenume";
            }
        }

        private void tbNrTel_Enter(object sender, EventArgs e)
        {
            if(tbNrTel.Text == "Numar de telefon")
            {
                tbNrTel.Text = "";
            }
        }

        private void tbNrTel_Leave(object sender, EventArgs e)
        {
            if (tbNrTel.Text == "")
            {
                tbNrTel.Text = "Numar de telefon";
            }
        }

        private void tbEmail_Enter(object sender, EventArgs e)
        {
            if (tbEmail.Text == "Email")
            {
                tbEmail.Text = "";
            }
        }

        private void tbEmail_Leave(object sender, EventArgs e)
        {
            if (tbEmail.Text == "")
            {
                tbEmail.Text = "Email";
            }
        }

        private void tbAdresa_Enter(object sender, EventArgs e)
        {
            if(tbAdresa.Text == "Adresa")
            {
                tbAdresa.Text = "";
            }
        }

        private void tbAdresa_Leave(object sender, EventArgs e)
        {
            if (tbAdresa.Text == "")
            {
                tbAdresa.Text = "Adresa";
            }
        }

        private void tbParola_Enter(object sender, EventArgs e)
        {
            if(tbParola.Text == "Parola")
            {
                tbParola.Text = "";
            }
        }

        private void tbParola_Leave(object sender, EventArgs e)
        {
            if (tbParola.Text == "")
            {
                tbParola.Text = "Parola";
            }
        }

        private void tbConfParola_Enter(object sender, EventArgs e)
        {
            if(tbConfParola.Text == "Confirmare parola")
            {
                tbConfParola.Text = "";
            }
        }

        private void tbConfParola_Leave(object sender, EventArgs e)
        {
            if (tbConfParola.Text == "")
            {
                tbConfParola.Text = "Confirmare parola";
            }
        }
    }
}
