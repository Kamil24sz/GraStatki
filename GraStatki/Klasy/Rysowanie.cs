using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraStatki.Klasy
{
    public static class Rysowanie
    {
        private static readonly Bitmap hitImage = Properties.Resources.hitImage;
        private static readonly Bitmap splashImage = Properties.Resources.splashImage;

        private const int SZEROKOSC_RAMKI = 35;
        private const int WYSOKOSC_RAMKI = 35;

        private const int SZEROKOSC_KOMORKI = 40;
        private const int WYSOKOSC_KOMORKI = 40;

        public static readonly Brush[] kolory = new SolidBrush[5]
        {
            new SolidBrush(Color.FromArgb(255, Color.Yellow)),
            new SolidBrush(Color.FromArgb(255, Color.Red)),
            new SolidBrush(Color.FromArgb(255, Color.Green)),
            new SolidBrush(Color.FromArgb(255, Color.Blue)),
            new SolidBrush(Color.FromArgb(255, Color.Violet))
        };
        
        public static void RysujObramowanie(int komorkaX, int komorkaY, int kolor, PictureBox plansza)
        {
            Graphics graphics = plansza.CreateGraphics();
            // rysowanie prostokąta (ramki) o rozmiarach 35x35px
            graphics.DrawRectangle(new Pen(Rysowanie.kolory[kolor], 3), 
                komorkaX * SZEROKOSC_KOMORKI, komorkaY *WYSOKOSC_KOMORKI, SZEROKOSC_RAMKI, WYSOKOSC_RAMKI);
        }

        public static void RysujKomorke(int komorkaX, int komorkaY, int kolor, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Rysowanie.kolory[kolor], komorkaX * SZEROKOSC_KOMORKI, komorkaY * WYSOKOSC_KOMORKI,
                SZEROKOSC_KOMORKI, WYSOKOSC_KOMORKI);
        }

        public static void RysujUstawioneKomorki(int[,] komorki, PaintEventArgs e)
        {
            for(int x = 0; x < Gracz.ROZMIAR_PLANSZY; x++)
            {
                for(int y = 0; y < Gracz.ROZMIAR_PLANSZY; y++)
                {
                    if(komorki[x, y] != -1)
                    {
                        RysujKomorke(x, y, komorki[x, y], e);
                    }
                }
            }
        }

        public static void RysujKomorki(bool[,] odkryteKomorki, int[,] komorki, PaintEventArgs e)
        {
            for(int x = 0; x < Gracz.ROZMIAR_PLANSZY; x++)
            {
                for(int y = 0; y < Gracz.ROZMIAR_PLANSZY; y++)
                {
                    if(odkryteKomorki[x, y])
                    {
                        if(komorki[x, y] != -1)
                        {
                            RysujTrafionaKomorke(x, y, e);
                        }
                        else
                        {
                            RysujeNietrafionaKomorke(x, y, e);
                        }
                    }
                }
            }
        }
        public static void RysujTrafionaKomorke(int komorkaX, int komorkaY, PaintEventArgs e)
        {
            e.Graphics.DrawImage(hitImage, komorkaX * 40, komorkaY * 40);
        }
        public static void RysujeNietrafionaKomorke(int komorkaX, int komorkaY, PaintEventArgs e)
        {
            e.Graphics.DrawImage(splashImage, komorkaX * 40, komorkaY * 40);
        }

        public static void RysujZatopioneStatki(int[,] komorki, int[] trafieniaStatku, PaintEventArgs e)
        {
            for(int aktualnyStatek = 0; aktualnyStatek < 4; aktualnyStatek++)
            {
                if(trafieniaStatku[aktualnyStatek] == 0) // 1,2,3,4 => 1,2,3,0 
                {
                    for(int x = 0; x < 10; x++)
                    {
                        for(int y = 0; y < 10; y++)
                        {
                            if(komorki[x, y] == aktualnyStatek)
                            {
                                RysujKomorke(x, y, aktualnyStatek, e);
                            }
                        }
                    }
                }  
            }
        }
    }
}
