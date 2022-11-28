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
    }
}
