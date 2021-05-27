using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici
{
    public abstract class Utilizator : ILogin
    {
        int id;
        String nume;
        String prenume;
        String nrTelefon;
        String email;
        String adresa;
        String parola;
        String tipUtilizator;

        public Utilizator()
        {
            id = 0;
            nume = "NA";
            prenume = "NA";
            nrTelefon = "NA";
            email = "NA";
            adresa = "NA";
            parola = "NA";
            tipUtilizator = "NA";
        }

        public Utilizator(String nume, String prenume, String parola, String tip)
        {
            id = 0;
            this.nume = nume;
            this.prenume = prenume;
            nrTelefon = "NA";
            email = "NA";
            adresa = "NA";
            this.parola = parola;
            tipUtilizator = tip;
        }

        //public Utilizator(String nume, String prenume, String nrTel, String email, String adresa)
        //{
        //    id = 0;
        //    this.nume = nume;
        //    this.prenume = prenume;
        //    nrTelefon = "NA";
        //    email = "NA";
        //    adresa = "NA";
        //    this.parola = parola;
        //    tipUtilizator = tip;
        //}

        public Utilizator( String n, String pre, String nr, String e, String a, String p, String tip)
        {
            //this.id = id;
            this.nume = n;
            this.prenume = pre;
            this.nrTelefon = nr;
            this.email = e;
            this.adresa = a;
            this.parola = p;
            this.tipUtilizator = tip;
        }

        public int ID
        {
            get { return this.id; }
            set { }
        }

        public String Nume
        {
            get { return this.nume; }
            set { if (value != null) this.nume = value; }
        }

        public String Prenume
        {
            get { return this.prenume; }
            set { if (value != null) this.prenume = value; }
        }

        public String NumarTelefon
        {
            get { return this.nrTelefon; }
            set { if (value != null) this.nrTelefon = value; }
        }

        public String Email
        {
            get { return this.email; }
            set { if (value != null) this.email = value; }
        }

        public String Adresa
        {
            get { return this.adresa; }
            set { if (value != null) this.adresa = value; }
        }

        public String Parola
        {
            get { return this.parola; }
            set { if (value != null) this.parola = value; }
        }

        public String TipUtilizator
        {
            get { return this.tipUtilizator; }
            set { if (value != null) this.tipUtilizator = value; }
        }

        public override string ToString()
        {
            return "Utilizatorul cu id-ul " + ID.ToString() + "are numele " + Nume + " " + Prenume + ", numarul de telefon " + NumarTelefon + ", adresa de email " + Email + ", adresa " + Adresa 
                + ", parola " + Parola + ", tip utilizator - " + TipUtilizator;
        }

        public bool verificaDate(string nume, string prenume, string parola)
        {
            if(Nume == nume && Prenume == prenume && Parola == parola)
            {
                return true;
            }
            return false;
        }
    }
}
