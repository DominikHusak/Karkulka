using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Karkulka
{
    internal class Hra
    {
        private Mapa mapa;
        private Karkulka karkulka;
        private bool hraBezi = true;
        private string text;
        Random random = new Random();

        public Hra(Karkulka karkulka)
        {
            this.karkulka = karkulka;
            this.mapa = new Mapa(karkulka);
        }

        public void Hraj()
        {
            while (true)
            {
                Console.Clear();    
                mapa.vytiskniMapu();
                Console.WriteLine(text);
                if (hraBezi == false)
                {
                    break;
                }
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
                vyhodnotPolicko();
            }
        }
        public void vyhodnotPolicko()
        {
            if (mapa.vratPolicko() == "Babicka")
            {
                navstevaBabicky();
            }
            if (mapa.vratPolicko() == "Vyhlidka")
            {
                Vyhled();
            }
            if (mapa.vratPolicko() == "Koren")
            {
                zaseknutiVKorenu();
            }
            if (mapa.vratPolicko() == "Vlk")
            {
                setkaniSVlkem();
            }
            if(mapa.vratPolicko() == "Louka")
            {
                pruchodLoukou();    
            }
            if (mapa.vratPolicko() == "Haj")
            {
                pruchodHajem();
            }
            if (mapa.vratPolicko() == "Bazina")
            {
                uviznutiNaPrekazce("v bazine");
            }
            if (mapa.vratPolicko() == "Strmy svah")
            {
                uviznutiNaPrekazce("na strmem svahu");
            }
            if (mapa.vratPolicko() == "Krovi")
            {
                uviznutiNaPrekazce("v krovi");
            }
            if (mapa.vratPolicko() == "Reka")
            {
                uviznutiNaPrekazce("v rece");
            }
        }
        public void zaseknutiVKorenu()
        {
            int X = 0;
            int Y = 0;
            do
            {
                Y = random.Next(mapa.vratVysku());
                X = random.Next(mapa.vratSirku());
            } while (Y == mapa.vratVysku() - 1 && X == mapa.vratSirku() - 1);
                karkulka.Y = Y;
                karkulka.X = X;
                vyhodnotPolicko();
            
        }
        public void setkaniSVlkem()
        {
            text = "Karkulka se setkala s vlkem.\n";
            Random random = new Random();
            for(int i = 0; i < 2; i++)
            {
                int hod = random.Next(1,7);
                if(hod >= 4)
                {
                    text += "Vlk mlsne kouka kosiku ale nic neziskal.";
                }
                else if(karkulka.vratPocetVeciVKosiku() > 0)
                {
                    string vec = karkulka.odeberZKosiku();
                    text += "Vlk snedl " + vec + " z kosiku.";
                }
                else
                {
                    text += "Vlk snedl Karkulku.";
                    hraBezi = false;
                    break;
                }
            }
        }
        public void uviznutiNaPrekazce(string misto)
        {
            text = "Karkulka uvizla " + misto + ".\n";
            Random random = new Random();
                int hod = random.Next(1, 7);
                if (hod >= 5)
                {
                    text += "Karkulka vyvazla bez uhony.";
                }
                else if (karkulka.vratPocetVeciVKosiku() > 0)
                {
                    string vec = karkulka.odeberZKosiku();
                    text += "Myzlivec zachranil Karkulku. Za odmenu dostal " + vec + ".";
                }
                else
                {
                    text += "Karkulka to nezvadla.";
                    hraBezi = false;
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
        public void Vyhled()
        {
            text = "Jaky to krasny vyhled.";
        }

        public void pruchodLoukou()
        {
            text = "Na louce jsou kvetiny. Karkulka si utrhla kvetinu.\n";
            text += karkulka.pridejDoKosiku("Kvetina");    

        }

        public void pruchodHajem()
        {
            text = "V haji rostou houby. Karkulka sebrala houbu.\n";
            text += karkulka.pridejDoKosiku("Houba");
        }
    }
}
