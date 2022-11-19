using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkulka
{
    internal class Karkulka
    {
        public int Y { get; set; } = 0;
        public int X { get; set; } = 0;

        private const int MAXPOCET = 2;

        private List<string> kosik = new List<string> { "Babovka", "Lahev vina"}; 

        public int vratPocetVeciVKosiku()
        {
            return kosik.Count; 
        }
        public void vyprazdniKosik()
        {
            kosik.Clear();
        }
        public string odeberZKosiku()
        {
            string vec = kosik[0];
            kosik.RemoveAt(0);
            return vec; 
        }
        public string pridejDoKosiku(string vec)
        {
            if (kosik.Count >= MAXPOCET)
            {
                return "Kosik je plny, " + vec + "nebyla pridana.";
            }
            kosik.Add(vec);
            return vec + " byla pridana.";
        }
    }
}
