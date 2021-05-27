using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici
{
    class Companie : Utilizator, IEnumerable<Clienti>
    {
        List<Clienti> listaClienti;
        List<Plati> listaFacturi;

        public Companie() : base()
        {
            listaClienti = null;
            listaFacturi = null;
        }

        public Companie( String n, String pre, String nr, String e, String a, String p, String tip, List<Clienti> cl, List<Plati> fact) :
            base( n, pre, nr, e, a, p, tip)
        {
            listaClienti = new List<Clienti>(cl.Count);
            cl.ForEach((item) =>
            {
                listaClienti.Add((Clienti)item.Clone());
            });

            listaFacturi = new List<Plati>(fact.Count);
            fact.ForEach((item) =>
            {
                listaFacturi.Add((Plati)item.Clone());
            });
        }

        public List<Clienti> ListaClienti
        {
            get { return listaClienti; }
            set { if (value.GetType() == listaClienti.GetType()) listaClienti = value; }
        }

        public List<Plati> ListaFacturi
        {
            get { return listaFacturi; }
            set { if (value.GetType() == listaFacturi.GetType()) listaFacturi = value; }
        }

        public Clienti this[int i]
        {
            get => listaClienti[i];
            set => listaClienti[i] = value;
        }

        private IEnumerable<Plati> GetValues()
        {
            foreach (var s in listaFacturi)
            {
                yield return s;
            }
        }

        public IEnumerator<Plati> GetEnumerator()
        {
            return GetValues().GetEnumerator();
        }

        IEnumerator<Clienti> IEnumerable<Clienti>.GetEnumerator()
        {
            return ((IEnumerable<Clienti>)listaClienti).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Clienti>)listaClienti).GetEnumerator();
        }

        public Plati this[Clienti cl]
        {
            get
            {
                foreach (Plati p in this)
                {
                    if (p.Client.ID == cl.ID)
                        return p;
                }
                return null;
            }

            set
            {
                foreach (Plati p in this)
                {
                    if (p.Client.ID == cl.ID)
                    {
                        p.Client = (Clienti)cl.Clone();
                    }
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + ". Compania are clientii: " + ListaClienti.ToString() + " si facturile: " + ListaFacturi.ToString();
        }
    }
}
