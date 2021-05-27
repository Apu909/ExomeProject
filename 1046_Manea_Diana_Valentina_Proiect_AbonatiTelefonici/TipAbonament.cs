using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici
{
    public class TipAbonament : ICloneable, IComparable, IEnumerable<TipAbonament>
    {
        String numeAbonament;
        float pretAbonament;
        int internet;
        int minuteNationale;
        int sms;
        int minuteInternationale;
        int areNetNelimitat;

        public TipAbonament()
        {
            this.numeAbonament = "NA";
            this.pretAbonament = 0.0f;
            this.internet = 0;
            this.minuteNationale = 0;
            this.sms = 0;
            this.minuteInternationale = 0;
            this.areNetNelimitat = 0;
        }

        public TipAbonament(string nume, float pret)
        {
            this.numeAbonament = nume;
            this.pretAbonament = pret;
            this.internet = 0;
            this.minuteNationale = 0;
            this.sms = 0;
            this.minuteInternationale = 0;
            this.areNetNelimitat = 0;
        }

        public TipAbonament(String nume, 
            float pret, int net, int minuteNat,
            int sms2, int minuteInt, int areNetNelim)
        {
            this.numeAbonament = nume;
            this.pretAbonament = pret;
            this.internet = net;
            this.minuteNationale = minuteNat;
            this.sms = sms2;
            this.minuteInternationale = minuteInt;
            this.areNetNelimitat = areNetNelim;
        }

        public TipAbonament(TipAbonament ta)
        {
            this.numeAbonament = ta.numeAbonament;
            this.pretAbonament = ta.pretAbonament;
            this.internet = ta.internet;
            this.minuteNationale = ta.minuteNationale;
            this.sms = ta.sms;
            this.minuteInternationale = ta.minuteInternationale;
            this.areNetNelimitat = ta.areNetNelimitat;
        }

        public String Nume
        {
            get { return this.numeAbonament; }
            set { if (value != null) this.numeAbonament = value; }
        }

        public float Pret
        {
            get { return this.pretAbonament; }
            set { if (value > 0) this.pretAbonament = value; }
        }

        public int Internet
        {
            get { return this.internet; }
            set { if (value > 0) this.internet = value; }
        }

        public int MinuteNationale
        {
            get { return this.minuteNationale; }
            set { if (value > 0) this.minuteNationale = value; }
        }

        public int SMS
        {
            get { return this.sms; }
            set { if (value > 0) this.sms = value; }
        }

        public int MinuteInternationale
        {
            get { return this.minuteInternationale; }
            set { if (value > 0) this.minuteInternationale = value; }
        }

        public int AreNetNelimitat
        {
            get { return this.areNetNelimitat; }
            set { if (value == 0 || value == 1) this.areNetNelimitat = value; }
        }

        public static TipAbonament operator > (TipAbonament ta1, TipAbonament ta2)
        {
            return ta1.Pret > ta2.Pret ? ta1 : ta2;
        }

        public static TipAbonament operator <(TipAbonament ta1, TipAbonament ta2)
        {
            return ta1.Pret < ta2.Pret ? ta1 : ta2;
        }

        public static TipAbonament operator ++(TipAbonament ta)
        {
            ta.Pret += 10;
            return ta;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public TipAbonament Clone()
        {
            return (TipAbonament)this.MemberwiseClone();
        }

        public int CompareTo(object obj)
        {
            if(obj != null && obj.GetType() != GetType())
            {
                throw new ArgumentException(string.Format("Obiectul trebuie sa fie de tip {0}", GetType()));
            }
            return CompareTo((TipAbonament)obj);
        }

        public int CompareTo(TipAbonament ta)
        {
            if(object.ReferenceEquals(this, ta))
            {
                return 0;
            }
            else if(ta == null)
            {
                return 1;
            }

            var cmp = this.Pret.CompareTo(ta.Pret);
            if(cmp != 0)
            {
                return cmp;
            }

            cmp = this.Nume.CompareTo(ta.Nume);
            if(cmp != 0)
            {
                return cmp;
            }

            return 0;
        }

        public List<TipAbonament> AdaugaAbonament(List<TipAbonament> listaAb, TipAbonament abNou)
        {
            listaAb.Add(abNou);
            return listaAb;
        }

        public void StergeAbonament(List<TipAbonament> listaAb, TipAbonament abNou)
        {
            listaAb.RemoveAll(item => ReferenceEquals(abNou, item));
        }

        IEnumerator<TipAbonament> IEnumerable<TipAbonament>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Abonamentul are urmatoarele detalii: " + "nume: " + Nume + ", pret: " + Pret.ToString() + ", minute nationale: " + MinuteNationale.ToString() + ", sms: " + SMS.ToString() + ", minute internationale" 
                + MinuteInternationale.ToString() + ", are net nelimitat: " + AreNetNelimitat.ToString();
        }

        public static explicit operator TipAbonament(UCab ucab)
        {
            TipAbonament tip = new TipAbonament();
            tip.numeAbonament = ucab.NumeAb;
            tip.pretAbonament = float.Parse(ucab.PretAb);
            tip.internet = int.Parse(ucab.NetAb);
            tip.minuteInternationale = int.Parse(ucab.MinInt);
            tip.sms = int.Parse(ucab.SmsAb);
            tip.minuteNationale = int.Parse(ucab.MinNat);
            tip.areNetNelimitat = int.Parse(ucab.AreNetNelim);

            return tip;
        }
    }
}
