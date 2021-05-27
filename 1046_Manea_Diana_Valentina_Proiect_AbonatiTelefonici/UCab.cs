using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici
{
    public partial class UCab : UserControl
    {
        private String areNetNelim;
        private String minInt;
        private String minNat;
        private String netAb;
        private String numeAb;
        private String pretAb;
        private String smsAb;
        TipAbonament tip;

        public UCab()
        {
            InitializeComponent();
        }

        public UCab(String areNetNelim, String minInt, String minNat, String netAb, String numeAb, String pretAb, String smsAb) : this()
        {
            this.tbAreNetNelim.Text = areNetNelim;
            this.tbMinInt.Text = minInt;
            this.tbMinNat.Text = minNat;
            this.tbNetAb.Text = netAb;
            this.tbNumeAb.Text = numeAb;
            this.tbPretAb.Text = pretAb;
            this.tbSMSab.Text = smsAb;

            this.areNetNelim = areNetNelim;
            this.minInt = minInt;
            this.minNat = minNat;
            this.netAb = netAb;
            this.numeAb= numeAb;
            this.pretAb = pretAb;
            this.smsAb = smsAb;
        }

        public String AreNetNelim
        {
            get { return this.areNetNelim; }
            set { this.areNetNelim = value; }
        }

        public String MinInt
        {
            get { return this.minInt; }
            set { this.minInt = value; }
        }
        public String MinNat
        {
            get { return this.minNat; }
            set { this.minNat = value; }
        }
        public String NetAb
        {
            get { return this.netAb; }
            set { this.netAb = value; }
        }
        public String NumeAb
        {
            get { return this.numeAb; }
            set { this.numeAb = value; }
        }
        public String PretAb
        {
            get { return this.pretAb; }
            set { this.pretAb = value; }
        }
        public String SmsAb
        {
            get { return this.smsAb; }
            set { this.smsAb = value; }
        }

        public TipAbonament Tip
        {
            get { tip = new TipAbonament(NumeAb, Convert.ToInt32(PretAb), Convert.ToInt32(netAb), Convert.ToInt32(minNat), Convert.ToInt32(smsAb), Convert.ToInt32(minInt), Convert.ToInt32(areNetNelim));  return tip; }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbPretAb_TextChanged(object sender, EventArgs e)
        {

        }

        public String Name
        {
            get { return tbNumeAb.Text; }
            set { }
        }

        public event EventHandler MyClick;
        private void OnMyClick(object sender, EventArgs e)
        {
            if(this.MyClick != null)
            {
                this.MyClick(this, EventArgs.Empty);
            }
        }

        public static explicit operator UCab(TipAbonament tip)
        {
            UCab ucab = new UCab();
            ucab.NumeAb = tip.Nume.ToString();
            ucab.PretAb = tip.Pret.ToString();
            ucab.NetAb = tip.Internet.ToString();
            ucab.MinInt = tip.MinuteInternationale.ToString();
            ucab.SmsAb = tip.SMS.ToString();
            ucab.MinNat = tip.MinuteNationale.ToString();
            ucab.AreNetNelim = tip.AreNetNelimitat.ToString();

            return ucab;
        }
    }
}
