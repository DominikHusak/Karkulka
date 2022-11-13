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

        private List<string> kosik = new List<string> { "Babovka", "Lahev vina"}; 
        public int vratPocetVeciVKosiku()
        {
            return kosik.Count; 
        }
    }
}
