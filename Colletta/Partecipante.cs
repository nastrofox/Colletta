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
        public override string ToString()
        {
            return Id + ";" + Nome + ";" + Importo.ToString();
        }
    }
}
