using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraStatki
{
    public static class Koordynaty
    {
        //pobieranie współrzędnej X
        public static int PobierzX(Form form, PictureBox pictureBox)
        {
            //obramowanie
            //form.Width - szerokość okna z obramowaniem
            //form.ClientSize.Width - szerokość okna wewnątrz

            int obramowanieOkna = (form.Width - form.ClientSize.Width) / 2;

            //obliczanie współrzędnej
            int wspolrzednaX = Control.MousePosition.X - form.Location.X - pictureBox.Location.X - obramowanieOkna;

            return wspolrzednaX;
        }

        //pobieranie współrzędnej Y
        public static int PobierzY(Form form, PictureBox pictureBox)
        {
            //obramowanie
            int obramowanieOkna = (form.Width - form.ClientSize.Width) / 2;

            int wysokoscPaskaTytulu = form.Height - form.ClientSize.Height - 2 * obramowanieOkna;

            int wspolrzednaY = Control.MousePosition.Y - form.Location.Y - 
                pictureBox.Location.Y - wysokoscPaskaTytulu - obramowanieOkna;

            return wspolrzednaY;
        }
        //obliczamy na której 
        public static int PobierzKomorke(int wspolrzedna)
        {
            int komorka = wspolrzedna / 40;

            if(komorka >= 0 && komorka <= 9)
            {
                return komorka;
            }
            else 
                return -1;
        }
    }
}
