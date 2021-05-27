using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1046_Manea_Diana_Valentina_Proiect_AbonatiTelefonici
{
    class Plati : ICloneable, IEnumerable<TipAbonament>, IEnumerable<ExtraOptiuni>
    {
        TipAbonament listaAbonamente;
        List<ExtraOptiuni> listaExtraOptiuni;
        Clienti client;
        String achitata;

        public Plati()
        {   
            this.listaAbonamente = null;
            this.listaExtraOptiuni = null;
            this.client = null;
            this.achitata = "Nu";
        }

        public Plati(TipAbonament listaAb, Clienti c)
        {
            this.listaAbonamente = listaAb.Clone();
            client = (Clienti)c.Clone();
        }
        public Plati(TipAbonament listaAb, List<ExtraOptiuni> listaEO, Clienti cl)
        {
            this.listaAbonamente = listaAb.Clone();
            listaExtraOptiuni = new List<ExtraOptiuni>(listaEO.Count);
            listaEO.ForEach((item) =>
            {
                listaExtraOptiuni.Add((ExtraOptiuni)item.Clone());
            });

            client = (Clienti)cl.Clone();
        }

        public TipAbonament ListaAbonamente
        {
            get { return listaAbonamente; }
            set { if (value.GetType() == listaAbonamente.GetType()) listaAbonamente = value; }
        }

        public List<ExtraOptiuni> ListaExtraOptiuni
        {
            get { return listaExtraOptiuni; }
            set { if (value.GetType() == listaExtraOptiuni.GetType()) listaExtraOptiuni = value; }
        }

        public Clienti Client
        {
            get { return client; }
            set { if (value.GetType() == client.GetType()) client = (Clienti)value.Clone(); }
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Plati Clone()
        {
            return (Plati)this.MemberwiseClone();
        }

        public IEnumerator<TipAbonament> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<ExtraOptiuni> IEnumerable<ExtraOptiuni>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public TipAbonament this[string nume]
        {
            get 
            { 
                foreach(TipAbonament ta in this)
                {
                    if(ta.Nume == nume)
                    {
                        return ta;
                    }
                }
                return null;
            }

            set
            {
                foreach(TipAbonament ta in this)
                {
                    if(ta.Nume == nume)
                    {
                        ta.Nume = nume;
                    }
                }
            }
        }

        public float calculeazaSumaPlata(List<TipAbonament> ta, List<ExtraOptiuni> eo)
        {
            float suma = 0;
            foreach(TipAbonament ta1 in ta)
            {
                suma += ta1.Pret;
            }

            foreach(ExtraOptiuni e in eo)
            {
                suma += e.Pret;
            }

            return suma;
        }

        public override string ToString()
        {
            return "Client: " + client.ToString() + "; Abonamente active: " + ListaAbonamente.ToString() + "; Extraoptiuni active: " + ListaExtraOptiuni.ToString();
        }
    }
}
