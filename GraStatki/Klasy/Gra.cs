using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraStatki.Klasy
{
    public static class Gra
    {
        //obiekty Graczy
        public static Gracz gracz;
        public static Gracz komputer;

        //informacja jakie mamy rozmiary satków (1-4 masztowców)
        public static int[] rozmiarStatku = new int[4] { 1, 2, 3, 4 };

        public static bool MoznaPostawicSatek(int aktualnyStatek, int komorkaX, int komorkaY, bool jestHoryzontalnie, int[,] komorki)
        {
            if(komorkaX < 0 || komorkaY < 0)
            {
                return false;
            }

            if (jestHoryzontalnie)
            {
                //sprawdzamy czy statek nie wyjdzie poza plansze
                if(komorkaX + Gra.rozmiarStatku[aktualnyStatek] - 1 <= 9)
                {
                    //między ustawionymi statkami musi być odległość conajmniej jednego pola
                    for(int i = Math.Max(0, komorkaX - 1); i <= Math.Min(9, komorkaX + Gra.rozmiarStatku[aktualnyStatek]); i++)
                    {
                        for(int j = Math.Max(0, komorkaY - 1); j <= Math.Min(9, komorkaY + 1); j++)
                        {
                            //sprawdzamy czy komórka jest zajęta
                            //pusta => -1
                            if(komorki[i,j] != -1)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                //sprawdzamy czy można postawić statek przy ustawieniu pionowym
                if(komorkaY + Gra.rozmiarStatku[aktualnyStatek] - 1 <= 9)
                {
                    for(int i = Math.Max(0, komorkaX - 1); i <= Math.Min(9, komorkaX+1); i++)
                    {
                        for(int j = Math.Max(0, komorkaY - 1); j <= Math.Min(9, komorkaY + Gra.rozmiarStatku[aktualnyStatek]); j++)
                        {
                            if(komorki[i, j] != -1)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void RozmiescStatek(int aktualnyStatek, int komorkaX, int komorkaY, bool jestHoryzontalnie, int[,] komorki)
        {
            if (jestHoryzontalnie)
            {
                for(int i = 0; i < Gra.rozmiarStatku[aktualnyStatek]; i++)
                {
                    komorki[komorkaX + i, komorkaY] = aktualnyStatek;
                }
            }
            else
            {
                for (int i = 0; i < Gra.rozmiarStatku[aktualnyStatek]; i++)
                {
                    komorki[komorkaX, komorkaY + i] = aktualnyStatek;
                }
            }
        }

        public static void RozmieszczenieStatkowKomputera()
        {
            for(int aktualnyStatek = 0; aktualnyStatek < 4; aktualnyStatek++)
            {
                //pomocnicza lista, w której umieścimy możliwe współrzędne dla statków
                List<int[]> mozliwosci = new List<int[]>();

                for(int x = 0; x < Gracz.ROZMIAR_PLANSZY; x++)
                {
                    for(int y = 0; y < Gracz.ROZMIAR_PLANSZY; y++)
                    {
                        //sprawdzamy czy w danym polu można postawić statek
                        if(MoznaPostawicSatek(aktualnyStatek, x, y, true, komputer.Plansza))
                        {
                            //dodajemy współrzedne do listy
                            mozliwosci.Add(new int[] { x, y });
                        }
                    }
                }
                //losujemy wartość z listy możliwości
                int wybor = new Random().Next(mozliwosci.Count);

                //rozmieszczamy statki
                RozmiescStatek(aktualnyStatek, mozliwosci[wybor][0], mozliwosci[wybor][1], true, Gra.komputer.Plansza);
            }
        }

        public static bool WykonajAtak(int komorkaX, int komorkaY, Gracz atakujacy, Gracz atakowany)
        {
            // lekkie opóźnienie 1s
            Thread.Sleep(1000);

            //wskazane pole zostaje ustawione jako odkryte
            atakowany.OdkrytePola[komorkaX, komorkaY] = true;

            //sprawdzamy czy został trafiony statek
            if(atakowany.Plansza[komorkaX,komorkaY] != -1)
            {
                //zmniejszenie wartości trafionego statku (tablica flota)
                atakowany.Flota[atakowany.Plansza[komorkaX, komorkaY]]--;  ///  1,2,3,4  => 1,2,3,3

                if(atakowany.Flota[atakowany.Plansza[komorkaX, komorkaY]] == 0)
                {
                    //jeśli statek zostanie zatopiony
                    atakowany.LiczbaStatkowDoZatopienia--; //4 => 3
                }

                if(atakowany.LiczbaStatkowDoZatopienia == 0)
                {
                    KoniecGry(atakujacy);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int[] StrzalKomputera(Gracz gracz)
        {
            //tworzymy obiekt losujący
            Random random = new Random();

            //losujemy współrzędne (strzał komputera)
            int x = random.Next(0, 10);
            int y = random.Next(0, 10);

            while(gracz.OdkrytePola[x, y] == true)
            {
                x = random.Next(0, 10);
                y = random.Next(0, 10);
            }

            //zwracamy współrzędne x i y
            int[] strzal = { x, y };
            return strzal;
        }

        public static void KoniecGry(Gracz gracz)
        {
            MessageBox.Show($"Koniec gry: wygrał {gracz.Nazwa}");
        }
    }
}
