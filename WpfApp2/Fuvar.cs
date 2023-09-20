using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    internal class Fuvar
    {

        int azonosito;
        DateTime indulasIdo;
        int utazasIdotartama;
        double tavolsag;
        double viteldij;
        double borravalo;
        string fizetesiMod;

        public Fuvar(int azonosito, DateTime indulasIdo, int utazasIdotartama, double tavolsag, double viteldij, double borravalo, string fizetesiMod)
        {
            this.azonosito = azonosito;
            this.indulasIdo = indulasIdo;
            this.utazasIdotartama = utazasIdotartama;
            this.tavolsag = tavolsag;
            this.viteldij = viteldij;
            this.borravalo = borravalo;
            this.fizetesiMod = fizetesiMod;
        }

        public int Azonosito { get => azonosito; set => azonosito = value; }
        public DateTime IndulasIdo { get => indulasIdo; set => indulasIdo = value; }
        public int UtazasIdotartama { get => utazasIdotartama; set => utazasIdotartama = value; }
        public double Tavolsag { get => tavolsag; set => tavolsag = value; }
        public double Viteldij { get => viteldij; set => viteldij = value; }
        public double Borravalo { get => borravalo; set => borravalo = value; }
        public string FizetesiMod { get => fizetesiMod; set => fizetesiMod = value; }
    }
}
