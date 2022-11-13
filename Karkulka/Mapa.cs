using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkulka
{
    internal class Mapa
    {
        private string[,] policka = new string[4,4];
        private Karkulka karkulka;

        public Mapa(Karkulka karkulka)
        {
            for (int i = 0; i < policka.GetLength(0); i++)
            {
                for (int j = 0; j < policka.GetLength(1); j++)
                {
                    policka[i, j] = "Vyhlidka";
                }
            }
            policka[0, 0] = "Domov";
            policka[3, 3] = "Babicka";
            nahodneUmisti("Vlk");
            nahodneUmisti("Koren");
            nahodneUmisti("Louka");
            nahodneUmisti("Prekazka");
            this.karkulka = karkulka;   
        }
        private void nahodneUmisti(string misto)
        {
            Random r = new Random();
            while (true)
            {
                int x = r.Next(4);
                int y = r.Next(4);
                if (policka[y, x] == "Vyhlidka")
                {
                    policka[y, x] = misto;
                    break;
                }
            }
        } 
        public int vratSirku()
        {
            return policka.GetLength(1);
        }
        public int vratVysku()
        {
            return policka.GetLength(0);
        }
        public string vratPolicko()
        {
            return policka[karkulka.Y, karkulka.X];
        }
        public void vytiskniMapu()
        {
            for (int i = 0; i < policka.GetLength(0); i++)
            {
                for (int j = 0; j < policka.GetLength(1); j++)
                {
                    if (karkulka.Y == i && karkulka.X == j)
                    {
                        Console.Write(">{0,10}<", policka[i, j]);
                    }
                    else
                    {
                        Console.Write("{0,12}", policka[i, j]);
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
