using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLI
{
    public class Haz
    {
        public Haz(int telekadoszam, string utcaneve, string hazszam, string adosav, int terulet)
        {
            Telekadoszam = telekadoszam;
            Utcaneve = utcaneve;
            Hazszam = hazszam;
            Adosav = adosav;
            Terulet = terulet;
        }

        public int Telekadoszam { get;private set; }
        public string Utcaneve { get; set; }
        public string Hazszam { get; set; }
        public string Adosav { get; set; }
        public int Terulet { get; set; }
    }
}
