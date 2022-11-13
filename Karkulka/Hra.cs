using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkulka
{
    internal class Hra
    {
        private Mapa mapa;
        private Karkulka karkulka;
        private bool hraBezi = true;

        public Hra(Karkulka karkulka)
        {
            this.karkulka = karkulka;
            this.mapa = new Mapa(karkulka);
        }

        public void Hraj()
        {
            while (hraBezi)
            {
                Console.Clear();    
                mapa.vytiskniMapu();
                 ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow && karkulka.Y < mapa.vratVysku() - 1 )
                {
                    karkulka.Y++;
                }
                if (key == ConsoleKey.UpArrow && karkulka.Y > 0)
                {
                    karkulka.Y--;
                }
                if (key == ConsoleKey.RightArrow && karkulka.X < mapa.vratSirku() - 1)
                {
                    karkulka.X++;
                }
                if (key == ConsoleKey.LeftArrow && karkulka.X > 0)
                {
                    karkulka.X--;
                }
                if (mapa.vratPolicko() == "Babicka")
                {
                    navstevaBabicky();
                }
            }
        }
        public void navstevaBabicky()
        {
            if(karkulka.vratPocetVeciVKosiku() < 2)
            {
                Console.WriteLine("Karkulka nedonesla vse co mela.");
            }
            else
            {
                Console.WriteLine("Karkulka donesla vse co mela.");
            }
            hraBezi = false;
        }
    }
}
