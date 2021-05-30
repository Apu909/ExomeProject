using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace _1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
    (
    int nLeftRect,
    int nTopRect,
    int nRightRect,
    int nBottomRect,
    int nWidthEllipse,
    int nHeightEllipse
    );

        Clienti cln = new Clienti();
        UCclientiPlataFacturi plataFacturi;
        UCClientAbonamente clab;
        //UserControlAbMeu ucAbonamentulMeu = new UserControlAbMeu();
        UserControlAbMeu ucAbonamentulMeu;
        public Form1(Clienti client)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            cln = client.Clone();
            clab = new UCClientAbonamente(cln);
            ucAbonamentulMeu = new UserControlAbMeu(cln);
            plataFacturi = new UCclientiPlataFacturi(cln);
            uCclientiPlataFacturi1.Hide();
            ucAbonamentulMeu.Hide();
            ucClientAbonamente1.Hide();
            plataFacturi.Hide();
            clab.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAbMeu_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnAbMeu.Height;
            pnlNav.Top = btnAbMeu.Top;
            pnlNav.Left = btnAbMeu.Left;
            btnAbMeu.BackColor = Color.FromArgb(49, 47, 74);
            uCclientiPlataFacturi1.Hide();
            ucClientAbonamente1.Hide();
            plataFacturi.Hide();
            clab.Hide();

            ucAbonamentulMeu.Show();
            ucAbonamentulMeu.Location = new Point(300, 100);
            ucAbonamentulMeu.Dock = DockStyle.None;
            this.Controls.Add(ucAbonamentulMeu);
        }

        private void btnExome_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnExome.Height;
            pnlNav.Top = btnExome.Top;
            btnExome.BackColor = Color.FromArgb(49, 47, 74);
        }

        private void btnAbonamente_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnAbonamente.Height;
            pnlNav.Top = btnAbonamente.Top;
            btnAbonamente.BackColor = Color.FromArgb(49, 47, 74);
            uCclientiPlataFacturi1.Hide();
            ucAbonamentulMeu.Hide();
            ucClientAbonamente1.Hide();
            plataFacturi.Hide();

            clab.Show();
            clab.Location = new Point(220, 50);
            clab.Dock = DockStyle.None;
            this.Controls.Add(clab);
        }

        private void btnPlatesteFactura_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnPlatesteFactura.Height;
            pnlNav.Top = btnPlatesteFactura.Top;
            btnPlatesteFactura.BackColor = Color.FromArgb(49, 47, 74);
            ucAbonamentulMeu.Hide();
            ucClientAbonamente1.Hide();
            plataFacturi.Hide();
            clab.Hide();

            uCclientiPlataFacturi1.Show();
            uCclientiPlataFacturi1.Location = new Point(420, 70);
            uCclientiPlataFacturi1.Show();
            this.Controls.Add(uCclientiPlataFacturi1);
        }

        private void btnReincarca_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnReincarca.Height;
            pnlNav.Top = btnReincarca.Top;
            btnReincarca.BackColor = Color.FromArgb(49, 47, 74);
        }

        private void btnOferteSpeciale_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnOferteSpeciale.Height;
            pnlNav.Top = btnOferteSpeciale.Top;
            btnOferteSpeciale.BackColor = Color.FromArgb(49, 47, 74);
        }

        private void btnSetari_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnSetari.Height;
            pnlNav.Top = btnSetari.Top;
            btnSetari.BackColor = Color.FromArgb(49, 47, 74);
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnContact.Height;
            pnlNav.Top = btnContact.Top;
            btnContact.BackColor = Color.FromArgb(49, 47, 74);
        }

        private void btnAjutor_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnAjutor.Height;
            pnlNav.Top = btnAjutor.Top;
            btnAjutor.BackColor = Color.FromArgb(49, 47, 74);
        }

        private void btnAbMeu_Leave(object sender, EventArgs e)
        {
            btnAbMeu.BackColor = Color.FromArgb(40, 45, 55);
        }

        private void btnExome_Leave(object sender, EventArgs e)
        {
            btnExome.BackColor = Color.FromArgb(40, 45, 55);
        }

        private void btnAbonamente_Leave(object sender, EventArgs e)
        {
            btnAbonamente.BackColor = Color.FromArgb(40, 45, 55);
        }

        private void btnPlatesteFactura_Leave(object sender, EventArgs e)
        {
            btnPlatesteFactura.BackColor = Color.FromArgb(40, 45, 55);
        }

        private void btnReincarca_Leave(object sender, EventArgs e)
        {
            btnReincarca.BackColor = Color.FromArgb(40, 45, 55);
        }

        private void btnOferteSpeciale_Leave(object sender, EventArgs e)
        {
            btnOferteSpeciale.BackColor = Color.FromArgb(40, 45, 55);
        }

        private void btnSetari_Leave(object sender, EventArgs e)
        {
            btnSetari.BackColor = Color.FromArgb(40, 45, 55);
        }

        private void btnContact_Leave(object sender, EventArgs e)
        {
            btnContact.BackColor = Color.FromArgb(40, 45, 55);
        }

        private void btnAjutor_Leave(object sender, EventArgs e)
        {
            btnAjutor.BackColor = Color.FromArgb(40, 45, 55);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iesiDinContToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }
    }
}
