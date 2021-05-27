using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici
{
    enum TipBonus
    {
        Altele,
        Internet_pe_mobil,
        Convorbiri_internationale,
        Roaming
    }

    class ExtraOptiuni : TipAbonament, ICloneable, IComparable
    {
        public const TipBonus TIPBONUS_MINIMUM = TipBonus.Altele;
        public const TipBonus TIPBONUS_MAXIMUM = TipBonus.Roaming;

        TipAbonament tipAb;
        TipBonus teo;
        int valabilitate;  //numarul de zile in care extraoptiunea este activa
        String codActivare;

        public ExtraOptiuni(): base()
        {
            tipAb = null;
            teo = 0;
            valabilitate = 0;
            codActivare = "???";
        }

        public ExtraOptiuni(TipAbonament ta, String n, float pret, int net, int minuteNat, int sms2, int minuteInt, int areNetNelim, TipBonus tb, int val, String codA) :
            base(n, pret, net, minuteNat, sms2, minuteInt, areNetNelim)
        {
            this.tipAb = new TipAbonament(ta);
            this.teo = tb;
            this.valabilitate = val;
            this.codActivare = codA;
        }

        public TipBonus TipBonusExtraOptiune
        {
            get { return teo; }
            set { if(value > TIPBONUS_MINIMUM && value < TIPBONUS_MAXIMUM) teo = value; }
        }

        public int Valabilitate
        {
            get { return valabilitate; }
            set { if (value > 10 && value < 31) valabilitate = value; }
        }

        public String CodActivare
        {
            get { return codActivare; }
            set { if (value != null && value.Length == 3) codActivare = value; }
        }


        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public ExtraOptiuni Clone()
        {
            return (ExtraOptiuni)this.MemberwiseClone();
        }

        public int CompareTo(object obj)
        {
            if(obj != null && obj.GetType() != GetType())
            {
                throw new ArgumentException(string.Format("Obiectul trebuie sa fie de tip {0}", GetType()));
            }
            return CompareTo((ExtraOptiuni)obj);
        }

        public int CompareTo(ExtraOptiuni ex)
        {
            if(object.ReferenceEquals(this, ex)){
                return 0;
            }
            else if(ex == null)
            {
                return 1;
            }

            var cmp = this.Pret.CompareTo(ex.Pret);
            if(cmp != 0)
            {
                return cmp;
            }

            cmp = this.Nume.CompareTo(ex.Nume);
            if (cmp != 0)
            {
                return cmp;
            }

            return 0;
        }

        public static ExtraOptiuni operator > (ExtraOptiuni eo1, ExtraOptiuni eo2)
        {
            return eo1.Pret > eo2.Pret ? eo1 : eo2;
        }

        public static ExtraOptiuni operator < (ExtraOptiuni eo1, ExtraOptiuni eo2)
        {
            return eo1.Pret < eo2.Pret ? eo1 : eo2;
        }

        public static ExtraOptiuni operator ++(ExtraOptiuni eo)
        {
            eo.Pret += 10;
            return eo;
        }

        public override string ToString()
        {
            return base.ToString() + ", tip extraoptiune " + TipBonusExtraOptiune.ToString() + ", valabilitate " + Valabilitate.ToString() + ", cod activare " + CodActivare;
        }

        public List<ExtraOptiuni> adaugaExtraOptiune(List<ExtraOptiuni> eo, ExtraOptiuni e)
        {
            eo.Add(e);
            return eo;
        }

        public List<ExtraOptiuni> stergeExtraOptiune(List<ExtraOptiuni> eo, ExtraOptiuni e)
        {
            eo.RemoveAll(item => ReferenceEquals(item, e));
            return eo;
        }
    }
}
