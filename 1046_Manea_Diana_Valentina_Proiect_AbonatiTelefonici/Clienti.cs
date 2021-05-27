using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici
{
    public class Clienti : Utilizator, ICloneable, IComparable
    {
        String dataNastere;
        String sex;
        List<TipAbonament> listaAbonamente = new List<TipAbonament>();

        public Clienti() : base()
        {
            dataNastere = "NA";
            sex = "NA";
        }

        public Clienti(String nume, String prenume, String parola, String tip) : base(nume, prenume, parola, tip)
        {
            dataNastere = "NA";
            sex = "NA";
        }

        public Clienti( String n, String pre, String nr, String e, String a, String p, String tip, String d, String s) : base( n, pre, nr, e, a, p, tip)
        {
            this.dataNastere = d;
            this.sex = s;
        }

        public String DataNastere
        {
            get { return dataNastere; }
            set { if (value != null) dataNastere = value; }
        }

        public String Sex
        {
            get { return sex; }
            set { if (value != null) sex = value; }
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Clienti Clone()
        {
            return (Clienti)this.MemberwiseClone();
        }

        public int CompareTo(object obj)
        {
            if (obj != null && obj.GetType() != GetType())
            {
                throw new ArgumentException(string.Format("Obiectul trebuie sa fie de tip {0}.", GetType()));
            }
            return CompareTo((Clienti)obj);
        }

        public int CompareTo(Clienti cl)
        {
            if (object.ReferenceEquals(this, cl))
            {
                return 0;
            }
            else if (cl == null)
            {
                return 1;
            }

            var cmp = this.ID.CompareTo(cl.ID);
            if (cmp != 0)
            {
                return cmp;
            }

            cmp = this.Nume.CompareTo(cl.Nume);
            if (cmp != 0)
            {
                return cmp;
            }

            return 0;
        }

        public override string ToString()
        {
            return base.ToString() + ", data nastere " + DataNastere + ", sex " + Sex;
        }

        public List<Clienti> adaugaClient(List<Clienti> lc, Clienti cl)
        {
            lc.Add(cl);
            return lc;
        }

        public List<Clienti> stergeClient(List<Clienti> lc, Clienti cl)
        {
            lc.RemoveAll(item => ReferenceEquals(item, cl));
            return lc;
        }

        public List<TipAbonament> ListaAb{
            get { return listaAbonamente; }
            set { }
        }
    }
}
