using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WerkzeugManager
{
    public class Werkzeug
    {
       
        public enum Gewindegrößen { m12, m16, m18 }
        
        public string Name { get; set; }

        public bool AusMetall { get; set; }

        public int Anzahl { get; set; }

        public Gewindegrößen Gewindegröße { get; set; }

        public Werkzeug(string name, bool ausMetall, int anzahl, Gewindegrößen gewindegröße)
        {
            Name = name;
            AusMetall = ausMetall;
            Anzahl = anzahl;
            Gewindegröße = gewindegröße;
        }

        public override string ToString()
        {
            string ausMetall = AusMetall ? ", aus Metall" : string.Empty;
            return $"{Name} ({Anzahl}), {Gewindegröße} {AusMetall}";
        }

    }
}
