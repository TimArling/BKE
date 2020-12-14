using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKE
{
    class BKE
    {
        //initialisatie globale variabelen
        Bord Bord = new Bord(3);
        int Ronde = 1;
        String EindTekst = "Niemand";

        /*
         * Start van het spel en het einde van het spel.
         */
        public void Start()
        {
            Bord.VulBordMetLeegte();
            SpeelSpel();
            
            //einde spel            
            Bord.PrintBord();
            Console.WriteLine(EindTekst);
            System.Threading.Thread.Sleep(10000);
        }

        /*
         * Hier wordt het spel daadwerkelijk gespeeld
         */
        private void SpeelSpel()
        {
            while (true)
            {
                Console.WriteLine("Ronde: " + Ronde);
                Console.WriteLine("Speler " + WiensBeurt(Ronde) + " is aan de beurt!");
                
                Bord.PrintBord();
                
                Console.WriteLine("Geef hier de rij in waar je je zet wil doen: ");
                String zetrij = Console.ReadLine();
                
                Console.WriteLine("Geef hier de Kolom in waar je je zet wil doen: ");
                String zetkol = Console.ReadLine();
                
                if(DoeZet(zetrij, zetkol)){

                    if (IsErEenWinnaar())
                    {
                        EindTekst = "Speler " + WiensBeurt(Ronde) + " is de winnaar!";
                        break;
                    }
                    else if (!IsErEenWinnaar() && Ronde == 9)
                    {
                        EindTekst = "Gelijkspel!";
                        break;
                    }
                    Ronde++;
                }
            }
            
        }

        /*
         * Kijk of er een winnaar is door middel van alle combinaties te doorlopen.
         * Er wordt alleen gekeken naar de speler die aan de beurt is.
         */
        private bool IsErEenWinnaar()
        {
            char teken;

            if (WiensBeurt(Ronde) % 2 == 1)
                teken = 'O';
            else
                teken = 'X';

            //horizontale winst
            if (Bord.Veld[0, 0].Equals(teken) && Bord.Veld[0, 1].Equals(teken) && Bord.Veld[0, 2].Equals(teken))
                return true;
            if (Bord.Veld[1, 0].Equals(teken) && Bord.Veld[1, 1].Equals(teken) && Bord.Veld[1, 2].Equals(teken))
                return true;
            if (Bord.Veld[2, 0].Equals(teken) && Bord.Veld[2, 1].Equals(teken) && Bord.Veld[2, 2].Equals(teken))
                return true;

            //verticale winst
            if (Bord.Veld[0, 0].Equals(teken) && Bord.Veld[1, 0].Equals(teken) && Bord.Veld[2, 0].Equals(teken))
                return true;
            if (Bord.Veld[0, 1].Equals(teken) && Bord.Veld[1, 1].Equals(teken) && Bord.Veld[2, 1].Equals(teken))
                return true;
            if (Bord.Veld[0, 2].Equals(teken) && Bord.Veld[1, 2].Equals(teken) && Bord.Veld[2, 2].Equals(teken))
                return true;
           
            //diagonale winst
            if (Bord.Veld[0, 2].Equals(teken) && Bord.Veld[1, 1].Equals(teken) && Bord.Veld[2, 0].Equals(teken))
                return true;
            if (Bord.Veld[0, 0].Equals(teken) && Bord.Veld[1, 1].Equals(teken) && Bord.Veld[2, 2].Equals(teken))
                return true;

            //geen winnaar
            return false;
        }

        /*
         * Controleer voor het parsen of de set valide is 
         * Dit vangt ook gelijk af of de variabele null is, waardoor de parser in de parse methode geen null exceptie krijgt
         */
        private bool ControleerZet(String zetrij, String zetkol)
        {
            List<String> correctenummers = new List<String> { "1", "2", "3" };
            bool bevatrij = correctenummers.Contains(zetrij, StringComparer.OrdinalIgnoreCase);
            bool bevatkol = correctenummers.Contains(zetkol, StringComparer.OrdinalIgnoreCase);
            
            if (bevatrij && bevatkol)
                return true;
            else
                return false;
        }

        /*
         * Hier wordt gekeken of de zet al is gedaan door te kijken of er iets anders in staat dan een spatie
         */
        private bool IsZetAlGedaan(int rij, int kol)
        {
            if (Bord.Veld[rij, kol].Equals(' '))
                return false;
            else
                return true;
        }

        /*
         * Hier wordt de zet van de speler daadwerkelijk ingevuld
         * Kijkend naar de ronde wordt bepaald welke speler aan de beurt is en welk teken wordt geplaatst
         */
        private bool DoeZet(String zetrij, String zetkol)
        {

            if (ControleerZet(zetrij, zetkol))
            {
                int rij = ParseStringNaarInt(zetrij);
                int kol = ParseStringNaarInt(zetkol);

                //correctie voor gebruikersgemak in de weergave
                rij--;
                kol--;

                if (IsZetAlGedaan(rij, kol)) {
                    Console.WriteLine("Zet is al gedaan!");
                    return false;
                }
                else {
                    if (WiensBeurt(Ronde) % 2 == 1)
                        Bord.Veld[rij, kol] = 'O';
                    else
                        Bord.Veld[rij, kol] = 'X';
                }
            }
            else { 
                Console.WriteLine("Dit is geen correcte zet, probeer het nog eens!");
                return false;
            }
            return true;
        }

        /*
         * Methode voor het bekijken wie er aan de beurt is
         * Als de ronde een oneven getal is dan is speler 1 en bij even speler 2
         */
        private char WiensBeurt(int turn)
        {
            if (turn % 2 == 0)
                return '2';
            else
                return '1';
        }

        /*
         * Methode voor het parsen van een String naar een int
         */
        private int ParseStringNaarInt(String arg)
        {
            return Int32.Parse(arg);
        }
    }
}
