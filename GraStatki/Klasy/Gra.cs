using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
