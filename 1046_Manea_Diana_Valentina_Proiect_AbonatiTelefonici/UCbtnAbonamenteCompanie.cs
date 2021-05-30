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
    public partial class UCbtnAbonamenteCompanie : UserControl
    {
        string connString;
        UCab ucAbonament = new UCab();
        List<UCab> listaAb = new List<UCab>();
        List<int> hoverId = new List<int>();

        UCab selectat;
        public UCbtnAbonamenteCompanie()
        {
            InitializeComponent();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Abonamente.accdb";
            incarca_date();
            AutoScrollMinSize = new Size(0, 1);
            AutoScroll = true;
            pictureBox1.Visible = false;
            pictureBox1.Refresh();
        }

        private void UCbtnAbonamenteCompanie_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
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
            OleDbConnection conexiune = new OleDbConnection(connString);
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
                x = 10;
                y = 100;
                int j = 0;
                foreach (var i in listaAb)
                {
                    if(x >= 500) {
                        y += 150;
                        x = 10;
                    }
                    i.Location = new Point(x, y);
                    i.Dock = DockStyle.None;
                    this.Controls.Add(i);
                    x += 150;
                    i.Tag = j;
                    hoverId.Add((int)i.Tag);
                    j++;
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btnAbMeu_Click(object sender, EventArgs e)
        {
            new FormAdaugaAbonament().Show();
        }

        private void afiseazaAbonamente()
        {
            try
            {
                foreach (var i in listaAb)
                {
                    this.Controls.Remove(i);
                    i.Dispose();
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            afiseazaAbonamente();
            incarca_date();
        }

        private int clickCounter = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if(clickCounter >= 1)
            {
                pictureBox1.Visible = false;
                foreach (var i in listaAb)
                {
                    ControlExtension.Draggable(i, false);
                }
                clickCounter = 0;
            }
            else
            {
                pictureBox1.Visible = true;
                foreach (var i in listaAb)
                {
                    ControlExtension.Draggable(i, true);
                    selectat = i;
                }
                clickCounter++;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;

                foreach (var itm in listaAb)
                    {
                    if (itm.Bounds.IntersectsWith(pictureBox1.Bounds))
                    {
                        MessageBox.Show("Abonamentul a fost sters din baza de date.");
                        comanda.CommandText = "DELETE FROM Abonamente WHERE NumeAbonament='" + itm.NumeAb + "'";
                        this.Controls.Remove(itm);
                        comanda.ExecuteNonQuery();
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
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
        }
    }
}
