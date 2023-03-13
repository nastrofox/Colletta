using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colletta
{
    internal class Importo
    {
        public Importo(double valore, string valuta)
        {
            Valore = valore;
            Valuta = valuta;
        }

        public double Valore { get; set; }
        public string Valuta { get; set; }

        public override string ToString()
        {
            return Valore + " " + Valuta;
        }
    }
}
