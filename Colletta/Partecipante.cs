using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colletta
{
    internal class Partecipante
    {
        public string Nome { get; set; }
        public float Importo { get; set; }
        public string Id { get; set; }
        public Partecipante(string nome, float importo)
        {
            Nome = nome;
            Importo = importo;
        }
        public Partecipante() : this("N/A", 0)
        {

        }
        public bool Equals(Partecipante p)
        {
            if (p == null)
                return false;
            if (p == this)
                return true;
            return Id.Equals(p.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(Object o)
        {
            if (!(o is Partecipante))
                return false;

            return Equals((Partecipante)o);
        }

        public override string ToString()
        {
            return Id + ";" + Nome + ";" + Importo.ToString();
        }
    }
}
