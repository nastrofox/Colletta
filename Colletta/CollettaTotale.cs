using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colletta
{
    internal class CollettaTotale
    {
        private Dictionary<string, Partecipante> _raccolta;
        public Dictionary<string, Partecipante> Raccolta { get; private set; }
        public float QuotaTotale { get; private set; }
        private int c;
        private string n;
        public CollettaTotale()
        {
            QuotaTotale = 0;
            Raccolta = new Dictionary<string, Partecipante>();
            c = 1;
        }
        public void Aggiungi(Partecipante persona)
        {
            if (persona != null)
            {
                n = "P" + c.ToString();
                Raccolta.Add(n, persona);
                persona.Id = n;
                QuotaTotale += persona.Importo;
                c++;
            }
            else
                throw new Exception("il reference del partecipante è null");
        }
        public void Modifica(Partecipante persona1, Partecipante persona2)
        {
            if (persona1 != null)
            {
                QuotaTotale -= Raccolta[persona1.Id].Importo;
                persona2.Id = persona1.Id;
                Raccolta[persona1.Id] = persona2;
                QuotaTotale += persona2.Importo;
            }
            else
                throw new Exception("il reference del partecipante è null");
        }
        public void Rimuovi(Partecipante persona)
        {
            if (persona != null)
            {
                Raccolta.Remove(persona.Id);
                QuotaTotale -= persona.Importo;
                c--;
            }
            else
                throw new Exception("il reference del partecipante è null");
        }
        
        public string getKey(Partecipante p)
        {
            string temp = "";
            foreach (KeyValuePair<string, Partecipante> kvp in Raccolta)
            {
                if (Raccolta[kvp.Key].Nome == p.Nome)
                    temp = kvp.Key;
            }
            return temp;
        }
    }
}
