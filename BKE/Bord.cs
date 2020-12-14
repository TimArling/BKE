using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKE
{
    class Bord
    {
        private char[,] veld;
        
        public Bord(int grootte)
        {
           Veld = new char[grootte, grootte];
        }

        /*
        * Voor de weergave wordt het bord eerst gevuld met spaties
        */
        public void VulBordMetLeegte()
        {
            for (int i = 0; i < Veld.GetLength(0); i++)
            {
                for (int x = 0; x < Veld.GetLength(1); x++)
                {
                    Veld[i, x] = ' ';
                }
            }
        }
        /*
        * Methode voor het weergeven van het veld
        */
        public void PrintBord()
        {
            Console.WriteLine("    1   2   3   ");
            for (int rij = 0; rij < Veld.GetLength(0); rij++)
            {
                Console.Write(rij + 1 + " | ");
                for (int kol = 0; kol < Veld.GetLength(1); kol++)
                {
                    Console.Write(Veld[rij, kol]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }

        public char[,] Veld
        {
            get { return veld; }
            set { veld = value; }
        }
    }
}
