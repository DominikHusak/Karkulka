using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkulka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Karkulka karkulka = new Karkulka();
            Hra hra = new Hra(karkulka);
            hra.Hraj();

        }
    }
}
