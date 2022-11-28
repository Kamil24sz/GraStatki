using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraStatki
{
    public class Gracz
    {
        //WŁAŚCIWOŚCI

        //nazwa gracz
        public string Nazwa;

        //plansza
        // -1 - pole będzie puste
        // 0 - pole nietrafione
        // 1-4 - pole statku w zależności od jego długości
        public int[,] Plansza;

        //pola kliknięte w trakcie gry
        public bool[,] OdkrytePola;

        //zestaw statków gracz
        public int[] Flota;
        public int LiczbaStatkowDoZatopienia;

        public static int ROZMIAR_PLANSZY = 10;

        //konstruktor klasy gracz
        public Gracz()
        {
            //ustawiamy 4 statki od 1-4 pól
            Flota = new int[] { 1, 2, 3, 4 };

            Plansza = new int[ROZMIAR_PLANSZY, ROZMIAR_PLANSZY];
            OdkrytePola = new bool[ROZMIAR_PLANSZY, ROZMIAR_PLANSZY];

            //liczba statków jest pobierana z wielkości floty
            LiczbaStatkowDoZatopienia = Flota.Length;

            for(int i = 0; i < ROZMIAR_PLANSZY; i++)
            {
                for(int j = 0; j< ROZMIAR_PLANSZY; j++)
                {
                    //do każdego elementu planszy przypisujemy -1 (puste pole)
                    Plansza[i, j] = -1;

                    //do każdego elementu tablicy przypisuje false (pole nieodkryte)
                    OdkrytePola[i, j] = false;
                }
            }

        }
    }
}
